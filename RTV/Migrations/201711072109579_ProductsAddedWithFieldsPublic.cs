namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsAddedWithFieldsPublic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Mark", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "rozdzielczosc", c => c.String());
            AddColumn("dbo.Products", "przekatna", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "czas_reakcji", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "jasnosc", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "technologiaPodswietlenia", c => c.String());
            AddColumn("dbo.Products", "typ", c => c.String());
            AddColumn("dbo.Products", "stan", c => c.String());
            AddColumn("dbo.Products", "seriaProcesora", c => c.String());
            AddColumn("dbo.Products", "iloscRdzeni", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "RAM", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "pamiecGrafika", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "system", c => c.String());
            AddColumn("dbo.Products", "zlacza", c => c.String());
            AddColumn("dbo.Products", "komunikacja", c => c.String());
            AddColumn("dbo.Products", "pojemnosc", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "pojemnosc");
            DropColumn("dbo.Products", "komunikacja");
            DropColumn("dbo.Products", "zlacza");
            DropColumn("dbo.Products", "system");
            DropColumn("dbo.Products", "pamiecGrafika");
            DropColumn("dbo.Products", "RAM");
            DropColumn("dbo.Products", "iloscRdzeni");
            DropColumn("dbo.Products", "seriaProcesora");
            DropColumn("dbo.Products", "stan");
            DropColumn("dbo.Products", "typ");
            DropColumn("dbo.Products", "technologiaPodswietlenia");
            DropColumn("dbo.Products", "jasnosc");
            DropColumn("dbo.Products", "czas_reakcji");
            DropColumn("dbo.Products", "przekatna");
            DropColumn("dbo.Products", "rozdzielczosc");
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Mark");
            DropColumn("dbo.Products", "Price");
        }
    }
}
