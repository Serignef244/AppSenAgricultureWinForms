namespace AppSenAgriculture.Migrations
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AppSenAgriculture.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AppSenAgriculture.Models.BdSenAgricultureContext>
    {
        private const string PasswordPrefix = "SHA256:";

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        private static string HashPassword(string plainTextPassword)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plainTextPassword ?? string.Empty);
                byte[] hash = sha.ComputeHash(bytes);
                return PasswordPrefix + Convert.ToBase64String(hash);
            }
        }

        protected override void Seed(AppSenAgriculture.Models.BdSenAgricultureContext context)
        {
            context.Personnes.AddOrUpdate(
                p => p.IdentifiantPersonne,
                new Personne
                {
                    NomCompletPersonne = "Administrateur",
                    AddressePersonne = "Dakar",
                    EmailPersonne = "admin@senagriculture.local",
                    TelPersonne = "770000000",
                    IdentifiantPersonne = "admin",
                    MotDePassePersonne = HashPassword("admin123")
                }
            );

            var clientsLegacy = context.Clients
                .Where(c => c.IdentifiantPersonne == "client1" || c.IdentifiantPersonne == "client2")
                .ToList();

            if (clientsLegacy.Count > 0)
            {
                foreach (var client in clientsLegacy)
                {
                    context.Clients.Remove(client);
                }
            }

            context.Categories.AddOrUpdate(
                c => c.Libelle,
                new Categorie { Libelle = "Cereales", DescriptionCategorie = "Riz, mil, mais et autres cereales." },
                new Categorie { Libelle = "Legumes", DescriptionCategorie = "Produits maraichers." },
                new Categorie { Libelle = "Fruits", DescriptionCategorie = "Mangue, papaye, banane et autres fruits." }
            );

            context.UniteMesures.AddOrUpdate(
                u => u.CodeUnite,
                new UniteMesure { CodeUnite = "KG", LibelleUnite = "Kilogramme" },
                new UniteMesure { CodeUnite = "L", LibelleUnite = "Litre" },
                new UniteMesure { CodeUnite = "SAC", LibelleUnite = "Sac" }
            );

            context.Regions.AddOrUpdate(
                r => r.NomRegion,
                new Region { NomRegion = "Dakar" },
                new Region { NomRegion = "Thies" }
            );

            context.SaveChanges();

            int? idDakar = context.Regions.Where(r => r.NomRegion == "Dakar").Select(r => (int?)r.IdRegion).FirstOrDefault();
            int? idThies = context.Regions.Where(r => r.NomRegion == "Thies").Select(r => (int?)r.IdRegion).FirstOrDefault();

            if (idDakar.HasValue)
            {
                context.Departements.AddOrUpdate(
                    d => d.Nom,
                    new Departement { Nom = "Dakar", IdRegion = idDakar.Value },
                    new Departement { Nom = "Pikine", IdRegion = idDakar.Value }
                );
            }

            if (idThies.HasValue)
            {
                context.Departements.AddOrUpdate(
                    d => d.Nom,
                    new Departement { Nom = "Thies", IdRegion = idThies.Value },
                    new Departement { Nom = "Mbour", IdRegion = idThies.Value }
                );
            }
        }
    }
}
