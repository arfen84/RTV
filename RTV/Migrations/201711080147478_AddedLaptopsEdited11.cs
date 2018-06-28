namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited11 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Laptop", "LaptopID", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Laptop", "przekatna", c => c.Int(nullable: false));
        }
    }
}
