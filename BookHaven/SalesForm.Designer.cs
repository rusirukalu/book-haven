namespace BookHaven
{
    partial class SalesForm
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
            groupBoxBookSelection = new GroupBox();
            btnAddToCart = new Button();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            dataGridViewBooks = new DataGridView();
            btnSearchBooks = new Button();
            lblSearchBooks = new Label();
            txtBookSearch = new TextBox();
            groupBoxCustomer = new GroupBox();
            btnAddCustomer = new Button();
            lblSelectCustomer = new Label();
            comboBoxCustomers = new ComboBox();
            groupBoxCart = new GroupBox();
            btnCancelSale = new Button();
            btnProcessSale = new Button();
            lblTotalAmount = new Label();
            lblTotalA = new Label();
            btnRemoveItem = new Button();
            dataGridViewCart = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBoxBookSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            groupBoxCustomer.SuspendLayout();
            groupBoxCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(groupBoxBookSelection);
            splitContainer1.Panel1.Controls.Add(groupBoxCustomer);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBoxCart);
            splitContainer1.Size = new Size(1327, 954);
            splitContainer1.SplitterDistance = 617;
            splitContainer1.TabIndex = 0;
            // 
            // groupBoxBookSelection
            // 
            groupBoxBookSelection.Controls.Add(btnAddToCart);
            groupBoxBookSelection.Controls.Add(lblQuantity);
            groupBoxBookSelection.Controls.Add(numQuantity);
            groupBoxBookSelection.Controls.Add(dataGridViewBooks);
            groupBoxBookSelection.Controls.Add(btnSearchBooks);
            groupBoxBookSelection.Controls.Add(lblSearchBooks);
            groupBoxBookSelection.Controls.Add(txtBookSearch);
            groupBoxBookSelection.Location = new Point(503, 12);
            groupBoxBookSelection.Name = "groupBoxBookSelection";
            groupBoxBookSelection.Size = new Size(727, 585);
            groupBoxBookSelection.TabIndex = 1;
            groupBoxBookSelection.TabStop = false;
            groupBoxBookSelection.Text = "Book Selection";
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(404, 151);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(150, 46);
            btnAddToCart.TabIndex = 6;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click_1;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(406, 38);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(111, 32);
            lblQuantity.TabIndex = 5;
            lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(404, 93);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(240, 39);
            numQuantity.TabIndex = 4;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(26, 253);
            dataGridViewBooks.MultiSelect = false;
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.ReadOnly = true;
            dataGridViewBooks.RowHeadersWidth = 82;
            dataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBooks.Size = new Size(670, 300);
            dataGridViewBooks.TabIndex = 3;
            // 
            // btnSearchBooks
            // 
            btnSearchBooks.Location = new Point(26, 174);
            btnSearchBooks.Name = "btnSearchBooks";
            btnSearchBooks.Size = new Size(187, 46);
            btnSearchBooks.TabIndex = 2;
            btnSearchBooks.Text = "Search";
            btnSearchBooks.UseVisualStyleBackColor = true;
            btnSearchBooks.Click += btnSearchBooks_Click;
            // 
            // lblSearchBooks
            // 
            lblSearchBooks.AutoSize = true;
            lblSearchBooks.Location = new Point(26, 65);
            lblSearchBooks.Name = "lblSearchBooks";
            lblSearchBooks.Size = new Size(161, 32);
            lblSearchBooks.TabIndex = 1;
            lblSearchBooks.Text = "Search Books:";
            // 
            // txtBookSearch
            // 
            txtBookSearch.Location = new Point(26, 117);
            txtBookSearch.Name = "txtBookSearch";
            txtBookSearch.Size = new Size(286, 39);
            txtBookSearch.TabIndex = 0;
            txtBookSearch.TextChanged += txtBookSearch_TextChanged;
            // 
            // groupBoxCustomer
            // 
            groupBoxCustomer.Controls.Add(btnAddCustomer);
            groupBoxCustomer.Controls.Add(lblSelectCustomer);
            groupBoxCustomer.Controls.Add(comboBoxCustomers);
            groupBoxCustomer.Location = new Point(12, 12);
            groupBoxCustomer.Name = "groupBoxCustomer";
            groupBoxCustomer.Padding = new Padding(10);
            groupBoxCustomer.Size = new Size(464, 299);
            groupBoxCustomer.TabIndex = 0;
            groupBoxCustomer.TabStop = false;
            groupBoxCustomer.Text = "Customer Information";
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(31, 174);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(232, 46);
            btnAddCustomer.TabIndex = 2;
            btnAddCustomer.Text = "Add New Customer";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click_1;
            // 
            // lblSelectCustomer
            // 
            lblSelectCustomer.AutoSize = true;
            lblSelectCustomer.Location = new Point(31, 65);
            lblSelectCustomer.Name = "lblSelectCustomer";
            lblSelectCustomer.Size = new Size(193, 32);
            lblSelectCustomer.TabIndex = 1;
            lblSelectCustomer.Text = "Select Customer:";
            // 
            // comboBoxCustomers
            // 
            comboBoxCustomers.FormattingEnabled = true;
            comboBoxCustomers.Location = new Point(31, 117);
            comboBoxCustomers.Name = "comboBoxCustomers";
            comboBoxCustomers.Size = new Size(378, 40);
            comboBoxCustomers.TabIndex = 0;
            // 
            // groupBoxCart
            // 
            groupBoxCart.Controls.Add(btnCancelSale);
            groupBoxCart.Controls.Add(btnProcessSale);
            groupBoxCart.Controls.Add(lblTotalAmount);
            groupBoxCart.Controls.Add(lblTotalA);
            groupBoxCart.Controls.Add(btnRemoveItem);
            groupBoxCart.Controls.Add(dataGridViewCart);
            groupBoxCart.Location = new Point(22, 20);
            groupBoxCart.Name = "groupBoxCart";
            groupBoxCart.Size = new Size(1177, 301);
            groupBoxCart.TabIndex = 0;
            groupBoxCart.TabStop = false;
            groupBoxCart.Text = "Shopping Cart";
            groupBoxCart.Enter += groupBoxCart_Enter;
            // 
            // btnCancelSale
            // 
            btnCancelSale.BackColor = Color.FromArgb(255, 128, 128);
            btnCancelSale.Location = new Point(815, 201);
            btnCancelSale.Name = "btnCancelSale";
            btnCancelSale.Size = new Size(150, 46);
            btnCancelSale.TabIndex = 5;
            btnCancelSale.Text = "Cancel Sale";
            btnCancelSale.UseVisualStyleBackColor = false;
            btnCancelSale.Click += btnCancelSale_Click_1;
            // 
            // btnProcessSale
            // 
            btnProcessSale.BackColor = Color.Lime;
            btnProcessSale.Location = new Point(576, 197);
            btnProcessSale.Name = "btnProcessSale";
            btnProcessSale.Size = new Size(181, 46);
            btnProcessSale.TabIndex = 4;
            btnProcessSale.Text = "Process Sale";
            btnProcessSale.UseVisualStyleBackColor = false;
            btnProcessSale.Click += btnProcessSale_Click_1;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalAmount.Location = new Point(742, 59);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(77, 32);
            lblTotalAmount.TabIndex = 3;
            lblTotalAmount.Text = "$0.00";
            // 
            // lblTotalA
            // 
            lblTotalA.AutoSize = true;
            lblTotalA.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalA.Location = new Point(547, 58);
            lblTotalA.Name = "lblTotalA";
            lblTotalA.Size = new Size(177, 32);
            lblTotalA.TabIndex = 2;
            lblTotalA.Text = "Total Amount:";
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.Location = new Point(540, 114);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(273, 46);
            btnRemoveItem.TabIndex = 1;
            btnRemoveItem.Text = "Remove Selected Item";
            btnRemoveItem.UseVisualStyleBackColor = true;
            btnRemoveItem.Click += btnRemoveItem_Click_1;
            // 
            // dataGridViewCart
            // 
            dataGridViewCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCart.Location = new Point(21, 52);
            dataGridViewCart.Name = "dataGridViewCart";
            dataGridViewCart.ReadOnly = true;
            dataGridViewCart.RowHeadersWidth = 82;
            dataGridViewCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCart.Size = new Size(480, 231);
            dataGridViewCart.TabIndex = 0;
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1327, 954);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SalesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Sale";
            Load += SalesForm_Load_1;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBoxBookSelection.ResumeLayout(false);
            groupBoxBookSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            groupBoxCustomer.ResumeLayout(false);
            groupBoxCustomer.PerformLayout();
            groupBoxCart.ResumeLayout(false);
            groupBoxCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBoxCustomer;
        private Button btnAddCustomer;
        private Label lblSelectCustomer;
        private ComboBox comboBoxCustomers;
        private GroupBox groupBoxBookSelection;
        private Button btnSearchBooks;
        private Label lblSearchBooks;
        private TextBox txtBookSearch;
        private Button btnAddToCart;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private DataGridView dataGridViewBooks;
        private GroupBox groupBoxCart;
        private DataGridView dataGridViewCart;
        private Label lblTotalA;
        private Button btnRemoveItem;
        private Label lblTotalAmount;
        private Button btnCancelSale;
        private Button btnProcessSale;
    }
}