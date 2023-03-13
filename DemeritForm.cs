using FISCA.Authentication;
using FISCA.Presentation.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DailyPerformanceWarningModule
{
    public partial class DemeritForm : BaseForm
    {
        /// <summary>
        /// 設定值
        /// </summary>
        DemeritConfigObj Config { get; set; }

        public DemeritForm()
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
            Config = new DemeritConfigObj();
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

            //學年度與學期
            if (Config.SingOrAll)
                cbSingSchoolYear.Checked = true;
            else
                cbSingSchoolYear.Checked = true;

            //統計
            cbStatistics.Checked = Config.StatisticsChange;

            tbDemeritA.Text = Config.DemeritA.ToString();
            tbDemeritB.Text = Config.DemeritB.ToString();
            tbDemeritC.Text = Config.DemeritC.ToString();

            cbxIsMeritAndDemerit.Checked = Config.DemeritBalance;

            textBoxX1.Text = Config.DemeritMessage.Replace("\n", "\r\n");
        }

        private void SaveConfig()
        {
            Config.Run = cbIsRun.Checked;
            Config.StatisticsChange = cbStatistics.Checked;

            //單或多學期
            if (cbSingSchoolYear.Checked)
            {
                Config.SingOrAll = true;
                Config.SchoolYear = intSchoolYear1.Value;
                Config.Semester = intSemester1.Value;
            }
            else
            {
                //選擇為多學期時,並指定學年期圍預設學年期
                Config.SingOrAll = false;
                Config.SchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);
                Config.Semester = int.Parse(K12.Data.School.DefaultSemester);
            }

            Config.DemeritBalance = cbxIsMeritAndDemerit.Checked;

            Config.DemeritA = tool.ParseInt(tbDemeritA.Text);
            Config.DemeritB = tool.ParseInt(tbDemeritB.Text);
            Config.DemeritC = tool.ParseInt(tbDemeritC.Text);

            Config.DemeritMessage = textBoxX1.Text.Replace("\r\n", "\n");

            Config.SaveConfig();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReduceForm config = new ReduceForm();
            config.ShowDialog();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (DSAServices.AccountType == AccountType.Greening)
            {
                btnSendMessage.Enabled = false;
                btnSendMessage.Text = "推播(開始發送作業)";
                Run.BGW_Dem.RunWorkerCompleted += BGW_Dem_RunWorkerCompleted;

                if (!Run.BGW_Dem.IsBusy)
                {
                    FISCA.Presentation.MotherForm.SetStatusBarMessage("儲存設定...");

                    SaveConfig();

                    FISCA.Presentation.MotherForm.SetStatusBarMessage("開始取得預警清單...");


                    IsSaveOrShow show = new IsSaveOrShow();
                    show.IsSave = cbStatistics.Checked; //控制已經預警過的學生
                    show.NowRun = true; //立即執行
                    Run.BGW_Dem.RunWorkerAsync(show);
                }
                else
                {
                    btnSendMessage.Enabled = true;
                    MsgBox.Show("系統忙碌中請稍後再試!!");
                }
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("必須是Greening帳號(如abc@gmail.com)");
            }
        }

        private void BGW_Dem_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string message = SetText(textBoxX1.Text);
            DoWorkObj _do = (DoWorkObj)e.Result;
            if (_do.DemeritList.Count > 0)
            {
                Run.CompletedAtt(_do);
                ViewDetail smessage = new ViewDetail(_do, true, "懲戒預警通知", message);
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

            Run.BGW_Dem.RunWorkerCompleted -= BGW_Dem_RunWorkerCompleted;
            btnSendMessage.Enabled = true;
        }

        private string SetText(string text)
        {

            text = text.Replace("{{學年期}}", cbSingSchoolYear.Checked ? string.Format("「{0}」學年度　第「{1}」學期", Config.SchoolYear, Config.Semester) : "「所有學期」");
            text = text.Replace("{{學年度}}", "" + Config.SchoolYear);
            text = text.Replace("{{學期}}", "" + Config.Semester);
            text = text.Replace("{{大過}}", "" + Config.DemeritA);
            text = text.Replace("{{小過}}", "" + Config.DemeritB);
            text = text.Replace("{{警告}}", "" + Config.DemeritC);
            text = text.Replace("{{功過相抵}}", Config.DemeritBalance ? "是" : "否");
            return text;
        }

        private void cbIsRun_CheckedChanged(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxX1.Text = @"親愛的家長您好
貴子弟 已達「懲戒預警」標準
請留意與檢視「懲戒資料」狀況
課業問題，可立即向導師或主任反映與尋求協助
如有釐清生涯志趣等疑惑，可由諮商中心幫忙
學校許多資源，敬請多加利用

本次預警條件如下：{{學年期}}
大過「{{大過}}」小過「{{小過}}」警告「{{警告}}」
是否功過相抵「{{功過相抵}}」";
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string message = @"功能變數：　　　說明：
{{學年期}}　　　「{0}」學年度 第「{1}」學期 or 「所有學期」
{{學年度}}　　　110
{{學期}}　　　　1 or 2
{{大過}}　　　　1~999
{{小過}}　　　　1~999
{{警告}}　　　　1~999
{{功過相抵}}　　是 or 否";

            ShowFieldForm sff = new ShowFieldForm(message);
            sff.ShowDialog();
        }
    }
}
