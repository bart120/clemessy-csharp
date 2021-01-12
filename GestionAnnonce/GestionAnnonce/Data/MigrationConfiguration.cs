using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace GestionAnnonce.Data
{
    public class MigrationConfiguration : DbMigrationsConfiguration<GADbContext>
    {

        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}