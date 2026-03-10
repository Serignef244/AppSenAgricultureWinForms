using AppSenAgriculture;
using AppSenAgriculture.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Commande
{
    public partial class frmCommande : Form
    {
        private BdSenAgricultureContext db;
        private bool _isLoaded;

        public frmCommande()
        {
            InitializeComponent();
            ApplyVisualStyle();
        }

        private void ApplyVisualStyle()
        {
            AppTheme.ApplyFormTheme(this);
            StyleInputs(this);
            AppTheme.StyleButton(btnNouvelleCommande, AppTheme.SavannaGreen, Color.White);
            AppTheme.StyleButton(btnSupprimerCommande, AppTheme.Danger, Color.White);
            AppTheme.StyleButton(btnDetailsCommande, AppTheme.Ochre, Color.White);
            AppTheme.StyleGrid(dgCommandes);
            dgCommandes.CellFormatting += dgCommandes_CellFormatting;
        }

        private void StyleInputs(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                TextBox textBox = control as TextBox;
                ComboBox comboBox = control as ComboBox;
                Label label = control as Label;
                DateTimePicker datePicker = control as DateTimePicker;

                if (textBox != null)
                {
                    AppTheme.StyleInput(textBox);
                }
                else if (comboBox != null)
                {
                    AppTheme.StyleComboBox(comboBox);
                }
                else if (label != null)
                {
                    AppTheme.StyleLabel(label);
                }
                else if (datePicker != null)
                {
                    datePicker.Font = AppTheme.UiFont(11F);
                    datePicker.CalendarMonthBackground = Color.White;
                }
            }
        }

        private void dgCommandes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgCommandes.Columns[e.ColumnIndex].Name != "Statut" || e.Value == null)
            {
                return;
            }

            string statut = e.Value.ToString();
            if (string.Equals(statut, "Validee", StringComparison.Ordinal))
            {
                e.CellStyle.BackColor = AppTheme.FreshGreen;
                e.CellStyle.ForeColor = Color.White;
            }
            else
            {
                e.CellStyle.BackColor = AppTheme.BaobabOrange;
                e.CellStyle.ForeColor = Color.White;
            }

            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            e.CellStyle.SelectionForeColor = Color.White;
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
                cmbFiltreStatut.SelectedIndex = 0;
                _isLoaded = true;
                ChargerCommandes();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmCommande.OnLoad");
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

        private void ChargerCommandes()
        {
            var query = db.Commandes.AsQueryable();

            string statut = cmbFiltreStatut.SelectedItem != null ? cmbFiltreStatut.SelectedItem.ToString() : "Tous";
            string clientRecherche = txtRechercheClient.Text.Trim();
            string produitRecherche = txtRechercheProduit.Text.Trim();
            bool filtrerDate = dtpRechercheDate.Checked;
            DateTime dateRecherche = dtpRechercheDate.Value.Date;

            if (string.Equals(statut, "En cours", StringComparison.Ordinal))
            {
                query = query.Where(c => !c.IsCommande);
            }
            else if (string.Equals(statut, "Validee", StringComparison.Ordinal))
            {
                query = query.Where(c => c.IsCommande);
            }

            if (!string.IsNullOrWhiteSpace(clientRecherche))
            {
                query = query.Where(c => c.Client != null && c.Client.NomCompletPersonne.Contains(clientRecherche));
            }

            if (!string.IsNullOrWhiteSpace(produitRecherche))
            {
                query = query.Where(c => c.DetailsCommandes.Any(d => d.Produit.LibelleProduit.Contains(produitRecherche)));
            }

            if (filtrerDate)
            {
                DateTime dateFin = dateRecherche.AddDays(1);
                query = query.Where(c => c.DateCommande >= dateRecherche && c.DateCommande < dateFin);
            }

            dgCommandes.DataSource = query
                .Select(c => new
                {
                    c.IdCommande,
                    c.NumeroCommande,
                    DateCommande = c.DateCommande,
                    DateModification = c.DateModificationCommande,
                    Statut = c.IsCommande ? "Validee" : "En cours",
                    Client = c.Client != null ? c.Client.NomCompletPersonne : "-",
                    Total = c.DetailsCommandes.Select(d => (double?)d.Quantite * d.PrixUnitaire).DefaultIfEmpty(0).Sum()
                })
                .OrderByDescending(c => c.DateCommande)
                .ToList()
                .Select(c => new
                {
                    c.IdCommande,
                    c.NumeroCommande,
                    c.DateCommande,
                    c.DateModification,
                    c.Statut,
                    c.Client,
                    c.Total,
                    Produits = string.Join(", ", db.DetailsCommandes
                        .Where(d => d.IdCommande == c.IdCommande)
                        .Select(d => d.Produit.LibelleProduit)
                        .Distinct()
                        .Take(5)
                        .ToList())
                })
                .ToList();

            if (dgCommandes.Columns.Contains("Total"))
            {
                dgCommandes.Columns["Total"].DefaultCellStyle.Format = "N2";
            }
        }

        private bool SelectionCommandeValide()
        {
            return dgCommandes.CurrentRow != null && dgCommandes.CurrentRow.Cells["IdCommande"] != null;
        }

        private int GetCommandeSelectionnee()
        {
            return Convert.ToInt32(dgCommandes.CurrentRow.Cells["IdCommande"].Value);
        }

        private void btnNouvelleCommande_Click(object sender, EventArgs e)
        {
            try
            {
                using (var f = new frmDetailsCommande())
                {
                    f.ShowDialog(this);
                }
                ChargerCommandes();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmCommande.btnNouvelleCommande_Click");
            }
        }

        private void OuvrirCommandeSelectionnee()
        {
            try
            {
                if (!SelectionCommandeValide())
                {
                    MessageBox.Show("Selectionnez une commande.", "Commande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = GetCommandeSelectionnee();
                string numero = Convert.ToString(dgCommandes.CurrentRow.Cells["NumeroCommande"].Value);

                using (var f = new frmDetailsCommande(id, numero))
                {
                    f.ShowDialog(this);
                }

                ChargerCommandes();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmCommande.OuvrirCommandeSelectionnee");
            }
        }

        private void btnDetailsCommande_Click(object sender, EventArgs e)
        {
            OuvrirCommandeSelectionnee();
        }

        private void btnSupprimerCommande_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SelectionCommandeValide())
                {
                    MessageBox.Show("Selectionnez une commande.", "Commande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = GetCommandeSelectionnee();
                var commande = db.Commandes.Find(id);
                if (commande == null)
                {
                    return;
                }

                if (commande.IsCommande)
                {
                    MessageBox.Show("Impossible de supprimer une commande validee.", "Commande", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Supprimer cette commande et ses details ?", "Commande", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                var details = db.DetailsCommandes.Where(d => d.IdCommande == id).ToList();
                if (details.Count > 0)
                {
                    db.DetailsCommandes.RemoveRange(details);
                }
                db.Commandes.Remove(commande);
                db.SaveChanges();
                ChargerCommandes();
                MessageBox.Show("Commande supprimée avec succès.", "Commande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmCommande.btnSupprimerCommande_Click");
            }
        }

        private void cmbFiltreStatut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded || db == null)
            {
                return;
            }
            ChargerCommandes();
        }

        private void dgCommandes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OuvrirCommandeSelectionnee();
            }
        }

        private void txtRechercheClient_TextChanged(object sender, EventArgs e)
        {
            if (!_isLoaded || db == null)
            {
                return;
            }
            ChargerCommandes();
        }

        private void txtRechercheProduit_TextChanged(object sender, EventArgs e)
        {
            if (!_isLoaded || db == null)
            {
                return;
            }
            ChargerCommandes();
        }

        private void dtpRechercheDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_isLoaded || db == null)
            {
                return;
            }
            ChargerCommandes();
        }
    }
}
