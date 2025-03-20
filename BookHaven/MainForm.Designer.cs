namespace BookHaven
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            dashboardToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            booksToolStripMenuItem = new ToolStripMenuItem();
            viewBooksToolStripMenuItem = new ToolStripMenuItem();
            addBooksToolStripMenuItem = new ToolStripMenuItem();
            manageInventoryToolStripMenuItem = new ToolStripMenuItem();
            customersToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            addCustomerToolStripMenuItem = new ToolStripMenuItem();
            salesToolStripMenuItem = new ToolStripMenuItem();
            newSaleToolStripMenuItem = new ToolStripMenuItem();
            viewSalesToolStripMenuItem = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            viewOrdersToolStripMenuItem = new ToolStripMenuItem();
            createOrderToolStripMenuItem = new ToolStripMenuItem();
            suppliersToolStripMenuItem = new ToolStripMenuItem();
            viewSuppliersToolStripMenuItem = new ToolStripMenuItem();
            addSupplierToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            salesReportToolStripMenuItem = new ToolStripMenuItem();
            inventoryReportToolStripMenuItem = new ToolStripMenuItem();
            mainPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, booksToolStripMenuItem, customersToolStripMenuItem, salesToolStripMenuItem, ordersToolStripMenuItem, suppliersToolStripMenuItem, reportsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1489, 40);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dashboardToolStripMenuItem, logoutToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 38);
            fileToolStripMenuItem.Text = "File";
            // 
            // dashboardToolStripMenuItem
            // 
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Size = new Size(262, 44);
            dashboardToolStripMenuItem.Text = "Dashboard";
            dashboardToolStripMenuItem.Click += dashboardToolStripMenuItem_Click;
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(262, 44);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(262, 44);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // booksToolStripMenuItem
            // 
            booksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewBooksToolStripMenuItem, addBooksToolStripMenuItem, manageInventoryToolStripMenuItem });
            booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            booksToolStripMenuItem.Size = new Size(98, 38);
            booksToolStripMenuItem.Text = "Books";
            // 
            // viewBooksToolStripMenuItem
            // 
            viewBooksToolStripMenuItem.Name = "viewBooksToolStripMenuItem";
            viewBooksToolStripMenuItem.Size = new Size(342, 44);
            viewBooksToolStripMenuItem.Text = "View Books";
            viewBooksToolStripMenuItem.Click += viewBooksToolStripMenuItem_Click;
            // 
            // addBooksToolStripMenuItem
            // 
            addBooksToolStripMenuItem.Name = "addBooksToolStripMenuItem";
            addBooksToolStripMenuItem.Size = new Size(342, 44);
            addBooksToolStripMenuItem.Text = "Add Book";
            addBooksToolStripMenuItem.Click += addBooksToolStripMenuItem_Click;
            // 
            // manageInventoryToolStripMenuItem
            // 
            manageInventoryToolStripMenuItem.Name = "manageInventoryToolStripMenuItem";
            manageInventoryToolStripMenuItem.Size = new Size(342, 44);
            manageInventoryToolStripMenuItem.Text = "Manage Inventory";
            manageInventoryToolStripMenuItem.Click += manageInventoryToolStripMenuItem_Click;
            // 
            // customersToolStripMenuItem
            // 
            customersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewToolStripMenuItem, addCustomerToolStripMenuItem });
            customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            customersToolStripMenuItem.Size = new Size(147, 38);
            customersToolStripMenuItem.Text = "Customers";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(318, 44);
            viewToolStripMenuItem.Text = "View Customers";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
            // 
            // addCustomerToolStripMenuItem
            // 
            addCustomerToolStripMenuItem.Name = "addCustomerToolStripMenuItem";
            addCustomerToolStripMenuItem.Size = new Size(318, 44);
            addCustomerToolStripMenuItem.Text = "Add Customer";
            addCustomerToolStripMenuItem.Click += addCustomerToolStripMenuItem_Click;
            // 
            // salesToolStripMenuItem
            // 
            salesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewSalesToolStripMenuItem, newSaleToolStripMenuItem });
            salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            salesToolStripMenuItem.Size = new Size(88, 36);
            salesToolStripMenuItem.Text = "Sales";
            // 
            // newSaleToolStripMenuItem
            // 
            newSaleToolStripMenuItem.Name = "newSaleToolStripMenuItem";
            newSaleToolStripMenuItem.Size = new Size(359, 44);
            newSaleToolStripMenuItem.Text = "New Sale";
            newSaleToolStripMenuItem.Click += newSaleToolStripMenuItem_Click;
            // 
            // viewSalesToolStripMenuItem
            // 
            viewSalesToolStripMenuItem.Name = "viewSalesToolStripMenuItem";
            viewSalesToolStripMenuItem.Size = new Size(359, 44);
            viewSalesToolStripMenuItem.Text = "View Sales";
            viewSalesToolStripMenuItem.Click += viewSalesToolStripMenuItem_Click;
            // 
            // ordersToolStripMenuItem
            // 
            ordersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewOrdersToolStripMenuItem, createOrderToolStripMenuItem });
            ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            ordersToolStripMenuItem.Size = new Size(105, 38);
            ordersToolStripMenuItem.Text = "Orders";
            // 
            // viewOrdersToolStripMenuItem
            // 
            viewOrdersToolStripMenuItem.Name = "viewOrdersToolStripMenuItem";
            viewOrdersToolStripMenuItem.Size = new Size(284, 44);
            viewOrdersToolStripMenuItem.Text = "View Orders";
            viewOrdersToolStripMenuItem.Click += viewOrdersToolStripMenuItem_Click;
            // 
            // createOrderToolStripMenuItem
            // 
            createOrderToolStripMenuItem.Name = "createOrderToolStripMenuItem";
            createOrderToolStripMenuItem.Size = new Size(284, 44);
            createOrderToolStripMenuItem.Text = "Create Order";
            createOrderToolStripMenuItem.Click += createOrderToolStripMenuItem_Click;
            // 
            // suppliersToolStripMenuItem
            // 
            suppliersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewSuppliersToolStripMenuItem, addSupplierToolStripMenuItem });
            suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            suppliersToolStripMenuItem.Size = new Size(132, 38);
            suppliersToolStripMenuItem.Text = "Suppliers";
            // 
            // viewSuppliersToolStripMenuItem
            // 
            viewSuppliersToolStripMenuItem.Name = "viewSuppliersToolStripMenuItem";
            viewSuppliersToolStripMenuItem.Size = new Size(303, 44);
            viewSuppliersToolStripMenuItem.Text = "View Suppliers";
            viewSuppliersToolStripMenuItem.Click += viewSuppliersToolStripMenuItem_Click;
            // 
            // addSupplierToolStripMenuItem
            // 
            addSupplierToolStripMenuItem.Name = "addSupplierToolStripMenuItem";
            addSupplierToolStripMenuItem.Size = new Size(303, 44);
            addSupplierToolStripMenuItem.Text = "Add Supplier";
            addSupplierToolStripMenuItem.Click += addSupplierToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salesReportToolStripMenuItem, inventoryReportToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(114, 38);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // salesReportToolStripMenuItem
            // 
            salesReportToolStripMenuItem.Name = "salesReportToolStripMenuItem";
            salesReportToolStripMenuItem.Size = new Size(325, 44);
            salesReportToolStripMenuItem.Text = "Sales Report";
            salesReportToolStripMenuItem.Click += salesReportToolStripMenuItem_Click;
            // 
            // inventoryReportToolStripMenuItem
            // 
            inventoryReportToolStripMenuItem.Name = "inventoryReportToolStripMenuItem";
            inventoryReportToolStripMenuItem.Size = new Size(325, 44);
            inventoryReportToolStripMenuItem.Text = "Inventory Report";
            inventoryReportToolStripMenuItem.Click += inventoryReportToolStripMenuItem_Click;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 40);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1489, 798);
            mainPanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1489, 838);
            Controls.Add(mainPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "BookHaven - Management System";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            Click += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem dashboardToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem booksToolStripMenuItem;
        private ToolStripMenuItem viewBooksToolStripMenuItem;
        private ToolStripMenuItem addBooksToolStripMenuItem;
        private ToolStripMenuItem manageInventoryToolStripMenuItem;
        private ToolStripMenuItem customersToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem addCustomerToolStripMenuItem;
        private ToolStripMenuItem salesToolStripMenuItem;
        private ToolStripMenuItem newSaleToolStripMenuItem;
        private ToolStripMenuItem viewSalesToolStripMenuItem;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem viewOrdersToolStripMenuItem;
        private ToolStripMenuItem createOrderToolStripMenuItem;
        private ToolStripMenuItem suppliersToolStripMenuItem;
        private ToolStripMenuItem viewSuppliersToolStripMenuItem;
        private ToolStripMenuItem addSupplierToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem salesReportToolStripMenuItem;
        private ToolStripMenuItem inventoryReportToolStripMenuItem;
        private Panel mainPanel;
    }
}
