namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Laptop", "przekatna");
            //AddColumn("dbo.Laptop", "LaptopID", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Laptop", "LaptopID");
        }
    }
}
