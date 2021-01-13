namespace GestionAnnonce.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutAnnonce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annonces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        Statut = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Annonces");
        }
    }
}
