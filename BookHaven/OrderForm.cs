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
    public partial class OrderForm : Form
    {
        private CustomerManager customerManager;
        private BookManager bookManager;
        private OrderManager orderManager;
        private List<Customer> customers;
        private List<Book> books;
        private List<OrderItem> cartItems;
        private Customer selectedCustomer;
        private decimal subtotal = 0;
        private decimal taxRate = 0.10m; // 10% tax rate
        private decimal totalAmount = 0;

        public OrderForm()
        {
            InitializeComponent();
            customerManager = new CustomerManager();
            bookManager = new BookManager();
            orderManager = new OrderManager();
            cartItems = new List<OrderItem>();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // Load customers for dropdown
            LoadCustomers();

            // Load books for DataGridView
            LoadBooks();

            // Initialize cart DataGridView
            SetupCartDataGridView();

            // Set default status to Pending
            cmbOrderStatus.SelectedIndex = 0;

            // Set delivery date to tomorrow by default
            dtpDeliveryDate.Value = DateTime.Now.AddDays(1);
        }

        private void LoadCustomers()
        {
            try
            {
                customers = customerManager.GetAllCustomers();
                cmbCustomers.DataSource = null;
                cmbCustomers.DisplayMember = "FullName";
                cmbCustomers.ValueMember = "CustomerID";
                cmbCustomers.DataSource = customers;

                if (customers.Count > 0)
                {
                    cmbCustomers.SelectedIndex = -1; // No selection by default
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                books = bookManager.GetAllBooks();
                dgvBooks.DataSource = null;
                dgvBooks.DataSource = books;
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
            if (dgvBooks.Columns.Count > 0)
            {
                // Configure which columns to display
                dgvBooks.Columns["BookID"].HeaderText = "ID";
                dgvBooks.Columns["BookID"].Width = 50;
                dgvBooks.Columns["Title"].Width = 200;
                dgvBooks.Columns["Author"].Width = 150;
                dgvBooks.Columns["ISBN"].Width = 100;
                dgvBooks.Columns["Genre"].Width = 100;
                dgvBooks.Columns["Price"].Width = 80;
                dgvBooks.Columns["Price"].DefaultCellStyle.Format = "C2";
                dgvBooks.Columns["StockQuantity"].HeaderText = "Stock";
                dgvBooks.Columns["StockQuantity"].Width = 80;

                // Hide unnecessary columns
                if (dgvBooks.Columns.Contains("Publisher"))
                {
                    dgvBooks.Columns["Publisher"].Visible = false;
                }
                if (dgvBooks.Columns.Contains("PublicationDate"))
                {
                    dgvBooks.Columns["PublicationDate"].Visible = false;
                }
            }
        }

        private void SetupCartDataGridView()
        {
            // Create columns for the cart DataGridView
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

            DataGridViewTextBoxColumn bookIDColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookID",
                HeaderText = "Book ID",
                Width = 60
            };

            DataGridViewTextBoxColumn titleColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookTitle",
                HeaderText = "Title",
                Width = 200
            };

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Price",
                Width = 80,
                DefaultCellStyle = { Format = "C2" }
            };

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Quantity",
                Width = 70
            };

            DataGridViewTextBoxColumn subtotalColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Subtotal",
                HeaderText = "Subtotal",
                Width = 90,
                DefaultCellStyle = { Format = "C2" }
            };

            dgvCart.Columns.Add(bookIDColumn);
            dgvCart.Columns.Add(titleColumn);
            dgvCart.Columns.Add(priceColumn);
            dgvCart.Columns.Add(quantityColumn);
            dgvCart.Columns.Add(subtotalColumn);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchTerm))
            {
                dgvBooks.DataSource = books;
            }
            else
            {
                List<Book> filteredBooks = books.FindAll(b =>
                    b.Title.ToLower().Contains(searchTerm) ||
                    b.Author.ToLower().Contains(searchTerm) ||
                    b.ISBN.ToLower().Contains(searchTerm));

                dgvBooks.DataSource = null;
                dgvBooks.DataSource = filteredBooks;
            }
            FormatBooksDataGridView();
        }

        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedIndex >= 0)
            {
                selectedCustomer = (Customer)cmbCustomers.SelectedItem;
                lblCustomerDetails.Text = $"Email: {selectedCustomer.Email}\nPhone: {selectedCustomer.Phone}\nAddress: {selectedCustomer.Address}";
            }
            else
            {
                lblCustomerDetails.Text = "";
                selectedCustomer = null;
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            CustomerManagementForm customerForm = new CustomerManagementForm();
            if (customerForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
                // Try to select the newly added customer (typically the last one)
                if (customers.Count > 0)
                {
                    cmbCustomers.SelectedIndex = customers.Count - 1;
                }
            }
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null)
            {
                MessageBox.Show("Please select a book to add to the order.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Book selectedBook = (Book)dgvBooks.CurrentRow.DataBoundItem;
            int quantity = (int)nudQuantity.Value;

            if (selectedBook.StockQuantity < quantity)
            {
                MessageBox.Show($"Insufficient stock. Only {selectedBook.StockQuantity} copies available.",
                    "Stock Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if book is already in cart
            OrderItem existingItem = cartItems.Find(item => item.BookID == selectedBook.BookID);
            if (existingItem != null)
            {
                // Update existing item
                existingItem.Quantity += quantity;
                // Refresh DataGridView
                dgvCart.DataSource = null;
                dgvCart.DataSource = cartItems;
            }
            else
            {
                // Add new item
                OrderItem item = new OrderItem
                {
                    BookID = selectedBook.BookID,
                    BookTitle = selectedBook.Title,
                    Price = selectedBook.Price,
                    Quantity = quantity
                };

                cartItems.Add(item);
                dgvCart.DataSource = null;
                dgvCart.DataSource = cartItems;
            }

            CalculateTotal();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null)
            {
                MessageBox.Show("Please select an item to remove.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OrderItem selectedItem = (OrderItem)dgvCart.CurrentRow.DataBoundItem;
            cartItems.Remove(selectedItem);

            dgvCart.DataSource = null;
            dgvCart.DataSource = cartItems;

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            subtotal = 0;
            foreach (OrderItem item in cartItems)
            {
                subtotal += item.Subtotal;
            }

            decimal tax = subtotal * taxRate;
            totalAmount = subtotal + tax;

            txtSubtotal.Text = subtotal.ToString("C2");
            txtTax.Text = tax.ToString("C2");
            txtTotal.Text = totalAmount.ToString("C2");
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer.", "Customer Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cartItems.Count == 0)
            {
                MessageBox.Show("Please add at least one book to the order.", "Empty Cart",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Create order object
                Order order = new Order
                {
                    CustomerID = selectedCustomer.CustomerID,
                    CustomerName = $"{selectedCustomer.FirstName} {selectedCustomer.LastName}",
                    OrderDate = DateTime.Now,
                    DeliveryDate = dtpDeliveryDate.Value,
                    Status = cmbOrderStatus.SelectedItem.ToString(),
                    TotalAmount = totalAmount,
                    OrderItems = cartItems,
                    TransactionType = "Order"
                };

                // Save order to database
                int orderId = orderManager.CreateOrder(order);

                if (orderId > 0)
                {
                    MessageBox.Show($"Order #{orderId} created successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the form for a new order
                    cmbCustomers.SelectedIndex = -1;
                    cartItems.Clear();
                    dgvCart.DataSource = null;
                    CalculateTotal();
                    LoadBooks(); // Refresh book list with updated stock
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating order: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This can be used if you want to add additional functionality when clicking on cells
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This can be used if you want to add additional functionality when clicking on cells
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            // This can be used if you want to add additional functionality when quantity changes
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            // This can be used if you want to add additional functionality when subtotal changes
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            // This can be used if you want to add additional functionality when tax changes
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            // This can be used if you want to add additional functionality when total changes
        }

        private void dtpDeliveryDate_ValueChanged(object sender, EventArgs e)
        {
            // This can be used if you want to add additional functionality when delivery date changes
        }

        private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This can be used if you want to add additional functionality when status changes
        }

        private void lblCustomerDetails_Click(object sender, EventArgs e)
        {
            // This can be used if you want to add additional functionality when clicking on customer details
        }

        private void gbCustomer_Enter(object sender, EventArgs e)
        {

        }
    }
}
