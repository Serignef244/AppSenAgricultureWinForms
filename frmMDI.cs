using AppSenAgriculture.Views.Commande;
using AppSenAgriculture.Models;
using AppSenAgriculture.Views.Parametre;
using AppSenAgriculture.Views.Stock;
using Microsoft.VisualBasic.Devices;
using System;
using System.Drawing;
using System.Linq;
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
                btnAccueil,
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
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Padding = new Padding(12, 0, 0, 0);
            }

            if (activeButton != null)
            {
                activeButton.BackColor = AppTheme.BaobabOrange;
                activeButton.ForeColor = Color.White;
            }

            _activeNavigationButton = activeButton;
            lblTopTitle.Text = title;
        }

        private void ShowDashboard(bool visible)
        {
            pnlDashboard.Visible = visible;
            if (visible)
            {
                lblTopTitle.Text = "Tableau de bord";
                lblTopSubtitle.Text = "Pilotage des produits, clients, commandes et stock";
            }
        }

        private void RefreshDashboardMetrics()
        {
            try
            {
                using (var db = new BdSenAgricultureContext())
                {
                    DateTime today = DateTime.Today;
                    DateTime tomorrow = today.AddDays(1);

                    int stockCritique = db.Stocks.Count(s => s.QuanteStock <= 5);
                    int commandesJour = db.Commandes.Count(c => c.DateCommande >= today && c.DateCommande < tomorrow);
                    int clientsTotal = db.Clients.Count();
                    int clientsActifs = db.Commandes
                        .Where(c => c.IdClient.HasValue)
                        .Select(c => c.IdClient.Value)
                        .Distinct()
                        .Count();

                    lblStockValue.Text = stockCritique.ToString() + " critiques";
                    lblCommandesValue.Text = commandesJour.ToString() + " / jour";
                    lblClientsValue.Text = clientsActifs.ToString() + " / " + clientsTotal.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmMDI.RefreshDashboardMetrics");
                lblStockValue.Text = "-";
                lblCommandesValue.Text = "-";
                lblClientsValue.Text = "-";
            }
        }

        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fermer();
                ShowDashboard(false);
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

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            fermer();
            RefreshDashboardMetrics();
            ShowDashboard(true);
            SetActiveNavigation(btnAccueil, "Tableau de bord");
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
                ShowDashboard(false);
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
                ShowDashboard(false);
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
                ShowDashboard(false);
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
                ShowDashboard(false);
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
                ShowDashboard(false);
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

            cardStock.BackColor = Color.White;
            cardCommandes.BackColor = Color.White;
            cardClients.BackColor = Color.White;
            lblDashboardHint.Font = AppTheme.UiFont(11F);
            lblDashboardHint.ForeColor = AppTheme.MutedText;
            lblStockCaption.Font = AppTheme.UiFont(11F, FontStyle.Bold);
            lblCommandesCaption.Font = AppTheme.UiFont(11F, FontStyle.Bold);
            lblClientsCaption.Font = AppTheme.UiFont(11F, FontStyle.Bold);
            lblStockValue.Font = AppTheme.TitleFont(18F);
            lblCommandesValue.Font = AppTheme.TitleFont(18F);
            lblClientsValue.Font = AppTheme.TitleFont(18F);
            lblStockValue.ForeColor = AppTheme.BaobabOrange;
            lblCommandesValue.ForeColor = AppTheme.SavannaGreen;
            lblClientsValue.ForeColor = AppTheme.Anthracite;

            RefreshDashboardMetrics();
            ShowDashboard(true);
            SetActiveNavigation(btnAccueil, "Tableau de bord");
        }
    }
}
