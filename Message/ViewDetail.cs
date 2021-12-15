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
        DoWorkObj _do;
        string _title;
        string _message;
        FISCA.Data.QueryHelper _q = new FISCA.Data.QueryHelper();
        List<string> _IDList = new List<string>();
        BackgroundWorker bgw = new BackgroundWorker();

        /// <summary>
        /// mode = True懲戒
        /// mode = False缺曠
        /// </summary>
        public ViewDetail(DoWorkObj ddo, bool mode, string title, string message)
        {
            InitializeComponent();
            _do = ddo;
            _message = message;
            tbTitle.Text = title;
            textBoxX1.Text = _message.Replace("<br>", "\r\n");

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

                if (mode)
                    gRow.Cells[5].Value = string.Format("大過「{0}」小過「{1}」警告「{2}」", each.DemeritA, each.DemeritB, each.DemeritC); //統計支數
                else
                    gRow.Cells[5].Value = string.Format("缺曠「{0}」", each.AttendanceCount); //統計支數

                dataGridViewX1.Rows.Add(gRow);
            }

            bgw.DoWork += Bgw_DoWork;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text != "")
            {
                btnSendMessage.Enabled = false;
                if (!bgw.IsBusy)
                {
                    _title = tbTitle.Text;
                    _message = textBoxX1.Text.Replace("\r\n", "</br>");

                    foreach (DataGridViewRow row in dataGridViewX1.Rows)
                    {
                        string id = "" + row.Cells[0].Value;
                        _IDList.Add(id);
                    }

                    bgw.RunWorkerAsync();
                }
                else
                {
                    MsgBox.Show("系統忙錄中\n請稍後試再試");
                }
            }
            else
            {
                MsgBox.Show("請輸入推播內容!");
            }

        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            SendMessage send = new SendMessage(_IDList, _title, _message);
            send.Run();

        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSendMessage.Enabled = true;

            if (!e.Cancelled)
            {
                if (e.Error != null)
                {
                    MsgBox.Show("推播發生錯誤:\n" + e.Error.Message);
                }
                else
                {
                    FISCA.Presentation.MotherForm.SetStatusBarMessage("推播完成");
                    MsgBox.Show("推播完成!");

                    this.DialogResult = DialogResult.Yes;
                }
            }
            else
            {
                MsgBox.Show("作業已取消\n無法推播給[教師/學生]以外對象");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
