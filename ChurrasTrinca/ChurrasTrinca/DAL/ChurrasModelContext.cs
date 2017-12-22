using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using ChurrasTrinca.Models;

namespace ChurrasTrinca.DAL
{
    public class ChurrasModelContext : DbContext
    {
        public DbSet<Churras> Churras { get; set; }
        public DbSet<Participante> Participantes { get; set; }

        public ChurrasModelContext()
            : base("name=ChurrasModelContext")
        {
            //Database.SetInitializer<ChurrasModelContext>(new CreateDatabaseIfNotExists<ChurrasModelContext>());
            Database.SetInitializer<ChurrasModelContext>(new DropCreateDatabaseIfModelChanges<ChurrasModelContext>());
            //Database.SetInitializer<ChurrasModelContext>(new DropCreateDatabaseAlways<ChurrasModelContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}