namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited16 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Monitor");
            DropPrimaryKey("dbo.Laptop");
            AddPrimaryKey("dbo.Monitor", "MonitorId");
            AddPrimaryKey("dbo.Laptop", "LaptopId");
            DropColumn("dbo.Monitor", "ProductID");
            DropColumn("dbo.Laptop", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Laptop", "ProductID", c => c.Int(nullable: false));
            AddColumn("dbo.Monitor", "ProductID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Laptop");
            DropPrimaryKey("dbo.Monitor");
            AddPrimaryKey("dbo.Laptop", "ProductID");
            AddPrimaryKey("dbo.Monitor", "ProductID");
        }
    }
}
