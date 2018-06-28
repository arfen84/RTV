namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited12 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Laptop", "LaptopID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Laptop", "LaptopID", c => c.Int(nullable: false, identity: true));
        }
    }
}
