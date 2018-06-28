namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noweProdukty5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Laptopy", "Rozdzielczosc", c => c.String());
            AddColumn("dbo.Laptopy", "Przekatna", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Laptopy", "Przekatna");
            DropColumn("dbo.Laptopy", "Rozdzielczosc");
        }
    }
}
