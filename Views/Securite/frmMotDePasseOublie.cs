using AppSenAgriculture.Models;
using AppSenAgriculture.Security;
using AppSenAgriculture.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Securite
{
    public partial class frmMotDePasseOublie : Form
    {
        public frmMotDePasseOublie()
        {
            InitializeComponent();
        }

        private void btnEnvoyer_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Veuillez saisir votre adresse email.", "Mot de passe oublié", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new BdSenAgricultureContext())
                {
                    // Chercher l'utilisateur par son email
                    var utilisateur = db.Personnes.FirstOrDefault(p => p.EmailPersonne == email);

                    if (utilisateur == null)
                    {
                        // Pour des raisons de sécurité, on ne dit pas si l'email existe ou non, 
                        // mais ici pour une app métier, on peut être plus explicite ou rester vague.
                        // Restons vague mais pro.
                        MessageBox.Show("Si cet email correspond à un compte, un nouveau mot de passe a été envoyé.", "Mot de passe oublié", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }

                    // Générer un mot de passe temporaire
                    string tempPwd = PasswordSecurity.GenerateTemporaryPassword();

                    // Mettre à jour l'utilisateur
                    string hashedPwd = PasswordSecurity.HashPassword(tempPwd);
                    utilisateur.MotDePassePersonne = hashedPwd;

                    // Si c'est un client, mettre aussi à jour son hash spécifique
                    var client = utilisateur as Client;
                    if (client != null)
                    {
                        client.MotDePasseHash = hashedPwd;
                        client.DoitChangerMotDePasse = true;
                    }

                    db.SaveChanges();

                    // Envoyer l'email
                    EmailService.SendTemporaryPassword(email, tempPwd);

                    Logger.LogInfo($"Mot de passe temporaire envoyé avec succès à {email}.", "frmMotDePasseOublie");

                    MessageBox.Show("Un nouveau mot de passe a été envoyé à votre adresse email.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex, "frmMotDePasseOublie.btnEnvoyer_Click");
                MessageBox.Show("Une erreur est survenue lors de la réinitialisation : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
