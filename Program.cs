using System;
using System.Data.Entity.Migrations;
using System.Windows.Forms;
using AppSenAgriculture.Migrations;

namespace AppSenAgriculture
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Set up global exception handling
            Application.ThreadException += (sender, e) => Logger.WriteLog(e.Exception, "Global UI Thread");
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => Logger.WriteLog(e.ExceptionObject as Exception, "Global Non-UI Thread");
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            try
            {
                // Apply pending EF migrations at startup to ensure required tables exist.
                var migrator = new DbMigrator(new Configuration());
                migrator.Update();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmConnexion());
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "Program.Main");
            }
        }
    }
}
