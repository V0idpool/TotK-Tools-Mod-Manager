using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotKModManager
{
    internal class ExceptionHandler
    {
       public static void LogError(Exception ex)
        {
            try
            {
                // Specify the path to your log file
                string logFilePath = Application.StartupPath + @"\log_file.txt";

                // Create or append to the log file
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    // Log the unhandled exception details to the file
                    writer.WriteLine($"[{DateTime.Now}] - Unhandled Exception Type: {ex.GetType().FullName}");
                    writer.WriteLine($"Message: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine(); // Add an empty line for better readability
                }

                Console.WriteLine($"Error details logged to: {logFilePath}");
            }
            catch (Exception logEx)
            {
                // If logging itself fails, you may want to handle that as well
                Console.WriteLine("Error logging failed: " + logEx.Message);
            }
        }
        public static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = e.ExceptionObject as Exception;

            if (exception != null)
            {
                // Log the type, message, and stack trace of the unhandled exception
                Console.WriteLine($"Unhandled Exception Type: {exception.GetType().FullName}");
                Console.WriteLine($"Message: {exception.Message}");
                Console.WriteLine($"StackTrace: {exception.StackTrace}");

                // Log the exception using your custom logging logic
                LogError(exception);
            }

            // Optionally, you can perform additional cleanup or actions before the application exits
            // Environment.Exit(1); // Terminate the application with a non-zero exit code
        }

    }
}
