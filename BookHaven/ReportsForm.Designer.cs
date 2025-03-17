namespace BookHaven
{
    partial class ReportsForm
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
            panelReportOptions = new Panel();
            btnExportReport = new Button();
            btnGenerateReport = new Button();
            cmbPeriod = new ComboBox();
            lblPeriod = new Label();
            dtpEndDate = new DateTimePicker();
            lblTo = new Label();
            dtpStartDate = new DateTimePicker();
            lblDateRange = new Label();
            cmbReportType = new ComboBox();
            lblReportType = new Label();
            tabControlReports = new TabControl();
            tabPage1 = new TabPage();
            dataGridViewReport = new DataGridView();
            tabPage2 = new TabPage();
            panelChart = new Panel();
            statusStripReports = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panelReportOptions.SuspendLayout();
            tabControlReports.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).BeginInit();
            tabPage2.SuspendLayout();
            statusStripReports.SuspendLayout();
            SuspendLayout();
            // 
            // panelReportOptions
            // 
            panelReportOptions.BackColor = SystemColors.ButtonFace;
            panelReportOptions.Controls.Add(btnExportReport);
            panelReportOptions.Controls.Add(btnGenerateReport);
            panelReportOptions.Controls.Add(cmbPeriod);
            panelReportOptions.Controls.Add(lblPeriod);
            panelReportOptions.Controls.Add(dtpEndDate);
            panelReportOptions.Controls.Add(lblTo);
            panelReportOptions.Controls.Add(dtpStartDate);
            panelReportOptions.Controls.Add(lblDateRange);
            panelReportOptions.Controls.Add(cmbReportType);
            panelReportOptions.Controls.Add(lblReportType);
            panelReportOptions.Dock = DockStyle.Top;
            panelReportOptions.Location = new Point(0, 0);
            panelReportOptions.Name = "panelReportOptions";
            panelReportOptions.Padding = new Padding(10);
            panelReportOptions.Size = new Size(1346, 200);
            panelReportOptions.TabIndex = 0;
            panelReportOptions.Paint += panelReportOptions_Paint;
            // 
            // btnExportReport
            // 
            btnExportReport.Enabled = false;
            btnExportReport.Location = new Point(1091, 131);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(179, 46);
            btnExportReport.TabIndex = 9;
            btnExportReport.Text = "Export to PDF";
            btnExportReport.UseVisualStyleBackColor = true;
            btnExportReport.Click += btnExportReport_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(886, 131);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(150, 46);
            btnGenerateReport.TabIndex = 8;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // cmbPeriod
            // 
            cmbPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPeriod.FormattingEnabled = true;
            cmbPeriod.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly" });
            cmbPeriod.Location = new Point(668, 54);
            cmbPeriod.Name = "cmbPeriod";
            cmbPeriod.Size = new Size(242, 40);
            cmbPeriod.TabIndex = 7;
            cmbPeriod.SelectedIndexChanged += cmbPeriod_SelectedIndexChanged;
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Location = new Point(558, 55);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new Size(86, 32);
            lblPeriod.TabIndex = 6;
            lblPeriod.Text = "Period:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(558, 130);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(215, 39);
            dtpEndDate.TabIndex = 5;
            dtpEndDate.Value = new DateTime(2025, 3, 13, 0, 0, 0, 0);
            dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(516, 135);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(36, 32);
            lblTo.TabIndex = 4;
            lblTo.Text = "to";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(279, 130);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(219, 39);
            dtpStartDate.TabIndex = 3;
            dtpStartDate.Value = new DateTime(2025, 3, 1, 0, 0, 0, 0);
            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Location = new Point(70, 128);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(143, 32);
            lblDateRange.TabIndex = 2;
            lblDateRange.Text = "Date Range:";
            // 
            // cmbReportType
            // 
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Sales Summary", "Best Selling Books", "Inventory Status" });
            cmbReportType.Location = new Point(274, 55);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(242, 40);
            cmbReportType.TabIndex = 1;
            cmbReportType.SelectedIndexChanged += cmbReportType_SelectedIndexChanged;
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = true;
            lblReportType.Location = new Point(70, 51);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(147, 32);
            lblReportType.TabIndex = 0;
            lblReportType.Text = "Report Type:";
            // 
            // tabControlReports
            // 
            tabControlReports.Controls.Add(tabPage1);
            tabControlReports.Controls.Add(tabPage2);
            tabControlReports.Dock = DockStyle.Fill;
            tabControlReports.Location = new Point(0, 200);
            tabControlReports.Name = "tabControlReports";
            tabControlReports.SelectedIndex = 0;
            tabControlReports.Size = new Size(1346, 616);
            tabControlReports.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridViewReport);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1330, 562);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Data View";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.AllowUserToAddRows = false;
            dataGridViewReport.AllowUserToDeleteRows = false;
            dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport.Dock = DockStyle.Fill;
            dataGridViewReport.Location = new Point(3, 3);
            dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewReport.RowHeadersWidth = 82;
            dataGridViewReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReport.Size = new Size(1324, 556);
            dataGridViewReport.TabIndex = 0;
            dataGridViewReport.CellContentClick += dataGridViewReport_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panelChart);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1330, 562);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Chart View";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelChart
            // 
            panelChart.Dock = DockStyle.Fill;
            panelChart.Location = new Point(3, 3);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(1324, 556);
            panelChart.TabIndex = 2;
            panelChart.Paint += panelChart_Paint;
            // 
            // statusStripReports
            // 
            statusStripReports.ImageScalingSize = new Size(32, 32);
            statusStripReports.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStripReports.Location = new Point(0, 774);
            statusStripReports.Name = "statusStripReports";
            statusStripReports.Size = new Size(1346, 42);
            statusStripReports.TabIndex = 2;
            statusStripReports.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(78, 32);
            toolStripStatusLabel1.Text = "Ready";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1346, 816);
            Controls.Add(statusStripReports);
            Controls.Add(tabControlReports);
            Controls.Add(panelReportOptions);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookHaven - Reports and Analytics";
            Load += ReportsForm_Load;
            panelReportOptions.ResumeLayout(false);
            panelReportOptions.PerformLayout();
            tabControlReports.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            tabPage2.ResumeLayout(false);
            statusStripReports.ResumeLayout(false);
            statusStripReports.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelReportOptions;
        private DateTimePicker dtpStartDate;
        private Label lblDateRange;
        private ComboBox cmbReportType;
        private Label lblReportType;
        private DateTimePicker dtpEndDate;
        private Label lblTo;
        private Label lblPeriod;
        private Button btnExportReport;
        private Button btnGenerateReport;
        private ComboBox cmbPeriod;
        private TabControl tabControlReports;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private DataGridView dataGridViewReport;
        private Panel panelChart;
        private StatusStrip statusStripReports;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}