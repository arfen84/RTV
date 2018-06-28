namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsAddedWithDiffrentClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Products", "przekatna", c => c.Int());
            AlterColumn("dbo.Products", "czas_reakcji", c => c.Int());
            AlterColumn("dbo.Products", "jasnosc", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "jasnosc", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "czas_reakcji", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "przekatna", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Discriminator");
        }
    }
}
