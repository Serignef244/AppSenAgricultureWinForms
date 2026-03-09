using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AppSenAgriculture.Security
{
    public static class PasswordSecurity
    {
        public const string PasswordPrefix = "PBKDF2$";
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100000;

        public static string HashPassword(string plainTextPassword)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                plainTextPassword ?? string.Empty,
                salt,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                byte[] key = pbkdf2.GetBytes(KeySize);
                return PasswordPrefix
                    + Iterations.ToString()
                    + "$"
                    + Convert.ToBase64String(salt)
                    + "$"
                    + Convert.ToBase64String(key);
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
                string[] parts = storedPassword.Split('$');
                if (parts.Length != 4)
                {
                    return false;
                }

                int iterations;
                if (!int.TryParse(parts[1], out iterations) || iterations <= 0)
                {
                    return false;
                }

                byte[] salt;
                byte[] expected;
                try
                {
                    salt = Convert.FromBase64String(parts[2]);
                    expected = Convert.FromBase64String(parts[3]);
                }
                catch (FormatException)
                {
                    return false;
                }

                using (var pbkdf2 = new Rfc2898DeriveBytes(
                    inputPassword ?? string.Empty,
                    salt,
                    iterations,
                    HashAlgorithmName.SHA256))
                {
                    byte[] actual = pbkdf2.GetBytes(expected.Length);
                    return ConstantTimeEquals(actual, expected);
                }
            }

            // Legacy support for previous SHA256 format.
            if (storedPassword.StartsWith("SHA256:", StringComparison.Ordinal))
            {
                using (var sha = SHA256.Create())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(inputPassword ?? string.Empty);
                    byte[] hash = sha.ComputeHash(bytes);
                    string legacyHash = "SHA256:" + Convert.ToBase64String(hash);
                    return string.Equals(legacyHash, storedPassword, StringComparison.Ordinal);
                }
            }

            // Backward compatibility for legacy clear-text values.
            return string.Equals(inputPassword, storedPassword, StringComparison.Ordinal);
        }

        private static bool ConstantTimeEquals(byte[] left, byte[] right)
        {
            if (left == null || right == null || left.Length != right.Length)
            {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < left.Length; i++)
            {
                diff |= left[i] ^ right[i];
            }

            return diff == 0;
        }

        public static bool ValidatePasswordPolicy(string password, string identifiant, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                errorMessage = "Le mot de passe doit contenir au moins 8 caracteres.";
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
