namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Monitories", newName: "Products");
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Discriminator");
            RenameTable(name: "dbo.Products", newName: "Monitories");
        }
    }
}
