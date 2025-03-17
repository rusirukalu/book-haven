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
    public partial class CustomerManagementForm : Form
    {
        private CustomerManager customerManager;
        private List<Customer> customers;
        private Customer selectedCustomer;

        public CustomerManagementForm()
        {
            InitializeComponent();
            customerManager = new CustomerManager();
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            ClearFields();
        }

        private void LoadCustomers()
        {
            try
            {
                customers = customerManager.GetAllCustomers();
                dataGridViewCustomers.DataSource = null;
                dataGridViewCustomers.DataSource = customers;

                // Format the DataGridView columns
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            // Set column headers and widths
            dataGridViewCustomers.Columns["CustomerID"].HeaderText = "ID";
            dataGridViewCustomers.Columns["FirstName"].HeaderText = "First Name";
            dataGridViewCustomers.Columns["LastName"].HeaderText = "Last Name";
            dataGridViewCustomers.Columns["Email"].HeaderText = "Email";
            dataGridViewCustomers.Columns["Phone"].HeaderText = "Phone";
            dataGridViewCustomers.Columns["Address"].HeaderText = "Address";

            // Set column widths
            dataGridViewCustomers.Columns["CustomerID"].Width = 50;
            dataGridViewCustomers.Columns["FirstName"].Width = 120;
            dataGridViewCustomers.Columns["LastName"].Width = 120;
            dataGridViewCustomers.Columns["Email"].Width = 180;
            dataGridViewCustomers.Columns["Phone"].Width = 120;
            dataGridViewCustomers.Columns["Address"].Width = 250;
        }

        private void dataGridViewCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewCustomers.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < customers.Count)
                {
                    selectedCustomer = customers[selectedIndex];
                    DisplayCustomerDetails(selectedCustomer);
                }
            }
        }

        private void DisplayCustomerDetails(Customer customer)
        {
            txtFirstName.Text = customer.FirstName;
            txtLastName.Text = customer.LastName;
            txtEmail.Text = customer.Email;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
        }

        private void ClearFields()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            selectedCustomer = null;
        }

        private Customer GetCustomerFromFields()
        {
            Customer customer = new Customer();

            if (selectedCustomer != null)
            {
                customer.CustomerID = selectedCustomer.CustomerID;
            }

            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.Email = txtEmail.Text;
            customer.Phone = txtPhone.Text;
            customer.Address = txtAddress.Text;

            return customer;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateCustomerFields())
                {
                    Customer newCustomer = GetCustomerFromFields();
                    customerManager.AddCustomer(newCustomer);

                    MessageBox.Show("Customer added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCustomers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCustomer == null)
                {
                    MessageBox.Show("Please select a customer to update", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ValidateCustomerFields())
                {
                    Customer updatedCustomer = GetCustomerFromFields();
                    customerManager.UpdateCustomer(updatedCustomer);

                    MessageBox.Show("Customer updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedCustomer == null)
                {
                    MessageBox.Show("Please select a customer to delete", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete customer {selectedCustomer.FirstName} {selectedCustomer.LastName}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    customerManager.DeleteCustomer(selectedCustomer.CustomerID);

                    MessageBox.Show("Customer deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCustomers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadCustomers();
                return;
            }

            try
            {
                List<Customer> searchResults = customers.FindAll(c =>
                    c.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.Phone.Contains(searchTerm));

                dataGridViewCustomers.DataSource = null;
                dataGridViewCustomers.DataSource = searchResults;

                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadCustomers();
        }

        private bool ValidateCustomerFields()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                // Simple email validation
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("Please enter a valid email address", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // real-time search
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadCustomers();
                return;
            }

            try
            {
                List<Customer> searchResults = customers.FindAll(c =>
                    c.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.Phone.Contains(searchTerm));

                dataGridViewCustomers.DataSource = null;
                dataGridViewCustomers.DataSource = searchResults;

                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching customers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int selectedIndex = e.RowIndex;
                    if (selectedIndex >= 0 && selectedIndex < customers.Count)
                    {
                        selectedCustomer = customers[selectedIndex];
                        DisplayCustomerDetails(selectedCustomer);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting customer: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
