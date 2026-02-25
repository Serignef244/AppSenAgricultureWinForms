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
                MessageBox.Show(
                    "Erreur au demarrage: " + ex.Message,
                    "Demarrage",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
