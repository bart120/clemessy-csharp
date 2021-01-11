using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContact.Metier
{
    public class ComparateurContactDate : IComparer<Contact>
    {
        public int Compare(Contact x, Contact y)
        {
            return x.DateNaissance.CompareTo(y.DateNaissance);
        }
    }
}
