namespace BookHaven
{
    partial class CustomerManagementForm
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
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            label1 = new Label();
            dataGridViewCustomers = new DataGridView();
            groupBoxCustomerDetails = new GroupBox();
            txtAddress = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            lblAddress = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            lblLastName = new Label();
            lblFirstName = new Label();
            panel1 = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
            groupBoxCustomerDetails.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(btnRefresh);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(label1);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 0);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1357, 83);
            panelSearch.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(956, 16);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 46);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(760, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(317, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(380, 39);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 20);
            label1.Name = "label1";
            label1.Size = new Size(210, 32);
            label1.TabIndex = 0;
            label1.Text = "Search Customers:";
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCustomers.AllowUserToAddRows = false;
            dataGridViewCustomers.AllowUserToDeleteRows = false;
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Location = new Point(68, 107);
            dataGridViewCustomers.MultiSelect = false;
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCustomers.ReadOnly = true;
            dataGridViewCustomers.RowHeadersWidth = 82;
            dataGridViewCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCustomers.Size = new Size(892, 300);
            dataGridViewCustomers.TabIndex = 1;
            dataGridViewCustomers.CellContentClick += dataGridViewCustomers_CellClick;
            // 
            // groupBoxCustomerDetails
            // 
            groupBoxCustomerDetails.Controls.Add(txtAddress);
            groupBoxCustomerDetails.Controls.Add(txtEmail);
            groupBoxCustomerDetails.Controls.Add(txtPhone);
            groupBoxCustomerDetails.Controls.Add(txtLastName);
            groupBoxCustomerDetails.Controls.Add(txtFirstName);
            groupBoxCustomerDetails.Controls.Add(lblAddress);
            groupBoxCustomerDetails.Controls.Add(lblPhone);
            groupBoxCustomerDetails.Controls.Add(lblEmail);
            groupBoxCustomerDetails.Controls.Add(lblLastName);
            groupBoxCustomerDetails.Controls.Add(lblFirstName);
            groupBoxCustomerDetails.Location = new Point(68, 453);
            groupBoxCustomerDetails.Name = "groupBoxCustomerDetails";
            groupBoxCustomerDetails.Size = new Size(892, 386);
            groupBoxCustomerDetails.TabIndex = 2;
            groupBoxCustomerDetails.TabStop = false;
            groupBoxCustomerDetails.Text = "Customer Details";
            // 
            // txtAddress
            // 
            txtAddress.AcceptsReturn = true;
            txtAddress.Location = new Point(184, 291);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(478, 39);
            txtAddress.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(184, 176);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(478, 39);
            txtEmail.TabIndex = 8;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(184, 236);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(478, 39);
            txtPhone.TabIndex = 7;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(184, 117);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(478, 39);
            txtLastName.TabIndex = 6;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(184, 60);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(478, 39);
            txtFirstName.TabIndex = 5;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(25, 298);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(103, 32);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Address:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(25, 243);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(87, 32);
            lblPhone.TabIndex = 3;
            lblPhone.Text = "Phone:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(25, 183);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(76, 32);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(25, 124);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(131, 32);
            lblLastName.TabIndex = 1;
            lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(25, 67);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(134, 32);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name:";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 911);
            panel1.Name = "panel1";
            panel1.Size = new Size(1357, 83);
            panel1.TabIndex = 3;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(857, 16);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(203, 46);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(622, 16);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(203, 46);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Customer";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(374, 16);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(222, 46);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update Customer";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(145, 16);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(203, 46);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Customer";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // CustomerManagementForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1357, 994);
            Controls.Add(panel1);
            Controls.Add(groupBoxCustomerDetails);
            Controls.Add(dataGridViewCustomers);
            Controls.Add(panelSearch);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CustomerManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Management";
            Load += CustomerManagementForm_Load;
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            groupBoxCustomerDetails.ResumeLayout(false);
            groupBoxCustomerDetails.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSearch;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label label1;
        private Button btnRefresh;
        private DataGridView dataGridViewCustomers;
        private GroupBox groupBoxCustomerDetails;
        private Label lblFirstName;
        private Label lblAddress;
        private Label lblPhone;
        private Label lblEmail;
        private Label lblLastName;
        private TextBox txtAddress;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Panel panel1;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
    }
}