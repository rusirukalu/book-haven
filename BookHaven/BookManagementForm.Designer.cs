namespace BookHaven
{
    partial class BookManagementForm
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
            dataGridViewBooks = new DataGridView();
            panelSearch = new Panel();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            groupBoxBookDetails = new GroupBox();
            txtStock = new TextBox();
            lblStock = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            txtGenre = new TextBox();
            lblGenre = new Label();
            txtISBN = new TextBox();
            lblISBN = new Label();
            txtAuthor = new TextBox();
            lblAuthor = new Label();
            txtTitle = new TextBox();
            lblTitle = new Label();
            panelButtons = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            panelSearch.SuspendLayout();
            groupBoxBookDetails.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.AllowUserToAddRows = false;
            dataGridViewBooks.AllowUserToDeleteRows = false;
            dataGridViewBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(41, 120);
            dataGridViewBooks.MultiSelect = false;
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.ReadOnly = true;
            dataGridViewBooks.RowHeadersVisible = false;
            dataGridViewBooks.RowHeadersWidth = 82;
            dataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBooks.Size = new Size(703, 509);
            dataGridViewBooks.TabIndex = 0;
            dataGridViewBooks.CellContentClick += dataGridViewBooks_CellClick;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(btnRefresh);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(10, 10);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(10);
            panelSearch.Size = new Size(1370, 76);
            panelSearch.TabIndex = 1;
            panelSearch.Paint += panelSearch_Paint;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(856, 18);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(150, 46);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(665, 18);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 46);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(195, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter title, author or ISBN";
            txtSearch.Size = new Size(402, 39);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(13, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(161, 32);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search Books:";
            // 
            // groupBoxBookDetails
            // 
            groupBoxBookDetails.Controls.Add(txtStock);
            groupBoxBookDetails.Controls.Add(lblStock);
            groupBoxBookDetails.Controls.Add(txtPrice);
            groupBoxBookDetails.Controls.Add(lblPrice);
            groupBoxBookDetails.Controls.Add(txtGenre);
            groupBoxBookDetails.Controls.Add(lblGenre);
            groupBoxBookDetails.Controls.Add(txtISBN);
            groupBoxBookDetails.Controls.Add(lblISBN);
            groupBoxBookDetails.Controls.Add(txtAuthor);
            groupBoxBookDetails.Controls.Add(lblAuthor);
            groupBoxBookDetails.Controls.Add(txtTitle);
            groupBoxBookDetails.Controls.Add(lblTitle);
            groupBoxBookDetails.Location = new Point(804, 120);
            groupBoxBookDetails.Name = "groupBoxBookDetails";
            groupBoxBookDetails.Padding = new Padding(10);
            groupBoxBookDetails.Size = new Size(529, 509);
            groupBoxBookDetails.TabIndex = 2;
            groupBoxBookDetails.TabStop = false;
            groupBoxBookDetails.Text = "Book Details";
            groupBoxBookDetails.Enter += groupBoxBookDetails_Enter;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(226, 399);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(280, 39);
            txtStock.TabIndex = 11;
            txtStock.TextChanged += txtStock_TextChanged;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(33, 399);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(175, 32);
            lblStock.TabIndex = 10;
            lblStock.Text = "Stock Quantity:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(158, 338);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(348, 39);
            txtPrice.TabIndex = 9;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(33, 338);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(70, 32);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "Price:";
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(158, 273);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(348, 39);
            txtGenre.TabIndex = 7;
            txtGenre.TextChanged += txtGenre_TextChanged;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(33, 273);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(83, 32);
            lblGenre.TabIndex = 6;
            lblGenre.Text = "Genre:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(158, 204);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(348, 39);
            txtISBN.TabIndex = 5;
            txtISBN.TextChanged += txtISBN_TextChanged;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.Location = new Point(33, 207);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(70, 32);
            lblISBN.TabIndex = 4;
            lblISBN.Text = "ISBN:";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(158, 129);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(348, 39);
            txtAuthor.TabIndex = 3;
            txtAuthor.TextChanged += txtAuthor_TextChanged;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(33, 136);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(92, 32);
            lblAuthor.TabIndex = 2;
            lblAuthor.Text = "Author:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(158, 64);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(348, 39);
            txtTitle.TabIndex = 1;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(33, 71);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(65, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title:";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnClear);
            panelButtons.Controls.Add(btnDelete);
            panelButtons.Controls.Add(btnUpdate);
            panelButtons.Controls.Add(btnAdd);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(10, 771);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1370, 121);
            panelButtons.TabIndex = 3;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(952, 36);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(177, 46);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(665, 36);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(177, 46);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Book";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(395, 36);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(177, 46);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Update Book";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(93, 36);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(152, 46);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add Book";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // BookManagementForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 902);
            Controls.Add(panelButtons);
            Controls.Add(groupBoxBookDetails);
            Controls.Add(panelSearch);
            Controls.Add(dataGridViewBooks);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "BookManagementForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Management";
            Load += BookManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            groupBoxBookDetails.ResumeLayout(false);
            groupBoxBookDetails.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewBooks;
        private Panel panelSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnRefresh;
        private Button btnSearch;
        private GroupBox groupBoxBookDetails;
        private Label lblTitle;
        private Label lblISBN;
        private TextBox txtAuthor;
        private Label lblAuthor;
        private TextBox txtTitle;
        private Label lblPrice;
        private TextBox txtGenre;
        private Label lblGenre;
        private TextBox txtISBN;
        private TextBox txtStock;
        private Label lblStock;
        private TextBox txtPrice;
        private Panel panelButtons;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnClear;
        private Button btnDelete;
    }
}