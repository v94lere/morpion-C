using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion {
    internal class GrilleMorpion {
        private int[,] grille = new int[3, 3];
        public GrilleMorpion() {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    grille[i, j] = 0;
                }
            }
        }
        public bool caseVide(int ligne, int colonne) {
            if (grille[ligne, colonne] == 0) {
                return true;
            }
            else
                return false;
        }

        public void deposerJeton(int ligne, int colonne, int id){

        while ((!caseVide(ligne, colonne)) || (ligne > 2) || (colonne > 2)) {
                Console.WriteLine("La case n'est pas libre");
                Console.WriteLine("Saisissez une ligne (0 - 2)");
                ligne = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Saisissez une colonne (0 - 2)");
                colonne = Convert.ToInt32(Console.ReadLine());
            }
            grille[ligne, colonne] = id;
        }
        public bool ligneComplete(int ligne, int id) {
            int total = 0;
            for (int i = 0; i < 3; i++)
            {
                if (grille[ligne, i] == id) {
                    total++;
                }
                else {
                    total = 0;
                }
            }
            if (total == 3) {
                return true;
            }
            else {
                return false;
            }
        }
        public bool colonneComplete(int colonne, int id) {
            int total = 0;
            for (int i = 0; i < 3; i++) {
                if (grille[i, colonne] == id) {
                    total++;
                }
                else {
                    total = 0;
                }
            }
            if (total == 3) {
                return true;
            }
            else {
                return false;
            }
        }
        public bool diagonaleComplete(int diagonale, int id) {
            bool plein = false;
            if (diagonale == 1) {
                if ((grille[0, 0] == id) && (grille[1, 1] == id) && (grille[2, 2] == id)) {
                    plein = true;
                }
                else {
                    plein = false;
                }
            }
            else if (diagonale == 2) {
                if ((grille[2, 0] == id) && (grille[1, 1] == id) && (grille[0, 2] == id)) {
                    plein = true;
                }
                else {
                    plein = false;
                }
            }
            return plein;
        }
        public bool victoireJoueur(int id, int ligne, int colonne) {
            if ((ligneComplete(ligne, id)) || (colonneComplete(colonne, id)) || (diagonaleComplete(1, id)) || (diagonaleComplete(2, id))) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool grillePleine() {
            int total = 0;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (grille[i, j] != 0) {
                        total++;
                    }
                }
            }
            if (total == grille.Length) {
                return true;
            }
            else
                return false;
        }
         public void affichageGrille() {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    Console.Write(grille[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

    }
}
