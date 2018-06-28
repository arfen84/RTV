namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrukarkaAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drukarka",
                c => new
                    {
                        DrukarkaId = c.Int(nullable: false, identity: true),
                        typ = c.String(),
                        ProductName = c.String(),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                        Mark = c.String(),
                        Description = c.String(),
                        Stan = c.String(),
                    })
                .PrimaryKey(t => t.DrukarkaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drukarka");
        }
    }
}
