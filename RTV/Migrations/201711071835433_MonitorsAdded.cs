namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MonitorsAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            
            CreateTable(
                "dbo.Monitories",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId });
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Monitories");
            CreateIndex("dbo.IdentityUserRoles", "IdentityRole_Id");
            AddForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles", "Id");
        }
    }
}
