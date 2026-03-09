using AppSenAgriculture;
using AppSenAgriculture.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Parametre
{
    public partial class frmProduit : Form
    {
        private BdSenAgricultureContext db;

        public frmProduit()
        {
            InitializeComponent();
        }

        private void frmProduit_Load(object sender, EventArgs e)
        {
            try
            {
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return;
                }

                db = new BdSenAgricultureContext();
                ChargerReferences();
                ChargerProduits();
                ReinitialiserSaisie();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmProduit.Load");
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

        private void ChargerReferences()
        {
            cmbCategorie.DataSource = db.Categories.OrderBy(c => c.Libelle).ToList();
            cmbCategorie.DisplayMember = "Libelle";
            cmbCategorie.ValueMember = "IdCategorie";

            cmbUnite.DataSource = db.UniteMesures.OrderBy(u => u.LibelleUnite).ToList();
            cmbUnite.DisplayMember = "LibelleUnite";
            cmbUnite.ValueMember = "IdUnite";
        }

        private void ChargerProduits()
        {
            var query = db.Produits.AsQueryable();
            AfficherProduits(query);
        }

        private void AfficherProduits(IQueryable<Produit> query)
        {
            dgProduits.DataSource = query
                .Select(p => new
                {
                    p.IdProduit,
                    p.LibelleProduit,
                    p.DescriptionProduit,
                    p.PrixUnitaireMin,
                    p.PrixUnitaireMax,
                    p.CategorieId,
                    Categorie = p.Categorie.Libelle,
                    p.IdUniteMesure,
                    Unite = p.UniteMesure.LibelleUnite
                })
                .OrderBy(p => p.LibelleProduit)
                .ToList();

            if (dgProduits.Columns.Contains("CategorieId"))
            {
                dgProduits.Columns["CategorieId"].Visible = false;
            }

            if (dgProduits.Columns.Contains("IdUniteMesure"))
            {
                dgProduits.Columns["IdUniteMesure"].Visible = false;
            }
        }

        private void RechercherProduits()
        {
            string libelle = txtRechercheLibelle.Text.Trim();
            string description = txtRechercheDescription.Text.Trim();
            string prixMinTexte = txtRecherchePrixMin.Text.Trim();

            var query = db.Produits.AsQueryable();

            if (!string.IsNullOrWhiteSpace(libelle))
            {
                query = query.Where(p => p.LibelleProduit.Contains(libelle));
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                query = query.Where(p => p.DescriptionProduit.Contains(description));
            }

            if (!string.IsNullOrWhiteSpace(prixMinTexte))
            {
                double prixUnitaireMin;
                if (!double.TryParse(prixMinTexte, out prixUnitaireMin))
                {
                    MessageBox.Show("Le prix minimum de recherche est invalide.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRecherchePrixMin.Focus();
                    return;
                }

                query = query.Where(p => p.PrixUnitaireMin >= prixUnitaireMin);
            }

            AfficherProduits(query);
        }

        private void ReinitialiserSaisie()
        {
            txtLibelleProduit.Clear();
            txtDescriptionProduit.Clear();
            txtPrixMin.Clear();
            txtPrixMax.Clear();

            if (cmbCategorie.Items.Count > 0)
            {
                cmbCategorie.SelectedIndex = 0;
            }

            if (cmbUnite.Items.Count > 0)
            {
                cmbUnite.SelectedIndex = 0;
            }

            txtLibelleProduit.Focus();
        }

        private bool SelectionValide()
        {
            return dgProduits.CurrentRow != null && dgProduits.CurrentRow.Cells.Count > 0;
        }

        private bool FormulaireValide()
        {
            if (string.IsNullOrWhiteSpace(txtLibelleProduit.Text))
            {
                MessageBox.Show("Le libelle du produit est obligatoire.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelleProduit.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescriptionProduit.Text))
            {
                MessageBox.Show("La description du produit est obligatoire.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescriptionProduit.Focus();
                return false;
            }

            double prixMin;
            double prixMax;
            if (!double.TryParse(txtPrixMin.Text.Trim(), out prixMin))
            {
                MessageBox.Show("Le prix minimum est invalide.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrixMin.Focus();
                return false;
            }

            if (!double.TryParse(txtPrixMax.Text.Trim(), out prixMax))
            {
                MessageBox.Show("Le prix maximum est invalide.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrixMax.Focus();
                return false;
            }

            if (prixMin > prixMax)
            {
                MessageBox.Show("Le prix minimum doit etre inferieur ou egal au prix maximum.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbCategorie.SelectedItem == null || cmbUnite.SelectedItem == null)
            {
                MessageBox.Show("Selectionnez la categorie et l'unite.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormulaireValide())
                {
                    return;
                }

                var produit = new Produit
                {
                    LibelleProduit = txtLibelleProduit.Text.Trim(),
                    DescriptionProduit = txtDescriptionProduit.Text.Trim(),
                    PrixUnitaireMin = Convert.ToDouble(txtPrixMin.Text.Trim()),
                    PrixUnitaireMax = Convert.ToDouble(txtPrixMax.Text.Trim()),
                    CategorieId = Convert.ToInt32(cmbCategorie.SelectedValue),
                    IdUniteMesure = Convert.ToInt32(cmbUnite.SelectedValue)
                };

                db.Produits.Add(produit);
                db.SaveChanges();
                ChargerProduits();
                ReinitialiserSaisie();
                MessageBox.Show("Produit ajouté avec succès.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmProduit.btnAjouter_Click");
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SelectionValide())
                {
                    MessageBox.Show("Selectionnez un produit.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!FormulaireValide())
                {
                    return;
                }

                int id = Convert.ToInt32(dgProduits.CurrentRow.Cells["IdProduit"].Value);
                var produit = db.Produits.Find(id);
                if (produit == null)
                {
                    MessageBox.Show("Produit introuvable.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                produit.LibelleProduit = txtLibelleProduit.Text.Trim();
                produit.DescriptionProduit = txtDescriptionProduit.Text.Trim();
                produit.PrixUnitaireMin = Convert.ToDouble(txtPrixMin.Text.Trim());
                produit.PrixUnitaireMax = Convert.ToDouble(txtPrixMax.Text.Trim());
                produit.CategorieId = Convert.ToInt32(cmbCategorie.SelectedValue);
                produit.IdUniteMesure = Convert.ToInt32(cmbUnite.SelectedValue);

                db.SaveChanges();
                ChargerProduits();
                ReinitialiserSaisie();
                MessageBox.Show("Produit modifié avec succès.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmProduit.btnModifier_Click");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SelectionValide())
                {
                    MessageBox.Show("Selectionnez un produit.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Voulez-vous supprimer ce produit ?", "Produit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                int id = Convert.ToInt32(dgProduits.CurrentRow.Cells["IdProduit"].Value);
                var produit = db.Produits.Find(id);
                if (produit == null)
                {
                    MessageBox.Show("Produit introuvable.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Produits.Remove(produit);
                db.SaveChanges();
                ChargerProduits();
                ReinitialiserSaisie();
                MessageBox.Show("Produit supprimé avec succès.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmProduit.btnSupprimer_Click");
            }
        }

        private void btnSelection_Click(object sender, EventArgs e)
        {
            if (!SelectionValide())
            {
                MessageBox.Show("Selectionnez un produit.", "Produit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtLibelleProduit.Text = dgProduits.CurrentRow.Cells["LibelleProduit"].Value.ToString();
            txtDescriptionProduit.Text = dgProduits.CurrentRow.Cells["DescriptionProduit"].Value.ToString();
            txtPrixMin.Text = dgProduits.CurrentRow.Cells["PrixUnitaireMin"].Value.ToString();
            txtPrixMax.Text = dgProduits.CurrentRow.Cells["PrixUnitaireMax"].Value.ToString();
            cmbCategorie.SelectedValue = Convert.ToInt32(dgProduits.CurrentRow.Cells["CategorieId"].Value);
            cmbUnite.SelectedValue = Convert.ToInt32(dgProduits.CurrentRow.Cells["IdUniteMesure"].Value);
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            RechercherProduits();
        }

        private void btnReinitialiserRecherche_Click(object sender, EventArgs e)
        {
            txtRechercheLibelle.Clear();
            txtRechercheDescription.Clear();
            txtRecherchePrixMin.Clear();
            ChargerProduits();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
