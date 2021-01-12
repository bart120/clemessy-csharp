using GestionAnnonce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestionAnnonce.Data
{
    public class GADbContext : DbContext
    {
        public GADbContext()
            :base("annonces_db_connection")
        {
            Database.SetInitializer<GADbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categorie> Categories { get; set; }
    }
}