namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolePoleAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "Role");
        }
    }
}
