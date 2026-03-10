using AppSenAgriculture;
using AppSenAgriculture.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Parametre
{
    public partial class frmLieu : Form
    {
        private BdSenAgricultureContext db;

        public frmLieu()
        {
            InitializeComponent();
            ApplyVisualStyle();
        }

        private void ApplyVisualStyle()
        {
            AppTheme.ApplyFormTheme(this);

            gbRegions.BackColor = Color.White;
            gbRegions.ForeColor = AppTheme.SavannaGreen;
            gbRegions.Font = AppTheme.UiFont(12F, FontStyle.Bold);

            gbDepartements.BackColor = Color.White;
            gbDepartements.ForeColor = AppTheme.SavannaGreen;
            gbDepartements.Font = AppTheme.UiFont(12F, FontStyle.Bold);

            foreach (Control control in Controls)
            {
                ApplyControlTheme(control);
            }

            AppTheme.StyleButton(btnAjouterRegion, AppTheme.SavannaGreen, Color.White);
            AppTheme.StyleButton(btnSupprimerRegion, AppTheme.Danger, Color.White);
            AppTheme.StyleButton(btnAjouterDepartement, AppTheme.SavannaGreen, Color.White);
            AppTheme.StyleButton(btnSupprimerDepartement, AppTheme.Danger, Color.White);
            AppTheme.StyleGrid(dgRegions);
            AppTheme.StyleGrid(dgDepartements);
        }

        private void ApplyControlTheme(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                TextBox textBox = control as TextBox;
                ComboBox comboBox = control as ComboBox;
                Label label = control as Label;

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

                if (control.HasChildren)
                {
                    ApplyControlTheme(control);
                }
            }
        }

        private void frmLieu_Load(object sender, EventArgs e)
        {
            try
            {
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    return;
                }

                db = new BdSenAgricultureContext();
                ChargerRegions();
                ChargerDepartements();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmLieu.Load");
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

        private void ChargerRegions()
        {
            dgRegions.DataSource = db.Regions
                .OrderBy(r => r.NomRegion)
                .Select(r => new
                {
                    r.IdRegion,
                    r.NomRegion
                })
                .ToList();

            cmbRegionDepartement.DataSource = db.Regions.OrderBy(r => r.NomRegion).ToList();
            cmbRegionDepartement.DisplayMember = "NomRegion";
            cmbRegionDepartement.ValueMember = "IdRegion";

            if (dgRegions.Columns.Contains("IdRegion"))
            {
                dgRegions.Columns["IdRegion"].Visible = false;
            }
        }

        private void ChargerDepartements()
        {
            dgDepartements.DataSource = db.Departements
                .OrderBy(d => d.Nom)
                .Select(d => new
                {
                    d.IdDepartement,
                    d.Nom,
                    d.IdRegion,
                    Region = d.Region != null ? d.Region.NomRegion : string.Empty
                })
                .ToList();

            if (dgDepartements.Columns.Contains("IdRegion"))
            {
                dgDepartements.Columns["IdRegion"].Visible = false;
            }
        }

        private void btnAjouterRegion_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomRegion.Text))
                {
                    MessageBox.Show("Le nom de la region est obligatoire.", "Lieu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomRegion.Focus();
                    return;
                }

                db.Regions.Add(new AppSenAgriculture.Models.Region { NomRegion = txtNomRegion.Text.Trim() });
                db.SaveChanges();
                txtNomRegion.Clear();
                ChargerRegions();
                ChargerDepartements();
                MessageBox.Show("Région ajoutée avec succès.", "Lieu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmLieu.btnAjouterRegion_Click");
            }
        }

        private void btnSupprimerRegion_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgRegions.CurrentRow == null)
                {
                    MessageBox.Show("Selectionnez une region.", "Lieu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Voulez-vous supprimer cette region ?", "Lieu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                int id = Convert.ToInt32(dgRegions.CurrentRow.Cells["IdRegion"].Value);
                var region = db.Regions.Find(id);
                if (region == null)
                {
                    return;
                }

                bool contientDepartements = db.Departements.Any(d => d.IdRegion == id);
                if (contientDepartements)
                {
                    MessageBox.Show("Impossible de supprimer cette region: des departements y sont rattaches.", "Lieu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Regions.Remove(region);
                db.SaveChanges();
                ChargerRegions();
                ChargerDepartements();
                MessageBox.Show("Région supprimée avec succès.", "Lieu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmLieu.btnSupprimerRegion_Click");
            }
        }

        private void btnAjouterDepartement_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomDepartement.Text))
                {
                    MessageBox.Show("Le nom du departement est obligatoire.", "Lieu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomDepartement.Focus();
                    return;
                }

                if (cmbRegionDepartement.SelectedValue == null)
                {
                    MessageBox.Show("Selectionnez une region.", "Lieu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                db.Departements.Add(new Departement
                {
                    Nom = txtNomDepartement.Text.Trim(),
                    IdRegion = Convert.ToInt32(cmbRegionDepartement.SelectedValue)
                });

                db.SaveChanges();
                txtNomDepartement.Clear();
                ChargerDepartements();
                MessageBox.Show("Département ajouté avec succès.", "Lieu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmLieu.btnAjouterDepartement_Click");
            }
        }

        private void btnSupprimerDepartement_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgDepartements.CurrentRow == null)
                {
                    MessageBox.Show("Selectionnez un departement.", "Lieu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Voulez-vous supprimer ce departement ?", "Lieu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                int id = Convert.ToInt32(dgDepartements.CurrentRow.Cells["IdDepartement"].Value);
                var departement = db.Departements.Find(id);
                if (departement == null)
                {
                    return;
                }

                db.Departements.Remove(departement);
                db.SaveChanges();
                ChargerDepartements();
                MessageBox.Show("Département supprimé avec succès.", "Lieu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmLieu.btnSupprimerDepartement_Click");
            }
        }
    }
}
