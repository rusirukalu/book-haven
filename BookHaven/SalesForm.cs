using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.Controllers;
using BookHaven.Models;

namespace BookHaven
{
    public partial class SalesForm : Form
    {
        private BookManager bookManager;
        private CustomerManager customerManager;
        private SaleManager saleManager;
        private List<Book> books;
        private List<Customer> customers;
        private List<SaleItem> cartItems;
        private decimal totalAmount = 0;

        public SalesForm()
        {
            InitializeComponent();
            bookManager = new BookManager();
            customerManager = new CustomerManager();
            saleManager = new SaleManager();
            cartItems = new List<SaleItem>();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadCustomers();
            SetupCartDataGridView();
        }

        private void LoadBooks()
        {
            try
            {
                books = bookManager.GetAllBooks();
                dataGridViewBooks.DataSource = books;

                // Format the DataGridView columns
                FormatBooksDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatBooksDataGridView()
        {
            dataGridViewBooks.Columns["BookID"].HeaderText = "ID";
            dataGridViewBooks.Columns["Title"].HeaderText = "Title";
            dataGridViewBooks.Columns["Author"].HeaderText = "Author";
            dataGridViewBooks.Columns["ISBN"].HeaderText = "ISBN";
            dataGridViewBooks.Columns["Genre"].HeaderText = "Genre";
            dataGridViewBooks.Columns["Price"].HeaderText = "Price";
            dataGridViewBooks.Columns["StockQuantity"].HeaderText = "Available";

            dataGridViewBooks.Columns["BookID"].Width = 50;
            dataGridViewBooks.Columns["Title"].Width = 200;
            dataGridViewBooks.Columns["Author"].Width = 150;
            dataGridViewBooks.Columns["ISBN"].Width = 100;
            dataGridViewBooks.Columns["Genre"].Width = 100;
            dataGridViewBooks.Columns["Price"].Width = 80;
            dataGridViewBooks.Columns["StockQuantity"].Width = 80;
        }

        private void LoadCustomers()
        {
            try
            {
                customers = customerManager.GetAllCustomers();

                // Configure the ComboBox
                comboBoxCustomers.DataSource = customers;
                comboBoxCustomers.DisplayMember = "LastName"; // You might want to customize this
                comboBoxCustomers.ValueMember = "CustomerID";

                // Add a custom format to display both first and last name
                comboBoxCustomers.Format += (s, e) =>
                {
                    if (e.ListItem is Customer customer)
                    {
                        e.Value = $"{customer.FirstName} {customer.LastName}";
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupCartDataGridView()
        {
            // Create columns for the cart DataGridView
            dataGridViewCart.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn bookIdColumn = new DataGridViewTextBoxColumn();
            bookIdColumn.DataPropertyName = "BookID";
            bookIdColumn.HeaderText = "Book ID";
            bookIdColumn.Width = 70;
            dataGridViewCart.Columns.Add(bookIdColumn);

            DataGridViewTextBoxColumn titleColumn = new DataGridViewTextBoxColumn();
            titleColumn.DataPropertyName = "BookTitle";
            titleColumn.HeaderText = "Title";
            titleColumn.Width = 200;
            dataGridViewCart.Columns.Add(titleColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "Price";
            priceColumn.HeaderText = "Price";
            priceColumn.Width = 80;
            priceColumn.DefaultCellStyle.Format = "C2";
            dataGridViewCart.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.DataPropertyName = "Quantity";
            quantityColumn.HeaderText = "Quantity";
            quantityColumn.Width = 80;
            dataGridViewCart.Columns.Add(quantityColumn);

            DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn();
            subtotalColumn.DataPropertyName = "Subtotal";
            subtotalColumn.HeaderText = "Subtotal";
            subtotalColumn.Width = 100;
            subtotalColumn.DefaultCellStyle.Format = "C2";
            dataGridViewCart.Columns.Add(subtotalColumn);
        }

        private void btnSearchBooks_Click(object sender, EventArgs e)
        {
            string searchTerm = txtBookSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadBooks();
                return;
            }

            try
            {
                List<Book> searchResults = books.FindAll(b =>
                    b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

                dataGridViewBooks.DataSource = null;
                dataGridViewBooks.DataSource = searchResults;

                FormatBooksDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching books: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to add to cart", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = dataGridViewBooks.SelectedRows[0].Index;
            Book selectedBook = books[selectedIndex];

            int quantity = (int)numQuantity.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedBook.StockQuantity < quantity)
            {
                MessageBox.Show("Not enough stock available", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if book is already in cart
            SaleItem existingItem = cartItems.Find(item => item.BookID == selectedBook.BookID);

            if (existingItem != null)
            {
                // Update quantity if book is already in cart
                existingItem.Quantity += quantity;
            }
            else
            {
                // Add new item to cart
                SaleItem newItem = new SaleItem
                {
                    BookID = selectedBook.BookID,
                    BookTitle = selectedBook.Title,
                    Price = selectedBook.Price,
                    Quantity = quantity
                };

                cartItems.Add(newItem);
            }

            // Update the cart display
            UpdateCartDisplay();
        }

        private void UpdateCartDisplay()
        {
            dataGridViewCart.DataSource = null;
            dataGridViewCart.DataSource = cartItems;

            // Calculate and display total
            totalAmount = cartItems.Sum(item => item.Subtotal);
            lblTotalAmount.Text = totalAmount.ToString("C2");
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = dataGridViewCart.SelectedRows[0].Index;

            if (selectedIndex >= 0 && selectedIndex < cartItems.Count)
            {
                cartItems.RemoveAt(selectedIndex);
                UpdateCartDisplay();
            }
        }

        private void btnProcessSale_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty. Please add items to process a sale.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Customer selectedCustomer = (Customer)comboBoxCustomers.SelectedItem;

                Sale sale = new Sale
                {
                    CustomerID = selectedCustomer.CustomerID,
                    CustomerName = $"{selectedCustomer.FirstName} {selectedCustomer.LastName}",
                    SaleDate = DateTime.Now,
                    TotalAmount = totalAmount,
                    SaleItems = cartItems
                };

                int saleId = saleManager.CreateSale(sale);

                MessageBox.Show($"Sale processed successfully! Sale ID: {saleId}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the cart and refresh the book list
                cartItems.Clear();
                UpdateCartDisplay();
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing sale: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelSale_Click(object sender, EventArgs e)
        {
            if (cartItems.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to cancel this sale?",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    cartItems.Clear();
                    UpdateCartDisplay();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerManagementForm customerForm = new CustomerManagementForm();
            customerForm.ShowDialog();

            // Refresh the customer list after adding a new customer
            LoadCustomers();
        }

        private void groupBoxCart_Enter(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void SalesForm_Load_1(object sender, EventArgs e)
        {
            LoadBooks();
            LoadCustomers();
            SetupCartDataGridView();
        }

        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to add to cart", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = dataGridViewBooks.SelectedRows[0].Index;
            Book selectedBook = books[selectedIndex];

            int quantity = (int)numQuantity.Value;

            if (quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedBook.StockQuantity < quantity)
            {
                MessageBox.Show("Not enough stock available", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if book is already in cart
            SaleItem existingItem = cartItems.Find(item => item.BookID == selectedBook.BookID);

            if (existingItem != null)
            {
                // Update quantity if book is already in cart
                existingItem.Quantity += quantity;
            }
            else
            {
                // Add new item to cart
                SaleItem newItem = new SaleItem
                {
                    BookID = selectedBook.BookID,
                    BookTitle = selectedBook.Title,
                    Price = selectedBook.Price,
                    Quantity = quantity
                };

                cartItems.Add(newItem);
            }

            // Update the cart display
            UpdateCartDisplay();

        }

        private void btnRemoveItem_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = dataGridViewCart.SelectedRows[0].Index;

            if (selectedIndex >= 0 && selectedIndex < cartItems.Count)
            {
                cartItems.RemoveAt(selectedIndex);
                UpdateCartDisplay();
            }

        }

        private void btnProcessSale_Click_1(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty. Please add items to process a sale.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Customer selectedCustomer = (Customer)comboBoxCustomers.SelectedItem;

                Sale sale = new Sale
                {
                    CustomerID = selectedCustomer.CustomerID,
                    CustomerName = $"{selectedCustomer.FirstName} {selectedCustomer.LastName}",
                    SaleDate = DateTime.Now,
                    TotalAmount = totalAmount,
                    SaleItems = cartItems
                };

                int saleId = saleManager.CreateSale(sale);

                MessageBox.Show($"Sale processed successfully! Sale ID: {saleId}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the cart and refresh the book list
                cartItems.Clear();
                UpdateCartDisplay();
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing sale: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelSale_Click_1(object sender, EventArgs e)
        {
            if (cartItems.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to cancel this sale?",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    cartItems.Clear();
                    UpdateCartDisplay();
                }
            }
            else
            {
                this.Close();
            }

        }

        private void btnAddCustomer_Click_1(object sender, EventArgs e)
        {
            CustomerManagementForm customerForm = new CustomerManagementForm();
            customerForm.ShowDialog();

            // Refresh the customer list after adding a new customer
            LoadCustomers();

        }

        private void txtBookSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtBookSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadBooks();
                return;
            }

            try
            {
                List<Book> searchResults = books.FindAll(b =>
                    b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

                dataGridViewBooks.DataSource = null;
                dataGridViewBooks.DataSource = searchResults;

                FormatBooksDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching books: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
