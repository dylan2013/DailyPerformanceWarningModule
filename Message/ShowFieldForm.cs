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
    public partial class ShowFieldForm : BaseForm
    {
        public ShowFieldForm(string message)
        {
            InitializeComponent();

            textBoxX1.Text = message;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
