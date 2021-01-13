using GestionAnnonce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GestionAnnonce.Data
{
    public class GADbContext : DbContext
    {
        public GADbContext()
            :base("annonces_db_connection")
        {
            this.Database.Log = GADbContext.Log;
            Database.SetInitializer<GADbContext>(null);
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Annonce> Annonces { get; set; }

        public static void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}