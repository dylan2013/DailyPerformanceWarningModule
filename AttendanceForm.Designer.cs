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
            this.cbStatistics = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnSendMessage = new DevComponents.DotNetBar.ButtonX();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.dateTimeStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dateTimeEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.checkBoxX2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel10.SuspendLayout();
            this.groupPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester1)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(9, 657);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(86, 17);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "缺曠類別權重";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupPanel10
            // 
            this.groupPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupPanel10.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel10.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel10.Controls.Add(this.listViewEx1);
            this.groupPanel10.Controls.Add(this.txtPeriodCount);
            this.groupPanel10.Controls.Add(this.labelX1);
            this.groupPanel10.Controls.Add(this.labelX2);
            this.groupPanel10.Controls.Add(this.cbxSelectAllPeriod);
            this.groupPanel10.Location = new System.Drawing.Point(12, 248);
            this.groupPanel10.Name = "groupPanel10";
            this.groupPanel10.Size = new System.Drawing.Size(373, 393);
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
            this.listViewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.listViewEx1.Border.Class = "ListViewBorder";
            this.listViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.listViewEx1.CheckBoxes = true;
            this.listViewEx1.HideSelection = false;
            this.listViewEx1.Location = new System.Drawing.Point(14, 62);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.Size = new System.Drawing.Size(338, 291);
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
            // groupPanel9
            // 
            this.groupPanel9.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel9.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel9.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel9.Controls.Add(this.dateTimeEnd);
            this.groupPanel9.Controls.Add(this.dateTimeStart);
            this.groupPanel9.Controls.Add(this.checkBoxX1);
            this.groupPanel9.Controls.Add(this.intSchoolYear1);
            this.groupPanel9.Controls.Add(this.intSemester1);
            this.groupPanel9.Controls.Add(this.cbAllSchoolYear);
            this.groupPanel9.Controls.Add(this.cbSingSchoolYear);
            this.groupPanel9.Controls.Add(this.lbSchoolYear1);
            this.groupPanel9.Controls.Add(this.lbSemester1);
            this.groupPanel9.Location = new System.Drawing.Point(12, 12);
            this.groupPanel9.Name = "groupPanel9";
            this.groupPanel9.Size = new System.Drawing.Size(373, 216);
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
            this.intSchoolYear1.Value = 110;
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
            this.cbAllSchoolYear.AutoSize = true;
            this.cbAllSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbAllSchoolYear.BackgroundStyle.Class = "";
            this.cbAllSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbAllSchoolYear.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbAllSchoolYear.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbAllSchoolYear.Location = new System.Drawing.Point(22, 156);
            this.cbAllSchoolYear.Name = "cbAllSchoolYear";
            this.cbAllSchoolYear.Size = new System.Drawing.Size(107, 21);
            this.cbAllSchoolYear.TabIndex = 5;
            this.cbAllSchoolYear.Text = "所有學期統計";
            // 
            // cbSingSchoolYear
            // 
            this.cbSingSchoolYear.AutoSize = true;
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
            this.cbSingSchoolYear.Size = new System.Drawing.Size(94, 21);
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
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(655, 649);
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
            this.cbIsRun.Location = new System.Drawing.Point(25, 7);
            this.cbIsRun.Name = "cbIsRun";
            this.cbIsRun.Size = new System.Drawing.Size(134, 21);
            this.cbIsRun.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbIsRun.TabIndex = 5;
            this.cbIsRun.Text = "執行登入缺曠預警\r\n";
            this.cbIsRun.TextColor = System.Drawing.Color.Red;
            this.cbIsRun.CheckedChanged += new System.EventHandler(this.cbIsRun_CheckedChanged);
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
            this.labelX3.Location = new System.Drawing.Point(43, 28);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(261, 56);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "勾選本選項,系統將於登入時\r\n依據條件內容顯示符合預警設定之學生清單\r\n(有本功能權限的使用者,進行顯示)";
            // 
            // cbStatistics
            // 
            this.cbStatistics.AutoSize = true;
            this.cbStatistics.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbStatistics.BackgroundStyle.Class = "";
            this.cbStatistics.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbStatistics.Location = new System.Drawing.Point(25, 90);
            this.cbStatistics.Name = "cbStatistics";
            this.cbStatistics.Size = new System.Drawing.Size(241, 21);
            this.cbStatistics.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbStatistics.TabIndex = 11;
            this.cbStatistics.Text = "統計改變的學生才顯示於預警清單內";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(44, 111);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(261, 56);
            this.labelX4.TabIndex = 12;
            this.labelX4.Text = "當符合標準之學生已經顯示於清單內\r\n下次登入則不再顯示相同內容之清單\r\n當該學生的統計已改變才再次顯示於清單內";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.BackColor = System.Drawing.Color.Transparent;
            this.btnSendMessage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSendMessage.ForeColor = System.Drawing.Color.Red;
            this.btnSendMessage.Location = new System.Drawing.Point(493, 649);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(156, 25);
            this.btnSendMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSendMessage.TabIndex = 16;
            this.btnSendMessage.Text = "查詢與推播";
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(486, 281);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(86, 17);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "使用預設訊息";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked_1);
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.textBoxX1);
            this.groupPanel2.Location = new System.Drawing.Point(391, 280);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(339, 361);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 20;
            this.groupPanel2.Text = "推播訊息";
            // 
            // textBoxX1
            // 
            this.textBoxX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.Location = new System.Drawing.Point(7, 5);
            this.textBoxX1.Multiline = true;
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxX1.Size = new System.Drawing.Size(318, 316);
            this.textBoxX1.TabIndex = 17;
            this.textBoxX1.Text = "親愛的家長您好\r\n貴子弟 已達「缺曠預警」標準\r\n請留意與檢視「缺曠資料」狀況\r\n課業問題，可立即向導師或主任反映與尋求協助\r\n如有釐清生涯志趣等疑惑，可由諮商中" +
    "心幫忙\r\n學校許多資源，敬請多加利用\r\n\r\n本次預警條件如下：{{學年期}}\r\n「假別」包含「{{假別}}」\r\n「節次」累積達「{{節次}}」以上";
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.checkBoxX2);
            this.groupPanel1.Controls.Add(this.cbIsRun);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.cbStatistics);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Location = new System.Drawing.Point(391, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(339, 262);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 22;
            this.groupPanel1.Text = "設定";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.Location = new System.Drawing.Point(616, 281);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(86, 17);
            this.linkLabel3.TabIndex = 23;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "顯示功能變數";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.AutoSize = true;
            this.checkBoxX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.Class = "";
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBoxX1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBoxX1.Location = new System.Drawing.Point(22, 78);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(94, 21);
            this.checkBoxX1.TabIndex = 6;
            this.checkBoxX1.Text = "依日期判斷";
            // 
            // dateTimeStart
            // 
            // 
            // 
            // 
            this.dateTimeStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeStart.ButtonDropDown.Visible = true;
            this.dateTimeStart.IsPopupCalendarOpen = false;
            this.dateTimeStart.Location = new System.Drawing.Point(126, 78);
            // 
            // 
            // 
            this.dateTimeStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeStart.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateTimeStart.MonthCalendar.BackgroundStyle.Class = "";
            this.dateTimeStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateTimeStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeStart.MonthCalendar.DayNames = new string[] {
        "日",
        "一",
        "二",
        "三",
        "四",
        "五",
        "六"};
            this.dateTimeStart.MonthCalendar.DisplayMonth = new System.DateTime(2026, 5, 1, 0, 0, 0, 0);
            this.dateTimeStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeStart.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateTimeStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeStart.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(180, 25);
            this.dateTimeStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeStart.TabIndex = 7;
            // 
            // dateTimeEnd
            // 
            // 
            // 
            // 
            this.dateTimeEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeEnd.ButtonDropDown.Visible = true;
            this.dateTimeEnd.IsPopupCalendarOpen = false;
            this.dateTimeEnd.Location = new System.Drawing.Point(126, 115);
            // 
            // 
            // 
            this.dateTimeEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeEnd.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dateTimeEnd.MonthCalendar.BackgroundStyle.Class = "";
            this.dateTimeEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dateTimeEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeEnd.MonthCalendar.DayNames = new string[] {
        "日",
        "一",
        "二",
        "三",
        "四",
        "五",
        "六"};
            this.dateTimeEnd.MonthCalendar.DisplayMonth = new System.DateTime(2026, 5, 1, 0, 0, 0, 0);
            this.dateTimeEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dateTimeEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dateTimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeEnd.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dateTimeEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeEnd.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(180, 25);
            this.dateTimeEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeEnd.TabIndex = 8;
            // 
            // checkBoxX2
            // 
            this.checkBoxX2.AutoSize = true;
            this.checkBoxX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBoxX2.BackgroundStyle.Class = "";
            this.checkBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX2.Location = new System.Drawing.Point(25, 178);
            this.checkBoxX2.Name = "checkBoxX2";
            this.checkBoxX2.Size = new System.Drawing.Size(214, 21);
            this.checkBoxX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX2.TabIndex = 13;
            this.checkBoxX2.Text = "依據『對應課程節次』設定判斷";
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 686);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupPanel10);
            this.Controls.Add(this.groupPanel9);
            this.Controls.Add(this.groupPanel2);
            this.DoubleBuffered = true;
            this.MaximizeBox = true;
            this.Name = "AttendanceForm";
            this.Text = "缺曠預警設定";
            this.groupPanel10.ResumeLayout(false);
            this.groupPanel10.PerformLayout();
            this.groupPanel9.ResumeLayout(false);
            this.groupPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intSchoolYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intSemester1)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeEnd)).EndInit();
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
        private DevComponents.DotNetBar.Controls.CheckBoxX cbStatistics;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnSendMessage;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeEnd;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeStart;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX2;
    }
}