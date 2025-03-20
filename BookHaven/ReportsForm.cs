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

            // enforcing access control
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
                DataTable salesData = new DataTable();
                salesData.Columns.Add("Date", typeof(DateTime));
                salesData.Columns.Add("Total Sales", typeof(decimal));
                salesData.Columns.Add("Number of Orders", typeof(int));
                salesData.Columns.Add("Average Order Value", typeof(decimal));

                // Format date parts for SQL query
                string dateFormat = "";
                string dateGroupBy = "";

                switch (period)
                {
                    case "Daily":
                        dateFormat = "%Y-%m-%d";
                        dateGroupBy = "DATE(sale_date)";
                        break;
                    case "Weekly":
                        dateFormat = "%Y-%U"; // Year-Week
                        dateGroupBy = "YEARWEEK(sale_date)";
                        break;
                    case "Monthly":
                        dateFormat = "%Y-%m";
                        dateGroupBy = "YEAR(sale_date), MONTH(sale_date)";
                        break;
                }

                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = $@"
                SELECT 
                    DATE_FORMAT(sale_date, '{dateFormat}') as ReportDate,
                    SUM(total_amount) as TotalSales,
                    COUNT(*) as NumberOfOrders,
                    SUM(total_amount)/COUNT(*) as AverageOrderValue
                FROM 
                    sales
                WHERE 
                    sale_date BETWEEN @StartDate AND @EndDate
                GROUP BY 
                    DATE_FORMAT(sale_date, '{dateFormat}')
                ORDER BY 
                    MIN(sale_date)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime reportDate;

                            if (period == "Weekly")
                            {
                                // Parse year-week format
                                string[] parts = reader["ReportDate"].ToString().Split('-');
                                int year = int.Parse(parts[0]);
                                int week = int.Parse(parts[1]);
                                reportDate = GetFirstDayOfWeek(year, week);
                            }
                            else
                            {
                                // Parse standard date format
                                reportDate = DateTime.Parse(reader["ReportDate"].ToString());
                            }

                            salesData.Rows.Add(
                                reportDate,
                                Convert.ToDecimal(reader["TotalSales"]),
                                Convert.ToInt32(reader["NumberOfOrders"]),
                                Convert.ToDecimal(reader["AverageOrderValue"])
                            );
                        }
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

        // Helper method for weekly date calculation
        private DateTime GetFirstDayOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
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
                DataTable booksData = new DataTable();
                booksData.Columns.Add("Book ID", typeof(int));
                booksData.Columns.Add("Title", typeof(string));
                booksData.Columns.Add("Author", typeof(string));
                booksData.Columns.Add("Quantity Sold", typeof(int));
                booksData.Columns.Add("Revenue", typeof(decimal));

                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    b.book_id as BookID,
                    b.title as Title,
                    b.author as Author,
                    SUM(si.quantity) as QuantitySold,
                    SUM(si.price * si.quantity) as Revenue
                FROM 
                    books b
                    INNER JOIN sale_items si ON b.book_id = si.book_id
                    INNER JOIN sales s ON si.sale_id = s.sale_id
                WHERE 
                    s.sale_date BETWEEN @StartDate AND @EndDate
                GROUP BY 
                    b.book_id, b.title, b.author
                ORDER BY 
                    QuantitySold DESC
                LIMIT 10";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            booksData.Rows.Add(
                                Convert.ToInt32(reader["BookID"]),
                                reader["Title"].ToString(),
                                reader["Author"].ToString(),
                                Convert.ToInt32(reader["QuantitySold"]),
                                Convert.ToDecimal(reader["Revenue"])
                            );
                        }
                    }
                }

                dataGridViewReport.DataSource = booksData;

                // Format the DataGridView
                dataGridViewReport.Columns["Revenue"].DefaultCellStyle.Format = "C2";
                dataGridViewReport.AutoResizeColumns();

                // Create chart for best selling books
                CreateBestSellingBooksChart(booksData);

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
                DataTable inventoryData = new DataTable();
                inventoryData.Columns.Add("Book ID", typeof(int));
                inventoryData.Columns.Add("Title", typeof(string));
                inventoryData.Columns.Add("Author", typeof(string));
                inventoryData.Columns.Add("Current Stock", typeof(int));
                inventoryData.Columns.Add("Reorder Level", typeof(int));
                inventoryData.Columns.Add("Status", typeof(string));

                // Define reorder level (you could store this in a settings table)
                int reorderLevel = 10;

                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    book_id as BookID,
                    title as Title,
                    author as Author,
                    stock_quantity as CurrentStock
                FROM 
                    books
                ORDER BY 
                    stock_quantity ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int currentStock = Convert.ToInt32(reader["CurrentStock"]);
                            string status = currentStock == 0 ? "Out of Stock" :
                                           currentStock < 5 ? "Critical" :
                                           currentStock < reorderLevel ? "Low" : "OK";

                            inventoryData.Rows.Add(
                                Convert.ToInt32(reader["BookID"]),
                                reader["Title"].ToString(),
                                reader["Author"].ToString(),
                                currentStock,
                                reorderLevel,
                                status
                            );
                        }
                    }
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

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panelReportOptions_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelChart_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
