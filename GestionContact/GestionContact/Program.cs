using GestionContact.Metier;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GestionContact.Utils;

namespace GestionContact
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                afficherMenu();
                Console.WriteLine("Votre choix ?");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        ajouterContact();
                        break;
                    case "2":
                        listerContact();
                        break;
                    case "3":
                        trierContact();
                        break;
                    case "4":
                        trierContactParDate();
                        break;
                    case "5":
                        rechercherContactParNom();
                        break;
                    case "6":
                        rechercherContactParMail();
                        break;
                    case "7":
                        rechercherContactLinq();
                        break;
                    case "q":
                        return;
                    default:
                        Console.WriteLine("Choix incorrect.");
                        break;
                }
            }
        }

        private static void rechercherContactLinq()
        {
            List<Contact> liste = Contact.Lister();
            liste.Where();
        }

        private static void rechercherContactParMail()
        {
            List<Contact> liste = Contact.Lister();
            Console.WriteLine("Domaine ?");
            var domaine = Console.ReadLine();

            //1
            /*List<Contact> resultat = liste.FindAll(delegate (Contact c)
            {
                return c.Email.Contains(domaine);
            });*/

            //2
            /*List<Contact> resultat = liste.FindAll(c =>
            {
                return c.Email.Contains(domaine);
            });*/

            //3
            List<Contact> resultat = liste.FindAll(c => c.Email.Contains(domaine));

            foreach (var item in resultat)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void rechercherContactParNom()
        {
            List<Contact> liste = Contact.Lister();

            List<Contact> resultat = liste.FindAll(Contact.RechercheNom);
            foreach (var item in resultat)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void trierContactParDate()
        {
            List<Contact> liste = Contact.Lister();

            liste.Sort(new ComparateurContactDate());

            foreach (var item in liste)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void trierContact()
        {
            List<Contact> liste = Contact.Lister();

            liste.Sort();

            foreach (var item in liste)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void listerContact()
        {
            /*DateTime dt = DateTime.Now;
            DateTime premier = Perso.PremierJourSemaine(dt);

            DateTime premier2 = dt.PremierJourSemaine();*/

            List<Contact> liste = Contact.Lister();

            foreach (var item in liste)
            {
                Console.WriteLine(item.ToString());
            }
        }



        private static void ajouterContact()
        {
            Contact c = new Contact();

            Console.WriteLine("Nom ?");
            c.Nom = Console.ReadLine();

            Console.WriteLine("Prénom ?");
            c.Prenom = Console.ReadLine();

            Console.WriteLine("Email ?");
            c.Email = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("Date de naissance ?");
                    c.DateNaissance = Convert.ToDateTime(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur de saisie!");
                }
            }
            c.Enregistrer();
            Console.WriteLine("Contact enregistré");
        }

        private static void afficherMenu()
        {
            Console.WriteLine("-- MENU --");
            Console.WriteLine("1- Ajouter contact");
            Console.WriteLine("2- Lister les contacts");
            Console.WriteLine("3- Trier les contacts");
            Console.WriteLine("4- Trier les contacts par date");
            Console.WriteLine("5- Rechercher les contacts par nom");
            Console.WriteLine("6- Rechercher les contacts par mail");
            Console.WriteLine("7- Linq");
            Console.WriteLine("q- Quitter");
        }

    }
}
