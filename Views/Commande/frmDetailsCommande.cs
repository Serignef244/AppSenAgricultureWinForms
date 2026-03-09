using AppSenAgriculture;
using AppSenAgriculture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Commande
{
    public partial class frmDetailsCommande : Form
    {
        private BdSenAgricultureContext db;
        private bool _isLoaded;
        private int? idCommande;
        private string numeroCommande;
        private bool isValidee;
        private readonly List<LigneBrouillon> lignesBrouillon = new List<LigneBrouillon>();

        private class LigneBrouillon
        {
            public int IdProduit { get; set; }
            public string Produit { get; set; }
            public double Quantite { get; set; }
            public double PrixUnitaire { get; set; }
            public double Montant { get { return Quantite * PrixUnitaire; } }
        }

        private class ClientOption
        {
            public int? IdClient { get; set; }
            public string NomComplet { get; set; }
        }

        public frmDetailsCommande()
        {
            InitializeComponent();
        }

        public frmDetailsCommande(int idCommande, string numeroCommande)
        {
            this.idCommande = idCommande;
            this.numeroCommande = numeroCommande;
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
                ChargerClients();
                ChargerProduits();
                if (idCommande.HasValue)
                {
                    ChargerCommandePersistante();
                }
                else
                {
                    RafraichirAffichageBrouillon();
                }
                _isLoaded = true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmDetailsCommande.OnLoad");
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

        private void ChargerClients()
        {
            var clients = db.Clients
                .OrderBy(c => c.NomCompletPersonne)
                .Select(c => new ClientOption
                {
                    IdClient = c.IdPersonne,
                    NomComplet = c.NomCompletPersonne
                })
                .ToList();

            clients.Insert(0, new ClientOption
            {
                IdClient = null,
                NomComplet = "-"
            });

            cmbClient.DataSource = clients;
            cmbClient.DisplayMember = "NomComplet";
            cmbClient.ValueMember = "IdClient";
            cmbClient.SelectedIndex = 0;
        }

        private int? ClientSelectionne()
        {
            if (cmbClient.SelectedValue == null || cmbClient.SelectedValue == DBNull.Value)
            {
                return null;
            }

            if (cmbClient.SelectedValue is int)
            {
                return (int)cmbClient.SelectedValue;
            }

            int idClient;
            return int.TryParse(cmbClient.SelectedValue.ToString(), out idClient) ? (int?)idClient : null;
        }

        private void ChargerCommandePersistante()
        {
            var cmd = db.Commandes.Find(idCommande.Value);
            if (cmd == null)
            {
                MessageBox.Show("Commande introuvable.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            numeroCommande = cmd.NumeroCommande;
            isValidee = cmd.IsCommande;
            cmbClient.SelectedValue = cmd.IdClient.HasValue ? (object)cmd.IdClient.Value : null;
            if (cmbClient.SelectedValue == null)
            {
                cmbClient.SelectedIndex = 0;
            }

            lblHeader.Text = "Commande " + numeroCommande + " - " + (isValidee ? "Validee" : "En cours");
            string clientLibelle = cmd.Client != null ? cmd.Client.NomCompletPersonne : "-";
            lblMeta.Text = "Statut: " + (isValidee ? "Validee" : "En cours")
                + " | Client: " + clientLibelle
                + " | Date commande: " + cmd.DateCommande.ToString("yyyy-MM-dd HH:mm:ss")
                + " | Date modification: " + (cmd.DateModificationCommande.HasValue ? cmd.DateModificationCommande.Value.ToString("yyyy-MM-dd HH:mm:ss") : "-");

            dgDetails.DataSource = db.DetailsCommandes
                .Where(d => d.IdCommande == idCommande.Value)
                .Select(d => new
                {
                    d.IdDetailsCommande,
                    d.IdProduit,
                    Produit = d.Produit.LibelleProduit,
                    d.Quantite,
                    d.PrixUnitaire,
                    Montant = d.Quantite * d.PrixUnitaire
                })
                .OrderBy(d => d.IdDetailsCommande)
                .ToList();

            if (dgDetails.Columns.Contains("IdProduit"))
            {
                dgDetails.Columns["IdProduit"].Visible = false;
            }

            double total = db.DetailsCommandes
                .Where(d => d.IdCommande == idCommande.Value)
                .Select(d => (double?)d.Quantite * d.PrixUnitaire)
                .DefaultIfEmpty(0)
                .Sum() ?? 0;
            lblTotalCommande.Text = "Total: " + total.ToString("N2");

            AppliquerEtatValidation();
        }

        private void RafraichirAffichageBrouillon()
        {
            dgDetails.DataSource = lignesBrouillon
                .Select(d => new
                {
                    d.IdProduit,
                    d.Produit,
                    d.Quantite,
                    d.PrixUnitaire,
                    d.Montant
                })
                .ToList();

            if (dgDetails.Columns.Contains("IdProduit"))
            {
                dgDetails.Columns["IdProduit"].Visible = false;
            }

            double total = lignesBrouillon.Sum(d => d.Montant);
            lblTotalCommande.Text = "Total: " + total.ToString("N2");
            string clientBrouillon = cmbClient.SelectedItem != null ? ((ClientOption)cmbClient.SelectedItem).NomComplet : "-";
            lblMeta.Text = "Statut: Brouillon | Client: " + clientBrouillon + " | Date commande: - | Date modification: -";
            btnValider.Enabled = false;
        }

        private void AppliquerEtatValidation()
        {
            bool editable = !isValidee;
            btnAjouterDetail.Enabled = editable;
            btnModifierDetail.Enabled = editable;
            btnSupprimerDetail.Enabled = editable;
            btnChargerDetail.Enabled = editable;
            txtQuantite.Enabled = editable;
            txtPrixUnitaire.Enabled = editable;
            cmbProduit.Enabled = editable;
            cmbClient.Enabled = editable;
            btnEnregistrer.Enabled = editable;
            btnValider.Enabled = editable;
        }

        private bool SelectionDetailValide()
        {
            return dgDetails.CurrentRow != null;
        }

        private bool SaisieDetailValide(out double quantite, out double prixUnitaire)
        {
            quantite = 0;
            prixUnitaire = 0;

            if (cmbProduit.SelectedValue == null)
            {
                MessageBox.Show("Selectionnez un produit.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!double.TryParse(txtQuantite.Text.Trim(), out quantite) || quantite <= 0)
            {
                MessageBox.Show("La quantite est invalide.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!double.TryParse(txtPrixUnitaire.Text.Trim(), out prixUnitaire) || prixUnitaire < 0)
            {
                MessageBox.Show("Le prix unitaire est invalide.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            dynamic p = cmbProduit.SelectedItem;
            double min = Convert.ToDouble(p.PrixUnitaireMin);
            double max = Convert.ToDouble(p.PrixUnitaireMax);
            if (prixUnitaire < min || prixUnitaire > max)
            {
                MessageBox.Show(
                    "Le prix unitaire doit etre entre " + min.ToString("N2") + " et " + max.ToString("N2") + ".",
                    "Details commande",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtPrixUnitaire.Focus();
                return false;
            }

            return true;
        }

        private int StockDisponibleProduit(int idProduit)
        {
            return db.Stocks
                .Where(s => s.IdProduit == idProduit)
                .Select(s => (int?)s.QuanteStock)
                .FirstOrDefault() ?? 0;
        }

        private double QuantiteDejaSaisieBrouillon(int idProduit, int? indexExclu)
        {
            return lignesBrouillon
                .Where((l, idx) => l.IdProduit == idProduit && (!indexExclu.HasValue || idx != indexExclu.Value))
                .Sum(l => l.Quantite);
        }

        private double QuantiteDejaSaisieBase(int idProduit, int? idDetailExclu)
        {
            var query = db.DetailsCommandes.Where(d => d.IdCommande == idCommande.Value && d.IdProduit == idProduit);
            if (idDetailExclu.HasValue)
            {
                query = query.Where(d => d.IdDetailsCommande != idDetailExclu.Value);
            }

            return query.Select(d => (double?)d.Quantite).DefaultIfEmpty(0).Sum() ?? 0;
        }

        private void btnAjouterDetail_Click(object sender, EventArgs e)
        {
            try
            {
                double quantite;
                double prixUnitaire;
                if (!SaisieDetailValide(out quantite, out prixUnitaire))
                {
                    return;
                }

                if (!idCommande.HasValue)
                {
                    int idProduit = Convert.ToInt32(cmbProduit.SelectedValue);
                    int stockDisponible = StockDisponibleProduit(idProduit);
                    double dejaSaisie = QuantiteDejaSaisieBrouillon(idProduit, null);
                    if (dejaSaisie + quantite > stockDisponible)
                    {
                        MessageBox.Show(
                            "Quantite demandee superieure au stock disponible (" + stockDisponible + ").",
                            "Details commande",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    dynamic selectedItem = cmbProduit.SelectedItem;
                    lignesBrouillon.Add(new LigneBrouillon
                    {
                        IdProduit = idProduit,
                        Produit = selectedItem.LibelleProduit,
                        Quantite = quantite,
                        PrixUnitaire = prixUnitaire
                    });
                    RafraichirAffichageBrouillon();
                    return;
                }

                var detail = new DetailsCommande
                {
                    IdCommande = idCommande.Value,
                    IdProduit = Convert.ToInt32(cmbProduit.SelectedValue),
                    Quantite = quantite,
                    PrixUnitaire = prixUnitaire
                };

                int stockDisponibleBase = StockDisponibleProduit(detail.IdProduit);
                double dejaSaisieBase = QuantiteDejaSaisieBase(detail.IdProduit, null);
                if (dejaSaisieBase + quantite > stockDisponibleBase)
                {
                    MessageBox.Show(
                        "Quantite demandee superieure au stock disponible (" + stockDisponibleBase + ").",
                        "Details commande",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                db.DetailsCommandes.Add(detail);
                var cmd = db.Commandes.Find(idCommande.Value);
                if (cmd != null)
                {
                    cmd.DateModificationCommande = DateTime.Now;
                }
                db.SaveChanges();
                ChargerCommandePersistante();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmDetailsCommande.btnAjouterDetail_Click");
            }
        }

        private void btnModifierDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SelectionDetailValide())
                {
                    MessageBox.Show("Selectionnez une ligne.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                double quantite;
                double prixUnitaire;
                if (!SaisieDetailValide(out quantite, out prixUnitaire))
                {
                    return;
                }

                if (!idCommande.HasValue)
                {
                    int index = dgDetails.CurrentRow.Index;
                    if (index < 0 || index >= lignesBrouillon.Count)
                    {
                        return;
                    }
                    int idProduit = Convert.ToInt32(cmbProduit.SelectedValue);
                    int stockDisponible = StockDisponibleProduit(idProduit);
                    double dejaSaisie = QuantiteDejaSaisieBrouillon(idProduit, index);
                    if (dejaSaisie + quantite > stockDisponible)
                    {
                        MessageBox.Show(
                            "Quantite demandee superieure au stock disponible (" + stockDisponible + ").",
                            "Details commande",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }

                    dynamic selectedItem = cmbProduit.SelectedItem;
                    lignesBrouillon[index].IdProduit = idProduit;
                    lignesBrouillon[index].Produit = selectedItem.LibelleProduit;
                    lignesBrouillon[index].Quantite = quantite;
                    lignesBrouillon[index].PrixUnitaire = prixUnitaire;
                    RafraichirAffichageBrouillon();
                    return;
                }

                int idDetail = Convert.ToInt32(dgDetails.CurrentRow.Cells["IdDetailsCommande"].Value);
                var detail = db.DetailsCommandes.Find(idDetail);
                if (detail == null)
                {
                    return;
                }

                int idProduitBase = Convert.ToInt32(cmbProduit.SelectedValue);
                int stockDisponiblePersist = StockDisponibleProduit(idProduitBase);
                double dejaSaisiePersist = QuantiteDejaSaisieBase(idProduitBase, idDetail);
                if (dejaSaisiePersist + quantite > stockDisponiblePersist)
                {
                    MessageBox.Show(
                        "Quantite demandee superieure au stock disponible (" + stockDisponiblePersist + ").",
                        "Details commande",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                detail.IdProduit = idProduitBase;
                detail.Quantite = quantite;
                detail.PrixUnitaire = prixUnitaire;
                var cmd = db.Commandes.Find(idCommande.Value);
                if (cmd != null)
                {
                    cmd.DateModificationCommande = DateTime.Now;
                }
                db.SaveChanges();
                ChargerCommandePersistante();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmDetailsCommande.btnModifierDetail_Click");
            }
        }

        private void btnSupprimerDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SelectionDetailValide())
                {
                    MessageBox.Show("Selectionnez une ligne.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!idCommande.HasValue)
                {
                    int index = dgDetails.CurrentRow.Index;
                    if (index >= 0 && index < lignesBrouillon.Count)
                    {
                        lignesBrouillon.RemoveAt(index);
                        RafraichirAffichageBrouillon();
                    }
                    return;
                }

                int idDetail = Convert.ToInt32(dgDetails.CurrentRow.Cells["IdDetailsCommande"].Value);
                var detail = db.DetailsCommandes.Find(idDetail);
                if (detail == null)
                {
                    return;
                }
                db.DetailsCommandes.Remove(detail);
                var cmd = db.Commandes.Find(idCommande.Value);
                if (cmd != null)
                {
                    cmd.DateModificationCommande = DateTime.Now;
                }
                db.SaveChanges();
                ChargerCommandePersistante();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmDetailsCommande.btnSupprimerDetail_Click");
            }
        }

        private void btnChargerDetail_Click(object sender, EventArgs e)
        {
            if (!SelectionDetailValide())
            {
                return;
            }

            txtQuantite.Text = Convert.ToString(dgDetails.CurrentRow.Cells["Quantite"].Value);
            txtPrixUnitaire.Text = Convert.ToString(dgDetails.CurrentRow.Cells["PrixUnitaire"].Value);
            cmbProduit.SelectedValue = Convert.ToInt32(dgDetails.CurrentRow.Cells["IdProduit"].Value);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                if (idCommande.HasValue)
                {
                    MessageBox.Show("Commande deja enregistree.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (lignesBrouillon.Count == 0)
                {
                    MessageBox.Show("Ajoutez au moins une ligne avant enregistrement.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? idClient = ClientSelectionne();
                if (!idClient.HasValue)
                {
                    MessageBox.Show("Selectionnez un client avant enregistrement.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cmd = new AppSenAgriculture.Models.Commande
                {
                    NumeroCommande = "CMD-" + DateTime.Now.ToString("yyyyMMdd-HHmmss-fff"),
                    DateModificationCommande = DateTime.Now,
                    DateCommande = DateTime.Now,
                    IsCommande = false,
                    IdClient = idClient
                };
                db.Commandes.Add(cmd);
                db.SaveChanges();

                foreach (var l in lignesBrouillon)
                {
                    db.DetailsCommandes.Add(new DetailsCommande
                    {
                        IdCommande = cmd.IdCommande,
                        IdProduit = l.IdProduit,
                        Quantite = l.Quantite,
                        PrixUnitaire = l.PrixUnitaire
                    });
                }
                db.SaveChanges();

                idCommande = cmd.IdCommande;
                numeroCommande = cmd.NumeroCommande;
                lignesBrouillon.Clear();
                ChargerCommandePersistante();
                MessageBox.Show("Commande enregistrée avec succès.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmDetailsCommande.btnEnregistrer_Click");
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                if (!idCommande.HasValue)
                {
                    MessageBox.Show("Enregistrez d'abord la commande.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cmd = db.Commandes.Find(idCommande.Value);
                if (cmd == null)
                {
                    return;
                }

                if (cmd.IsCommande)
                {
                    MessageBox.Show("Cette commande est deja validee.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!cmd.IdClient.HasValue)
                {
                    MessageBox.Show("Associez un client a cette commande avant validation.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool aDetails = db.DetailsCommandes.Any(d => d.IdCommande == idCommande.Value);
                if (!aDetails)
                {
                    MessageBox.Show("La commande doit contenir au moins une ligne.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var besoinsStock = db.DetailsCommandes
                    .Where(d => d.IdCommande == idCommande.Value)
                    .GroupBy(d => d.IdProduit)
                    .Select(g => new
                    {
                        IdProduit = g.Key,
                        QuantiteDemandee = g.Sum(x => x.Quantite)
                    })
                    .ToList();

                foreach (var besoin in besoinsStock)
                {
                    var stock = db.Stocks.FirstOrDefault(s => s.IdProduit == besoin.IdProduit);
                    int disponible = stock != null ? stock.QuanteStock : 0;
                    if (disponible < besoin.QuantiteDemandee)
                    {
                        string libelleProduit = db.Produits
                            .Where(p => p.IdProduit == besoin.IdProduit)
                            .Select(p => p.LibelleProduit)
                            .FirstOrDefault() ?? ("ID " + besoin.IdProduit);

                        MessageBox.Show(
                            "Stock insuffisant pour le produit " + libelleProduit
                            + ". Disponible: " + disponible.ToString("N0")
                            + " | Demande: " + besoin.QuantiteDemandee.ToString("N0") + ".",
                            "Details commande",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        return;
                    }
                }

                foreach (var besoin in besoinsStock)
                {
                    var stock = db.Stocks.FirstOrDefault(s => s.IdProduit == besoin.IdProduit);
                    if (stock == null)
                    {
                        continue;
                    }

                    stock.QuanteStock -= Convert.ToInt32(Math.Ceiling(besoin.QuantiteDemandee));
                    stock.Date = DateTime.Now;
                }

                cmd.IsCommande = true;
                cmd.DateModificationCommande = DateTime.Now;
                db.SaveChanges();
                isValidee = true;
                ChargerCommandePersistante();
                MessageBox.Show("Commande validée et stock mis à jour.", "Details commande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmDetailsCommande.btnValider_Click");
            }
        }

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded)
            {
                return;
            }

            if (!idCommande.HasValue)
            {
                RafraichirAffichageBrouillon();
            }
        }
    }
}
