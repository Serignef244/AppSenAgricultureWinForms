using System;
using System.Windows.Forms;

namespace AppSenAgriculture
{
    public static class Logger
    {
        private static readonly string LogDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        private static readonly object LockObject = new object();

        private static string FormatExceptionDetails(Exception ex)
        {
            if (ex == null) return string.Empty;

            // ex.ToString() inclut déjà message + stack trace + inner exceptions,
            // mais on ajoute un séparateur pour la lisibilité.
            return ex.ToString();
        }

        /// <summary>
        /// Logs an exception to a daily text file.
        /// </summary>
        public static void WriteLog(Exception ex, string context = "")
        {
            if (ex == null) return;

            string details = FormatExceptionDetails(ex);
            string logEntry = string.Format(
                "[{0}] [ERROR] CONTEXT: {1}\nTYPE: {2}\nMESSAGE: {3}\nSTACK TRACE: {4}\nDETAILS: {5}\n{6}\n",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                context ?? "N/A",
                ex.GetType().FullName,
                ex.Message,
                ex.StackTrace,
                details,
                new string('-', 80)
            );

            WriteToFile(logEntry);

            if (System.Windows.Forms.Application.MessageLoop)
            {
                string displayMsg = string.IsNullOrEmpty(context)
                    ? $"Une erreur est survenue : {ex.Message}"
                    : $"Erreur dans context [{context}] : {ex.Message}";
                
                MessageBox.Show(displayMsg + "\n\nConsultez les fichiers de log dans le dossier 'logs' pour plus de détails.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        public static void LogInfo(string message, string context = "")
        {
            string logEntry = string.Format(
                "[{0}] [INFO] CONTEXT: {1}\nMESSAGE: {2}\n{3}\n",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                context ?? "N/A",
                message,
                new string('-', 80)
            );

            WriteToFile(logEntry);
        }

        private static void WriteToFile(string content)
        {
            try
            {
                lock (LockObject)
                {
                    if (!System.IO.Directory.Exists(LogDirectory))
                    {
                        System.IO.Directory.CreateDirectory(LogDirectory);
                    }

                    string fileName = $"log_{DateTime.Now:yyyyMMdd}.txt";
                    string filePath = System.IO.Path.Combine(LogDirectory, fileName);

                    System.IO.File.AppendAllText(filePath, content);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CRITICAL: Failed to write to log file: " + ex.Message);
            }
        }
    }
}
