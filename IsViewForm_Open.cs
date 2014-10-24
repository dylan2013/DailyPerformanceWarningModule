using Aspose.Cells;
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
    public partial class IsViewForm_Open : BaseForm
    {
        string Url { get; set; }

        bool _type { get; set; }

        DoWorkObj _do { get; set; }

        List<KeyBoStudent> _StudentIDList { get; set; }

        public IsViewForm_Open(string m, DoWorkObj dod, bool IsAttOrDem)
        {
            InitializeComponent();

            _do = dod;
            _type = IsAttOrDem;

            textBoxX1.Text = m.Replace("\n", "\r\n");

            if (_type)
            {
                _StudentIDList = _do.AttendanceList.Values.ToList();
            }
            else
            {
                _StudentIDList = _do.DemeritList.Values.ToList();
            }

            _StudentIDList.Sort(tool.SortStudent);

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_StudentIDList.Count > 0)
            {
                K12.Presentation.NLDPanels.Student.RemoveFromTemp(K12.Presentation.NLDPanels.Student.TempSource);
                List<string> list = new List<string>();
                foreach (KeyBoStudent each in _StudentIDList)
                {
                    list.Add(each.ID);
                }
                K12.Presentation.NLDPanels.Student.AddToTemp(list);
            }
            else
            {
                MsgBox.Show("無預警學生!!");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (_type)
                saveFileDialog1.FileName = "缺曠預警清單";
            else
                saveFileDialog1.FileName = "懲戒預警清單";

            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
            DataTable dt = new DataTable();

            if (_type)
            {

                dt.Columns.Add("班級");
                dt.Columns.Add("座號");
                dt.Columns.Add("學號");
                dt.Columns.Add("姓名");
                dt.Columns.Add("缺曠總計");

                foreach (KeyBoStudent each in _StudentIDList)
                {
                    DataRow row = dt.NewRow();
                    row["班級"] = each.ClassName;
                    row["座號"] = each.SeatNo;
                    row["學號"] = each.StudentNumber;
                    row["姓名"] = each.Name;
                    row["缺曠總計"] = each.AttendanceCount;
                    dt.Rows.Add(row);
                }

                wb.Worksheets[0].Cells.ImportDataTable(dt, true, "A1");
            }
            else
            {
                dt.Columns.Add("班級");
                dt.Columns.Add("座號");
                dt.Columns.Add("學號");
                dt.Columns.Add("姓名");
                dt.Columns.Add("大過");
                dt.Columns.Add("小過");
                dt.Columns.Add("警告");

                foreach (KeyBoStudent each in _StudentIDList)
                {
                    DataRow row = dt.NewRow();
                    row["班級"] = each.ClassName;
                    row["座號"] = each.SeatNo;
                    row["學號"] = each.StudentNumber;
                    row["姓名"] = each.Name;
                    row["大過"] = each.DemeritA;
                    row["小過"] = each.DemeritB;
                    row["警告"] = each.DemeritC;
                    dt.Rows.Add(row);
                }

                wb.Worksheets[0].Cells.ImportDataTable(dt, true, "A1");
            }
            wb.Save(saveFileDialog1.FileName, FileFormatType.Excel2003);
            System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }
    }
}
