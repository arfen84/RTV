namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noweProdukty4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drukarki", "Sprzedany", c => c.Boolean(nullable: false));
            AddColumn("dbo.Graficzne", "Sprzedany", c => c.Boolean(nullable: false));
            AddColumn("dbo.Laptopy", "Sprzedany", c => c.Boolean(nullable: false));
            AddColumn("dbo.Plyty", "Sprzedany", c => c.Boolean(nullable: false));
            AddColumn("dbo.Procesory", "Sprzedany", c => c.Boolean(nullable: false));
            AddColumn("dbo.RAMy", "Sprzedany", c => c.Boolean(nullable: false));
            AddColumn("dbo.Zasilacze", "Sprzedany", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Zasilacze", "Sprzedany");
            DropColumn("dbo.RAMy", "Sprzedany");
            DropColumn("dbo.Procesory", "Sprzedany");
            DropColumn("dbo.Plyty", "Sprzedany");
            DropColumn("dbo.Laptopy", "Sprzedany");
            DropColumn("dbo.Graficzne", "Sprzedany");
            DropColumn("dbo.Drukarki", "Sprzedany");
        }
    }
}
