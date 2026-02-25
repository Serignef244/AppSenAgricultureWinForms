using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSenAgriculture.Models
{
    //paremetre a jouter 
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdSenAgricultureContext:DbContext
    {
        //constructeur qui passe la chaine de connexion au contexte de base
        public BdSenAgricultureContext(): base("conSenAgriculture")
        {

        }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<UniteMesure> UniteMesures { get; set; }

        public DbSet<Produit> Produits { get; set; }

        public DbSet<Commande> Commandes { get; set; }

        public DbSet<DetailsCommande> DetailsCommandes { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Agriculteur> Agriculteurs { get; set; }

        public DbSet<Personne> Personnes { get; set; }

        public DbSet<Facilitateur> Facilitateurs { get; set; }

        public DbSet<Client>Clients { get; set; }

        public DbSet<Cultivateur> Cultivateurs { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Departement> Departements { get; set; }


    }
}
