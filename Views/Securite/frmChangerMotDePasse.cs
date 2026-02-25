using AppSenAgriculture.Models;
using AppSenAgriculture.Security;
using System;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Securite
{
    public partial class frmChangerMotDePasse : Form
    {
        private readonly int _idClient;
        private BdSenAgricultureContext db;

        public frmChangerMotDePasse(int idClient)
        {
            _idClient = idClient;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                return;
            }
            db = new BdSenAgricultureContext();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.OnFormClosed(e);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            var client = db.Clients.Find(_idClient);
            if (client == null)
            {
                MessageBox.Show("Client introuvable.", "Securite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ancien = txtAncienMotDePasse.Text.Trim();
            string nouveau = txtNouveauMotDePasse.Text.Trim();
            string confirmation = txtConfirmerMotDePasse.Text.Trim();

            string hashReference = !string.IsNullOrWhiteSpace(client.MotDePasseHash)
                ? client.MotDePasseHash
                : client.MotDePassePersonne;

            if (!PasswordSecurity.VerifyPassword(ancien, hashReference))
            {
                MessageBox.Show("Ancien mot de passe incorrect.", "Securite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAncienMotDePasse.Focus();
                return;
            }

            if (!string.Equals(nouveau, confirmation, StringComparison.Ordinal))
            {
                MessageBox.Show("La confirmation du mot de passe ne correspond pas.", "Securite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmerMotDePasse.Focus();
                return;
            }

            string policyError;
            if (!PasswordSecurity.ValidatePasswordPolicy(nouveau, client.IdentifiantPersonne, out policyError))
            {
                MessageBox.Show(policyError, "Securite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNouveauMotDePasse.Focus();
                return;
            }

            string nouveauHash = PasswordSecurity.HashPassword(nouveau);
            client.MotDePasseHash = nouveauHash;
            client.MotDePassePersonne = nouveauHash;
            client.DoitChangerMotDePasse = false;
            db.SaveChanges();

            MessageBox.Show("Mot de passe mis a jour avec succes.", "Securite", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
