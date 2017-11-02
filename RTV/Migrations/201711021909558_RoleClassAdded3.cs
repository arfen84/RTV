namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleClassAdded3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Role", newName: "IdentityRole");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.IdentityRole", newName: "Role");
        }
    }
}
