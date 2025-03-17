using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.Utilities;
using BookHaven.Models;

namespace BookHaven
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string role = cmbRole.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Please enter username, password and select a role.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                User user = AuthenticateUser(username, password, role);

                if (user != null)
                {
                    MainForm mainForm = new MainForm(user);
                    this.Hide();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username, password, or role.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "logging in");
            }
        }

        private User AuthenticateUser(string username, string password, string role)
        {
            User user = null;

            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM users WHERE username = @username AND role = @role AND is_active = TRUE";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@role", role);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["password_hash"].ToString();
                            string storedSalt = reader["salt"].ToString();

                            // If salt is empty (for old records), use direct comparison
                            bool passwordValid = string.IsNullOrEmpty(storedSalt)
                                ? storedHash == password
                                : SecurityHelper.VerifyPassword(password, storedHash, storedSalt);

                            if (passwordValid)
                            {
                                user = new User
                                {
                                    UserID = Convert.ToInt32(reader["user_id"]),
                                    Username = reader["username"].ToString(),
                                    PasswordHash = storedHash,
                                    Salt = storedSalt,
                                    Role = reader["role"].ToString(),
                                    IsActive = Convert.ToBoolean(reader["is_active"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "authenticating user");
            }

            return user;
        }
    }
}
