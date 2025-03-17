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
    public partial class OrderManagementForm : Form
    {
        private OrderManager orderManager;
        private List<Order> orders;
        private Order? selectedOrder;

        public OrderManagementForm()
        {
            InitializeComponent();
            orderManager = new OrderManager();
            orders = new List<Order>(); // Initialize to avoid CS8618
        }

        private void OrderManagementForm_Load(object sender, EventArgs e)
        {

            // Make sure the combo box has items before setting selected index
            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0; // Select "All" by default
            }

            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                orders = orderManager.GetAllOrders();

                // Debug: Check if orders were retrieved
                if (orders == null || orders.Count == 0)
                {
                    MessageBox.Show("No orders found in the database.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                FilterOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterOrders()
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            string statusFilter = cmbStatus.SelectedItem?.ToString() ?? "All";

            if (orders == null)
            {
                return;
            }

            List<Order> filteredOrders = orders;

            if (statusFilter != "All")
            {
                filteredOrders = filteredOrders.FindAll(o => o.Status == statusFilter);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredOrders = filteredOrders.FindAll(o =>
                    o.OrderID.ToString().Contains(searchTerm) ||
                    o.CustomerName.ToLower().Contains(searchTerm));
            }

            dataGridViewOrders.DataSource = null;
            dataGridViewOrders.DataSource = filteredOrders;

            FormatOrdersDataGridView();
        }

        private void FormatOrdersDataGridView()
        {
            // Check if DataGridView has any columns
            if (dataGridViewOrders.Columns.Count == 0 || dataGridViewOrders.DataSource == null)
            {
                return;
            }

            // Add null checks for each column access
            if (dataGridViewOrders.Columns.Contains("OrderID"))
                dataGridViewOrders.Columns["OrderID"].HeaderText = "Order ID";

            if (dataGridViewOrders.Columns.Contains("CustomerID"))
                dataGridViewOrders.Columns["CustomerID"].Visible = false;

            if (dataGridViewOrders.Columns.Contains("CustomerName"))
                dataGridViewOrders.Columns["CustomerName"].HeaderText = "Customer";

            if (dataGridViewOrders.Columns.Contains("OrderDate"))
                dataGridViewOrders.Columns["OrderDate"].HeaderText = "Order Date";

            if (dataGridViewOrders.Columns.Contains("DeliveryDate"))
                dataGridViewOrders.Columns["DeliveryDate"].HeaderText = "Delivery Date";

            if (dataGridViewOrders.Columns.Contains("Status"))
                dataGridViewOrders.Columns["Status"].HeaderText = "Status";

            if (dataGridViewOrders.Columns.Contains("TotalAmount"))
            {
                dataGridViewOrders.Columns["TotalAmount"].HeaderText = "Total Amount";
                dataGridViewOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
            }

            if (dataGridViewOrders.Columns.Contains("OrderItems"))
                dataGridViewOrders.Columns["OrderItems"].Visible = false;

            // Set column widths only if columns exist
            if (dataGridViewOrders.Columns.Contains("OrderID"))
                dataGridViewOrders.Columns["OrderID"].Width = 80;

            if (dataGridViewOrders.Columns.Contains("CustomerName"))
                dataGridViewOrders.Columns["CustomerName"].Width = 150;

            if (dataGridViewOrders.Columns.Contains("OrderDate"))
                dataGridViewOrders.Columns["OrderDate"].Width = 120;

            if (dataGridViewOrders.Columns.Contains("DeliveryDate"))
                dataGridViewOrders.Columns["DeliveryDate"].Width = 120;

            if (dataGridViewOrders.Columns.Contains("Status"))
                dataGridViewOrders.Columns["Status"].Width = 100;

            if (dataGridViewOrders.Columns.Contains("TotalAmount"))
                dataGridViewOrders.Columns["TotalAmount"].Width = 120;
        }

        private void dataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridViewOrders.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < dataGridViewOrders.Rows.Count)
                {
                    selectedOrder = (Order)dataGridViewOrders.SelectedRows[0].DataBoundItem;
                    DisplayOrderDetails(selectedOrder);
                }
            }
        }

        private void DisplayOrderDetails(Order order)
        {
            txtOrderID.Text = order.OrderID.ToString();
            txtCustomer.Text = order.CustomerName;
            dtpOrderDate.Value = order.OrderDate;
            cmbOrderStatus.Text = order.Status;

            if (order.DeliveryDate.HasValue)
            {
                dtpDeliveryDate.Value = order.DeliveryDate.Value;
                dtpDeliveryDate.Checked = true;
            }
            else
            {
                dtpDeliveryDate.Checked = false;
            }

            txtTotalAmount.Text = order.TotalAmount.ToString("C2");

            // Display order items
            dataGridViewOrderItems.DataSource = null;
            dataGridViewOrderItems.DataSource = order.OrderItems;

            FormatOrderItemsDataGridView();
        }

        private void FormatOrderItemsDataGridView()
        {
            // Check if DataGridView has any columns
            if (dataGridViewOrderItems.Columns.Count == 0 || dataGridViewOrderItems.DataSource == null)
            {
                return;
            }

            // Add null checks for each column access
            if (dataGridViewOrderItems.Columns.Contains("OrderItemID"))
                dataGridViewOrderItems.Columns["OrderItemID"].Visible = false;

            if (dataGridViewOrderItems.Columns.Contains("OrderID"))
                dataGridViewOrderItems.Columns["OrderID"].Visible = false;

            if (dataGridViewOrderItems.Columns.Contains("BookID"))
                dataGridViewOrderItems.Columns["BookID"].Visible = false;

            if (dataGridViewOrderItems.Columns.Contains("BookTitle"))
            {
                dataGridViewOrderItems.Columns["BookTitle"].HeaderText = "Book";
                dataGridViewOrderItems.Columns["BookTitle"].Width = 300;
            }

            if (dataGridViewOrderItems.Columns.Contains("Price"))
            {
                dataGridViewOrderItems.Columns["Price"].HeaderText = "Price";
                dataGridViewOrderItems.Columns["Price"].Width = 100;
                dataGridViewOrderItems.Columns["Price"].DefaultCellStyle.Format = "C2";
            }

            if (dataGridViewOrderItems.Columns.Contains("Quantity"))
            {
                dataGridViewOrderItems.Columns["Quantity"].HeaderText = "Quantity";
                dataGridViewOrderItems.Columns["Quantity"].Width = 100;
            }

            if (dataGridViewOrderItems.Columns.Contains("Subtotal"))
            {
                dataGridViewOrderItems.Columns["Subtotal"].HeaderText = "Subtotal";
                dataGridViewOrderItems.Columns["Subtotal"].Width = 100;
                dataGridViewOrderItems.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void dtpDeliveryDate_ValueChanged(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void btnUpdateStatus_Click_1(object sender, EventArgs e)
        {
            if (selectedOrder == null)
            {
                MessageBox.Show("Please select an order to update", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string newStatus = cmbOrderStatus.Text;
                DateTime? deliveryDate = dtpDeliveryDate.Checked ? dtpDeliveryDate.Value : (DateTime?)null;

                orderManager.UpdateOrderStatus(selectedOrder.OrderID, newStatus, deliveryDate);

                MessageBox.Show("Order status updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating order status: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewOrder_Click_1(object sender, EventArgs e)
        {
            // Open the sales form to create a new order
            SalesForm salesForm = new SalesForm();
            salesForm.ShowDialog();

            // Refresh the orders list after creating a new order
            LoadOrders();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click to select and display order details
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewOrders.Rows.Count)
            {
                // Select the entire row when any cell is clicked
                dataGridViewOrders.Rows[e.RowIndex].Selected = true;

                // Get the selected order
                if (dataGridViewOrders.SelectedRows.Count > 0)
                {
                    selectedOrder = (Order)dataGridViewOrders.SelectedRows[0].DataBoundItem;
                    DisplayOrderDetails(selectedOrder);
                }
            }
        }

        private void dataGridViewOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This event handler can be used if you want to implement specific 
            // actions when clicking on order items, such as:

            // 1. Showing detailed book information
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Example: If clicking on the book title column, show book details
                if (dataGridViewOrderItems.Columns[e.ColumnIndex].Name == "BookTitle")
                {
                    OrderItem item = (OrderItem)dataGridViewOrderItems.Rows[e.RowIndex].DataBoundItem;
                    MessageBox.Show($"Book Details:\nTitle: {item.BookTitle}\nPrice: {item.Price:C2}\n" +
                                   $"Quantity: {item.Quantity}\nSubtotal: {item.Subtotal:C2}",
                                   "Book Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
