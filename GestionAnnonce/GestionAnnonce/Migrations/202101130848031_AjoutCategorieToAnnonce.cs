namespace GestionAnnonce.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutCategorieToAnnonce : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Annonces", "CategorieID", c => c.Int(nullable: false));
            AlterColumn("dbo.Annonces", "Label", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Annonces", "CategorieID");
            AddForeignKey("dbo.Annonces", "CategorieID", "dbo.cat", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Annonces", "CategorieID", "dbo.cat");
            DropIndex("dbo.Annonces", new[] { "CategorieID" });
            AlterColumn("dbo.Annonces", "Label", c => c.String(nullable: false));
            DropColumn("dbo.Annonces", "CategorieID");
        }
    }
}
