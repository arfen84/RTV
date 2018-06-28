namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited15 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductName = c.String(),
                        Category = c.String(),
                        Price = c.Double(nullable: false),
                        Mark = c.String(),
                        Description = c.String(),
                        Stan = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
    }
}
