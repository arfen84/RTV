using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RTV.Models
{
    public class Context : DbContext
    {
        public Context()
        : base("Context") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new
            {
                r.RoleId,
                r.UserId
            });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            // throw new UnintentionalCodeFirstException();
        }

        public DbSet<Registration> Registrations { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }

    }
    //public class DXContext : DbContext
    //{
    //    public DXContext()
    //        : base("name=Context") // connection string in the application configuration file.
    //    {
    //        Database.SetInitializer<DXContext>(null); // Remove default initializer
    //        Configuration.LazyLoadingEnabled = false;
    //        Configuration.ProxyCreationEnabled = false;
    //    }

    //    // Domain Model
    //    public DbSet<IdentityRole> Roles { get; set; }
    //    // ... other custom DbSets

    //    public static DXContext Create()
    //    {
    //        return new DXContext();
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
    //        modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
    //        modelBuilder.Entity<IdentityUserRole>().HasKey(r => new {
    //            r.RoleId,
    //            r.UserId
    //        });
    //        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

    //        // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
    //        modelBuilder.Entity<IdentityRole>().ToTable("Role");
    //    }

    //    public DbQuery<T> Query<T>() where T : class
    //    {
    //        return Set<T>().AsNoTracking();
    //    }
    //}
}