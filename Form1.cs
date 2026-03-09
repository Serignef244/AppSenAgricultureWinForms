using AppSenAgriculture.Models;
using AppSenAgriculture.Security;
using AppSenAgriculture.Views.Securite;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AppSenAgriculture
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
        }

        private static string BuildErrorMessage(Exception ex)
        {
            if (ex == null)
            {
                return "Erreur inconnue.";
            }

            string message = ex.Message;
            if (ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message))
            {
                message += " | Detail: " + ex.InnerException.Message;
            }

            return message;
        }

        private void bnSeConnecter_Click(object sender, EventArgs e)
        {
            string identifiant = txtIdentifiant.Text.Trim();
            string motDePasse = txtMotDePasse.Text.Trim();

            if (string.IsNullOrWhiteSpace(identifiant) || string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Saisissez l'identifiant et le mot de passe.", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new BdSenAgricultureContext())
                {
                    db.Database.CreateIfNotExists();

                    if (!db.Personnes.Any())
                    {
                        db.Personnes.Add(new Personne
                        {
                            NomCompletPersonne = "Administrateur",
                            AddressePersonne = "Dakar",
                            EmailPersonne = "admin@senagriculture.local",
                            TelPersonne = "770000000",
                            IdentifiantPersonne = "admin",
                            MotDePassePersonne = PasswordSecurity.HashPassword("admin123")
                        });
                        db.SaveChanges();
                    }

                    var utilisateur = db.Personnes.FirstOrDefault(p => p.IdentifiantPersonne == identifiant);
                    var client = utilisateur as Client;

                    string storedHash = client != null && !string.IsNullOrWhiteSpace(client.MotDePasseHash)
                        ? client.MotDePasseHash
                        : utilisateur != null ? utilisateur.MotDePassePersonne : string.Empty;

                    if (utilisateur == null || !PasswordSecurity.VerifyPassword(motDePasse, storedHash))
                    {
                        MessageBox.Show("Identifiant ou mot de passe incorrect.", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Upgrade an old clear-text password to the hashed format after a successful login.
                    if (!utilisateur.MotDePassePersonne.StartsWith(PasswordSecurity.PasswordPrefix, StringComparison.Ordinal))
                    {
                        utilisateur.MotDePassePersonne = PasswordSecurity.HashPassword(motDePasse);
                        if (client != null)
                        {
                            client.MotDePasseHash = utilisateur.MotDePassePersonne;
                        }
                        db.SaveChanges();
                    }

                    if (client != null && string.IsNullOrWhiteSpace(client.MotDePasseHash))
                    {
                        client.MotDePasseHash = utilisateur.MotDePassePersonne;
                        db.SaveChanges();
                    }

                    if (client != null && client.DoitChangerMotDePasse)
                    {
                        this.Hide();
                        using (var f = new frmChangerMotDePasse(client.IdPersonne))
                        {
                            if (f.ShowDialog(this) != DialogResult.OK)
                            {
                                this.Show();
                                txtMotDePasse.Clear();
                                txtIdentifiant.Focus();
                                return;
                            }
                        }
                    }
                }

                this.Hide();
                using (var f = new frmMDI())
                {
                    f.ShowDialog(this);
                }
                this.Show();
                txtMotDePasse.Clear();
                txtIdentifiant.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur de connexion a la base: " + BuildErrorMessage(ex),
                    "Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lnkMotDePasseOublie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var f = new frmMotDePasseOublie())
            {
                f.ShowDialog(this);
            }
        }
    }
}
