using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionContact.Metier
{
    public class Adresse
    {
        public string Mail{ get; set; }
        public string  Rue { get; set; }
        public string Code { get; set; }
        public string Ville { get; set; }

        public static List<Adresse> Lister()
        {
            var liste = new List<Adresse>();
            var fichier = File.ReadLines(ConfigurationManager.AppSettings["chemin_fichier_adresses"]);
            foreach (var ligne in fichier)
            {
                var tab = ligne.Split(';');
                liste.Add(new Adresse
                {
                    Mail = tab[0],
                    Rue = tab[1],
                    Code = tab[2],
                    Ville = tab[3]
                });
            }
            return liste;
        }
    }
}
