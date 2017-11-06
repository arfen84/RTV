namespace RTV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminSecured : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Registration", newName: "Registrations");
            DropForeignKey("dbo.IdentityUserClaim", "Registration_UserId", "dbo.Registration");
            DropForeignKey("dbo.IdentityUserLogin", "Registration_UserId", "dbo.Registration");
            DropIndex("dbo.IdentityUserClaim", new[] { "Registration_UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "Registration_UserId" });
            DropColumn("dbo.Registrations", "EmailConfirmed");
            DropColumn("dbo.Registrations", "PasswordHash");
            DropColumn("dbo.Registrations", "SecurityStamp");
            DropColumn("dbo.Registrations", "PhoneNumber");
            DropColumn("dbo.Registrations", "PhoneNumberConfirmed");
            DropColumn("dbo.Registrations", "TwoFactorEnabled");
            DropColumn("dbo.Registrations", "LockoutEndDateUtc");
            DropColumn("dbo.Registrations", "LockoutEnabled");
            DropColumn("dbo.Registrations", "AccessFailedCount");
            DropColumn("dbo.Registrations", "Id");

            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.IdentityUserLogin");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Registration_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Registrations", "Id", c => c.String());
            AddColumn("dbo.Registrations", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Registrations", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Registrations", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Registrations", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Registrations", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Registrations", "PhoneNumber", c => c.String());
            AddColumn("dbo.Registrations", "SecurityStamp", c => c.String());
            AddColumn("dbo.Registrations", "PasswordHash", c => c.String());
            AddColumn("dbo.Registrations", "EmailConfirmed", c => c.Boolean(nullable: false));
            CreateIndex("dbo.IdentityUserLogin", "Registration_UserId");
            CreateIndex("dbo.IdentityUserClaim", "Registration_UserId");
            AddForeignKey("dbo.IdentityUserLogin", "Registration_UserId", "dbo.Registration", "UserId");
            AddForeignKey("dbo.IdentityUserClaim", "Registration_UserId", "dbo.Registration", "UserId");

            RenameTable(name: "dbo.Registrations", newName: "Registration");
        }
    }
}
