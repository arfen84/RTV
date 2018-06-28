namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Laptop", "przekatna", c => c.Int(nullable: true, identity: true));
        }
        
        public override void Down()
        {
        }
    }
}
