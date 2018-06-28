namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Laptop", "rozdzielczosc", c => c.String());
            AddColumn("dbo.Laptop", "przekatna", c => c.Int());
        }
        
        public override void Down()
        {
        }
    }
}
