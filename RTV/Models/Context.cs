using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace RTV.Models
{
    public class Context : DbContext
    {
        public Context()  
        : base("Context")  {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // throw new UnintentionalCodeFirstException();
        }

        public DbSet<Registration> Registrations { get; set; }
    }
}