using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContact.Utils
{
    public static class Perso
    {

        public static DateTime PremierJourSemaine(this DateTime dt)
        {
            return dt.AddDays(-1);
        }

    }
}
