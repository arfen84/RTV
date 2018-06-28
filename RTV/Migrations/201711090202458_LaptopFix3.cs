namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaptopFix3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Monitor", "Matryca", c => c.String());
            DropColumn("dbo.Laptop", "komunikacja");
            DropColumn("dbo.Monitor", "technologiaPodswietlenia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Monitor", "technologiaPodswietlenia", c => c.String());
            AddColumn("dbo.Laptop", "komunikacja", c => c.String());
            DropColumn("dbo.Monitor", "Matryca");
        }
    }
}
