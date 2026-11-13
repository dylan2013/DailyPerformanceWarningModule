using FISCA.Authentication;
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
    public partial class AttendanceForm : BaseForm
    {
        /// <summary>
        /// 設定值
        /// </summary>
        AttendanceConfigObj Config { get; set; }

        public AttendanceForm()
        {
            InitializeComponent();

            BackgroundWorker BGW = new BackgroundWorker();
            BGW.RunWorkerCompleted += BGW_RunWorkerCompleted;
            BGW.DoWork += BGW_DoWork;
            BGW.RunWorkerAsync();
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //取得相關設定值
            Config = new AttendanceConfigObj();
            Config.GetConfig();
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                if (e.Error == null)
                {
                    SetConfig();
                }
                else
                {
                    MsgBox.Show("取得資料發生錯誤\n請重新開啟本畫面!");
                }
            }
            else
            {
                MsgBox.Show("已中止操作!");
            }
        }

        /// <summary>
        /// 設定畫面上的資料
        /// </summary>
        private void SetConfig()
        {
            this.cbIsRun.CheckedChanged -= new System.EventHandler(this.cbIsRun_CheckedChanged);
            cbIsRun.Checked = Config.Run;
            this.cbIsRun.CheckedChanged += new System.EventHandler(this.cbIsRun_CheckedChanged);

            intSchoolYear1.Value = Config.SchoolYear;
            intSemester1.Value = Config.Semester;

            //判斷模式
            if (Config.DateMode == AttendanceConfigObj.Mode_Sem)
                cbSingSchoolYear.Checked = true;
            else if (Config.DateMode == AttendanceConfigObj.Mode_Date)
                checkBoxX1.Checked = true;
            else
                cbAllSchoolYear.Checked = true;

            dateTimeStart.Value = Config.StartDate;
            dateTimeEnd.Value = Config.EndDate;

            cbSingSchoolYear.CheckedChanged += Condition_CheckedChanged;
            checkBoxX1.CheckedChanged += Condition_CheckedChanged;
            cbAllSchoolYear.CheckedChanged += Condition_CheckedChanged;
            UpdateConditionInputState();

            //統計
            cbStatistics.Checked = Config.StatisticsChange;

            //依據『對應課程節次』設定判斷
            checkBoxX2.Checked = Config.ByCoursePeriod;



            txtPeriodCount.Text = "" + Config.AttenanceCount;

            foreach (K12.Data.AbsenceMappingInfo info in K12.Data.AbsenceMapping.SelectAll())
            {
                //listViewEx1.Items.Add(info.Name);
                ListViewItem item = new ListViewItem();
                item.Text = info.Name;
                if (Config.AttendanceList.Contains(info.Name))
                {
                    item.Checked = true;
                }
                listViewEx1.Items.Add(item);
            }

            textBoxX1.Text = Config.AttendanceMessage.Replace("\n", "\r\n");
        }

        private bool SaveConfig()
        {
            //依日期判斷時,先驗證日期(於異動 Config 前驗證,失敗則不存檔)
            if (checkBoxX1.Checked)
            {
                if (dateTimeStart.IsEmpty || dateTimeEnd.IsEmpty)
                {
                    MsgBox.Show("請選擇起始日期與結束日期!");
                    return false;
                }
                if (dateTimeStart.Value.Date > dateTimeEnd.Value.Date)
                {
                    MsgBox.Show("起始日期不可大於結束日期!");
                    return false;
                }
            }

            Config.AttenanceCount = tool.ParseInt(txtPeriodCount.Text);
            Config.Run = cbIsRun.Checked;
            Config.StatisticsChange = cbStatistics.Checked;
            Config.ByCoursePeriod = checkBoxX2.Checked;

            //判斷模式
            if (cbSingSchoolYear.Checked)
            {
                Config.DateMode = AttendanceConfigObj.Mode_Sem;
                Config.SingOrAll = true;
                Config.SchoolYear = intSchoolYear1.Value;
                Config.Semester = intSemester1.Value;
            }
            else if (checkBoxX1.Checked)
            {
                Config.DateMode = AttendanceConfigObj.Mode_Date;
                Config.SingOrAll = false;
                Config.StartDate = dateTimeStart.Value.Date;
                Config.EndDate = dateTimeEnd.Value.Date;
                //指定學年期為預設學年期
                Config.SchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);
                Config.Semester = int.Parse(K12.Data.School.DefaultSemester);
            }
            else
            {
                //所有學期統計,指定學年期為預設學年期
                Config.DateMode = AttendanceConfigObj.Mode_All;
                Config.SingOrAll = false;
                Config.SchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);
                Config.Semester = int.Parse(K12.Data.School.DefaultSemester);
            }

            //假別條件
            Config.AttendanceList.Clear();
            foreach (ListViewItem item in listViewEx1.Items)
            {
                if (item.Checked)
                {
                    Config.AttendanceList.Add(item.Text);
                }
            }
            Config.AttendanceMessage = textBoxX1.Text.Replace("\r\n", "\n");
            Config.SaveConfig();
            return true;
        }

        /// <summary>
        /// 依目前判斷模式,啟用/停用對應輸入欄位
        /// </summary>
        private void UpdateConditionInputState()
        {
            intSchoolYear1.Enabled = cbSingSchoolYear.Checked;
            intSemester1.Enabled = cbSingSchoolYear.Checked;
            dateTimeStart.Enabled = checkBoxX1.Checked;
            dateTimeEnd.Enabled = checkBoxX1.Checked;
        }

        private void Condition_CheckedChanged(object sender, EventArgs e)
        {
            UpdateConditionInputState();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BalanceConfigForm BCForm = new BalanceConfigForm();
            BCForm.ShowDialog();
        }

        private void cbxSelectAllPeriod_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem each in listViewEx1.Items)
            {
                each.Checked = cbxSelectAllPeriod.Checked;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            //推播改由 Behavior.Push 發送(以推播金鑰授權),不再限定 Greening 帳號
            if (!Run.BGW_Att.IsBusy)
            {
                btnSendMessage.Enabled = false;
                btnSendMessage.Text = "推播(開始發送作業)";

                FISCA.Presentation.MotherForm.SetStatusBarMessage("儲存設定...");

                if (!SaveConfig())
                {
                    //存檔失敗(日期驗證未過),還原按鈕狀態並中止作業
                    btnSendMessage.Enabled = true;
                    btnSendMessage.Text = "查詢與推播";
                    FISCA.Presentation.MotherForm.SetStatusBarMessage("");
                    return;
                }

                FISCA.Presentation.MotherForm.SetStatusBarMessage("開始取得預警清單...");

                Run.BGW_Att.RunWorkerCompleted += BGW_Att_RunWorkerCompleted;

                IsSaveOrShow show = new IsSaveOrShow();
                show.IsSave = cbStatistics.Checked; //控制已經預警過的學生
                show.NowRun = true; //立即執行
                show.IsShow = false;
                Run.BGW_Att.RunWorkerAsync(show);
            }
            else
            {
                MsgBox.Show("系統忙碌中請稍後再試!!");
            }
        }

        private void BGW_Att_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message = SetText(textBoxX1.Text);
            DoWorkObj _do = (DoWorkObj)e.Result;

            if (_do.AttendanceList.Count > 0)
            {
                ViewDetail smessage = new ViewDetail(_do, false, "缺曠預警通知", message);
                DialogResult dr = smessage.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    btnSendMessage.Text = "推播(已發送)";
                }
                else
                {
                    btnSendMessage.Text = "推播(已取消)";
                }
            }
            else
            {
                btnSendMessage.Text = "推播(查無符合條件)";
            }

            Run.BGW_Att.RunWorkerCompleted -= BGW_Att_RunWorkerCompleted;
            btnSendMessage.Enabled = true;
        }

        private string SetText(string text)
        {
            string dateText = string.Format("「{0}」至「{1}」", Config.StartDate.ToString("yyyy/MM/dd"), Config.EndDate.ToString("yyyy/MM/dd"));
            string syText;
            if (Config.DateMode == AttendanceConfigObj.Mode_Sem)
                syText = string.Format("「{0}」學年度 第「{1}」學期", Config.SchoolYear, Config.Semester);
            else if (Config.DateMode == AttendanceConfigObj.Mode_Date)
                syText = dateText;
            else
                syText = "「所有學期」";

            text = text.Replace("{{學年期}}", syText);
            text = text.Replace("{{日期}}", Config.DateMode == AttendanceConfigObj.Mode_Date ? dateText : "");
            text = text.Replace("{{學年度}}", "" + Config.SchoolYear);
            text = text.Replace("{{學期}}", "" + Config.Semester);
            text = text.Replace("{{節次}}", "" + Config.AttenanceCount);
            text = text.Replace("{{假別}}", "" + string.Join("，", Config.AttendanceList));
            return text;
        }

        private void cbIsRun_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveConfig())
            {
                //存檔失敗(日期驗證未過),還原勾選狀態
                this.cbIsRun.CheckedChanged -= new System.EventHandler(this.cbIsRun_CheckedChanged);
                cbIsRun.Checked = Config.Run;
                this.cbIsRun.CheckedChanged += new System.EventHandler(this.cbIsRun_CheckedChanged);
            }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxX1.Text = @"親愛的家長您好
貴子弟 已達「缺曠預警」標準
請留意與檢視「缺曠資料」狀況
課業問題，可立即向導師或主任反映與尋求協助
如有釐清生涯志趣等疑惑，可由諮商中心幫忙
學校許多資源，敬請多加利用

本次預警條件如下：{{學年期}}
「假別」包含「{{假別}}」
「缺曠」累積達「{{節次}}」節次以上";
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string message = @"功能變數：　　　說明：
{{學年期}}　　　「{0}」學年度 第「{1}」學期 or 「所有學期」 or 日期區間
{{日期}}　　　　「2026/01/01」至「2026/05/19」(僅依日期判斷時)
{{學年度}}　　　110
{{學期}}　　　　1 or 2
{{節次}}　　　　1~999
{{假別}}　　　　曠課，缺課";

            ShowFieldForm sff = new ShowFieldForm(message);
            sff.ShowDialog();
        }
    }

}
