using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using YAPMT_PM.Models;

namespace YAPMT_PM.DAL
{
    public class ProjectContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public ProjectContext()
            : base("name=ProjectContext")
        {
            //Database.SetInitializer<ProjectContext>(new CreateDatabaseIfNotExists<ProjectContext>());
            Database.SetInitializer<ProjectContext>(new DropCreateDatabaseIfModelChanges<ProjectContext>());
            //Database.SetInitializer<ProjectContext>(new DropCreateDatabaseAlways<ProjectContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}