namespace BookHaven
{
    partial class OrderManagementForm
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
            splitContainer1 = new SplitContainer();
            dataGridViewOrders = new DataGridView();
            panelSearch = new Panel();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearchOrders = new Label();
            groupBoxOrderDetails = new GroupBox();
            btnClose = new Button();
            btnNewOrder = new Button();
            btnUpdateStatus = new Button();
            txtTotalAmount = new TextBox();
            lblTotalAmount = new Label();
            dataGridViewOrderItems = new DataGridView();
            dtpDeliveryDate = new DateTimePicker();
            lblDeliveryDate = new Label();
            cmbOrderStatus = new ComboBox();
            lblStatus2 = new Label();
            dtpOrderDate = new DateTimePicker();
            lblOrderDate = new Label();
            txtCustomer = new TextBox();
            lblCustomer = new Label();
            txtOrderID = new TextBox();
            lblOrderID = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            panelSearch.SuspendLayout();
            groupBoxOrderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderItems).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewOrders);
            splitContainer1.Panel1.Controls.Add(panelSearch);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBoxOrderDetails);
            splitContainer1.Size = new Size(1420, 972);
            splitContainer1.SplitterDistance = 473;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Dock = DockStyle.Fill;
            dataGridViewOrders.Location = new Point(0, 75);
            dataGridViewOrders.MultiSelect = false;
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.RowHeadersWidth = 82;
            dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrders.Size = new Size(1420, 398);
            dataGridViewOrders.TabIndex = 1;
            dataGridViewOrders.CellContentClick += dataGridViewOrders_CellContentClick;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(lblStatus);
            panelSearch.Controls.Add(cmbStatus);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearchOrders);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1420, 75);
            panelSearch.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(747, 22);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(83, 32);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "All", "Pending", "Processing", "Completed", "Cancelled" });
            cmbStatus.Location = new Point(875, 16);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(242, 40);
            cmbStatus.TabIndex = 3;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(545, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(235, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(276, 39);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearchOrders
            // 
            lblSearchOrders.AutoSize = true;
            lblSearchOrders.Location = new Point(32, 23);
            lblSearchOrders.Name = "lblSearchOrders";
            lblSearchOrders.Size = new Size(168, 32);
            lblSearchOrders.TabIndex = 0;
            lblSearchOrders.Text = "Search Orders:";
            // 
            // groupBoxOrderDetails
            // 
            groupBoxOrderDetails.Controls.Add(btnClose);
            groupBoxOrderDetails.Controls.Add(btnNewOrder);
            groupBoxOrderDetails.Controls.Add(btnUpdateStatus);
            groupBoxOrderDetails.Controls.Add(txtTotalAmount);
            groupBoxOrderDetails.Controls.Add(lblTotalAmount);
            groupBoxOrderDetails.Controls.Add(dataGridViewOrderItems);
            groupBoxOrderDetails.Controls.Add(dtpDeliveryDate);
            groupBoxOrderDetails.Controls.Add(lblDeliveryDate);
            groupBoxOrderDetails.Controls.Add(cmbOrderStatus);
            groupBoxOrderDetails.Controls.Add(lblStatus2);
            groupBoxOrderDetails.Controls.Add(dtpOrderDate);
            groupBoxOrderDetails.Controls.Add(lblOrderDate);
            groupBoxOrderDetails.Controls.Add(txtCustomer);
            groupBoxOrderDetails.Controls.Add(lblCustomer);
            groupBoxOrderDetails.Controls.Add(txtOrderID);
            groupBoxOrderDetails.Controls.Add(lblOrderID);
            groupBoxOrderDetails.Dock = DockStyle.Fill;
            groupBoxOrderDetails.Location = new Point(0, 0);
            groupBoxOrderDetails.Name = "groupBoxOrderDetails";
            groupBoxOrderDetails.Size = new Size(1420, 495);
            groupBoxOrderDetails.TabIndex = 0;
            groupBoxOrderDetails.TabStop = false;
            groupBoxOrderDetails.Text = "Order Details";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(1045, 399);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(189, 46);
            btnClose.TabIndex = 15;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click_1;
            // 
            // btnNewOrder
            // 
            btnNewOrder.Location = new Point(791, 404);
            btnNewOrder.Name = "btnNewOrder";
            btnNewOrder.Size = new Size(189, 46);
            btnNewOrder.TabIndex = 14;
            btnNewOrder.Text = "New Order";
            btnNewOrder.UseVisualStyleBackColor = true;
            btnNewOrder.Click += btnNewOrder_Click_1;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Location = new Point(560, 411);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(189, 46);
            btnUpdateStatus.TabIndex = 13;
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.UseVisualStyleBackColor = true;
            btnUpdateStatus.Click += btnUpdateStatus_Click_1;
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Location = new Point(236, 411);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(275, 39);
            txtTotalAmount.TabIndex = 12;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(58, 406);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(163, 32);
            lblTotalAmount.TabIndex = 11;
            lblTotalAmount.Text = "Total Amount:";
            // 
            // dataGridViewOrderItems
            // 
            dataGridViewOrderItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrderItems.Location = new Point(678, 59);
            dataGridViewOrderItems.Name = "dataGridViewOrderItems";
            dataGridViewOrderItems.ReadOnly = true;
            dataGridViewOrderItems.RowHeadersWidth = 82;
            dataGridViewOrderItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrderItems.Size = new Size(694, 300);
            dataGridViewOrderItems.TabIndex = 10;
            dataGridViewOrderItems.CellContentClick += dataGridViewOrderItems_CellContentClick;
            // 
            // dtpDeliveryDate
            // 
            dtpDeliveryDate.Enabled = false;
            dtpDeliveryDate.Location = new Point(223, 312);
            dtpDeliveryDate.Name = "dtpDeliveryDate";
            dtpDeliveryDate.Size = new Size(400, 39);
            dtpDeliveryDate.TabIndex = 9;
            dtpDeliveryDate.ValueChanged += dtpDeliveryDate_ValueChanged;
            // 
            // lblDeliveryDate
            // 
            lblDeliveryDate.AutoSize = true;
            lblDeliveryDate.Location = new Point(36, 309);
            lblDeliveryDate.Name = "lblDeliveryDate";
            lblDeliveryDate.Size = new Size(163, 32);
            lblDeliveryDate.TabIndex = 8;
            lblDeliveryDate.Text = "Delivery Date:";
            // 
            // cmbOrderStatus
            // 
            cmbOrderStatus.FormattingEnabled = true;
            cmbOrderStatus.Items.AddRange(new object[] { "Pending", "Processing", "Completed", "Cancelled" });
            cmbOrderStatus.Location = new Point(150, 254);
            cmbOrderStatus.Name = "cmbOrderStatus";
            cmbOrderStatus.Size = new Size(242, 40);
            cmbOrderStatus.TabIndex = 7;
            // 
            // lblStatus2
            // 
            lblStatus2.AutoSize = true;
            lblStatus2.Location = new Point(22, 257);
            lblStatus2.Name = "lblStatus2";
            lblStatus2.Size = new Size(83, 32);
            lblStatus2.TabIndex = 6;
            lblStatus2.Text = "Status:";
            lblStatus2.Click += label1_Click;
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Enabled = false;
            dtpOrderDate.Location = new Point(176, 197);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(400, 39);
            dtpOrderDate.TabIndex = 5;
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Location = new Point(22, 197);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(137, 32);
            lblOrderDate.TabIndex = 4;
            lblOrderDate.Text = "Order Date:";
            // 
            // txtCustomer
            // 
            txtCustomer.Location = new Point(164, 119);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.ReadOnly = true;
            txtCustomer.Size = new Size(286, 39);
            txtCustomer.TabIndex = 3;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(22, 119);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(122, 32);
            lblCustomer.TabIndex = 2;
            lblCustomer.Text = "Customer:";
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(164, 59);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.ReadOnly = true;
            txtOrderID.Size = new Size(286, 39);
            txtOrderID.TabIndex = 1;
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Location = new Point(22, 66);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(110, 32);
            lblOrderID.TabIndex = 0;
            lblOrderID.Text = "Order ID:";
            // 
            // OrderManagementForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1420, 972);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "OrderManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Order Management";
            Load += OrderManagementForm_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            groupBoxOrderDetails.ResumeLayout(false);
            groupBoxOrderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panelSearch;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearchOrders;
        private DataGridView dataGridViewOrders;
        private GroupBox groupBoxOrderDetails;
        private TextBox txtCustomer;
        private Label lblCustomer;
        private TextBox txtOrderID;
        private Label lblOrderID;
        private Label lblOrderDate;
        private DateTimePicker dtpOrderDate;
        private Label lblStatus2;
        private DateTimePicker dtpDeliveryDate;
        private Label lblDeliveryDate;
        private ComboBox cmbOrderStatus;
        private TextBox txtTotalAmount;
        private Label lblTotalAmount;
        private DataGridView dataGridViewOrderItems;
        private Button btnClose;
        private Button btnNewOrder;
        private Button btnUpdateStatus;
    }
}