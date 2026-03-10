using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace AppSenAgriculture.Services
{
    public static class EmailService
    {
        // ⚠️ ATTENTION: identifiants en clair dans le code (à éviter en production).
        // Utilisés seulement si App.config n'est pas renseigné.
        private const string FallbackSmtpHost = "smtp.gmail.com";
        private const int FallbackSmtpPort = 587;
        private const bool FallbackSmtpEnableSsl = true;
        private const string FallbackSmtpUser = "ssouyouniang13@gmail.com";
        private const string FallbackSmtpPass = "awry olpr pvtb iswi";
        private const string FallbackFromName = "Sen Agriculture Support";

        private static string GetRequiredSetting(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ConfigurationErrorsException($"Paramètre manquant dans App.config: appSettings['{key}'].");
            }
            return value.Trim();
        }

        private static string GetOptionalSetting(string key, string fallback)
        {
            var value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrWhiteSpace(value) ? fallback : value.Trim();
        }

        private static int GetIntSetting(string key, int defaultValue)
        {
            var raw = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(raw)) return defaultValue;
            if (int.TryParse(raw.Trim(), out int v)) return v;
            throw new ConfigurationErrorsException($"Paramètre invalide dans App.config: appSettings['{key}'] doit être un entier.");
        }

        private static bool GetBoolSetting(string key, bool defaultValue)
        {
            var raw = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(raw)) return defaultValue;
            if (bool.TryParse(raw.Trim(), out bool v)) return v;
            throw new ConfigurationErrorsException($"Paramètre invalide dans App.config: appSettings['{key}'] doit être true/false.");
        }

        public static void SendTemporaryPassword(string toEmail, string temporaryPassword)
        {
            if (string.IsNullOrWhiteSpace(toEmail))
                throw new ArgumentException("L'adresse email est requise.");

            try
            {
               
                string smtpHost = "smtp.gmail.com";
                int smtpPort = 587;
                    bool enableSsl = true;
                    string smtpUser = "ssouyouniang13@gmail.com";
                string smtpPass = "awry olpr pvtb iswi";
                string fromName = "Sen Agriculture Support";

                var fromAddress = new MailAddress(smtpUser, fromName);
                var toAddress = new MailAddress(toEmail);

                using (var smtp = new SmtpClient
                {
                    Host = smtpHost,
                    Port = smtpPort,
                    EnableSsl = enableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, smtpPass)
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
                throw new Exception("Échec de l'envoi de l'email. Veuillez vérifier la configuration SMTP. Détail: " + ex.Message, ex);
            }
        }
    }
}
