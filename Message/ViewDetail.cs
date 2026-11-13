using Behavior.Push;
using FISCA.Presentation.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyPerformanceWarningModule
{
    public partial class ViewDetail : BaseForm
    {
        /// <summary>
        /// APP 上顯示的來源名稱
        /// </summary>
        const string PushCategoryName = "預警通知";

        /// <summary>
        /// 推播對象說明(結果訊息、推播紀錄使用)
        /// </summary>
        const string PushReceiverText = "學生、家長";

        /// <summary>
        /// 推播紀錄類型(campus.push.log 的 push_type)
        /// </summary>
        public const string PushType_Attendance = "缺曠預警";
        public const string PushType_Demerit = "懲戒預警";

        DoWorkObj _do;

        /// <summary>
        /// True懲戒 / False缺曠
        /// </summary>
        bool _mode;

        /// <summary>
        /// 開啟畫面當時的日期(推播紀錄的 ref_date)
        /// </summary>
        DateTime _queryDate = DateTime.Today;

        /// <summary>
        /// 是否發送中(發送中不可關閉畫面)
        /// </summary>
        bool _sending = false;

        /// <summary>
        /// mode = True懲戒
        /// mode = False缺曠
        /// </summary>
        public ViewDetail(DoWorkObj ddo, bool mode, string title, string message)
        {
            InitializeComponent();
            _do = ddo;
            _mode = mode;
            tbTitle.Text = title;
            textBoxX1.Text = ("" + message).Replace("<br>", "\r\n");

            //建立資料
            List<KeyBoStudent> keyBoList = new List<KeyBoStudent>();
            if (mode)
            {
                keyBoList = _do.DemeritList.Values.ToList();
            }
            else
            {
                keyBoList = _do.AttendanceList.Values.ToList();
            }

            foreach (KeyBoStudent each in keyBoList)
            {
                DataGridViewRow gRow = new DataGridViewRow();
                gRow.CreateCells(dataGridViewX1);
                gRow.Cells[0].Value = each.ID;
                gRow.Cells[1].Value = each.ClassName;
                gRow.Cells[2].Value = each.SeatNo;
                gRow.Cells[3].Value = each.StudentNumber;
                gRow.Cells[4].Value = each.Name;
                gRow.Cells[5].Value = GetStatisticsText(each);
                gRow.Tag = each;

                dataGridViewX1.Rows.Add(gRow);
            }

            this.FormClosing += ViewDetail_FormClosing;
            this.Shown += ViewDetail_Shown;
            dataGridViewX1.SelectionChanged += (s, ev) => UpdateSelectionText();
            dataGridViewX1.RowsRemoved += (s, ev) => UpdateSelectionText();
        }

        /// <summary>
        /// labelX1 的說明文字(不含選取人數)
        /// </summary>
        const string SelectionHint = "請選取要發送推播的學生(可按 Ctrl / Shift 多選，Ctrl+A 全選)";

        /// <summary>
        /// 於 labelX1 顯示選取人數
        /// </summary>
        private void UpdateSelectionText()
        {
            labelX1.Text = string.Format("{0}　已選取 {1} / {2} 位"
                , SelectionHint, dataGridViewX1.SelectedRows.Count, dataGridViewX1.Rows.Count);
        }

        /// <summary>
        /// 畫面顯示後,於背景查詢各學生的最近推播時間
        /// </summary>
        private async void ViewDetail_Shown(object sender, EventArgs e)
        {
            //預設不選取任何學生,由使用者自行選取要發送的對象(避免誤發給預設選取的第一位)
            dataGridViewX1.ClearSelection();
            UpdateSelectionText();

            List<string> studentIDs = dataGridViewX1.Rows.Cast<DataGridViewRow>()
                .Select(x => x.Tag as KeyBoStudent)
                .Where(x => x != null)
                .Select(x => x.ID)
                .Distinct()
                .ToList();

            if (studentIDs.Count == 0)
                return;

            foreach (DataGridViewRow row in dataGridViewX1.Rows)
                row.Cells[colPushTime.Index].Value = "查詢中...";

            Dictionary<string, PushLogUDT> latest;
            try
            {
                string pushType = PushType;
                latest = await Task.Run(() => SelectLatestPushLog(pushType, studentIDs));
            }
            catch (Exception ex)
            {
                if (IsDisposed)
                    return;
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    row.Cells[colPushTime.Index].Value = "查詢失敗";
                    row.Cells[colPushTime.Index].ToolTipText = ex.Message;
                }
                return;
            }

            if (IsDisposed)
                return;

            UpdatePushTimeColumn(latest);
        }

        /// <summary>
        /// 查詢學生在此推播類型的最近一筆推播紀錄(預警為累計條件,不限定日期)
        /// </summary>
        private static Dictionary<string, PushLogUDT> SelectLatestPushLog(string pushType, List<string> studentIDs)
        {
            FISCA.UDT.AccessHelper access = new FISCA.UDT.AccessHelper();
            List<PushLogUDT> logs = new List<PushLogUDT>();

            //學生數多時分批查詢,避免 SQL 條件過長
            const int batchSize = 500;
            for (int i = 0; i < studentIDs.Count; i += batchSize)
            {
                string inList = string.Join(",", studentIDs.Skip(i).Take(batchSize).Select(x => "'" + x.Replace("'", "''") + "'"));
                string condition = string.Format("push_type='{0}' and ref_type='student' and ref_id in ({1})", pushType.Replace("'", "''"), inList);
                logs.AddRange(access.Select<PushLogUDT>(condition));
            }

            return PushLog.Latest(logs, x => x.RefID);
        }

        private void ViewDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_sending)
            {
                e.Cancel = true;
                MsgBox.Show("推播發送中,請稍候...");
            }
        }

        /// <summary>
        /// 統計支數 / 缺曠節次
        /// </summary>
        private string GetStatisticsText(KeyBoStudent each)
        {
            if (_mode)
                return string.Format("大過「{0}」小過「{1}」警告「{2}」", each.DemeritA, each.DemeritB, each.DemeritC);
            else
                return string.Format("缺曠「{0}」", each.AttendanceCount);
        }

        private string PushType
        {
            get { return _mode ? PushType_Demerit : PushType_Attendance; }
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count == 0)
            {
                MsgBox.Show("清單中無可以發送的學生");
                return;
            }

            //只發送所選的學生(依畫面順序)
            List<DataGridViewRow> selectedRows = dataGridViewX1.SelectedRows.Cast<DataGridViewRow>()
                .OrderBy(x => x.Index)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MsgBox.Show("請先選取要發送推播的學生");
                return;
            }

            string title = tbTitle.Text.Trim();
            string body = textBoxX1.Text;

            if (title == "")
            {
                MsgBox.Show("請輸入推播標題!");
                return;
            }

            if (body.Trim() == "")
            {
                MsgBox.Show("請輸入推播內容!");
                return;
            }

            //一位學生一則推播(推給學生本人與家長)
            List<PushRequest> requests = new List<PushRequest>();
            List<string> invalidList = new List<string>();
            HashSet<string> addedIDs = new HashSet<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                KeyBoStudent stud = row.Tag as KeyBoStudent;
                if (stud == null || !addedIDs.Add(stud.ID))
                    continue;

                StudentReceiver receiver = PushReceiver.Student(stud.ID, true, true);
                if (receiver == null)
                {
                    invalidList.Add(stud.Name);
                    continue;
                }

                PushRequest request = new PushRequest();
                request.Title = title;
                request.Body = body;
                request.CategoryName = PushCategoryName;
                request.AddReceiver(receiver);
                request.State = stud;

                //推播紀錄(發送成功後由 Behavior.Push 自動寫入 campus.push.log)
                PushLogUDT log = new PushLogUDT();
                log.PushType = PushType;
                log.RefType = "student";
                log.RefID = stud.ID;
                log.ReceiverType = "student";
                log.ReceiverID = stud.ID;
                log.RefDate = PushLog.ToDateString(_queryDate);
                log.SetDetail("student_name", stud.Name)
                   .SetDetail("class_name", stud.ClassName)
                   .SetDetail("seat_no", stud.SeatNo)
                   .SetDetail("student_number", stud.StudentNumber)
                   .SetDetail("statistics", GetStatisticsText(stud))
                   .SetDetail("receiver", PushReceiverText);
                request.AddLog(log);

                requests.Add(request);
            }

            if (requests.Count == 0)
            {
                MsgBox.Show("所選學生中沒有可以發送推播的學生");
                return;
            }

            if (invalidList.Count > 0)
                MsgBox.Show(string.Format("下列學生資料有誤,將不會發送推播：\n{0}", string.Join("、", invalidList)));

            //防呆:檢查今天是否已推播過,避免重複發送
            requests = await CheckPushedToday(requests);
            if (requests == null)
                return;

            FISCA.Presentation.MotherForm.SetStatusBarMessage("推播發送中...");

            PushBatchResult result;
            _sending = true;
            btnExit.Enabled = false;
            try
            {
                result = await PushWorkflow.SendAsync(btnSendMessage, requests, WriteApplicationLog, "位學生");
            }
            catch (Exception ex)
            {
                FISCA.Presentation.MotherForm.SetStatusBarMessage("");
                MsgBox.Show("推播發生錯誤:\n" + ex.Message);
                return;
            }
            finally
            {
                _sending = false;
                btnExit.Enabled = true;
            }

            if (result != null && result.SuccessCount > 0)
            {
                FISCA.Presentation.MotherForm.SetStatusBarMessage("推播完成");
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                FISCA.Presentation.MotherForm.SetStatusBarMessage("推播未完成");
            }
        }

        /// <summary>
        /// 防呆:發送前重新查詢推播紀錄(畫面開啟期間可能已有其他人發送),
        /// 有學生今天(伺服器日期)已推播過時,由使用者選擇全部發送 / 排除已推播學生 / 取消
        /// </summary>
        /// <returns>要發送的推播;取消時回傳 null</returns>
        private async Task<List<PushRequest>> CheckPushedToday(List<PushRequest> requests)
        {
            List<string> studentIDs = requests.Select(x => ((KeyBoStudent)x.State).ID).ToList();
            string pushType = PushType;

            Dictionary<string, PushLogUDT> latest;
            string today;

            FISCA.Presentation.MotherForm.SetStatusBarMessage("檢查推播紀錄...");
            _sending = true;
            btnSendMessage.Enabled = false;
            btnExit.Enabled = false;
            try
            {
                latest = await Task.Run(() => SelectLatestPushLog(pushType, studentIDs));
                today = await Task.Run(() => PushSender.GetServerTime().Substring(0, 10));
            }
            catch (Exception ex)
            {
                FISCA.Presentation.MotherForm.SetStatusBarMessage("");
                DialogResult goOn = MsgBox.Show("檢查推播紀錄失敗,無法確認今天是否已推播過：\n" + ex.Message + "\n\n是否仍要發送?"
                    , "推播紀錄", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                return goOn == DialogResult.Yes ? requests : null;
            }
            finally
            {
                _sending = false;
                btnSendMessage.Enabled = true;
                btnExit.Enabled = true;
            }

            FISCA.Presentation.MotherForm.SetStatusBarMessage("");

            //今天已推播過的學生
            List<PushRequest> pushedToday = new List<PushRequest>();
            foreach (PushRequest request in requests)
            {
                PushLogUDT log;
                if (latest.TryGetValue(((KeyBoStudent)request.State).ID, out log)
                    && ("" + log.PushTime).StartsWith(today))
                    pushedToday.Add(request);
            }

            //同步更新畫面上的「最近推播時間」
            UpdatePushTimeColumn(latest);

            if (pushedToday.Count == 0)
                return requests;

            const int maxShow = 15;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("下列 {0} 位學生今天已推播過「{1}」：", pushedToday.Count, pushType));
            foreach (PushRequest request in pushedToday.Take(maxShow))
            {
                KeyBoStudent stud = (KeyBoStudent)request.State;
                sb.AppendLine(string.Format("{0} {1}號 {2}({3})", stud.ClassName, stud.SeatNo, stud.Name, latest[stud.ID].PushTime));
            }
            if (pushedToday.Count > maxShow)
                sb.AppendLine(string.Format("...等,共 {0} 位", pushedToday.Count));
            sb.AppendLine();
            sb.AppendLine("「是」：全部發送(含已推播學生)");
            sb.AppendLine(string.Format("「否」：排除已推播學生,只發送其餘 {0} 位", requests.Count - pushedToday.Count));
            sb.AppendLine("「取消」：不發送");

            DialogResult dr = MsgBox.Show(sb.ToString(), "重複推播提醒"
                , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
                return requests;

            if (dr == DialogResult.No)
            {
                List<PushRequest> remain = requests.Except(pushedToday).ToList();
                if (remain.Count == 0)
                {
                    MsgBox.Show("排除今天已推播的學生後,沒有需要發送的學生");
                    return null;
                }
                return remain;
            }

            return null;
        }

        /// <summary>
        /// 將推播紀錄填入「最近推播時間」欄
        /// </summary>
        private void UpdatePushTimeColumn(Dictionary<string, PushLogUDT> latest)
        {
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                KeyBoStudent stud = row.Tag as KeyBoStudent;
                DataGridViewCell cell = row.Cells[colPushTime.Index];
                PushLogUDT log;
                if (stud != null && latest.TryGetValue(stud.ID, out log))
                {
                    cell.Value = log.PushTime;
                    cell.ToolTipText = string.Format("推播者：{0}\n標題：{1}", log.PushBy, log.Title);
                }
                else
                {
                    cell.Value = "未推播";
                    cell.ToolTipText = "";
                }
            }
        }

        /// <summary>
        /// 將發送成功的推播寫入系統紀錄(推播紀錄已由 Behavior.Push 自動儲存)
        /// </summary>
        private void WriteApplicationLog(PushBatchResult result)
        {
            List<PushResult> succeeded = result.Succeeded;
            if (succeeded.Count == 0)
                return;

            PushRequest first = succeeded[0].Request;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("已執行「{0}」推播：", PushType));
            sb.AppendLine(string.Format("發送對象「{0}」", PushReceiverText));
            sb.AppendLine(string.Format("發送標題「{0}」", first.Title));
            sb.AppendLine(string.Format("發送單位「{0}」", PushCategoryName));
            sb.AppendLine(string.Format("發送內容「{0}」", first.Body));
            sb.AppendLine(string.Format("發送學生(共{0}位)：", succeeded.Count));
            foreach (PushResult each in succeeded)
            {
                KeyBoStudent stud = (KeyBoStudent)each.Request.State;
                sb.AppendLine(string.Format("班級「{0}」座號「{1}」學號「{2}」姓名「{3}」", stud.ClassName, stud.SeatNo, stud.StudentNumber, stud.Name));
            }

            FISCA.LogAgent.ApplicationLog.Log("預警系統", "推播", sb.ToString());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
