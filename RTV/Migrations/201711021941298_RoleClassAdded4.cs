namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleClassAdded4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Registration_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Registration", t => t.Registration_UserId)
                .Index(t => t.Registration_UserId);
            
            AddColumn("dbo.Registration", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Registration", "PasswordHash", c => c.String());
            AddColumn("dbo.Registration", "SecurityStamp", c => c.String());
            AddColumn("dbo.Registration", "PhoneNumber", c => c.String());
            AddColumn("dbo.Registration", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Registration", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Registration", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Registration", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Registration", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Registration", "Id", c => c.String());
            AddColumn("dbo.IdentityUserRole", "Registration_UserId", c => c.Int());
            AddColumn("dbo.IdentityUserLogin", "Registration_UserId", c => c.Int());
            CreateIndex("dbo.IdentityUserLogin", "Registration_UserId");
            CreateIndex("dbo.IdentityUserRole", "Registration_UserId");
            AddForeignKey("dbo.IdentityUserLogin", "Registration_UserId", "dbo.Registration", "UserId");
            AddForeignKey("dbo.IdentityUserRole", "Registration_UserId", "dbo.Registration", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "Registration_UserId", "dbo.Registration");
            DropForeignKey("dbo.IdentityUserLogin", "Registration_UserId", "dbo.Registration");
            DropForeignKey("dbo.IdentityUserClaim", "Registration_UserId", "dbo.Registration");
            DropIndex("dbo.IdentityUserRole", new[] { "Registration_UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "Registration_UserId" });
            DropIndex("dbo.IdentityUserClaim", new[] { "Registration_UserId" });
            DropColumn("dbo.IdentityUserLogin", "Registration_UserId");
            DropColumn("dbo.IdentityUserRole", "Registration_UserId");
            DropColumn("dbo.Registration", "Id");
            DropColumn("dbo.Registration", "AccessFailedCount");
            DropColumn("dbo.Registration", "LockoutEnabled");
            DropColumn("dbo.Registration", "LockoutEndDateUtc");
            DropColumn("dbo.Registration", "TwoFactorEnabled");
            DropColumn("dbo.Registration", "PhoneNumberConfirmed");
            DropColumn("dbo.Registration", "PhoneNumber");
            DropColumn("dbo.Registration", "SecurityStamp");
            DropColumn("dbo.Registration", "PasswordHash");
            DropColumn("dbo.Registration", "EmailConfirmed");
            DropTable("dbo.IdentityUserClaim");
        }
    }
}
