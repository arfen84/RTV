namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLaptopsEdited5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "rozdzielczosc", newName: "rozdzielczosc");
            RenameColumn(table: "dbo.Products", name: "przekatna", newName: "przekatna");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Products", name: "przekatna1", newName: "przekatna");
            RenameColumn(table: "dbo.Products", name: "rozdzielczosc1", newName: "rozdzielczosc");
        }
    }
}
