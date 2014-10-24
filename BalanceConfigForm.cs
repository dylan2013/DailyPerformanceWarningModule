using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using System.Xml;

namespace DailyPerformanceWarningModule
{
    public partial class BalanceConfigForm : BaseForm
    {
        public BalanceConfigForm()
        {
            InitializeComponent();
        }

        private void BalanceConfigForm_Load(object sender, EventArgs e)
        {
            //取得設定檔
            Dictionary<string, double> ConfigByName = tool.GetPeriodConfig();

            foreach (string each in ConfigByName.Keys)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewX1);
                row.Cells[0].Value = each;
                row.Cells[1].Value = ConfigByName[each]; //如果沒有設定值...預設為1
                dataGridViewX1.Rows.Add(row);
            }

        }

        //儲存
        private void buttonX1_Click(object sender, EventArgs e)
        {
            K12.Data.Configuration.ConfigData cd = K12.Data.School.Configuration[tool.SPstudentConfigList];
            //先移除
            //K12.Data.School.Configuration.Remove(cd);

            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {

                if (row.Cells[1].ErrorText != "")
                {
                    MsgBox.Show("輸入資料有誤,請修正後再儲存!");
                    return;
                }

                string Cell1 = "" + row.Cells[0].Value;
                string Cell2 = "" + row.Cells[1].Value;

                cd[Cell1] = Cell2;

            }

            cd.Save();

            FISCA.Presentation.Controls.MsgBox.Show("儲存設定成功");
            this.Close();
        }

        //離開
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string Cellvalue = "" + dataGridViewX1.CurrentCell.Value;

            if (tool.doubleCheck(Cellvalue))
            {
                dataGridViewX1.CurrentCell.ErrorText = "";
            }
            else
            {
                dataGridViewX1.CurrentCell.ErrorText = "儲存格必須輸入數字";
            }
        }
    }
}
