using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.Models;

namespace BookHaven
{
    public partial class MainForm : Form
    {
        private User currentUser; // Add this field to store the current user

        // Add a parameterless constructor for the designer
        public MainForm()
        {
            InitializeComponent();
        }

        // Add a constructor that accepts a User parameter
        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set form title to include username and role
            if (currentUser != null)
            {
                this.Text = $"BookHaven - {currentUser.Role}: {currentUser.Username}";

                // Configure menu access based on user role
                ConfigureMenuAccess();
            }
        }
        private void ConfigureMenuAccess()
        {
            // If the user is not an Admin, hide admin-only features
            if (currentUser != null && currentUser.Role != "Admin")
            {
                // Hide the dashboard menu item completely
                dashboardToolStripMenuItem.Visible = false;

                // Hide reports menu
                reportsToolStripMenuItem.Visible = false;

                // Hide suppliers menu
                suppliersToolStripMenuItem.Visible = false;

                // Hide View Sales option
                viewSalesToolStripMenuItem.Visible = false;

                // You can add more restrictions here as needed
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUser != null && currentUser.Role == "Admin")
            {
                AdminDashboardForm dashboardForm = new AdminDashboardForm(currentUser);
                dashboardForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access denied. Only administrators can access the dashboard.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the login form again
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookManagementForm bookForm = new BookManagementForm();
            bookForm.ShowDialog();
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookManagementForm bookForm = new BookManagementForm();
            bookForm.ShowDialog();
        }

        private void manageInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookManagementForm bookForm = new BookManagementForm();
            bookForm.ShowDialog();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerManagementForm customerForm = new CustomerManagementForm();
            customerForm.ShowDialog();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerManagementForm customerForm = new CustomerManagementForm();
            customerForm.ShowDialog();
        }

        private void newSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
            salesForm.ShowDialog();
        }

        private void viewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check user role before allowing access
            if (currentUser != null && currentUser.Role == "Admin")
            {
                ReportsForm reportsForm = new ReportsForm(currentUser);
                reportsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Access denied. Administrator privileges required to access detailed reports.",
                    "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                // Do NOT proceed to open the form after showing this message
            }
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderManagementForm orderForm = new OrderManagementForm();
            orderForm.ShowDialog();
        }

        private void createOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
            salesForm.ShowDialog();
        }

        private void viewSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierManagementForm supplierForm = new SupplierManagementForm();
            supplierForm.ShowDialog();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierManagementForm supplierForm = new SupplierManagementForm();
            supplierForm.ShowDialog();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm(currentUser);
            // Pre-select Sales Summary report type if available
            reportsForm.ShowDialog();
        }

        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm(currentUser);
            // Pre-select Inventory Status report type if available
            reportsForm.ShowDialog();
        }
    }
}
