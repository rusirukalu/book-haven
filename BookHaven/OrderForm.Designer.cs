namespace BookHaven
{
    partial class OrderForm
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
            gbCustomer = new GroupBox();
            lblCustomerDetails = new Label();
            btnNewCustomer = new Button();
            cmbCustomers = new ComboBox();
            lblCustomer = new Label();
            gbBookSearch = new GroupBox();
            nudQuantity = new NumericUpDown();
            btnAddToOrder = new Button();
            dgvBooks = new DataGridView();
            txtSearch = new TextBox();
            lblSearch = new Label();
            gbOrderItems = new GroupBox();
            btnRemoveItem = new Button();
            dgvCart = new DataGridView();
            gbOrderDetails = new GroupBox();
            btnCreateOrder = new Button();
            dtpDeliveryDate = new DateTimePicker();
            lblDeliveryDate = new Label();
            txtTotal = new TextBox();
            lblTotal = new Label();
            txtTax = new TextBox();
            lblTax = new Label();
            txtSubtotal = new TextBox();
            lblSubtotal = new Label();
            lblStatus = new Label();
            cmbOrderStatus = new ComboBox();
            gbCustomer.SuspendLayout();
            gbBookSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            gbOrderItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            gbOrderDetails.SuspendLayout();
            SuspendLayout();
            // 
            // gbCustomer
            // 
            gbCustomer.Controls.Add(lblCustomerDetails);
            gbCustomer.Controls.Add(btnNewCustomer);
            gbCustomer.Controls.Add(cmbCustomers);
            gbCustomer.Controls.Add(lblCustomer);
            gbCustomer.Location = new Point(26, 27);
            gbCustomer.Name = "gbCustomer";
            gbCustomer.Size = new Size(1426, 242);
            gbCustomer.TabIndex = 0;
            gbCustomer.TabStop = false;
            gbCustomer.Text = "Customer Information";
            gbCustomer.Enter += gbCustomer_Enter;
            // 
            // lblCustomerDetails
            // 
            lblCustomerDetails.AutoSize = true;
            lblCustomerDetails.BorderStyle = BorderStyle.FixedSingle;
            lblCustomerDetails.Location = new Point(726, 74);
            lblCustomerDetails.Name = "lblCustomerDetails";
            lblCustomerDetails.Size = new Size(2, 34);
            lblCustomerDetails.TabIndex = 3;
            lblCustomerDetails.Click += lblCustomerDetails_Click;
            // 
            // btnNewCustomer
            // 
            btnNewCustomer.Location = new Point(503, 66);
            btnNewCustomer.Name = "btnNewCustomer";
            btnNewCustomer.Size = new Size(184, 46);
            btnNewCustomer.TabIndex = 2;
            btnNewCustomer.Text = "New Customer";
            btnNewCustomer.UseVisualStyleBackColor = true;
            btnNewCustomer.Click += btnNewCustomer_Click;
            // 
            // cmbCustomers
            // 
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(169, 66);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(304, 40);
            cmbCustomers.TabIndex = 1;
            cmbCustomers.SelectedIndexChanged += cmbCustomers_SelectedIndexChanged;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(31, 63);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(122, 32);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Customer:";
            // 
            // gbBookSearch
            // 
            gbBookSearch.Controls.Add(nudQuantity);
            gbBookSearch.Controls.Add(btnAddToOrder);
            gbBookSearch.Controls.Add(dgvBooks);
            gbBookSearch.Controls.Add(txtSearch);
            gbBookSearch.Controls.Add(lblSearch);
            gbBookSearch.Location = new Point(29, 275);
            gbBookSearch.Name = "gbBookSearch";
            gbBookSearch.Size = new Size(1423, 385);
            gbBookSearch.TabIndex = 1;
            gbBookSearch.TabStop = false;
            gbBookSearch.Text = "Book Search";
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(759, 55);
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(145, 39);
            nudQuantity.TabIndex = 4;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.ValueChanged += nudQuantity_ValueChanged;
            // 
            // btnAddToOrder
            // 
            btnAddToOrder.Location = new Point(545, 52);
            btnAddToOrder.Name = "btnAddToOrder";
            btnAddToOrder.Size = new Size(180, 46);
            btnAddToOrder.TabIndex = 3;
            btnAddToOrder.Text = "Add To Order";
            btnAddToOrder.UseVisualStyleBackColor = true;
            btnAddToOrder.Click += btnAddToOrder_Click;
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(34, 115);
            dgvBooks.MultiSelect = false;
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 82;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(1354, 243);
            dgvBooks.TabIndex = 2;
            dgvBooks.CellContentClick += dgvBooks_CellContentClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(129, 56);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(350, 39);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(20, 56);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(90, 32);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // gbOrderItems
            // 
            gbOrderItems.Controls.Add(btnRemoveItem);
            gbOrderItems.Controls.Add(dgvCart);
            gbOrderItems.Location = new Point(36, 695);
            gbOrderItems.Name = "gbOrderItems";
            gbOrderItems.Size = new Size(1423, 285);
            gbOrderItems.TabIndex = 2;
            gbOrderItems.TabStop = false;
            gbOrderItems.Text = "Order Items";
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.Location = new Point(1193, 127);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(188, 46);
            btnRemoveItem.TabIndex = 1;
            btnRemoveItem.Text = "Remove Item";
            btnRemoveItem.UseVisualStyleBackColor = true;
            btnRemoveItem.Click += btnRemoveItem_Click;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(17, 50);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersWidth = 82;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(1117, 211);
            dgvCart.TabIndex = 0;
            dgvCart.CellContentClick += dgvCart_CellContentClick;
            // 
            // gbOrderDetails
            // 
            gbOrderDetails.Controls.Add(btnCreateOrder);
            gbOrderDetails.Controls.Add(dtpDeliveryDate);
            gbOrderDetails.Controls.Add(lblDeliveryDate);
            gbOrderDetails.Controls.Add(txtTotal);
            gbOrderDetails.Controls.Add(lblTotal);
            gbOrderDetails.Controls.Add(txtTax);
            gbOrderDetails.Controls.Add(lblTax);
            gbOrderDetails.Controls.Add(txtSubtotal);
            gbOrderDetails.Controls.Add(lblSubtotal);
            gbOrderDetails.Location = new Point(40, 1006);
            gbOrderDetails.Name = "gbOrderDetails";
            gbOrderDetails.Size = new Size(1419, 286);
            gbOrderDetails.TabIndex = 3;
            gbOrderDetails.TabStop = false;
            gbOrderDetails.Text = "Order Details";
            // 
            // btnCreateOrder
            // 
            btnCreateOrder.BackColor = Color.LightGreen;
            btnCreateOrder.Location = new Point(1158, 57);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(175, 46);
            btnCreateOrder.TabIndex = 8;
            btnCreateOrder.Text = "Create Order";
            btnCreateOrder.UseVisualStyleBackColor = false;
            btnCreateOrder.Click += btnCreateOrder_Click;
            // 
            // dtpDeliveryDate
            // 
            dtpDeliveryDate.Location = new Point(682, 63);
            dtpDeliveryDate.Name = "dtpDeliveryDate";
            dtpDeliveryDate.Size = new Size(400, 39);
            dtpDeliveryDate.TabIndex = 7;
            dtpDeliveryDate.ValueChanged += dtpDeliveryDate_ValueChanged;
            // 
            // lblDeliveryDate
            // 
            lblDeliveryDate.AutoSize = true;
            lblDeliveryDate.Location = new Point(489, 63);
            lblDeliveryDate.Name = "lblDeliveryDate";
            lblDeliveryDate.Size = new Size(163, 32);
            lblDeliveryDate.TabIndex = 6;
            lblDeliveryDate.Text = "Delivery Date:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(132, 192);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(296, 39);
            txtTotal.TabIndex = 5;
            txtTotal.TextChanged += txtTotal_TextChanged;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(23, 199);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(70, 32);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total:";
            // 
            // txtTax
            // 
            txtTax.Location = new Point(167, 120);
            txtTax.Name = "txtTax";
            txtTax.ReadOnly = true;
            txtTax.Size = new Size(261, 39);
            txtTax.TabIndex = 3;
            txtTax.TextChanged += txtTax_TextChanged;
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Location = new Point(17, 123);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(119, 32);
            lblTax.TabIndex = 2;
            lblTax.Text = "Tax (10%):";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(132, 57);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(296, 39);
            txtSubtotal.TabIndex = 1;
            txtSubtotal.TextChanged += txtSubtotal_TextChanged;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(13, 53);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(108, 32);
            lblSubtotal.TabIndex = 0;
            lblSubtotal.Text = "Subtotal:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(49, 1319);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(151, 32);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Order Status:";
            // 
            // cmbOrderStatus
            // 
            cmbOrderStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrderStatus.FormattingEnabled = true;
            cmbOrderStatus.Items.AddRange(new object[] { "Pending", "Processing", "Completed", "Cancelled" });
            cmbOrderStatus.Location = new Point(210, 1319);
            cmbOrderStatus.Name = "cmbOrderStatus";
            cmbOrderStatus.Size = new Size(298, 40);
            cmbOrderStatus.TabIndex = 5;
            cmbOrderStatus.SelectedIndexChanged += cmbOrderStatus_SelectedIndexChanged;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1547, 1363);
            Controls.Add(cmbOrderStatus);
            Controls.Add(lblStatus);
            Controls.Add(gbOrderDetails);
            Controls.Add(gbOrderItems);
            Controls.Add(gbBookSearch);
            Controls.Add(gbCustomer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "OrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create New Order";
            Load += OrderForm_Load;
            gbCustomer.ResumeLayout(false);
            gbCustomer.PerformLayout();
            gbBookSearch.ResumeLayout(false);
            gbBookSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            gbOrderItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            gbOrderDetails.ResumeLayout(false);
            gbOrderDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbCustomer;
        private Button btnNewCustomer;
        private ComboBox cmbCustomers;
        private Label lblCustomer;
        private Label lblCustomerDetails;
        private GroupBox gbBookSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private DataGridView dgvBooks;
        private NumericUpDown nudQuantity;
        private Button btnAddToOrder;
        private GroupBox gbOrderItems;
        private DataGridView dgvCart;
        private Button btnRemoveItem;
        private GroupBox gbOrderDetails;
        private Label lblSubtotal;
        private TextBox txtSubtotal;
        private TextBox txtTax;
        private Label lblTax;
        private TextBox txtTotal;
        private Label lblTotal;
        private Button btnCreateOrder;
        private DateTimePicker dtpDeliveryDate;
        private Label lblDeliveryDate;
        private Label lblStatus;
        private ComboBox cmbOrderStatus;
    }
}