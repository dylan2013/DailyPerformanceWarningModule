namespace DailyPerformanceWarningModule
{
    partial class AttendanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupPanel10 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.listViewEx1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.txtPeriodCount = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbxSelectAllPeriod = new System.Windows.Forms.CheckBox();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel9 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.intSchoolYear1 = new DevComponents.Editors.IntegerInput();
            this.intSemester1 = new DevComponents.Editors.IntegerInput();
            this.cbAllSchoolYear = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbSingSchoolYear = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.lbSchoolYear1 = new DevComponents.DotNetBar.LabelX();
            this.lbSemester1 = new DevComponents.DotNetBar.LabelX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.cbIsRun = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupPanel10.SuspendLayout();
            this.groupPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester1)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(9, 439);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 17);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "缺曠類別權重設定";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupPanel10
            // 
            this.groupPanel10.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel10.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel10.Controls.Add(this.listViewEx1);
            this.groupPanel10.Controls.Add(this.txtPeriodCount);
            this.groupPanel10.Controls.Add(this.labelX1);
            this.groupPanel10.Controls.Add(this.labelX2);
            this.groupPanel10.Controls.Add(this.cbxSelectAllPeriod);
            this.groupPanel10.Location = new System.Drawing.Point(14, 205);
            this.groupPanel10.Name = "groupPanel10";
            this.groupPanel10.Size = new System.Drawing.Size(373, 219);
            // 
            // 
            // 
            this.groupPanel10.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel10.Style.BackColorGradientAngle = 90;
            this.groupPanel10.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel10.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderBottomWidth = 1;
            this.groupPanel10.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel10.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderLeftWidth = 1;
            this.groupPanel10.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderRightWidth = 1;
            this.groupPanel10.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderTopWidth = 1;
            this.groupPanel10.Style.Class = "";
            this.groupPanel10.Style.CornerDiameter = 4;
            this.groupPanel10.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel10.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel10.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel10.StyleMouseDown.Class = "";
            this.groupPanel10.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel10.StyleMouseOver.Class = "";
            this.groupPanel10.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel10.TabIndex = 1;
            this.groupPanel10.Text = "其他條件";
            // 
            // listViewEx1
            // 
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.CheckBoxes = true;
            this.listViewEx1.Location = new System.Drawing.Point(14, 62);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(338, 123);
            this.listViewEx1.TabIndex = 4;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.List;
            // 
            // txtPeriodCount
            // 
            // 
            // 
            // 
            this.txtPeriodCount.Border.Class = "TextBoxBorder";
            this.txtPeriodCount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPeriodCount.Location = new System.Drawing.Point(117, 8);
            this.txtPeriodCount.Name = "txtPeriodCount";
            this.txtPeriodCount.Size = new System.Drawing.Size(82, 25);
            this.txtPeriodCount.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(14, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(101, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "輸入累計節次：";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(14, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(101, 21);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "勾選假別條件：";
            // 
            // cbxSelectAllPeriod
            // 
            this.cbxSelectAllPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSelectAllPeriod.AutoSize = true;
            this.cbxSelectAllPeriod.BackColor = System.Drawing.Color.Transparent;
            this.cbxSelectAllPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(66)))), ((int)(((byte)(133)))));
            this.cbxSelectAllPeriod.Location = new System.Drawing.Point(293, 37);
            this.cbxSelectAllPeriod.Name = "cbxSelectAllPeriod";
            this.cbxSelectAllPeriod.Size = new System.Drawing.Size(53, 21);
            this.cbxSelectAllPeriod.TabIndex = 3;
            this.cbxSelectAllPeriod.Text = "全選";
            this.cbxSelectAllPeriod.UseVisualStyleBackColor = false;
            this.cbxSelectAllPeriod.CheckedChanged += new System.EventHandler(this.cbxSelectAllPeriod_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(231, 434);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "儲存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupPanel9
            // 
            this.groupPanel9.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel9.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel9.Controls.Add(this.intSchoolYear1);
            this.groupPanel9.Controls.Add(this.intSemester1);
            this.groupPanel9.Controls.Add(this.cbAllSchoolYear);
            this.groupPanel9.Controls.Add(this.cbSingSchoolYear);
            this.groupPanel9.Controls.Add(this.lbSchoolYear1);
            this.groupPanel9.Controls.Add(this.lbSemester1);
            this.groupPanel9.Location = new System.Drawing.Point(14, 67);
            this.groupPanel9.Name = "groupPanel9";
            this.groupPanel9.Size = new System.Drawing.Size(373, 132);
            // 
            // 
            // 
            this.groupPanel9.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel9.Style.BackColorGradientAngle = 90;
            this.groupPanel9.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel9.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderBottomWidth = 1;
            this.groupPanel9.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel9.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderLeftWidth = 1;
            this.groupPanel9.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderRightWidth = 1;
            this.groupPanel9.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel9.Style.BorderTopWidth = 1;
            this.groupPanel9.Style.Class = "";
            this.groupPanel9.Style.CornerDiameter = 4;
            this.groupPanel9.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel9.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel9.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel9.StyleMouseDown.Class = "";
            this.groupPanel9.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel9.StyleMouseOver.Class = "";
            this.groupPanel9.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel9.TabIndex = 0;
            this.groupPanel9.Text = "選擇學年期";
            // 
            // intSchoolYear1
            // 
            // 
            // 
            // 
            this.intSchoolYear1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intSchoolYear1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intSchoolYear1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intSchoolYear1.Location = new System.Drawing.Point(126, 36);
            this.intSchoolYear1.MaxValue = 999;
            this.intSchoolYear1.MinValue = 90;
            this.intSchoolYear1.Name = "intSchoolYear1";
            this.intSchoolYear1.ShowUpDown = true;
            this.intSchoolYear1.Size = new System.Drawing.Size(61, 25);
            this.intSchoolYear1.TabIndex = 2;
            this.intSchoolYear1.Value = 102;
            // 
            // intSemester1
            // 
            // 
            // 
            // 
            this.intSemester1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.intSemester1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.intSemester1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.intSemester1.Location = new System.Drawing.Point(245, 36);
            this.intSemester1.MaxValue = 2;
            this.intSemester1.MinValue = 1;
            this.intSemester1.Name = "intSemester1";
            this.intSemester1.ShowUpDown = true;
            this.intSemester1.Size = new System.Drawing.Size(61, 25);
            this.intSemester1.TabIndex = 4;
            this.intSemester1.Value = 1;
            // 
            // cbAllSchoolYear
            // 
            this.cbAllSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbAllSchoolYear.BackgroundStyle.Class = "";
            this.cbAllSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbAllSchoolYear.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbAllSchoolYear.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbAllSchoolYear.Location = new System.Drawing.Point(23, 73);
            this.cbAllSchoolYear.Name = "cbAllSchoolYear";
            this.cbAllSchoolYear.Size = new System.Drawing.Size(110, 23);
            this.cbAllSchoolYear.TabIndex = 5;
            this.cbAllSchoolYear.Text = "所有學期統計";
            // 
            // cbSingSchoolYear
            // 
            this.cbSingSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbSingSchoolYear.BackgroundStyle.Class = "";
            this.cbSingSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbSingSchoolYear.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbSingSchoolYear.Checked = true;
            this.cbSingSchoolYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSingSchoolYear.CheckValue = "Y";
            this.cbSingSchoolYear.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbSingSchoolYear.Location = new System.Drawing.Point(22, 6);
            this.cbSingSchoolYear.Name = "cbSingSchoolYear";
            this.cbSingSchoolYear.Size = new System.Drawing.Size(110, 23);
            this.cbSingSchoolYear.TabIndex = 0;
            this.cbSingSchoolYear.Text = "依學期判斷";
            // 
            // lbSchoolYear1
            // 
            this.lbSchoolYear1.AutoSize = true;
            this.lbSchoolYear1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbSchoolYear1.BackgroundStyle.Class = "";
            this.lbSchoolYear1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSchoolYear1.Location = new System.Drawing.Point(67, 38);
            this.lbSchoolYear1.Name = "lbSchoolYear1";
            this.lbSchoolYear1.Size = new System.Drawing.Size(47, 21);
            this.lbSchoolYear1.TabIndex = 1;
            this.lbSchoolYear1.Text = "學年度";
            // 
            // lbSemester1
            // 
            this.lbSemester1.AutoSize = true;
            this.lbSemester1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbSemester1.BackgroundStyle.Class = "";
            this.lbSemester1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbSemester1.Location = new System.Drawing.Point(199, 38);
            this.lbSemester1.Name = "lbSemester1";
            this.lbSemester1.Size = new System.Drawing.Size(34, 21);
            this.lbSemester1.TabIndex = 3;
            this.lbSemester1.Text = "學期";
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(312, 434);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbIsRun
            // 
            this.cbIsRun.AutoSize = true;
            this.cbIsRun.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbIsRun.BackgroundStyle.Class = "";
            this.cbIsRun.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbIsRun.Location = new System.Drawing.Point(13, 12);
            this.cbIsRun.Name = "cbIsRun";
            this.cbIsRun.Size = new System.Drawing.Size(107, 21);
            this.cbIsRun.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbIsRun.TabIndex = 5;
            this.cbIsRun.Text = "執行缺曠預警\r\n";
            this.cbIsRun.TextColor = System.Drawing.Color.Red;
            this.cbIsRun.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Red;
            this.labelX3.Location = new System.Drawing.Point(130, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(261, 39);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "勾選本選項,系統將於登入時\r\n依據條件內容進行學生資料預警之訊息提示";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(137, 439);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(60, 17);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "測試預警";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 464);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.cbIsRun);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupPanel10);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupPanel9);
            this.DoubleBuffered = true;
            this.Name = "AttendanceForm";
            this.Text = "缺曠警示設定";
            this.groupPanel10.ResumeLayout(false);
            this.groupPanel10.PerformLayout();
            this.groupPanel9.ResumeLayout(false);
            this.groupPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel10;
        private DevComponents.DotNetBar.Controls.ListViewEx listViewEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPeriodCount;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.CheckBox cbxSelectAllPeriod;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel9;
        private DevComponents.Editors.IntegerInput intSchoolYear1;
        private DevComponents.Editors.IntegerInput intSemester1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbAllSchoolYear;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbSingSchoolYear;
        private DevComponents.DotNetBar.LabelX lbSchoolYear1;
        private DevComponents.DotNetBar.LabelX lbSemester1;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbIsRun;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}