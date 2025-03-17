using System;
using System.Collections.Generic;
using BookHaven.Models;
using BookHaven.Utilities;
using MySql.Data.MySqlClient;

namespace BookHaven.Controllers
{
    public class SupplierManager
    {
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM suppliers ORDER BY name";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier
                            {
                                SupplierID = Convert.ToInt32(reader["supplier_id"]),
                                Name = reader["name"].ToString(),
                                ContactPerson = reader["contact_person"].ToString(),
                                Email = reader["email"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Address = reader["address"].ToString(),
                                IsActive = Convert.ToBoolean(reader["is_active"])
                            };

                            suppliers.Add(supplier);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving suppliers: " + ex.Message);
            }

            return suppliers;
        }

        public void AddSupplier(Supplier supplier)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO suppliers (name, contact_person, email, phone, address, is_active) " +
                                  "VALUES (@name, @contactPerson, @email, @phone, @address, @isActive)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", supplier.Name);
                    cmd.Parameters.AddWithValue("@contactPerson", supplier.ContactPerson);
                    cmd.Parameters.AddWithValue("@email", supplier.Email);
                    cmd.Parameters.AddWithValue("@phone", supplier.Phone);
                    cmd.Parameters.AddWithValue("@address", supplier.Address);
                    cmd.Parameters.AddWithValue("@isActive", supplier.IsActive);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding supplier: " + ex.Message);
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE suppliers SET name = @name, contact_person = @contactPerson, " +
                                  "email = @email, phone = @phone, address = @address, is_active = @isActive " +
                                  "WHERE supplier_id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", supplier.Name);
                    cmd.Parameters.AddWithValue("@contactPerson", supplier.ContactPerson);
                    cmd.Parameters.AddWithValue("@email", supplier.Email);
                    cmd.Parameters.AddWithValue("@phone", supplier.Phone);
                    cmd.Parameters.AddWithValue("@address", supplier.Address);
                    cmd.Parameters.AddWithValue("@isActive", supplier.IsActive);
                    cmd.Parameters.AddWithValue("@id", supplier.SupplierID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating supplier: " + ex.Message);
            }
        }

        public void DeleteSupplier(int supplierId)
        {
            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM suppliers WHERE supplier_id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", supplierId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting supplier: " + ex.Message);
            }
        }
    }
}
