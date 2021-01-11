using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;

namespace GestionContact.Metier
{
    public class Contact : IComparable<Contact>
    {
        public Contact()
        {
            this.DateNaissance = DateTime.Now;

        }

        public Contact(string nom) : this()
        {
            this.Nom = nom;
        }

        public Contact(string nom, string prenom) : this(nom)
        {
            this.Prenom = prenom;
        }

        ~Contact()
        {
            // destructeur
        }

        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom { get; set; }

        public DateTime DateNaissance { get; set; }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                Regex regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
                if (regex.IsMatch(value))
                    _email = value;
                else
                    throw new FormatException("L'email n'est pas au bon format.");
            }
        }

        public void Enregistrer()
        {
            string chemin = ConfigurationManager.AppSettings["chemin_fichier"];
            using (StreamWriter sw = new StreamWriter(chemin, true, Encoding.UTF8))
            {
                sw.WriteLine(this.ToString());
            }

            //File.AppendAllText(chemin, this.ToString());
        }

        public static List<Contact> Lister()
        {
            var liste = new List<Contact>();
            var fichier = File.ReadLines(ConfigurationManager.AppSettings["chemin_fichier"]);
            foreach (var ligne in fichier)
            {
                var tab = ligne.Split(';');
                liste.Add(new Contact
                {
                    Nom = tab[0],
                    Prenom = tab[1],
                    Email = tab[2],
                    DateNaissance = Convert.ToDateTime(tab[3])
                });
            }
            return liste;
        }

        public static bool RechercheNom(Contact c)
        {
            return c.Nom.Contains("o");
        }

        public override string ToString()
        {
            string resultat = string.Format("{0};{1};{2};{3}", Nom, Prenom, Email, DateNaissance.ToString("dd/MM/yyyy"));
            return resultat;
        }

        public int CompareTo(Contact other)
        {
            var comp = this.Nom.CompareTo(other.Nom);
            if(comp == 0)
                return this.Prenom.CompareTo(other.Prenom);
            return comp;

        }
    }
}
