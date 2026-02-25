namespace AppSenAgriculture.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenamePersonneToUtilisateur : DbMigration
    {
        public override void Up()
        {
            // Intentionally empty: the current model still uses Personne/IdPersonne.
            // Keeping this migration as a no-op avoids applying incompatible renames.
        }

        public override void Down()
        {
            // No-op mirror of Up().
        }
    }
}
