namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaptopFix2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Laptop",
                c => new
                    {
                        LaptopId = c.Int(nullable: false, identity: true),
                        pojemnosc = c.Int(nullable: false),
                        seriaProcesora = c.String(),
                        iloscRdzeni = c.Int(nullable: false),
                        RAM = c.Int(nullable: false),
                        pamiecGrafika = c.Int(nullable: false),
                        system = c.String(),
                        zlacza = c.String(),
                        komunikacja = c.String(),
                        ProductName = c.String(),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                        Mark = c.String(),
                        Description = c.String(),
                        Stan = c.String(),
                    })
                .PrimaryKey(t => t.LaptopId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Laptop");
        }
    }
}
