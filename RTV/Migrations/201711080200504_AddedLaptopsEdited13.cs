namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited13 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Laptop", "rozdzielczosc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Laptop", "rozdzielczosc", c => c.String());
        }
    }
}
