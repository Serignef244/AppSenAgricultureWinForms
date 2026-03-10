using AppSenAgriculture.Views.Commande;
using AppSenAgriculture.Views.Parametre;
using AppSenAgriculture.Views.Stock;
using Microsoft.VisualBasic.Devices;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppSenAgriculture
{
    public partial class frmMDI : Form
    {
        private Button _activeNavigationButton;

        public frmMDI()
        {
            InitializeComponent();
        }

        private void fermer()
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
            {
                chform.Close();
            }
        }

        private void SetActiveNavigation(Button activeButton, string title)
        {
            Button[] buttons =
            {
                btnProduit,
                btnCategorie,
                btnLieu,
                btnClient,
                btnCommande,
                btnStock,
                btnDeconnexion,
                btnQuitterApp
            };

            foreach (Button button in buttons)
            {
                button.BackColor = Color.Transparent;
                button.ForeColor = AppTheme.WarmCream;
                button.FlatAppearance.MouseOverBackColor = AppTheme.SavannaGreen;
            }

            if (activeButton != null)
            {
                activeButton.BackColor = AppTheme.BaobabOrange;
                activeButton.ForeColor = Color.White;
            }

            _activeNavigationButton = activeButton;
            lblTopTitle.Text = title;
        }

        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fermer();
                frmProduit f = new frmProduit();
                f.MdiParent = this;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
                SetActiveNavigation(btnProduit, "Produits");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmMDI.produitToolStripMenuItem_Click");
            }
        }

        private void seDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetActiveNavigation(btnDeconnexion, "Session");
            this.Close();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetActiveNavigation(btnQuitterApp, "Application");
            Application.Exit();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fermer();
                frmCategorie f = new frmCategorie();
                f.MdiParent = this;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
                SetActiveNavigation(btnCategorie, "Categories");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmMDI.cToolStripMenuItem_Click");
            }
        }

        private void lieuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fermer();
                frmLieu f = new frmLieu();
                f.MdiParent = this;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
                SetActiveNavigation(btnLieu, "Lieux");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmMDI.lieuToolStripMenuItem_Click");
            }
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fermer();
                frmClient f = new frmClient();
                f.MdiParent = this;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
                SetActiveNavigation(btnClient, "Clients");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmMDI.clientToolStripMenuItem_Click");
            }
        }

        private void commandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fermer();
                frmCommande f = new frmCommande();
                f.MdiParent = this;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
                SetActiveNavigation(btnCommande, "Commandes");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmMDI.commandeToolStripMenuItem_Click");
            }
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fermer();
                frmStock f = new frmStock();
                f.MdiParent = this;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
                SetActiveNavigation(btnStock, "Stock");
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmMDI.stockToolStripMenuItem_Click");
            }
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.WindowState = FormWindowState.Maximized;

            foreach (Control control in Controls)
            {
                MdiClient client = control as MdiClient;
                if (client != null)
                {
                    client.BackColor = AppTheme.WarmCream;
                    break;
                }
            }

            SetActiveNavigation(_activeNavigationButton, "Tableau de bord");
        }
    }
}
