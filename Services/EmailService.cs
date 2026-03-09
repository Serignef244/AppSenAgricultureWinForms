using System;
using System.Net;
using System.Net.Mail;

namespace AppSenAgriculture.Services
{
    public static class EmailService
    {
        // Ces coordonnées seront changées par l'utilisateur
        private const string SmtpHost = "smtp.gmail.com";
        private const int SmtpPort = 587;
        private const string SmtpUser = "ssouyouniang13@gmail.com";
        private const string SmtpPass = "awry olpr pvtb iswi";

        public static void SendTemporaryPassword(string toEmail, string temporaryPassword)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
                throw new ArgumentException("L'adresse email est requise.");

            try
            {
                var fromAddress = new MailAddress(SmtpUser, "Sen Agriculture Support");
                var toAddress = new MailAddress(toEmail);

                using (var smtp = new SmtpClient
                {
                    Host = SmtpHost,
                    Port = SmtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, SmtpPass)
                })
                {
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = "Réinitialisation de votre mot de passe - Sen Agriculture",
                        Body = $@"Bonjour,

Une demande de réinitialisation de mot de passe a été effectuée pour votre compte Sen Agriculture.

Votre mot de passe temporaire est : {temporaryPassword}

Pour des raisons de sécurité, il vous sera demandé de changer ce mot de passe lors de votre prochaine connexion.

Si vous n'êtes pas à l'origine de cette demande, veuillez ignorer cet email.

Cordialement,
L'équipe Sen Agriculture"
                    })
                    {
                        smtp.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                // On log l'erreur mais on remonte une exception spécifique pour l'UI
                Logger.WriteLog(ex, "EmailService.SendTemporaryPassword");
                throw new Exception("Échec de l'envoi de l'email. Veuillez vérifier la configuration SMTP.", ex);
            }
        }
    }
}
