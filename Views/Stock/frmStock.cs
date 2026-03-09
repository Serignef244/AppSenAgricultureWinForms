using AppSenAgriculture;
using AppSenAgriculture.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Stock
{
    public partial class frmStock : Form
    {
        private BdSenAgricultureContext db;
        private bool _isLoaded;

        public frmStock()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return;
                }
                db = new BdSenAgricultureContext();
                _isLoaded = true;
                ChargerProduits();
                ChargerStocks();
                AfficherInfosProduit();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmStock.OnLoad");
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.OnFormClosed(e);
        }

        private void ChargerProduits()
        {
            cmbProduit.DataSource = db.Produits
                .OrderBy(p => p.LibelleProduit)
                .Select(p => new
                {
                    p.IdProduit,
                    p.LibelleProduit,
                    p.PrixUnitaireMin,
                    p.PrixUnitaireMax
                })
                .ToList();
            cmbProduit.DisplayMember = "LibelleProduit";
            cmbProduit.ValueMember = "IdProduit";
        }

        private void ChargerStocks()
        {
            dgStock.DataSource = db.Stocks
                .Select(s => new
                {
                    s.Id,
                    s.IdProduit,
                    Produit = s.Produit.LibelleProduit,
                    QuantiteDisponible = s.QuanteStock,
                    PrixUnitaire = s.Pu,
                    DateMaj = s.Date
                })
                .OrderBy(s => s.Produit)
                .ToList();

            if (dgStock.Columns.Contains("IdProduit"))
            {
                dgStock.Columns["IdProduit"].Visible = false;
            }
        }

        private dynamic ProduitSelectionne()
        {
            return cmbProduit.SelectedItem;
        }

        private bool TryGetSelectedProduitId(out int idProduit)
        {
            idProduit = 0;
            if (cmbProduit.SelectedValue == null)
            {
                return false;
            }

            if (cmbProduit.SelectedValue is int)
            {
                idProduit = (int)cmbProduit.SelectedValue;
                return true;
            }

            return int.TryParse(cmbProduit.SelectedValue.ToString(), out idProduit);
        }

        private void AfficherInfosProduit()
        {
            if (cmbProduit.SelectedValue == null)
            {
                lblPrixMinMax.Text = "Prix min/max: -";
                lblQuantiteDisponible.Text = "Stock disponible: -";
                return;
            }

            dynamic p = ProduitSelectionne();
            lblPrixMinMax.Text = "Prix min/max: " + p.PrixUnitaireMin.ToString("N2") + " - " + p.PrixUnitaireMax.ToString("N2");

            int idProduit;
            if (!TryGetSelectedProduitId(out idProduit))
            {
                lblQuantiteDisponible.Text = "Stock disponible: -";
                return;
            }
            int disponible = db.Stocks
                .Where(s => s.IdProduit == idProduit)
                .Select(s => (int?)s.QuanteStock)
                .FirstOrDefault() ?? 0;
            lblQuantiteDisponible.Text = "Stock disponible: " + disponible;
        }

        private bool LireSaisie(out int quantite)
        {
            quantite = 0;

            int idProduit;
            if (!TryGetSelectedProduitId(out idProduit))
            {
                MessageBox.Show("Selectionnez un produit.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtQuantite.Text.Trim(), out quantite) || quantite <= 0)
            {
                MessageBox.Show("La quantite est invalide.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantite.Focus();
                return false;
            }

            return true;
        }

        private AppSenAgriculture.Models.Stock StockParProduit(int idProduit)
        {
            return db.Stocks.FirstOrDefault(s => s.IdProduit == idProduit);
        }

        private void btnApprovisionner_Click(object sender, EventArgs e)
        {
            try
            {
                int quantite;
                if (!LireSaisie(out quantite))
                {
                    return;
                }

                int idProduit;
                if (!TryGetSelectedProduitId(out idProduit))
                {
                    MessageBox.Show("Selectionnez un produit.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AppSenAgriculture.Models.Stock stock = StockParProduit(idProduit);
                if (stock == null)
                {
                    stock = new AppSenAgriculture.Models.Stock
                    {
                        IdProduit = idProduit,
                        QuanteStock = 0,
                        Date = DateTime.Now,
                        DateDispo = DateTime.Now,
                        DatePaiement = DateTime.Now,
                        Pu = 0
                    };
                    db.Stocks.Add(stock);
                }

                stock.QuanteStock += quantite;
                stock.Date = DateTime.Now;
                stock.DateDispo = DateTime.Now;
                stock.DatePaiement = DateTime.Now;
                db.SaveChanges();

                txtQuantite.Clear();
                ChargerStocks();
                AfficherInfosProduit();
                MessageBox.Show("Stock mis à jour avec succès.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmStock.btnApprovisionner_Click");
            }
        }

        private void cmbProduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded || db == null)
            {
                return;
            }
            AfficherInfosProduit();
        }
    }
}
