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
        List<string> _IDList;
        string _title;
        string _message;
        string _fileName;
        FISCA.Data.QueryHelper _q = new FISCA.Data.QueryHelper();

        BackgroundWorker bgw = new BackgroundWorker();

        public ViewDetail(List<string> IDList, string title, string message)
        {
            InitializeComponent();
            _IDList = IDList;
            _message = message;
            tbTitle.Text = title;
            textBoxX1.Text = _message.Replace("<br>", "\r\n");

            //建立資料

            DataTable dt = _q.Select(string.Format("select id,name from student where id in('{0}')", string.Join("','", IDList)));
            foreach (DataRow dRow in dt.Rows)
            {
                DataGridViewRow gRow = new DataGridViewRow();
                gRow.CreateCells(dataGridViewX1);
                gRow.Cells[0].Value = "" + dRow["id"];
                gRow.Cells[1].Value = "" + dRow["name"];
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
                    _message = textBoxX1.Text;
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
