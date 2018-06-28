namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Laptop", "LaptopId", c => c.Int(nullable: false, identity: false));
            AddColumn("dbo.Monitor", "MonitorId", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Monitor", "MonitorId");
            DropColumn("dbo.Laptop", "LaptopId");
        }
    }
}
