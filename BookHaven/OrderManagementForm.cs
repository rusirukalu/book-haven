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
        private SaleManager saleManager;

        public OrderManagementForm()
        {
            InitializeComponent();
            this.Text = "Transaction Management";
            orderManager = new OrderManager();
            saleManager = new SaleManager();
            orders = new List<Order>();

            if (cmbTransactionType.Items.Count == 0)
            {
                cmbTransactionType.Items.AddRange(new object[] { "All Transactions", "Orders", "Sales" });
                cmbTransactionType.SelectedIndex = 0;
            }
        }

        private void OrderManagementForm_Load(object sender, EventArgs e)
        {

            // Make sure the combo box has items before setting selected index
            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0; // Select "All" by default
            }

            if (cmbTransactionType.Items.Count == 0)
            {
                cmbTransactionType.Items.AddRange(new object[] { "All Transactions", "Orders", "Sales" });
            }
            if (cmbTransactionType.Items.Count > 0)
            {
                cmbTransactionType.SelectedIndex = 0; // Select "All Transactions" by default
            }

            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                orders = new List<Order>(); // Clear existing orders
                string transactionType = cmbTransactionType.SelectedItem?.ToString() ?? "All Transactions";

                // Load orders if needed
                if (transactionType == "All Transactions" || transactionType == "Orders")
                {
                    List<Order> ordersList = orderManager.GetAllOrders();
                    if (ordersList != null && ordersList.Count > 0)
                    {
                        // Ensure orders have the correct transaction type set
                        foreach (Order order in ordersList)
                        {
                            order.TransactionType = "Order";
                        }
                        orders.AddRange(ordersList);
                    }
                }

                // Load sales if needed
                if (transactionType == "All Transactions" || transactionType == "Sales")
                {
                    List<Sale> sales = saleManager.GetAllSales();
                    if (sales != null && sales.Count > 0)
                    {
                        // Convert sales to order format for display
                        foreach (Sale sale in sales)
                        {
                            Order orderFromSale = new Order
                            {
                                OrderID = sale.SaleID,
                                CustomerID = sale.CustomerID,
                                CustomerName = sale.CustomerName,
                                OrderDate = sale.SaleDate,
                                DeliveryDate = null, // Sales don't have delivery dates
                                Status = "Completed", // Sales are always completed
                                TotalAmount = sale.TotalAmount,
                                TransactionType = "Sale",
                                OrderItems = new List<OrderItem>()
                            };

                            // Convert SaleItems to OrderItems
                            foreach (SaleItem saleItem in sale.SaleItems)
                            {
                                OrderItem orderItem = new OrderItem
                                {
                                    OrderItemID = saleItem.SaleItemID,
                                    OrderID = saleItem.SaleID,
                                    BookID = saleItem.BookID,
                                    BookTitle = saleItem.BookTitle,
                                    Price = saleItem.Price,
                                    Quantity = saleItem.Quantity
                                };

                                orderFromSale.OrderItems.Add(orderItem);
                            }

                            orders.Add(orderFromSale);
                        }
                    }
                }

                // Debug: Check if transactions were retrieved
                if (orders == null || orders.Count == 0)
                {
                    MessageBox.Show("No transactions found in the database.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                FilterOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterOrders()
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            string statusFilter = cmbStatus.SelectedItem?.ToString() ?? "All";
            string transactionTypeFilter = cmbTransactionType.SelectedItem?.ToString() ?? "All Transactions";

            if (orders == null)
            {
                return;
            }

            List<Order> filteredOrders = new List<Order>(orders);

            // Filter by transaction type if not "All Transactions"
            if (transactionTypeFilter != "All Transactions")
            {
                if (transactionTypeFilter == "Orders")
                    filteredOrders = filteredOrders.FindAll(o => o.TransactionType == "Order");
                else if (transactionTypeFilter == "Sales")
                    filteredOrders = filteredOrders.FindAll(o => o.TransactionType == "Sale");
            }

            // Filter by status if not "All"
            if (statusFilter != "All")
            {
                filteredOrders = filteredOrders.FindAll(o => o.Status == statusFilter);
            }

            // Filter by search term
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

            // Null checks for each column access
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

            if (dataGridViewOrders.Columns.Contains("TransactionType"))
            {
                dataGridViewOrders.Columns["TransactionType"].HeaderText = "Type";
                dataGridViewOrders.Columns["TransactionType"].Width = 80;
            }
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
            lblTransactionTypeValue.Text = order.TransactionType;

            // Update the group box title based on transaction type
            if (order.TransactionType == "Sale")
            {
                groupBoxOrderDetails.Text = "Sale Details";
                lblOrderID.Text = "Sale ID:";
                lblOrderDate.Text = "Sale Date:";

                // For sales, hide delivery-related controls completely
                cmbOrderStatus.Text = "Completed";
                cmbOrderStatus.Enabled = false;
                btnUpdateStatus.Visible = false;

                // Hide delivery date controls
                lblDeliveryDate.Visible = false;
                dtpDeliveryDate.Visible = false;
            }
            else // For orders
            {
                groupBoxOrderDetails.Text = "Order Details";
                lblOrderID.Text = "Order ID:";
                lblOrderDate.Text = "Order Date:";

                // Show all controls for Orders
                cmbOrderStatus.Text = order.Status;
                cmbOrderStatus.Enabled = true;
                btnUpdateStatus.Visible = true;

                // Show delivery date controls
                lblDeliveryDate.Visible = true;
                dtpDeliveryDate.Visible = true;
                dtpDeliveryDate.Enabled = true;

                if (order.DeliveryDate.HasValue)
                {
                    dtpDeliveryDate.Value = order.DeliveryDate.Value;
                    dtpDeliveryDate.Checked = true;
                }
                else
                {
                    dtpDeliveryDate.Checked = false;
                }
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

            // Null checks for each column access
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

            // Add color coding for transaction types
            dataGridViewOrders.CellFormatting += (sender, e) => {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridViewOrders.Rows.Count &&
                    dataGridViewOrders.Rows[e.RowIndex].DataBoundItem is Order order)
                {
                    if (order.TransactionType == "Sale")
                        e.CellStyle.BackColor = Color.FromArgb(230, 255, 230); // Light green
                    else if (order.TransactionType == "Order")
                        e.CellStyle.BackColor = Color.FromArgb(230, 240, 255); // Light blue
                }
            };
        }

        private void UpdateUIForTransactionType(string transactionType)
        {
            if (transactionType == "Sales")
            {
                // Update group box title
                groupBoxOrderDetails.Text = "Sale Details";
                lblOrderID.Text = "Sale ID:";
                lblOrderDate.Text = "Sale Date:";

                // Hide order-specific controls
                lblDeliveryDate.Visible = false;
                dtpDeliveryDate.Visible = false;
                btnUpdateStatus.Visible = false;

                // Disable status dropdown
                cmbOrderStatus.Enabled = false;
                cmbOrderStatus.Text = "Completed";

                // Clear fields if no item is selected
                if (selectedOrder == null || selectedOrder.TransactionType != "Sale")
                {
                    txtOrderID.Text = "";
                    txtCustomer.Text = "";
                    txtTotalAmount.Text = "";
                    dataGridViewOrderItems.DataSource = null;
                }
            }
            else // Orders or All Transactions
            {
                // Update group box title
                groupBoxOrderDetails.Text = "Order Details";
                lblOrderID.Text = "Order ID:";
                lblOrderDate.Text = "Order Date:";

                // Show order-specific controls
                lblDeliveryDate.Visible = true;
                dtpDeliveryDate.Visible = true;
                btnUpdateStatus.Visible = true;

                // Enable status dropdown
                cmbOrderStatus.Enabled = true;

                // Clear fields if no item is selected
                if (selectedOrder == null || selectedOrder.TransactionType != "Order")
                {
                    txtOrderID.Text = "";
                    txtCustomer.Text = "";
                    cmbOrderStatus.Text = "";
                    txtTotalAmount.Text = "";
                    dataGridViewOrderItems.DataSource = null;
                }
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterOrders();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpDeliveryDate_ValueChanged(object sender, EventArgs e)
        {

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the header based on selection
            string? viewType = cmbTransactionType.SelectedItem?.ToString();
            if (viewType == "Orders")
            {
                lblViewType.Text = "ORDERS VIEW";
                lblViewType.BackColor = Color.FromArgb(230, 240, 255); // Light blue
                this.Text = "Order Management";
                UpdateUIForTransactionType("Orders");
            }
            else if (viewType == "Sales")
            {
                lblViewType.Text = "SALES VIEW";
                lblViewType.BackColor = Color.FromArgb(230, 255, 230); // Light green
                this.Text = "Sales Management";
                UpdateUIForTransactionType("Sales");
            }
            else
            {
                lblViewType.Text = "ALL TRANSACTIONS";
                lblViewType.BackColor = Color.Transparent;
                this.Text = "Transaction Management";
                UpdateUIForTransactionType("All");
            }

            LoadOrders();
        }

        private void groupBoxOrderDetails_Enter(object sender, EventArgs e)
        {

        }

        private void panelSearch_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
