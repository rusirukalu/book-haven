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
using MySql.Data.MySqlClient;
using BookHaven.Utilities;

namespace BookHaven
{
    public partial class AdminDashboardForm : Form
    {
        private BookManager bookManager;
        private CustomerManager customerManager;
        private OrderManager orderManager;
        private SaleManager saleManager;
        private User currentUser;

        // Add a parameterless constructor for the designer
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        // Add a constructor that accepts a User parameter
        public AdminDashboardForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            // Prevent non-admin users from accessing this form
            if (currentUser == null || currentUser.Role != "Admin")
            {
                MessageBox.Show("Access denied. Only administrators can access the dashboard.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            bookManager = new BookManager();
            customerManager = new CustomerManager();
            orderManager = new OrderManager();
            saleManager = new SaleManager();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            // Check if user is admin
            if (currentUser == null || currentUser.Role != "Admin")
            {
                MessageBox.Show("You do not have permission to access the Admin Dashboard.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                LoadSalesSummary();
                LoadInventoryStatus();
                LoadRecentOrders();
                LoadTopSellingBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSalesSummary()
        {
            // For now, we'll just display some placeholder data
            // In a real implementation, you would fetch this from the database

            // Clear the group box
            groupBoxSalesSummary.Controls.Clear();

            // Add labels for sales metrics
            Label lblTodaySales = new Label
            {
                Text = "Today's Sales: $1,250.00",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 30)
            };

            Label lblWeeklySales = new Label
            {
                Text = "Weekly Sales: $8,750.00",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 60)
            };

            Label lblMonthlySales = new Label
            {
                Text = "Monthly Sales: $32,500.00",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 90)
            };

            Label lblTotalCustomers = new Label
            {
                Text = "Total Customers: 125",
                Font = new Font("Arial", 12, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(20, 130)
            };

            Label lblTotalOrders = new Label
            {
                Text = "Total Orders: 450",
                Font = new Font("Arial", 12, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(20, 160)
            };

            // Add labels to the group box
            groupBoxSalesSummary.Controls.Add(lblTodaySales);
            groupBoxSalesSummary.Controls.Add(lblWeeklySales);
            groupBoxSalesSummary.Controls.Add(lblMonthlySales);
            groupBoxSalesSummary.Controls.Add(lblTotalCustomers);
            groupBoxSalesSummary.Controls.Add(lblTotalOrders);
        }

        private void LoadInventoryStatus()
        {
            // Clear the group box
            groupBoxInventory.Controls.Clear();

            // Add labels for inventory metrics
            Label lblTotalBooks = new Label
            {
                Text = "Total Books: 1,250",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 30)
            };

            Label lblLowStock = new Label
            {
                Text = "Low Stock Items: 15",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 60)
            };

            Label lblOutOfStock = new Label
            {
                Text = "Out of Stock: 5",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 90)
            };

            // Add a ListView for low stock items
            ListView listViewLowStock = new ListView
            {
                Location = new Point(20, 130),
                Size = new Size(400, 150),
                View = View.Details
            };

            // Add columns to the ListView
            listViewLowStock.Columns.Add("Book ID", 60);
            listViewLowStock.Columns.Add("Title", 200);
            listViewLowStock.Columns.Add("Author", 100);
            listViewLowStock.Columns.Add("Stock", 60);

            // Add some sample items
            ListViewItem item1 = new ListViewItem("101");
            item1.SubItems.Add("The Great Gatsby");
            item1.SubItems.Add("F. Scott Fitzgerald");
            item1.SubItems.Add("3");

            ListViewItem item2 = new ListViewItem("203");
            item2.SubItems.Add("To Kill a Mockingbird");
            item2.SubItems.Add("Harper Lee");
            item2.SubItems.Add("2");

            ListViewItem item3 = new ListViewItem("305");
            item3.SubItems.Add("1984");
            item3.SubItems.Add("George Orwell");
            item3.SubItems.Add("4");

            listViewLowStock.Items.Add(item1);
            listViewLowStock.Items.Add(item2);
            listViewLowStock.Items.Add(item3);

            // Add controls to the group box
            groupBoxInventory.Controls.Add(lblTotalBooks);
            groupBoxInventory.Controls.Add(lblLowStock);
            groupBoxInventory.Controls.Add(lblOutOfStock);
            groupBoxInventory.Controls.Add(listViewLowStock);
        }

        private void LoadRecentOrders()
        {
            // Clear the group box
            groupBoxRecentOrders.Controls.Clear();

            // Add a ListView for recent orders
            ListView listViewRecentOrders = new ListView
            {
                Location = new Point(20, 30),
                Size = new Size(450, 250),
                View = View.Details
            };

            // Add columns to the ListView
            listViewRecentOrders.Columns.Add("Order ID", 60);
            listViewRecentOrders.Columns.Add("Customer", 120);
            listViewRecentOrders.Columns.Add("Date", 100);
            listViewRecentOrders.Columns.Add("Amount", 80);
            listViewRecentOrders.Columns.Add("Status", 80);

            // Add some sample items
            ListViewItem item1 = new ListViewItem("1001");
            item1.SubItems.Add("John Doe");
            item1.SubItems.Add("2023-11-15");
            item1.SubItems.Add("$125.50");
            item1.SubItems.Add("Completed");

            ListViewItem item2 = new ListViewItem("1002");
            item2.SubItems.Add("Jane Smith");
            item2.SubItems.Add("2023-11-14");
            item2.SubItems.Add("$78.25");
            item2.SubItems.Add("Processing");

            ListViewItem item3 = new ListViewItem("1003");
            item3.SubItems.Add("Robert Johnson");
            item3.SubItems.Add("2023-11-13");
            item3.SubItems.Add("$210.75");
            item3.SubItems.Add("Pending");

            listViewRecentOrders.Items.Add(item1);
            listViewRecentOrders.Items.Add(item2);
            listViewRecentOrders.Items.Add(item3);

            // Add controls to the group box
            groupBoxRecentOrders.Controls.Add(listViewRecentOrders);
        }

        private void LoadTopSellingBooks()
        {
            // Clear the group box
            groupBoxTopSelling.Controls.Clear();

            // Add a ListView for top selling books
            ListView listViewTopSelling = new ListView
            {
                Location = new Point(20, 30),
                Size = new Size(450, 250),
                View = View.Details
            };

            // Add columns to the ListView
            listViewTopSelling.Columns.Add("Book ID", 60);
            listViewTopSelling.Columns.Add("Title", 200);
            listViewTopSelling.Columns.Add("Author", 100);
            listViewTopSelling.Columns.Add("Sold", 60);

            // Add some sample items
            ListViewItem item1 = new ListViewItem("203");
            item1.SubItems.Add("To Kill a Mockingbird");
            item1.SubItems.Add("Harper Lee");
            item1.SubItems.Add("42");

            ListViewItem item2 = new ListViewItem("101");
            item2.SubItems.Add("The Great Gatsby");
            item2.SubItems.Add("F. Scott Fitzgerald");
            item2.SubItems.Add("38");

            ListViewItem item3 = new ListViewItem("305");
            item3.SubItems.Add("1984");
            item3.SubItems.Add("George Orwell");
            item3.SubItems.Add("35");

            listViewTopSelling.Items.Add(item1);
            listViewTopSelling.Items.Add(item2);
            listViewTopSelling.Items.Add(item3);

            // Add controls to the group box
            groupBoxTopSelling.Controls.Add(listViewTopSelling);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void groupBoxSalesSummary_Enter(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void groupBoxTopSelling_Enter(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void groupBoxInventory_Enter(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void groupBoxRecentOrders_Enter(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void AdminDashboardForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
