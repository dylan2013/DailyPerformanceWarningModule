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

            IsBackGround = false;
            BackgroundWorker BGW = new BackgroundWorker();
            BGW.RunWorkerCompleted += BGW_RunWorkerCompleted;
            BGW.DoWork += BGW_DoWork;

            BGW.RunWorkerAsync();
        }

        bool IsBackGround
        {
            set
            {
                linkLabel2.Enabled = value;
                btnSave.Enabled = value;
            }
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //取得相關設定值
            Config = new DemeritConfigObj();
            Config.GetConfig();
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsBackGround = true;
            if (!e.Cancelled)
            {
                if (e.Error == null)
                {
                    SetConfig();

                    groupPanel9.Enabled = cbIsRun.Checked;
                    groupPanel6.Enabled = cbIsRun.Checked;
                    groupPanel8.Enabled = cbIsRun.Checked;
                    linkLabel2.Enabled = cbIsRun.Checked;
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
            cbIsRun.Checked = Config.Run;

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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             SaveConfig();

            MsgBox.Show("儲存完成!");

            this.Close();

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

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            groupPanel9.Enabled = cbIsRun.Checked;
            groupPanel6.Enabled = cbIsRun.Checked;
            groupPanel8.Enabled = cbIsRun.Checked;
            linkLabel2.Enabled = cbIsRun.Checked;
            cbStatistics.Enabled = cbIsRun.Checked;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             if (!Run.BGW_Dem.IsBusy)
             {
                  FISCA.Presentation.MotherForm.SetStatusBarMessage("儲存設定..."); 

                  SaveConfig();

                  FISCA.Presentation.MotherForm.SetStatusBarMessage("開始取得預警清單..."); 
                  Run.BGW_Dem.RunWorkerAsync(false);
             }
             else
             {
                  MsgBox.Show("系統忙碌中請稍後再試!!");
             }
        }
    }
}
