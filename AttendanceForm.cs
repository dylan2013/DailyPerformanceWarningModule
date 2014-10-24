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
                linkLabel1.Enabled = value;
                btnSave.Enabled = value;
            }
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //取得相關設定值
            Config = new AttendanceConfigObj();
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
                    groupPanel10.Enabled = cbIsRun.Checked;
                    linkLabel1.Enabled = cbIsRun.Checked;
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
                cbAllSchoolYear.Checked = true;


            txtPeriodCount.Text = Config.AttenanceCount.ToString();

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
        }

        /// <summary>
        /// 儲存相關設定值
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {

            //缺曠內容
            Config.AttenanceCount = tool.ParseInt(txtPeriodCount.Text);
            Config.Run = cbIsRun.Checked;
            //單或多學期
            if (cbSingSchoolYear.Checked)
            {
                Config.SingOrAll = true;
                Config.SchoolYear = intSchoolYear1.Value;
                Config.Semester = intSemester1.Value;
            }
            else
            {
                //選擇為多學期時,指定學年期圍預設學年期
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

            Config.SaveConfig();

            MsgBox.Show("儲存完成!");

            this.Close();
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

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            groupPanel9.Enabled = cbIsRun.Checked;
            groupPanel10.Enabled = cbIsRun.Checked;
            linkLabel1.Enabled = cbIsRun.Checked;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Run.BGW_Att.RunWorkerAsync(false);
        }

    }

}
