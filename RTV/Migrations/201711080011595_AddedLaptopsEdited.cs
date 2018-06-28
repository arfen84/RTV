namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "rozdzielczosc", newName: "rozdzielczosc1");
            RenameColumn(table: "dbo.Products", name: "przekatna", newName: "przekatna1");
            AlterColumn("dbo.Products", "pojemnosc", c => c.Int());
            DropColumn("dbo.Products", "typ");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "typ", c => c.String());
            AlterColumn("dbo.Products", "pojemnosc", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "przekatna1", newName: "przekatna");
            RenameColumn(table: "dbo.Products", name: "rozdzielczosc1", newName: "rozdzielczosc");
        }
    }
}
