namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited4 : DbMigration
    {
        public override void Up()
        {
            
            RenameColumn(table: "dbo.Products", name: "rozdzielczosc1", newName: "rozdzielczosc");
            RenameColumn(table: "dbo.Products", name: "przekatna1", newName: "przekatna");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Products", name: "przekatna", newName: "przekatna1");
            RenameColumn(table: "dbo.Products", name: "rozdzielczosc", newName: "rozdzielczosc1");
            AddColumn("dbo.Products", "przekatna", c => c.Int());
            AddColumn("dbo.Products", "rozdzielczosc", c => c.String());
        }
    }
}
