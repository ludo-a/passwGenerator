using generateur_mot_de_passe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formationCS
{
    static class outils
    {
        public static int DemanderNombrePositifNonNul(string question)
        {
            return DemanderNombreEntre(question, 1, int.MaxValue);
        }

        public static int DemanderNombreEntre(string question, int min, int max)
        {
            // nombre = DemanderNombre(question)
            int nombre = DemanderNombre(question);
            if ((nombre >= min) && (nombre <= max))
            {
                // valide
                return nombre;
            }
            Console.WriteLine("ERREUR : Le nombre doit être compris entre " + min + " et " + max);

            return DemanderNombreEntre(question, min, max);
        }

        static int DemanderNombre(string question)
        {
            while (true)
            {
                Console.Write(question);
                string reponse = Console.ReadLine();
                try
                {
                    int reponseInt = int.Parse(reponse);
                    return reponseInt;
                }
                catch
                {
                    Console.WriteLine("ERREUR : Vous devez rentrer un nombre");
                }
            }
        }

        public static MotDePasse GenerationMDP(int longeurMotDePasse, int choix)
        {
            //creation des possibilitées
            string minuscules = "abcdefghijklmnopqrstuvwxyz";
            string majuscules = minuscules.ToUpper();
            string chiffres = "0123456789";
            string caracteres = "&#(?[!-])@$";
            string alphabet ="";

            switch (choix)
            {
                case 1:
                    alphabet = minuscules;
                    break;

                case 2:
                    alphabet = minuscules + majuscules;
                    break;

                case 3:
                    alphabet = chiffres + caracteres;
                    break;

                case 4:
                    alphabet = minuscules + majuscules + chiffres + caracteres;
                    break;
            }

            string motDePasse = "";
            int longueurAlphabet = alphabet.Length;
            Random rand = new Random();

            //boucler sur longueur motdepasse
            for (int i = 0; i < longeurMotDePasse; i++)
            {
                int index = rand.Next(0, longueurAlphabet);
                motDePasse += alphabet[index];
            }

            MotDePasse mot = new MotDePasse();
            mot.Name = motDePasse;
            
            return mot;
        }

        public static List<MotDePasse> GenerateurAllMDP(int longeurMotDePasse, int choix, int nombreMotDePasse)
        {
            List<MotDePasse> list = new List<MotDePasse>();
            for(int i= 0; i < nombreMotDePasse; i++)
            {
                list.Add(GenerationMDP(longeurMotDePasse, choix));
            }
            return list;
        }
    }
}
