using System;
using System.Windows.Forms;

namespace AppSenAgriculture
{
    public static class Logger
    {
        private static readonly string LogDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        private static readonly object LockObject = new object();

        /// <summary>
        /// Logs an exception to a daily text file.
        /// </summary>
        public static void WriteLog(Exception ex, string context = "")
        {
            if (ex == null) return;

            try
            {
                lock (LockObject)
                {
                    // Create directory if it doesn't exist
                    if (!System.IO.Directory.Exists(LogDirectory))
                    {
                        System.IO.Directory.CreateDirectory(LogDirectory);
                    }

                    // Create log file name based on current date
                    string fileName = $"log_{DateTime.Now:yyyyMMdd}.txt";
                    string filePath = System.IO.Path.Combine(LogDirectory, fileName);

                    // Prepare the log message
                    string logEntry = string.Format(
                        "[{0}] CONTEXT: {1}\nERROR: {2}\nMESSAGE: {3}\nSTACK TRACE: {4}\n{5}\n",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        context ?? "N/A",
                        ex.GetType().FullName,
                        ex.Message,
                        ex.StackTrace,
                        new string('-', 80)
                    );

                    // Append to file
                    System.IO.File.AppendAllText(filePath, logEntry);
                }

                // Show a user-friendly message for critical context errors if needed
                // But generally, global handlers will show the error via MessageBox in Part 1's skeleton if still present.
                // Let's refine the message box to be less intrusive or only for UI errors.
                if (System.Windows.Forms.Application.MessageLoop)
                {
                    // Optionally show message box here or let the calling catch block handle it.
                    // Keep the Part 1 MessageBox logic but refined.
                    string displayMsg = string.IsNullOrEmpty(context)
                        ? $"Une erreur est survenue : {ex.Message}"
                        : $"Erreur dans context [{context}] : {ex.Message}";
                    
                    MessageBox.Show(displayMsg + "\n\nConsultez les fichiers de log dans le dossier 'logs' pour plus de détails.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                // Prevent Logger from crashing the app if logging itself fails (e.g. disk full)
                System.Diagnostics.Debug.WriteLine("CRITICAL: Failed to write to log file.");
            }
        }
    }
}
