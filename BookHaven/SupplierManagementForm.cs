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
    public partial class SupplierManagementForm : Form
    {
        private SupplierManager supplierManager;
        private List<Supplier> suppliers;
        private Supplier selectedSupplier;

        public SupplierManagementForm()
        {
            InitializeComponent();
            supplierManager = new SupplierManager();
        }

        private void SupplierManagementForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            ClearFields();
        }

        private void LoadSuppliers()
        {
            try
            {
                suppliers = supplierManager.GetAllSuppliers();
                FilterSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading suppliers: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterSuppliers()
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            bool showInactive = chkShowInactive.Checked;

            List<Supplier> filteredSuppliers = new List<Supplier>();

            foreach (Supplier supplier in suppliers)
            {
                // Skip inactive suppliers if not showing inactive
                if (!showInactive && !supplier.IsActive)
                    continue;

                // Apply search filter if any
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    if (supplier.Name.ToLower().Contains(searchTerm) ||
                        supplier.ContactPerson.ToLower().Contains(searchTerm) ||
                        supplier.Email.ToLower().Contains(searchTerm) ||
                        supplier.Phone.Contains(searchTerm))
                    {
                        filteredSuppliers.Add(supplier);
                    }
                }
                else
                {
                    filteredSuppliers.Add(supplier);
                }
            }

            dataGridViewSuppliers.DataSource = null;
            dataGridViewSuppliers.DataSource = filteredSuppliers;

            FormatSuppliersDataGridView();
        }

        private void FormatSuppliersDataGridView()
        {
            dataGridViewSuppliers.Columns["SupplierID"].HeaderText = "ID";
            dataGridViewSuppliers.Columns["Name"].HeaderText = "Name";
            dataGridViewSuppliers.Columns["ContactPerson"].HeaderText = "Contact Person";
            dataGridViewSuppliers.Columns["Email"].HeaderText = "Email";
            dataGridViewSuppliers.Columns["Phone"].HeaderText = "Phone";
            dataGridViewSuppliers.Columns["Address"].HeaderText = "Address";
            dataGridViewSuppliers.Columns["IsActive"].HeaderText = "Active";

            dataGridViewSuppliers.Columns["SupplierID"].Width = 50;
            dataGridViewSuppliers.Columns["Name"].Width = 150;
            dataGridViewSuppliers.Columns["ContactPerson"].Width = 150;
            dataGridViewSuppliers.Columns["Email"].Width = 150;
            dataGridViewSuppliers.Columns["Phone"].Width = 100;
            dataGridViewSuppliers.Columns["Address"].Width = 200;
            dataGridViewSuppliers.Columns["IsActive"].Width = 60;
        }

        private void dataGridViewSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSuppliers.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewSuppliers.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < dataGridViewSuppliers.Rows.Count)
                {
                    selectedSupplier = (Supplier)dataGridViewSuppliers.SelectedRows[0].DataBoundItem;
                    DisplaySupplierDetails(selectedSupplier);
                }
            }
        }

        private void DisplaySupplierDetails(Supplier supplier)
        {
            txtName.Text = supplier.Name;
            txtContactPerson.Text = supplier.ContactPerson;
            txtEmail.Text = supplier.Email;
            txtPhone.Text = supplier.Phone;
            txtAddress.Text = supplier.Address;
            chkIsActive.Checked = supplier.IsActive;
        }

        private void ClearFields()
        {
            txtName.Text = string.Empty;
            txtContactPerson.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            chkIsActive.Checked = true;
            selectedSupplier = null;
        }

        private Supplier GetSupplierFromFields()
        {
            Supplier supplier = new Supplier();

            if (selectedSupplier != null)
            {
                supplier.SupplierID = selectedSupplier.SupplierID;
            }

            supplier.Name = txtName.Text;
            supplier.ContactPerson = txtContactPerson.Text;
            supplier.Email = txtEmail.Text;
            supplier.Phone = txtPhone.Text;
            supplier.Address = txtAddress.Text;
            supplier.IsActive = chkIsActive.Checked;

            return supplier;
        }

        private bool ValidateSupplierFields()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Supplier Name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSupplierFields())
                {
                    Supplier newSupplier = GetSupplierFromFields();
                    supplierManager.AddSupplier(newSupplier);

                    MessageBox.Show("Supplier added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadSuppliers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding supplier: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSupplier == null)
                {
                    MessageBox.Show("Please select a supplier to update", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ValidateSupplierFields())
                {
                    Supplier updatedSupplier = GetSupplierFromFields();
                    supplierManager.UpdateSupplier(updatedSupplier);

                    MessageBox.Show("Supplier updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadSuppliers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating supplier: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSupplier == null)
                {
                    MessageBox.Show("Please select a supplier to delete", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete supplier '{selectedSupplier.Name}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    supplierManager.DeleteSupplier(selectedSupplier.SupplierID);

                    MessageBox.Show("Supplier deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadSuppliers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting supplier: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterSuppliers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadSuppliers();
        }

        private void chkShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            FilterSuppliers();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void btnStockOrder_Click(object sender, EventArgs e)
        {
            // This would open a form to create a stock order
            MessageBox.Show("Stock Order functionality will be implemented in the next phase.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Real-time search
            FilterSuppliers();
        }

    }
}
