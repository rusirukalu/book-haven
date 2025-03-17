namespace BookHaven
{
    partial class SupplierManagementForm
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
            panelSearch = new Panel();
            chkShowInactive = new CheckBox();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearchSuppliers = new Label();
            dataGridViewSuppliers = new DataGridView();
            groupBoxSupplierDetails = new GroupBox();
            chkIsActive = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtContactPerson = new TextBox();
            txtName = new TextBox();
            panelButtons = new Panel();
            btnStockOrder = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).BeginInit();
            groupBoxSupplierDetails.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(chkShowInactive);
            panelSearch.Controls.Add(btnRefresh);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearchSuppliers);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1437, 80);
            panelSearch.TabIndex = 0;
            // 
            // chkShowInactive
            // 
            chkShowInactive.AutoSize = true;
            chkShowInactive.Location = new Point(903, 27);
            chkShowInactive.Name = "chkShowInactive";
            chkShowInactive.Size = new Size(298, 36);
            chkShowInactive.TabIndex = 4;
            chkShowInactive.Text = "Show Inactive Suppliers";
            chkShowInactive.UseVisualStyleBackColor = true;
            chkShowInactive.CheckedChanged += chkShowInactive_CheckedChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(712, 17);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 46);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(521, 17);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(257, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 39);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearchSuppliers
            // 
            lblSearchSuppliers.AutoSize = true;
            lblSearchSuppliers.Location = new Point(30, 20);
            lblSearchSuppliers.Name = "lblSearchSuppliers";
            lblSearchSuppliers.Size = new Size(195, 32);
            lblSearchSuppliers.TabIndex = 0;
            lblSearchSuppliers.Text = "Search Suppliers:";
            // 
            // dataGridViewSuppliers
            // 
            dataGridViewSuppliers.AllowUserToAddRows = false;
            dataGridViewSuppliers.AllowUserToDeleteRows = false;
            dataGridViewSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSuppliers.Location = new Point(732, 118);
            dataGridViewSuppliers.MultiSelect = false;
            dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            dataGridViewSuppliers.ReadOnly = true;
            dataGridViewSuppliers.RowHeadersWidth = 82;
            dataGridViewSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSuppliers.Size = new Size(663, 509);
            dataGridViewSuppliers.TabIndex = 1;
            dataGridViewSuppliers.SelectionChanged += dataGridViewSuppliers_SelectionChanged;
            // 
            // groupBoxSupplierDetails
            // 
            groupBoxSupplierDetails.Controls.Add(chkIsActive);
            groupBoxSupplierDetails.Controls.Add(label5);
            groupBoxSupplierDetails.Controls.Add(label4);
            groupBoxSupplierDetails.Controls.Add(label3);
            groupBoxSupplierDetails.Controls.Add(label2);
            groupBoxSupplierDetails.Controls.Add(label1);
            groupBoxSupplierDetails.Controls.Add(txtAddress);
            groupBoxSupplierDetails.Controls.Add(txtPhone);
            groupBoxSupplierDetails.Controls.Add(txtEmail);
            groupBoxSupplierDetails.Controls.Add(txtContactPerson);
            groupBoxSupplierDetails.Controls.Add(txtName);
            groupBoxSupplierDetails.Location = new Point(30, 106);
            groupBoxSupplierDetails.Name = "groupBoxSupplierDetails";
            groupBoxSupplierDetails.Size = new Size(657, 521);
            groupBoxSupplierDetails.TabIndex = 2;
            groupBoxSupplierDetails.TabStop = false;
            groupBoxSupplierDetails.Text = "Supplier Details";
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(312, 459);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(206, 36);
            chkIsActive.TabIndex = 10;
            chkIsActive.Text = "Active Supplier";
            chkIsActive.UseVisualStyleBackColor = true;
            chkIsActive.CheckedChanged += chkIsActive_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 403);
            label5.Name = "label5";
            label5.Size = new Size(103, 32);
            label5.TabIndex = 9;
            label5.Text = "Address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 316);
            label4.Name = "label4";
            label4.Size = new Size(87, 32);
            label4.TabIndex = 8;
            label4.Text = "Phone:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 230);
            label3.Name = "label3";
            label3.Size = new Size(76, 32);
            label3.TabIndex = 7;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 151);
            label2.Name = "label2";
            label2.Size = new Size(179, 32);
            label2.TabIndex = 6;
            label2.Text = "Contact Person:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 71);
            label1.Name = "label1";
            label1.Size = new Size(83, 32);
            label1.TabIndex = 5;
            label1.Text = "Name:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(246, 396);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(373, 39);
            txtAddress.TabIndex = 4;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(246, 313);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(373, 39);
            txtPhone.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(246, 223);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(373, 39);
            txtEmail.TabIndex = 2;
            // 
            // txtContactPerson
            // 
            txtContactPerson.Location = new Point(246, 144);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(373, 39);
            txtContactPerson.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(246, 64);
            txtName.Name = "txtName";
            txtName.Size = new Size(373, 39);
            txtName.TabIndex = 0;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnStockOrder);
            panelButtons.Controls.Add(btnClear);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnUpdate);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 668);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1437, 87);
            panelButtons.TabIndex = 3;
            // 
            // btnStockOrder
            // 
            btnStockOrder.Location = new Point(983, 20);
            btnStockOrder.Name = "btnStockOrder";
            btnStockOrder.Size = new Size(245, 46);
            btnStockOrder.TabIndex = 4;
            btnStockOrder.Text = "Create Stock Order";
            btnStockOrder.UseVisualStyleBackColor = true;
            btnStockOrder.Click += btnStockOrder_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(808, 20);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 46);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(571, 20);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(218, 46);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Supplier";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(352, 20);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(204, 46);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update Supplier";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(147, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(174, 46);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Supplier";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // SupplierManagementForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1437, 755);
            Controls.Add(panelButtons);
            Controls.Add(groupBoxSupplierDetails);
            Controls.Add(dataGridViewSuppliers);
            Controls.Add(panelSearch);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SupplierManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Supplier Management";
            Load += SupplierManagementForm_Load;
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSuppliers).EndInit();
            groupBoxSupplierDetails.ResumeLayout(false);
            groupBoxSupplierDetails.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearch;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearchSuppliers;
        private CheckBox chkShowInactive;
        private Button btnRefresh;
        private DataGridView dataGridViewSuppliers;
        private GroupBox groupBoxSupplierDetails;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtContactPerson;
        private TextBox txtName;
        private CheckBox chkIsActive;
        private Panel panelButtons;
        private Button btnStockOrder;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
    }
}