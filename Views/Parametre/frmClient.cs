using AppSenAgriculture;
using AppSenAgriculture.Models;
using AppSenAgriculture.Security;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Parametre
{
    public partial class frmClient : Form
    {
        private BdSenAgricultureContext db;

        public frmClient()
        {
            InitializeComponent();
            ApplyVisualStyle();
        }

        private void ApplyVisualStyle()
        {
            BackColor = Color.FromArgb(245, 240, 232);
            ForeColor = Color.FromArgb(44, 24, 16);
            Font = new Font("Source Sans 3", 12F);

            StyleInputs(this);
            StyleActionButton(btnAjouter, Color.FromArgb(45, 80, 22), Color.White);
            StyleActionButton(btnModifier, Color.FromArgb(196, 137, 42), Color.White);
            StyleActionButton(btnSupprimer, Color.FromArgb(140, 54, 32), Color.White);
            StyleActionButton(btnSelectionner, Color.White, Color.FromArgb(44, 24, 16));
            StyleActionButton(btnReinitialiser, Color.White, Color.FromArgb(44, 24, 16));
            StyleGrid(dgClients);
        }

        private void StyleInputs(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                TextBox textBox = control as TextBox;
                Label label = control as Label;

                if (textBox != null)
                {
                    textBox.BackColor = Color.White;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Font = new Font("Source Sans 3", 12F);
                }
                else if (label != null)
                {
                    label.Font = new Font("Source Sans 3", 12F, FontStyle.Bold);
                    label.ForeColor = Color.FromArgb(44, 24, 16);
                }
            }
        }

        private void StyleActionButton(Button button, Color backColor, Color foreColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.FromArgb(196, 137, 42);
            button.FlatAppearance.BorderSize = backColor == Color.White ? 1 : 0;
            button.Font = new Font("Source Sans 3", 11F, FontStyle.Bold);
            button.Height = 38;
        }

        private void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 80, 22);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Source Sans 3", 11F, FontStyle.Bold);
            grid.DefaultCellStyle.Font = new Font("JetBrains Mono", 10F);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(196, 137, 42);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 232);
            grid.RowHeadersVisible = false;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(230, 220, 204);
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
                ReinitialiserFormulaire();
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmClient.OnLoad");
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

        private void ChargerClients()
        {
            dgClients.DataSource = db.Clients
                .OrderBy(c => c.NomCompletPersonne)
                .Select(c => new
                {
                    c.IdPersonne,
                    c.NomCompletPersonne,
                    c.AddressePersonne,
                    c.EmailPersonne,
                    c.TelPersonne,
                    c.IdentifiantPersonne,
                    c.ProfessionClient
                })
                .ToList();
        }

        private void ReinitialiserFormulaire()
        {
            txtNom.Clear();
            txtAdresse.Clear();
            txtEmail.Clear();
            txtTelephone.Clear();
            txtIdentifiant.Clear();
            txtProfession.Clear();
            txtNom.Focus();
        }

        private bool SelectionValide()
        {
            return dgClients.CurrentRow != null && dgClients.CurrentRow.Cells["IdPersonne"] != null;
        }

        private int GetClientSelectionne()
        {
            return Convert.ToInt32(dgClients.CurrentRow.Cells["IdPersonne"].Value);
        }

        private bool FormulaireValide()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom complet est obligatoire.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAdresse.Text))
            {
                MessageBox.Show("L'adresse est obligatoire.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdresse.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("L'email est obligatoire.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Le telephone est obligatoire.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelephone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
            {
                MessageBox.Show("L'identifiant est obligatoire.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdentifiant.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProfession.Text))
            {
                MessageBox.Show("La profession est obligatoire.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProfession.Focus();
                return false;
            }

            return true;
        }

        private bool IdentifiantDisponible(string identifiant, int? idExclu)
        {
            string normalized = (identifiant ?? string.Empty).Trim();
            var query = db.Personnes.Where(p => p.IdentifiantPersonne == normalized);
            if (idExclu.HasValue)
            {
                query = query.Where(p => p.IdPersonne != idExclu.Value);
            }
            return !query.Any();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormulaireValide())
                {
                    return;
                }

                string identifiant = txtIdentifiant.Text.Trim();
                if (!IdentifiantDisponible(identifiant, null))
                {
                    MessageBox.Show("Cet identifiant existe deja. Choisissez-en un autre.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdentifiant.Focus();
                    return;
                }

                string motDePasseTemporaire = "passer";

                string passwordHash = PasswordSecurity.HashPassword(motDePasseTemporaire);

                db.Clients.Add(new Client
                {
                    NomCompletPersonne = txtNom.Text.Trim(),
                    AddressePersonne = txtAdresse.Text.Trim(),
                    EmailPersonne = txtEmail.Text.Trim(),
                    TelPersonne = txtTelephone.Text.Trim(),
                    IdentifiantPersonne = identifiant,
                    MotDePassePersonne = passwordHash,
                    MotDePasseHash = passwordHash,
                    DoitChangerMotDePasse = true,
                    ProfessionClient = txtProfession.Text.Trim(),
                });
                db.SaveChanges();

                ChargerClients();
                ReinitialiserFormulaire();
                MessageBox.Show(
                    "Client cree avec succes.\nMot de passe temporaire: " + motDePasseTemporaire
                    + "\nLe client devra le changer a la premiere connexion.",
                    "Client",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmClient.btnAjouter_Click");
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SelectionValide())
                {
                    MessageBox.Show("Selectionnez un client.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!FormulaireValide())
                {
                    return;
                }

                int id = GetClientSelectionne();
                var client = db.Clients.Find(id);
                if (client == null)
                {
                    MessageBox.Show("Client introuvable.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string identifiant = txtIdentifiant.Text.Trim();
                if (!IdentifiantDisponible(identifiant, id))
                {
                    MessageBox.Show("Cet identifiant existe deja. Choisissez-en un autre.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdentifiant.Focus();
                    return;
                }

                client.NomCompletPersonne = txtNom.Text.Trim();
                client.AddressePersonne = txtAdresse.Text.Trim();
                client.EmailPersonne = txtEmail.Text.Trim();
                client.TelPersonne = txtTelephone.Text.Trim();
                client.IdentifiantPersonne = identifiant;
                client.ProfessionClient = txtProfession.Text.Trim();

                if (string.IsNullOrWhiteSpace(client.MotDePasseHash) && !string.IsNullOrWhiteSpace(client.MotDePassePersonne))
                {
                    client.MotDePasseHash = client.MotDePassePersonne;
                }

                db.SaveChanges();
                ChargerClients();
                ReinitialiserFormulaire();
                MessageBox.Show("Client modifié avec succès.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmClient.btnModifier_Click");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!SelectionValide())
                {
                    MessageBox.Show("Selectionnez un client.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Voulez-vous supprimer ce client ?", "Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                int id = GetClientSelectionne();
                bool lieCommande = db.Commandes.Any(c => c.IdClient == id);
                if (lieCommande)
                {
                    MessageBox.Show("Impossible de supprimer ce client: il est lie a des commandes.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var client = db.Clients.Find(id);
                if (client == null)
                {
                    return;
                }

                db.Clients.Remove(client);
                db.SaveChanges();
                ChargerClients();
                ReinitialiserFormulaire();
                MessageBox.Show("Client supprimé avec succès.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmClient.btnSupprimer_Click");
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (!SelectionValide())
            {
                MessageBox.Show("Selectionnez un client.", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtNom.Text = Convert.ToString(dgClients.CurrentRow.Cells["NomCompletPersonne"].Value);
            txtAdresse.Text = Convert.ToString(dgClients.CurrentRow.Cells["AddressePersonne"].Value);
            txtEmail.Text = Convert.ToString(dgClients.CurrentRow.Cells["EmailPersonne"].Value);
            txtTelephone.Text = Convert.ToString(dgClients.CurrentRow.Cells["TelPersonne"].Value);
            txtIdentifiant.Text = Convert.ToString(dgClients.CurrentRow.Cells["IdentifiantPersonne"].Value);
            txtProfession.Text = Convert.ToString(dgClients.CurrentRow.Cells["ProfessionClient"].Value);
        }

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            ReinitialiserFormulaire();
        }

        private void lblNom_Click(object sender, EventArgs e)
        {

        }
    }
}
