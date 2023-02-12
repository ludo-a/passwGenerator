using formationCS;
using System;
using System.Collections.Generic;

namespace generateur_mot_de_passe
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 - Demander a longueur du mot de passe (DemanderNombre) int longeur_mot_de_passe = ...
            int longeurMotDePasse = outils.DemanderNombrePositifNonNul("Longueur du mot de passe : ");

            // 2 - Poser la question du choix du type de mot de passe et récupérer le choix
            int choix = outils.DemanderNombreEntre("Vous voulez un mot de passe avec:\n" +
                "1 - Uniquement des caractères en minuscule\n" +
                "2 - Des caractères minuscules et majuscules\n" +
                "3 - Des caractères et des chiffres\n" +
                "4 - Caractères, chiffres et caractères spéciaux\n" +
                "Votre choix : ", 1, 4);

            int nombreMotDePasse = outils.DemanderNombrePositifNonNul("Combien de mot de passe ? : ");

            List<MotDePasse> reponseGenerateur = outils.GenerateurAllMDP(longeurMotDePasse, choix, nombreMotDePasse);

            //afficher les résultats
            reponseGenerateur.ForEach(motDepasse =>
            {
                Console.WriteLine(motDepasse.Name);
            });
        }
    }
}
