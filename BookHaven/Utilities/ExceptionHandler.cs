using System;
using System.IO;
using System.Windows.Forms;

namespace BookHaven.Utilities
{
    public static class ExceptionHandler
    {
        public static void HandleException(Exception ex, string operation)
        {
            // Log the exception
            LogException(ex, operation);

            // Display user-friendly message
            MessageBox.Show($"An error occurred while {operation}. Please try again or contact support.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void LogException(Exception ex, string operation)
        {
            try
            {
                // Log to file
                string logPath = Path.Combine(Application.StartupPath, "logs");
                Directory.CreateDirectory(logPath);

                string logFile = Path.Combine(logPath, $"error_log_{DateTime.Now:yyyyMMdd}.txt");

                using (StreamWriter writer = File.AppendText(logFile))
                {
                    writer.WriteLine($"[{DateTime.Now}] Error during {operation}");
                    writer.WriteLine($"Message: {ex.Message}");
                    writer.WriteLine($"Stack Trace: {ex.StackTrace}");
                    writer.WriteLine(new string('-', 50));
                }
            }
            catch
            {
                // If logging fails, at least we tried
            }
        }
    }
}
