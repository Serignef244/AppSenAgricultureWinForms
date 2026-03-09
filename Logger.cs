using System;
using System.Windows.Forms;

namespace AppSenAgriculture
{
    public static class Logger
    {
        /// <summary>
        /// Logs an exception. In Part 1, this only shows a MessageBox or writes to Debug.
        /// </summary>
        public static void WriteLog(Exception ex, string context = "")
        {
            try
            {
                string message = string.IsNullOrEmpty(context) 
                    ? $"Une erreur est survenue : {ex.Message}" 
                    : $"Erreur dans context [{context}] : {ex.Message}";

                // For Part 1, we just show a message box.
                // In Part 2, we will implement file writing.
                MessageBox.Show(message + "\n\nConsultez les logs pour plus de détails.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                System.Diagnostics.Debug.WriteLine($"[LOG - {DateTime.Now}] {context}: {ex}");
            }
            catch
            {
                // Prevent Logger from crashing the app
            }
        }
    }
}
