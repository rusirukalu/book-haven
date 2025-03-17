using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BookHaven.Utilities
{
    public static class DBConnection
    {
        private static string server = "localhost";
        private static string database = "bookhaven_db";
        private static string uid = "root";
        private static string password = "zyvsaR-xubvez-4mevni";

        private static string connectionString = "SERVER=localhost;DATABASE=bookhaven_db;UID=root;PASSWORD=zyvsaR-xubvez-4mevni;";

        public static MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed: " + ex.Message);
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
