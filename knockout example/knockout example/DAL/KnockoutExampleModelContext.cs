using knockout_example.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace knockout_example.DAL
{
    public class KnockoutExampleModelContext : DbContext
    {
        public DbSet<Lookup> Lookup { get; set; }

        public KnockoutExampleModelContext()
            : base("name=KnockoutExampleModelContext")
        {
            //Database.SetInitializer<KnockoutExampleModelContext>(new CreateDatabaseIfNotExists<KnockoutExampleModelContext>());
            Database.SetInitializer<KnockoutExampleModelContext>(new DropCreateDatabaseIfModelChanges<KnockoutExampleModelContext>());
            //Database.SetInitializer<KnockoutExampleModelContext>(new DropCreateDatabaseAlways<KnockoutExampleModelContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}