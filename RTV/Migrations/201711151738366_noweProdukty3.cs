namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noweProdukty3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Monitory", "Sprzedany", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Monitory", "Sprzedany", c => c.String());
        }
    }
}
