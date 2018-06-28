namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptops : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "iloscRdzeni", c => c.Int());
            AlterColumn("dbo.Products", "RAM", c => c.Int());
            AlterColumn("dbo.Products", "pamiecGrafika", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "pamiecGrafika", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "RAM", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "iloscRdzeni", c => c.Int(nullable: false));
        }
    }
}
