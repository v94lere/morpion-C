    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion_ValereNeveux
{
    static internal class Jeu
    {

        public static void jouerMorpion()
        {
            int Joueur = 0;
            bool fini = false;
            GrilleMorpion grilleMorpion = new GrilleMorpion();
            int ligne;
            int colonne;

            grilleMorpion.affichageGrille();
            while (!fini)
            {
                if ((Joueur == 0) || (Joueur == 2))
                {
                    Joueur = 1;
                }
                else if (Joueur == 1)
                {
                    Joueur = 2;
                }
                Console.WriteLine("Dans quel ligne souhaitez vous insérer votre jeton? (0 - 2)");
                ligne = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Dans quel colonne souhaitez vous insérer votre jeton? (0 - 2)");
                colonne = Convert.ToInt32(Console.ReadLine());
                grilleMorpion.deposerJeton(ligne, colonne, Joueur);
                if (grilleMorpion.victoireJoueur(Joueur, ligne, colonne))
                {
                    fini = true;
                    Console.WriteLine(" La partie est finit, le Joueur " + Joueur + " à remporté le jeu");
                }
                if ((grilleMorpion.grillePleine()) && (!fini))
                {
                    fini = true;
                    Console.WriteLine("Egalité !");
                }
                grilleMorpion.affichageGrille();


            }

        }

        public static void jouerPuissance4()
        {
            int Joueur = 0;
            bool fini = false;
            GrillePuissance4 grillePuissance4 = new GrillePuissance4();
            int colonne;

            grillePuissance4.affichageGrille();
            while (!fini)
            {
                if ((Joueur == 0) || (Joueur == 2))
                {
                    Joueur = 1;
                }
                else if (Joueur == 1)
                {
                    Joueur = 2;
                }
                Console.WriteLine("Dans quel colonne souhaitez vous insérer votre jeton? (0 - 6)");
                colonne = Convert.ToInt32(Console.ReadLine());
                grillePuissance4.deposerJeton(colonne, Joueur);
                if (grillePuissance4.victoireJoueur(Joueur, colonne))
                {
                    fini = true;
                    Console.WriteLine("La partie est finit, le Joueur " + Joueur + " à remporté le jeu");
                }
                if ((grillePuissance4.grillePleine()) && (!fini))
                {
                    fini = true;
                    Console.WriteLine("Egalité !");
                }
                grillePuissance4.affichageGrille();


            }

        }

        static void Main(string[] args)
        {
            bool jouer = true;
            int choix = 0;

            while (jouer)
            {
                Console.WriteLine("A quel jeu voulez vous jouer ? Tapez 1 pour Morpion, tapez 2 pour  Puissance 4");
                choix = Convert.ToInt32(Console.ReadLine());
                while ((choix < 1) || (choix > 2))
                {
                    Console.WriteLine("Choisissez entre 1 et 2");
                    choix = Convert.ToInt32(Console.ReadLine());
                }

                if (choix == 1)
                {
                    Jeu.jouerMorpion();
                }
                else if (choix == 2)
                {
                    Jeu.jouerPuissance4();
                }
                Console.WriteLine("Voulez vous rejouer ? (O pour Oui, N pour Non)");
                if ((Console.ReadLine() == "N") || (Console.ReadLine() == "Non"))
                {
                    jouer = false;
                }
            }
            Console.WriteLine("A bientot !");




        }

    }
}