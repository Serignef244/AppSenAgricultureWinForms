using AppSenAgriculture.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void frmCategorie_Load(object sender, EventArgs e)
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
        }

        private void btnModifier_Click(object sender, EventArgs e)
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
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
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
