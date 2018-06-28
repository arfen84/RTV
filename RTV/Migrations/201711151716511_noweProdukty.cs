namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noweProdukty : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Drukarka", newName: "Drukarki");
            RenameTable(name: "dbo.Laptop", newName: "Laptopy");
            RenameTable(name: "dbo.Monitor", newName: "Monitory");
            CreateTable(
                "dbo.Graficzne",
                c => new
                    {
                        GrafikaId = c.Int(nullable: false, identity: true),
                        Chipset = c.String(),
                        ProducentChipsetu = c.String(),
                        RAM = c.Int(nullable: false),
                        RodzajRAM = c.String(),
                        Szyna = c.Int(nullable: false),
                        Zlacze = c.String(),
                        Laczenie = c.String(),
                        Standard = c.String(),
                        Wyjscie = c.String(),
                        Nazwa = c.String(),
                        Kategoria = c.String(),
                        Cena = c.Double(nullable: false),
                        Marka = c.String(),
                        Opis = c.String(),
                        Stan = c.String(),
                    })
                .PrimaryKey(t => t.GrafikaId);
            
            CreateTable(
                "dbo.Plyty",
                c => new
                    {
                        PlytaId = c.Int(nullable: false, identity: true),
                        Standard = c.String(),
                        Gniazdo = c.String(),
                        Chipset = c.String(),
                        PanelTylni = c.String(),
                        GniazdoRAM = c.String(),
                        CzestotliwoscRAM = c.String(),
                        Nazwa = c.String(),
                        Kategoria = c.String(),
                        Cena = c.Double(nullable: false),
                        Marka = c.String(),
                        Opis = c.String(),
                        Stan = c.String(),
                    })
                .PrimaryKey(t => t.PlytaId);
            
            CreateTable(
                "dbo.Procesory",
                c => new
                    {
                        ProcesorId = c.Int(nullable: false, identity: true),
                        Linia = c.String(),
                        Gniazdo = c.String(),
                        Rdzenie = c.Int(nullable: false),
                        Mnoznik = c.Boolean(nullable: false),
                        Chlodzenie = c.Boolean(nullable: false),
                        Nazwa = c.String(),
                        Kategoria = c.String(),
                        Cena = c.Double(nullable: false),
                        Marka = c.String(),
                        Opis = c.String(),
                        Stan = c.String(),
                    })
                .PrimaryKey(t => t.ProcesorId);
            
            CreateTable(
                "dbo.RAMy",
                c => new
                    {
                        RAMId = c.Int(nullable: false, identity: true),
                        Typ = c.String(),
                        Pojemnosc = c.Int(nullable: false),
                        Czestotliwosc = c.Int(nullable: false),
                        Moduly = c.Int(nullable: false),
                        Opoznienie = c.Int(nullable: false),
                        Napiecie = c.Single(nullable: false),
                        Chlodzenie = c.Boolean(nullable: false),
                        Nazwa = c.String(),
                        Kategoria = c.String(),
                        Cena = c.Double(nullable: false),
                        Marka = c.String(),
                        Opis = c.String(),
                        Stan = c.String(),
                    })
                .PrimaryKey(t => t.RAMId);
            
            CreateTable(
                "dbo.Zasilacze",
                c => new
                    {
                        ZasilaczId = c.Int(nullable: false, identity: true),
                        Standard = c.String(),
                        Sprawnosc = c.String(),
                        Modularne = c.String(),
                        Chlodzenie = c.String(),
                        Wentylator = c.String(),
                        PFC = c.String(),
                        Nazwa = c.String(),
                        Kategoria = c.String(),
                        Cena = c.Double(nullable: false),
                        Marka = c.String(),
                        Opis = c.String(),
                        Stan = c.String(),
                    })
                .PrimaryKey(t => t.ZasilaczId);
            
            AddColumn("dbo.Drukarki", "Nazwa", c => c.String());
            AddColumn("dbo.Drukarki", "Kategoria", c => c.String());
            AddColumn("dbo.Drukarki", "Cena", c => c.Double(nullable: false));
            AddColumn("dbo.Drukarki", "Marka", c => c.String());
            AddColumn("dbo.Drukarki", "Opis", c => c.String());
            AddColumn("dbo.Laptopy", "Nazwa", c => c.String());
            AddColumn("dbo.Laptopy", "Kategoria", c => c.String());
            AddColumn("dbo.Laptopy", "Cena", c => c.Double(nullable: false));
            AddColumn("dbo.Laptopy", "Marka", c => c.String());
            AddColumn("dbo.Laptopy", "Opis", c => c.String());
            AddColumn("dbo.Monitory", "Nazwa", c => c.String());
            AddColumn("dbo.Monitory", "Kategoria", c => c.String());
            AddColumn("dbo.Monitory", "Cena", c => c.Double(nullable: false));
            AddColumn("dbo.Monitory", "Marka", c => c.String());
            AddColumn("dbo.Monitory", "Opis", c => c.String());
            DropColumn("dbo.Drukarki", "ProductName");
            DropColumn("dbo.Drukarki", "Category");
            DropColumn("dbo.Drukarki", "Price");
            DropColumn("dbo.Drukarki", "Mark");
            DropColumn("dbo.Drukarki", "Description");
            DropColumn("dbo.Laptopy", "ProductName");
            DropColumn("dbo.Laptopy", "Category");
            DropColumn("dbo.Laptopy", "Price");
            DropColumn("dbo.Laptopy", "Mark");
            DropColumn("dbo.Laptopy", "Description");
            DropColumn("dbo.Monitory", "ProductName");
            DropColumn("dbo.Monitory", "Category");
            DropColumn("dbo.Monitory", "Price");
            DropColumn("dbo.Monitory", "Mark");
            DropColumn("dbo.Monitory", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Monitory", "Description", c => c.String());
            AddColumn("dbo.Monitory", "Mark", c => c.String());
            AddColumn("dbo.Monitory", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Monitory", "Category", c => c.String());
            AddColumn("dbo.Monitory", "ProductName", c => c.String());
            AddColumn("dbo.Laptopy", "Description", c => c.String());
            AddColumn("dbo.Laptopy", "Mark", c => c.String());
            AddColumn("dbo.Laptopy", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Laptopy", "Category", c => c.String());
            AddColumn("dbo.Laptopy", "ProductName", c => c.String());
            AddColumn("dbo.Drukarki", "Description", c => c.String());
            AddColumn("dbo.Drukarki", "Mark", c => c.String());
            AddColumn("dbo.Drukarki", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Drukarki", "Category", c => c.String());
            AddColumn("dbo.Drukarki", "ProductName", c => c.String());
            DropColumn("dbo.Monitory", "Opis");
            DropColumn("dbo.Monitory", "Marka");
            DropColumn("dbo.Monitory", "Cena");
            DropColumn("dbo.Monitory", "Kategoria");
            DropColumn("dbo.Monitory", "Nazwa");
            DropColumn("dbo.Laptopy", "Opis");
            DropColumn("dbo.Laptopy", "Marka");
            DropColumn("dbo.Laptopy", "Cena");
            DropColumn("dbo.Laptopy", "Kategoria");
            DropColumn("dbo.Laptopy", "Nazwa");
            DropColumn("dbo.Drukarki", "Opis");
            DropColumn("dbo.Drukarki", "Marka");
            DropColumn("dbo.Drukarki", "Cena");
            DropColumn("dbo.Drukarki", "Kategoria");
            DropColumn("dbo.Drukarki", "Nazwa");
            DropTable("dbo.Zasilacze");
            DropTable("dbo.RAMy");
            DropTable("dbo.Procesory");
            DropTable("dbo.Plyty");
            DropTable("dbo.Graficzne");
            RenameTable(name: "dbo.Monitory", newName: "Monitor");
            RenameTable(name: "dbo.Laptopy", newName: "Laptop");
            RenameTable(name: "dbo.Drukarki", newName: "Drukarka");
        }
    }
}
