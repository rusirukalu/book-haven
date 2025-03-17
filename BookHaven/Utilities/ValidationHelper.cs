using System;
using System.Linq;

namespace BookHaven.Utilities
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidISBN(string isbn)
        {
            // Remove any hyphens
            isbn = isbn.Replace("-", "");

            // Check if it's a valid ISBN-10 or ISBN-13
            return (isbn.Length == 10 || isbn.Length == 13) && isbn.All(char.IsDigit);
        }

        public static bool IsValidPrice(decimal price)
        {
            return price >= 0;
        }

        public static bool IsValidQuantity(int quantity)
        {
            return quantity >= 0;
        }
    }
}
