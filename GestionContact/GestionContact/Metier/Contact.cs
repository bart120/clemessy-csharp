using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;

namespace GestionContact.Metier
{
    public class Contact
    {
        public Contact()
        {
            this.DateNaissance = DateTime.Now;
                
        }

        public Contact(string nom):this()
        {
            this.Nom = nom;
        }

        public Contact(string nom, string prenom):this(nom)
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
            set {
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
        }

        public override string ToString()
        {
            string resultat = string.Format("{0};{1};{2};{3}", Nom, Prenom, Email, DateNaissance.ToString("dd/MM/yyyy"));
            return resultat;
        }

    }
}
