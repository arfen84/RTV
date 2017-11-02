namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleClassAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registrations", "Role", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "Role", c => c.Byte(nullable: false));
        }
    }
}
