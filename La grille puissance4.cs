using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion_ValereNeveux
{
    internal class GrillePuissance4
    {
        private int[,] grille = new int[4, 7];
        public GrillePuissance4()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    grille[i, j] = 0;
                }
            }
        }

        public bool caseVide(int ligne, int colonne)
        {
            if (grille[ligne, colonne] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void deposerJeton(int colonne, int id)
        {
            bool poser = false;
            int ligne = 3;

            while ((colonne > 6) || (grille[0, colonne] != 0))
            {

                Console.WriteLine("La colonne est pas libre");
                Console.WriteLine("Saisissez une nouvelle colonne (0 - 6)");
                colonne = Convert.ToInt32(Console.ReadLine());
            }

            while (!poser)
            {
                if (grille[ligne, colonne] == 0)
                {
                    grille[ligne, colonne] = id;
                    poser = true;
                }
                else
                {
                    ligne--;
                }

            }

        }

        public bool ligneComplete(int id)
        {
            int total = 0;

            for (int i = 0; i < 4; i++)
            {
                total = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (grille[i, j] == id)
                    {
                        total++;
                        if (total == 4)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        total = 0;
                    }


                }
            }

            return false;

        }
        public bool colonneComplete(int colonne, int id)
        {
            int total = 0;

            for (int i = 0; i < 4; i++)
            {
                if (grille[i, colonne] == id)
                {
                    total++;
                    if (total == 4)
                    {
                        return true;
                    }
                }
                else
                {
                    total = 0;
                }



            }
            return false;

        }
        public bool diagonaleComplete(int colonne, int id)
        {

            int total = 0;
            int ligneVerif = 0;
            int colonneVerif = 0;
            int i = 0;

            for (i = 0; i < 3; i++)
            {
                if (grille[i, colonne] == id)
                {
                    ligneVerif = i;
                    break;
                }
            }
            colonneVerif = colonne;
            ligneVerif = i;
            if ((grille[ligneVerif, colonne] == id) && (i - 3 >= 0) && (colonne - 3 >= 0))
            {


                for (int j = 0; j < 4; j++)
                {
                    if (grille[ligneVerif, colonneVerif] == id)
                    {
                        total++;
                        if (total == 4)
                        {
                            return true;
                        }

                    }
                    ligneVerif--;
                    colonneVerif--;
                }
                total = 0;
            }
            colonneVerif = colonne;
            ligneVerif = i;
            if ((grille[ligneVerif, colonne] == id) && (i + 3 < 4) && (colonne - 3 >= 0))
            {
                ligneVerif = i;
                colonneVerif = colonne;
                for (int j = 0; j < 4; j++)
                {
                    if (grille[ligneVerif, colonneVerif] == id)
                    {
                        total++;
                        if (total == 4)
                        {
                            return true;
                        }
                    }
                    ligneVerif++;
                    colonneVerif--;

                }
                total = 0;
            }
            colonneVerif = colonne;
            ligneVerif = i;
            if ((grille[ligneVerif, colonne] == id) && (i + 3 < 4) && (colonne + 3 < 7))
            {
                ligneVerif = i;
                colonneVerif = colonne;
                for (int j = 0; j < 4; j++)
                {
                    if (grille[ligneVerif, colonneVerif] == id)
                    {
                        total++;
                        if (total == 4)
                        {
                            return true;
                        }

                    }
                    ligneVerif++;
                    colonneVerif++;
                }
                total = 0;
            }
            ligneVerif = i;
            colonneVerif = colonne;
            if ((grille[ligneVerif, colonne] == id) && (i - 3 >= 0) && (colonne + 3 < 7))
            {
                ligneVerif = i;
                colonneVerif = colonne;
                for (int j = 0; j < 4; j++)
                {
                    if (grille[ligneVerif, colonneVerif] == id)
                    {
                        total++;
                        if (total == 4)
                        {
                            return true;
                        }

                    }
                    ligneVerif--;
                    colonneVerif++;
                }
                total = 0;
            }

            return false;
        }

        public bool victoireJoueur(int id, int colonne)
        {
            if ((ligneComplete(id)) || (colonneComplete(colonne, id)) || (diagonaleComplete(colonne, id)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool grillePleine()
        {

            int total = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (grille[i, j] != 0)
                    {
                        total++;
                    }
                }
            }
            if (total == grille.Length)
            {
                return true;
            }
            else
                return false;
        }

        public void affichageGrille()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(grille[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}