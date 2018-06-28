namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noweProdukty2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Monitory", "Sprzedany", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Monitory", "Sprzedany");
        }
    }
}
