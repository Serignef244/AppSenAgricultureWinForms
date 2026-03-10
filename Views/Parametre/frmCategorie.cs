using AppSenAgriculture;
using AppSenAgriculture.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Parametre
{
    public partial class frmCategorie : Form
    {
        private BdSenAgricultureContext db;
        private bool _isLoaded;

        public frmCategorie()
        {
            InitializeComponent();
            ApplyVisualStyle();
        }

        private void ApplyVisualStyle()
        {
            AppTheme.ApplyFormTheme(this);
            AppTheme.StyleInput(txtLibelle);
            AppTheme.StyleInput(txtDescription);
            AppTheme.StyleInput(txtRecherche);
            AppTheme.StyleLabel(label1);
            AppTheme.StyleLabel(label2);
            AppTheme.StyleLabel(lblRecherche);
            AppTheme.StyleButton(btnAjouter, AppTheme.SavannaGreen, Color.White);
            AppTheme.StyleButton(btnModifier, AppTheme.Ochre, Color.White);
            AppTheme.StyleButton(btnSupprimer, AppTheme.Danger, Color.White);
            AppTheme.StyleButton(btnSelection, Color.White, AppTheme.Anthracite);
            AppTheme.StyleGrid(dgCategorie);

            txtDescription.Height = 150;
            btnSelection.Width = 170;
            btnSelection.Height = 40;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void frmCategorie_Load(object sender, EventArgs e)
        {
            try
            {
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return;
                }

                db = new BdSenAgricultureContext();
                _isLoaded = true;
                //on le recupere avec ORM
                effacerChamps();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmCategorie.Load");
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

        //effacer le champs

        public void effacerChamps()
        {
            txtLibelle.Clear();
            txtDescription.Clear();
            ChargerCategories(txtRecherche.Text.Trim());
            txtLibelle.Focus();
        }

        private void ChargerCategories(string recherche)
        {
            var query = db.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(recherche))
            {
                query = query.Where(c =>
                    c.Libelle.Contains(recherche) ||
                    c.DescriptionCategorie.Contains(recherche));
            }

            dgCategorie.DataSource = query
                .OrderBy(c => c.Libelle)
                .Select(c => new
                {
                    c.IdCategorie,
                    c.Libelle,
                    c.DescriptionCategorie
                })
                .ToList();

            if (dgCategorie.Columns.Contains("IdCategorie"))
            {
                dgCategorie.Columns["IdCategorie"].Visible = false;
            }
        }

        private bool SelectionValide()
        {
            return dgCategorie.CurrentRow != null && dgCategorie.CurrentRow.Cells.Count > 0;
        }

        /// <summary>
        /// Ajouter  un Categorie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLibelle.Text))
                {
                    MessageBox.Show("Le libelle est obligatoire.", "Categorie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLibelle.Focus();
                    return;
                }

                Categorie cat = new Categorie()
                {
                    Libelle = txtLibelle.Text.Trim(),
                    DescriptionCategorie = txtDescription.Text.Trim(),

                };
                //permet d'ajouter dans le cache db
                db.Categories.Add(cat);
                db.SaveChanges();
                effacerChamps();
                MessageBox.Show("Categorie ajoutée avec succès.", "Categorie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmCategorie.btnAjouter_Click");
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SelectionValide())
                {
                    MessageBox.Show("Selectionnez une categorie.", "Categorie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLibelle.Text))
                {
                    MessageBox.Show("Le libelle est obligatoire.", "Categorie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLibelle.Focus();
                    return;
                }

                int id = Convert.ToInt32(dgCategorie.CurrentRow.Cells[0].Value);

                Categorie cat = db.Categories.Find(id);

                if (cat != null)
                {
                    cat.Libelle = txtLibelle.Text.Trim();
                    cat.DescriptionCategorie = txtDescription.Text.Trim();
                    db.SaveChanges();
                    effacerChamps();
                    MessageBox.Show("Categorie modifiée avec succès.", "Categorie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmCategorie.btnModifier_Click");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SelectionValide())
                {
                    MessageBox.Show("Selectionnez une categorie.", "Categorie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Voulez-vous supprimer cette categorie ?", "Categorie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                int id = Convert.ToInt32(dgCategorie.CurrentRow.Cells[0].Value);
                Categorie cat = db.Categories.Find(id);
                if (cat != null)
                {
                    db.Categories.Remove(cat);
                    db.SaveChanges();
                    effacerChamps();
                    MessageBox.Show("Categorie supprimée avec succès.", "Categorie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmCategorie.btnSupprimer_Click");
            }
        }

        private void btnSelection_Click(object sender, EventArgs e)
        {
            if (!SelectionValide())
            {
                MessageBox.Show("Selectionnez une categorie.", "Categorie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtLibelle.Text = dgCategorie.CurrentRow.Cells[1].Value.ToString();
            txtDescription.Text = dgCategorie.CurrentRow.Cells[2].Value.ToString();

        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            if (!_isLoaded || db == null)
            {
                return;
            }
            ChargerCategories(txtRecherche.Text.Trim());
        }
    }
}
