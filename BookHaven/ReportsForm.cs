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
using BookHaven.Utilities;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BookHaven
{
    public partial class ReportsForm : Form
    {
        private BookManager bookManager;
        private SaleManager saleManager;
        private User? currentUser;

        public ReportsForm()
        {
            InitializeComponent();
            bookManager = new BookManager();
            saleManager = new SaleManager();
        }

        public ReportsForm(User user) : this()
        {
            currentUser = user;

            // Add this block to enforce access control
            if (currentUser != null && currentUser.Role != "Admin")
            {
                MessageBox.Show("You need administrator privileges to access detailed reports.",
                    "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // Set default values
            cmbReportType.SelectedIndex = 0; // Sales Summary
            cmbPeriod.SelectedIndex = 2; // Monthly

            // Set default date range to current month
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;

            // Check if user has permission to access reports
            if (currentUser != null && currentUser.Role != "Admin")
            {
                MessageBox.Show("You need administrator privileges to access detailed reports.",
                    "Access Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Disable sensitive report options but allow basic reports
                cmbReportType.Items.Remove("Sales Summary");
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear previous report data
                dataGridViewReport.DataSource = null;

                // Get selected report type
                string? reportType = cmbReportType.SelectedItem?.ToString();
                DateTime startDate = dtpStartDate.Value;
                DateTime endDate = dtpEndDate.Value.AddDays(1).AddSeconds(-1);
                string? period = cmbPeriod.SelectedItem?.ToString();

                // Validate date range
                if (startDate > endDate)
                {
                    MessageBox.Show("Start date cannot be after end date.", "Invalid Date Range",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generate the appropriate report
                switch (reportType)
                {
                    case "Sales Summary":
                        if (period == null)
                        {
                            MessageBox.Show("Please select a period.", "Period Required",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        GenerateSalesSummaryReport(startDate, endDate, period);
                        break;
                    case "Best Selling Books":
                        GenerateBestSellingBooksReport(startDate, endDate);
                        break;
                    case "Inventory Status":
                        GenerateInventoryStatusReport();
                        break;
                    default:
                        MessageBox.Show("Please select a report type.", "Report Type Required",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }

                // Enable export button if report was generated
                if (dataGridViewReport.Rows.Count > 0)
                {
                    btnExportReport.Enabled = true;
                    statusStripReports.Items[0].Text = $"Report generated successfully. {dataGridViewReport.Rows.Count} rows.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusStripReports.Items[0].Text = "Error generating report.";
            }
        }

        private void GenerateSalesSummaryReport(DateTime startDate, DateTime endDate, string period)
        {
            try
            {
                // This would typically fetch data from the database
                // For now, we'll create a sample dataset

                DataTable salesData = new DataTable();
                salesData.Columns.Add("Date", typeof(DateTime));
                salesData.Columns.Add("Total Sales", typeof(decimal));
                salesData.Columns.Add("Number of Orders", typeof(int));
                salesData.Columns.Add("Average Order Value", typeof(decimal));

                // In a real implementation, this would be fetched from the database
                // For this example, we'll generate sample data
                Random random = new Random();
                DateTime currentDate = startDate;

                while (currentDate <= endDate)
                {
                    decimal totalSales = random.Next(500, 2000);
                    int numberOfOrders = random.Next(5, 20);
                    decimal averageOrderValue = totalSales / numberOfOrders;

                    salesData.Rows.Add(currentDate, totalSales, numberOfOrders, Math.Round(averageOrderValue, 2));

                    // Increment date based on selected period
                    switch (period)
                    {
                        case "Daily":
                            currentDate = currentDate.AddDays(1);
                            break;
                        case "Weekly":
                            currentDate = currentDate.AddDays(7);
                            break;
                        case "Monthly":
                            currentDate = currentDate.AddMonths(1);
                            break;
                    }
                }

                dataGridViewReport.DataSource = salesData;

                // Format the DataGridView
                dataGridViewReport.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dataGridViewReport.Columns["Total Sales"].DefaultCellStyle.Format = "C2";
                dataGridViewReport.Columns["Average Order Value"].DefaultCellStyle.Format = "C2";

                // Adjust column widths for better visibility
                dataGridViewReport.AutoResizeColumns();

                // Create chart data
                CreateSalesChart(salesData);

                // Set the chart title
                tabControlReports.SelectedTab = tabControlReports.TabPages["Data View"];
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating sales summary report: " + ex.Message);
            }
        }

        private void CreateSalesChart(DataTable data)
        {
            // Clear any existing chart
            panelChart.Controls.Clear();

            // Create a chart control
            System.Windows.Forms.DataVisualization.Charting.Chart chart =
                new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart.Dock = DockStyle.Fill;

            // Create a chart area
            chart.ChartAreas.Add("ChartArea");
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisY.Title = "Amount";

            // Create series for total sales
            chart.Series.Add("Total Sales");
            chart.Series["Total Sales"].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart.Series["Total Sales"].XValueMember = "Date";
            chart.Series["Total Sales"].YValueMembers = "Total Sales";
            chart.Series["Total Sales"].IsValueShownAsLabel = true;
            chart.Series["Total Sales"].LabelFormat = "C0";

            // Add data to chart
            chart.DataSource = data;
            chart.DataBind();

            // Add chart to panel
            panelChart.Controls.Add(chart);
        }

        private void GenerateBestSellingBooksReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                // This would typically fetch data from the database
                // For now, we'll create a sample dataset

                DataTable booksData = new DataTable();
                booksData.Columns.Add("Book ID", typeof(int));
                booksData.Columns.Add("Title", typeof(string));
                booksData.Columns.Add("Author", typeof(string));
                booksData.Columns.Add("Quantity Sold", typeof(int));
                booksData.Columns.Add("Revenue", typeof(decimal));

                // Sample data
                booksData.Rows.Add(101, "The Great Gatsby", "F. Scott Fitzgerald", 42, 545.58);
                booksData.Rows.Add(203, "To Kill a Mockingbird", "Harper Lee", 38, 569.62);
                booksData.Rows.Add(305, "1984", "George Orwell", 35, 419.65);
                booksData.Rows.Add(407, "Pride and Prejudice", "Jane Austen", 30, 389.70);
                booksData.Rows.Add(512, "The Catcher in the Rye", "J.D. Salinger", 28, 335.72);

                // Sort by quantity sold descending
                DataView dv = booksData.DefaultView;
                dv.Sort = "Quantity Sold DESC";
                DataTable sortedTable = dv.ToTable();

                dataGridViewReport.DataSource = sortedTable;

                // Format the DataGridView
                dataGridViewReport.Columns["Revenue"].DefaultCellStyle.Format = "C2";
                dataGridViewReport.AutoResizeColumns();

                // Create chart for best selling books
                CreateBestSellingBooksChart(sortedTable);

                tabControlReports.SelectedTab = tabControlReports.TabPages["Data View"];
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating best selling books report: " + ex.Message);
            }
        }

        private void CreateBestSellingBooksChart(DataTable data)
        {
            // Clear any existing chart
            panelChart.Controls.Clear();

            // Create a chart control
            System.Windows.Forms.DataVisualization.Charting.Chart chart =
                new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart.Dock = DockStyle.Fill;

            // Create a chart area
            chart.ChartAreas.Add("ChartArea");
            chart.ChartAreas[0].AxisX.Title = "Books";
            chart.ChartAreas[0].AxisY.Title = "Quantity Sold";

            // Create series for quantity sold
            chart.Series.Add("Quantity Sold");
            chart.Series["Quantity Sold"].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;

            // Add data points
            for (int i = 0; i < Math.Min(data.Rows.Count, 10); i++)
            {
                string? title = data.Rows[i]["Title"].ToString();
                int quantity = Convert.ToInt32(data.Rows[i]["Quantity Sold"]);

                chart.Series["Quantity Sold"].Points.AddXY(title, quantity);
                chart.Series["Quantity Sold"].Points[i].Label = quantity.ToString();
            }

            // Add chart to panel
            panelChart.Controls.Add(chart);
        }

        private void GenerateInventoryStatusReport()
        {
            try
            {
                // This would typically fetch data from the database
                // For now, we'll create a sample dataset

                DataTable inventoryData = new DataTable();
                inventoryData.Columns.Add("Book ID", typeof(int));
                inventoryData.Columns.Add("Title", typeof(string));
                inventoryData.Columns.Add("Author", typeof(string));
                inventoryData.Columns.Add("Current Stock", typeof(int));
                inventoryData.Columns.Add("Reorder Level", typeof(int));
                inventoryData.Columns.Add("Status", typeof(string));

                // Sample data
                inventoryData.Rows.Add(101, "The Great Gatsby", "F. Scott Fitzgerald", 15, 10, "OK");
                inventoryData.Rows.Add(203, "To Kill a Mockingbird", "Harper Lee", 8, 10, "Low");
                inventoryData.Rows.Add(305, "1984", "George Orwell", 3, 10, "Critical");
                inventoryData.Rows.Add(407, "Pride and Prejudice", "Jane Austen", 0, 10, "Out of Stock");
                inventoryData.Rows.Add(512, "The Catcher in the Rye", "J.D. Salinger", 12, 10, "OK");

                // Add more sample data...
                for (int i = 600; i < 620; i++)
                {
                    Random rand = new Random(i);
                    int stock = rand.Next(0, 25);
                    string status = stock == 0 ? "Out of Stock" :
                                   stock < 5 ? "Critical" :
                                   stock < 10 ? "Low" : "OK";

                    inventoryData.Rows.Add(
                        i,
                        $"Book Title {i}",
                        $"Author {i % 10}",
                        stock,
                        10,
                        status);
                }

                dataGridViewReport.DataSource = inventoryData;

                // Format the DataGridView - color code based on status
                dataGridViewReport.CellFormatting += (sender, e) => {
                    if (e.ColumnIndex == inventoryData.Columns["Status"]?.Ordinal && e.Value != null)
                    {
                        string status = e.Value.ToString() ?? string.Empty;
                        if (e.CellStyle != null)
                        {
                            if (status == "Out of Stock")
                                e.CellStyle.BackColor = Color.Red;
                            else if (status == "Critical")
                                e.CellStyle.BackColor = Color.Orange;
                            else if (status == "Low")
                                e.CellStyle.BackColor = Color.Yellow;
                            else
                                e.CellStyle.BackColor = Color.LightGreen;
                        }
                    }
                };

                dataGridViewReport.AutoResizeColumns();

                // Create inventory status chart
                CreateInventoryStatusChart(inventoryData);

                tabControlReports.SelectedTab = tabControlReports.TabPages["Data View"];
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating inventory status report: " + ex.Message);
            }
        }

        private void CreateInventoryStatusChart(DataTable data)
        {
            // Clear any existing chart
            panelChart.Controls.Clear();

            // Create a chart control
            System.Windows.Forms.DataVisualization.Charting.Chart chart =
                new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart.Dock = DockStyle.Fill;

            // Create a chart area
            chart.ChartAreas.Add("ChartArea");

            // Create series for inventory status
            chart.Series.Add("Inventory Status");
            chart.Series["Inventory Status"].ChartType =
                System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            // Count items by status
            int outOfStock = 0, critical = 0, low = 0, ok = 0;
            foreach (DataRow row in data.Rows)
            {
                string? status = row["Status"].ToString();
                switch (status)
                {
                    case "Out of Stock": outOfStock++; break;
                    case "Critical": critical++; break;
                    case "Low": low++; break;
                    case "OK": ok++; break;
                }
            }

            // Add data points
            chart.Series["Inventory Status"].Points.AddXY("Out of Stock", outOfStock);
            chart.Series["Inventory Status"].Points[0].Color = Color.Red;
            chart.Series["Inventory Status"].Points.AddXY("Critical", critical);
            chart.Series["Inventory Status"].Points[1].Color = Color.Orange;
            chart.Series["Inventory Status"].Points.AddXY("Low", low);
            chart.Series["Inventory Status"].Points[2].Color = Color.Yellow;
            chart.Series["Inventory Status"].Points.AddXY("OK", ok);
            chart.Series["Inventory Status"].Points[3].Color = Color.LightGreen;

            // Show labels with percentages
            chart.Series["Inventory Status"].IsValueShownAsLabel = true;
            chart.Series["Inventory Status"].LabelFormat = "#.#'%'";
            chart.Series["Inventory Status"]["PieLabelStyle"] = "Outside";

            // Add a legend
            chart.Legends.Add("InventoryLegend");
            chart.Series["Inventory Status"].Legend = "InventoryLegend";

            // Add chart to panel
            panelChart.Controls.Add(chart);
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Show save dialog
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf|Excel Files (*.xlsx)|*.xlsx";
                saveDialog.Title = "Export Report";
                saveDialog.FileName = $"BookHaven_{cmbReportType.Text.Replace(" ", "")}_{DateTime.Now:yyyyMMdd}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveDialog.FileName;
                    string fileExtension = Path.GetExtension(filePath).ToLower();

                    if (fileExtension == ".pdf")
                    {
                        // Create PDF using iTextSharp
                        using (FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            Document document = new Document();
                            PdfWriter writer = PdfWriter.GetInstance(document, fs);
                            document.Open();

                            // Add title
                            Paragraph title = new Paragraph($"{cmbReportType.Text} Report");
                            title.Alignment = Element.ALIGN_CENTER;
                            document.Add(title);
                            document.Add(new Paragraph(" ")); // Add space

                            // Create a table for the data
                            PdfPTable table = new PdfPTable(dataGridViewReport.Columns.Count);

                            // Add headers
                            for (int i = 0; i < dataGridViewReport.Columns.Count; i++)
                            {
                                table.AddCell(dataGridViewReport.Columns[i].HeaderText);
                            }

                            // Add data
                            for (int i = 0; i < dataGridViewReport.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataGridViewReport.Columns.Count; j++)
                                {
                                    var cell = dataGridViewReport.Rows[i].Cells[j];
                                    if (cell != null && cell.Value != null)
                                    {
                                        table.AddCell(cell.Value.ToString() ?? string.Empty);
                                    }
                                    else
                                    {
                                        table.AddCell(string.Empty);
                                    }
                                }
                            }

                            document.Add(table);
                            document.Close();
                            writer.Close();
                        }
                    }
                    else if (fileExtension == ".xlsx")
                    {
                        MessageBox.Show("Excel export is not implemented in this version.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    MessageBox.Show($"Report successfully exported to {filePath}", "Export Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    statusStripReports.Items[0].Text = $"Report exported to {filePath}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting report: " + ex.Message, "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusStripReports.Items[0].Text = "Error exporting report.";
            }
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem?.ToString() ?? string.Empty;

            // Enable/disable date controls based on report type
            bool dateControlsEnabled = reportType != "Inventory Status";

            lblDateRange.Enabled = dateControlsEnabled;
            dtpStartDate.Enabled = dateControlsEnabled;
            lblTo.Enabled = dateControlsEnabled;
            dtpEndDate.Enabled = dateControlsEnabled;
            lblPeriod.Enabled = reportType == "Sales Summary";
            cmbPeriod.Enabled = reportType == "Sales Summary";

            // Reset export button
            btnExportReport.Enabled = false;

            // Clear previous report data
            dataGridViewReport.DataSource = null;

            statusStripReports.Items[0].Text = "Ready";
        }

        private void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void panelReportOptions_Paint(object sender, PaintEventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void dataGridViewReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }

        private void panelChart_Paint(object sender, PaintEventArgs e)
        {
            // This is an auto-generated event handler, can be left empty
        }
    }
}
