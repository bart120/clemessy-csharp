using GestionContact.Metier;
using System;
using System.Collections.Generic;
using System.Text;

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
                    case "q":
                        return;
                    default:
                        Console.WriteLine("Choix incorrect.");
                        break;
                }
            }
        }

        private static void listerContact()
        {
            List<Contact> liste =  Contact.Lister();

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
            Console.WriteLine("q- Quitter");
        }

    }
}
