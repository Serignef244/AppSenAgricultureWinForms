using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AppSenAgriculture.Security
{
    public static class PasswordSecurity
    {
        public const string PasswordPrefix = "SHA256:";

        public static string HashPassword(string plainTextPassword)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plainTextPassword ?? string.Empty);
                byte[] hash = sha.ComputeHash(bytes);
                return PasswordPrefix + Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string inputPassword, string storedPassword)
        {
            if (string.IsNullOrWhiteSpace(storedPassword))
            {
                return false;
            }

            if (storedPassword.StartsWith(PasswordPrefix, StringComparison.Ordinal))
            {
                return string.Equals(HashPassword(inputPassword), storedPassword, StringComparison.Ordinal);
            }

            // Backward compatibility for legacy clear-text values.
            return string.Equals(inputPassword, storedPassword, StringComparison.Ordinal);
        }

        public static bool ValidatePasswordPolicy(string password, string identifiant, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                errorMessage = "Le mot de passe doit contenir au moins 6 caracteres.";
                return false;
            }

            if (password.Any(char.IsWhiteSpace))
            {
                errorMessage = "Le mot de passe ne doit pas contenir d'espace.";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(identifiant) &&
                string.Equals(password, identifiant, StringComparison.OrdinalIgnoreCase))
            {
                errorMessage = "Le mot de passe ne doit pas etre identique a l'identifiant.";
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                errorMessage = "Le mot de passe doit contenir au moins une lettre majuscule.";
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                errorMessage = "Le mot de passe doit contenir au moins une lettre minuscule.";
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                errorMessage = "Le mot de passe doit contenir au moins un chiffre.";
                return false;
            }

            const string specials = "!@#$%^&*()-_=+[]{};:,.?/\\|`~";
            if (!password.Any(c => specials.Contains(c)))
            {
                errorMessage = "Le mot de passe doit contenir au moins un caractere special.";
                return false;
            }

            return true;
        }

        public static string GenerateTemporaryPassword()
        {
            const string uppercase = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string lowercase = "abcdefghijkmnopqrstuvwxyz";
            const string digits = "23456789";
            const string specials = "!@#$%&*";
            string all = uppercase + lowercase + digits + specials;

            // Guarantee all required categories first.
            char[] buffer = new char[10];
            buffer[0] = Pick(uppercase);
            buffer[1] = Pick(lowercase);
            buffer[2] = Pick(digits);
            buffer[3] = Pick(specials);

            for (int i = 4; i < buffer.Length; i++)
            {
                buffer[i] = Pick(all);
            }

            // Fisher-Yates shuffle.
            for (int i = buffer.Length - 1; i > 0; i--)
            {
                int j = NextInt(i + 1);
                char temp = buffer[i];
                buffer[i] = buffer[j];
                buffer[j] = temp;
            }

            return new string(buffer);
        }

        private static char Pick(string chars)
        {
            return chars[NextInt(chars.Length)];
        }

        private static int NextInt(int maxExclusive)
        {
            if (maxExclusive <= 0)
            {
                throw new ArgumentOutOfRangeException("maxExclusive");
            }

            byte[] bytes = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                uint limit = uint.MaxValue - (uint.MaxValue % (uint)maxExclusive);
                uint value;
                do
                {
                    rng.GetBytes(bytes);
                    value = BitConverter.ToUInt32(bytes, 0);
                }
                while (value >= limit);

                return (int)(value % (uint)maxExclusive);
            }
        }
    }
}
