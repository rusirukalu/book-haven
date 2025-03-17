using System;
using System.Windows.Forms;
using BookHaven.Utilities;

namespace BookHaven
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Test database connection before showing the login form
            if (DBConnection.TestConnection())
            {
                // Connection successful, proceed to login form
                Application.Run(new LoginForm());
            }
            else
            {
                // Connection failed, show error message
                MessageBox.Show("Failed to connect to database. Please check your connection settings.",
                    "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // You can either exit or still try to start the application
                // Uncomment the line below to exit the application if connection fails
                // Application.Exit();

                // Or continue anyway
                Application.Run(new LoginForm());
            }
        }
    }
}
