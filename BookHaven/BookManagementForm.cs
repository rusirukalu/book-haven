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

namespace BookHaven
{
    public partial class BookManagementForm : Form
    {
        private BookManager bookManager;
        private List<Book> books;
        private Book selectedBook;

        public BookManagementForm()
        {
            InitializeComponent();
            bookManager = new BookManager();
        }

        private void BookManagementForm_Load(object sender, EventArgs e)
        {
            // Ensure this runs after the form is fully initialized
            this.BeginInvoke(new Action(() => {
                LoadBooks();
                ClearFields();
            }));
        }

        private void LoadBooks()
        {
            try
            {
                books = bookManager.GetAllBooks();

                // Make sure there's data before binding
                if (books == null || books.Count == 0)
                {
                    MessageBox.Show("No books found in the database.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Clear and set DataSource
                dataGridViewBooks.DataSource = null;
                dataGridViewBooks.DataSource = books;

                // Format the DataGridView columns
                FormatDataGridView();

                // Force refresh and update
                dataGridViewBooks.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            // Set column headers and widths
            dataGridViewBooks.Columns["BookID"].HeaderText = "ID";
            dataGridViewBooks.Columns["Title"].HeaderText = "Title";
            dataGridViewBooks.Columns["Author"].HeaderText = "Author";
            dataGridViewBooks.Columns["ISBN"].HeaderText = "ISBN";
            dataGridViewBooks.Columns["Genre"].HeaderText = "Genre";
            dataGridViewBooks.Columns["Price"].HeaderText = "Price";
            dataGridViewBooks.Columns["StockQuantity"].HeaderText = "Stock";

            // Set column widths
            dataGridViewBooks.Columns["BookID"].Width = 50;
            dataGridViewBooks.Columns["Title"].Width = 200;
            dataGridViewBooks.Columns["Author"].Width = 150;
            dataGridViewBooks.Columns["ISBN"].Width = 100;
            dataGridViewBooks.Columns["Genre"].Width = 100;
            dataGridViewBooks.Columns["Price"].Width = 80;
            dataGridViewBooks.Columns["StockQuantity"].Width = 80;
        }

        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedIndex = e.RowIndex;
                if (selectedIndex >= 0 && selectedIndex < books.Count)
                {
                    selectedBook = books[selectedIndex];
                    DisplayBookDetails(selectedBook);
                }
            }
        }

        private void DisplayBookDetails(Book book)
        {
            txtTitle.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtISBN.Text = book.ISBN;
            txtGenre.Text = book.Genre;
            txtPrice.Text = book.Price.ToString();
            txtStock.Text = book.StockQuantity.ToString();
        }

        private void ClearFields()
        {
            txtTitle.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtISBN.Text = string.Empty;
            txtGenre.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtStock.Text = string.Empty;
            selectedBook = null;
        }

        private Book GetBookFromFields()
        {
            Book book = new Book();

            if (selectedBook != null)
            {
                book.BookID = selectedBook.BookID;
            }

            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.ISBN = txtISBN.Text;
            book.Genre = txtGenre.Text;

            decimal price;
            if (decimal.TryParse(txtPrice.Text, out price))
            {
                book.Price = price;
            }
            else
            {
                throw new Exception("Invalid price format");
            }

            int stock;
            if (int.TryParse(txtStock.Text, out stock))
            {
                book.StockQuantity = stock;
            }
            else
            {
                throw new Exception("Invalid stock quantity format");
            }

            return book;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateBookFields())
                {
                    Book newBook = GetBookFromFields();
                    bookManager.AddBook(newBook);

                    MessageBox.Show("Book added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBooks();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "adding a book");
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBook == null)
                {
                    MessageBox.Show("Please select a book to update", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ValidateBookFields())
                {
                    Book updatedBook = GetBookFromFields();
                    bookManager.UpdateBook(updatedBook);

                    MessageBox.Show("Book updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedBook == null)
                {
                    MessageBox.Show("Please select a book to delete", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete '{selectedBook.Title}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bookManager.DeleteBook(selectedBook.BookID);

                        MessageBox.Show("Book deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadBooks();
                        ClearFields();
                    }
                    catch (MySqlException ex)
                    {
                        // Check if this is a foreign key constraint error (MySQL error code 1451)
                        if (ex.Number == 1451)
                        {
                            MessageBox.Show(
                                "This book cannot be deleted because it is part of existing orders or sales.\n\n" +
                                "To maintain accurate sales history, books that have been purchased cannot be removed.\n\n" +
                                "You can instead update the book or mark it as out of stock.",
                                "Cannot Delete Book",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Handle other database errors
                            MessageBox.Show("Database error: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting book: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // real-time search
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadBooks();
                return;
            }

            try
            {
                List<Book> searchResults = books.FindAll(b =>
                    b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

                dataGridViewBooks.DataSource = null;
                dataGridViewBooks.DataSource = searchResults;

                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching books: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadBooks();
                return;
            }

            try
            {
                List<Book> searchResults = books.FindAll(b =>
                    b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    b.ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

                dataGridViewBooks.DataSource = null;
                dataGridViewBooks.DataSource = searchResults;

                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching books: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadBooks();
        }

        private bool ValidateBookFields()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Author is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("ISBN is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!ValidationHelper.IsValidISBN(txtISBN.Text))
            {
                MessageBox.Show("Invalid ISBN format. ISBN must be 10 or 13 digits.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text, out price) || !ValidationHelper.IsValidPrice(price))
            {
                MessageBox.Show("Please enter a valid price (must be 0 or greater)", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int stock;
            if (!int.TryParse(txtStock.Text, out stock) || !ValidationHelper.IsValidQuantity(stock))
            {
                MessageBox.Show("Please enter a valid stock quantity (must be 0 or greater)", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void panelSearch_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBoxBookDetails_Enter(object sender, EventArgs e)
        {

        }

        private void txtISBN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGenre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
