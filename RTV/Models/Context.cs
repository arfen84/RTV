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

            modelBuilder.Entity<Monitor>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Monitory");
            });
            modelBuilder.Entity<Drukarka>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Drukarki");
            });
            modelBuilder.Entity<Laptop>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Laptopy");
            });
            modelBuilder.Entity<Grafika>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Graficzne");
            });
            modelBuilder.Entity<Procesor>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Procesory");
            });
            modelBuilder.Entity<Plyta>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Plyty");
            });
            modelBuilder.Entity<RAM>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("RAMy");
            });
            modelBuilder.Entity<Zasilacz>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Zasilacze");
            });
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new
            //{
            //    r.RoleId,
            //    r.UserId
            //});
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            // modelBuilder.Entity<IdentityRole>().ToTable("Role");
            // throw new UnintentionalCodeFirstException();
        }

        public DbSet<Registration> Registrations { get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }

        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Drukarka> Drukarki { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Grafika> Graficzne { get; set; }
        public DbSet<Procesor> Procesory { get; set; }
        public DbSet<Plyta> Plyty { get; set; }
        public DbSet<RAM> RAM { get; set; }
        public DbSet<Zasilacz> Zasilacze { get; set; }
        //public DbSet<Product> Products { get; set; }
    }
}