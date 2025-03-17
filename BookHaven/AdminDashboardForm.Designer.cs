namespace BookHaven
{
    partial class AdminDashboardForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBoxSalesSummary = new GroupBox();
            btnRefresh = new Button();
            groupBoxInventory = new GroupBox();
            groupBoxRecentOrders = new GroupBox();
            groupBoxTopSelling = new GroupBox();
            tableLayoutPanel1.SuspendLayout();
            groupBoxSalesSummary.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBoxSalesSummary, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBoxInventory, 1, 0);
            tableLayoutPanel1.Controls.Add(groupBoxRecentOrders, 0, 1);
            tableLayoutPanel1.Controls.Add(groupBoxTopSelling, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1441, 798);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBoxSalesSummary
            // 
            groupBoxSalesSummary.Controls.Add(btnRefresh);
            groupBoxSalesSummary.Dock = DockStyle.Fill;
            groupBoxSalesSummary.Location = new Point(3, 3);
            groupBoxSalesSummary.Name = "groupBoxSalesSummary";
            groupBoxSalesSummary.Size = new Size(714, 393);
            groupBoxSalesSummary.TabIndex = 0;
            groupBoxSalesSummary.TabStop = false;
            groupBoxSalesSummary.Text = "Sales Summary";
            groupBoxSalesSummary.Enter += groupBoxSalesSummary_Enter;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(540, 347);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(174, 46);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh Data";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // groupBoxInventory
            // 
            groupBoxInventory.Dock = DockStyle.Fill;
            groupBoxInventory.Location = new Point(723, 3);
            groupBoxInventory.Name = "groupBoxInventory";
            groupBoxInventory.Size = new Size(715, 393);
            groupBoxInventory.TabIndex = 1;
            groupBoxInventory.TabStop = false;
            groupBoxInventory.Text = "Inventory Status";
            groupBoxInventory.Enter += groupBoxInventory_Enter;
            // 
            // groupBoxRecentOrders
            // 
            groupBoxRecentOrders.Dock = DockStyle.Fill;
            groupBoxRecentOrders.Location = new Point(3, 402);
            groupBoxRecentOrders.Name = "groupBoxRecentOrders";
            groupBoxRecentOrders.Size = new Size(714, 393);
            groupBoxRecentOrders.TabIndex = 2;
            groupBoxRecentOrders.TabStop = false;
            groupBoxRecentOrders.Text = "Recent Orders";
            groupBoxRecentOrders.Enter += groupBoxRecentOrders_Enter;
            // 
            // groupBoxTopSelling
            // 
            groupBoxTopSelling.Dock = DockStyle.Fill;
            groupBoxTopSelling.Location = new Point(723, 402);
            groupBoxTopSelling.Name = "groupBoxTopSelling";
            groupBoxTopSelling.Size = new Size(715, 393);
            groupBoxTopSelling.TabIndex = 3;
            groupBoxTopSelling.TabStop = false;
            groupBoxTopSelling.Text = "Top Selling Books";
            groupBoxTopSelling.Enter += groupBoxTopSelling_Enter;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1441, 798);
            Controls.Add(tableLayoutPanel1);
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookHaven - Admin Dashboard";
            WindowState = FormWindowState.Maximized;
            Load += AdminDashboardForm_Load_1;
            Click += AdminDashboardForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            groupBoxSalesSummary.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBoxSalesSummary;
        private GroupBox groupBoxInventory;
        private GroupBox groupBoxRecentOrders;
        private GroupBox groupBoxTopSelling;
        private Button btnRefresh;
    }
}