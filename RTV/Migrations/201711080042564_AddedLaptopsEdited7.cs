namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited7 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "Laptop");
           
            DropPrimaryKey("dbo.Laptop");
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                        Mark = c.String(),
                        Description = c.String(),
                        Stan = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Monitor",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                        Mark = c.String(),
                        Description = c.String(),
                        Stan = c.String(),
                        rozdzielczosc = c.String(),
                        przekatna = c.Int(nullable: false),
                        czas_reakcji = c.Int(nullable: false),
                        jasnosc = c.Int(nullable: false),
                        technologiaPodswietlenia = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            AlterColumn("dbo.Laptop", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Laptop", "pojemnosc", c => c.Int(nullable: false));
            AlterColumn("dbo.Laptop", "przekatna", c => c.Int(nullable: false));
            AlterColumn("dbo.Laptop", "iloscRdzeni", c => c.Int(nullable: false));
            AlterColumn("dbo.Laptop", "RAM", c => c.Int(nullable: false));
            AlterColumn("dbo.Laptop", "pamiecGrafika", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Laptop", "ProductId");
            DropColumn("dbo.Laptop", "rozdzielczosc");
            DropColumn("dbo.Laptop", "przekatna");
            DropColumn("dbo.Laptop", "czas_reakcji");
            DropColumn("dbo.Laptop", "jasnosc");
            DropColumn("dbo.Laptop", "technologiaPodswietlenia");
            DropColumn("dbo.Laptop", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Laptop", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Laptop", "technologiaPodswietlenia", c => c.String());
            AddColumn("dbo.Laptop", "jasnosc", c => c.Int());
            AddColumn("dbo.Laptop", "czas_reakcji", c => c.Int());
            AddColumn("dbo.Laptop", "przekatna", c => c.Int());
            AddColumn("dbo.Laptop", "rozdzielczosc", c => c.String());
            DropPrimaryKey("dbo.Laptop");
            AlterColumn("dbo.Laptop", "pamiecGrafika", c => c.Int());
            AlterColumn("dbo.Laptop", "RAM", c => c.Int());
            AlterColumn("dbo.Laptop", "iloscRdzeni", c => c.Int());
            AlterColumn("dbo.Laptop", "przekatna", c => c.Int());
            AlterColumn("dbo.Laptop", "pojemnosc", c => c.Int());
            AlterColumn("dbo.Laptop", "ProductId", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Monitor");
            DropTable("dbo.Products");
            AddPrimaryKey("dbo.Laptop", "ProductId");
            RenameColumn(table: "dbo.Monitor", name: "przekatna", newName: "przekatna");
            RenameColumn(table: "dbo.Monitor", name: "rozdzielczosc", newName: "rozdzielczosc");
            RenameTable(name: "dbo.Laptop", newName: "Products");
        }
    }
}
