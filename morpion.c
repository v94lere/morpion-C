#include <stdio.h>
#include <stdlib.h>
#include "morpion.h"

void initialiserTableau(morp *morpion) {
    int i = 0, j = 0;

    for(i = 0; i < 3; i++) {
        for(j = 0; j < 3; j++) {
            morpion->tableau[i][j] = 0;
        }
    }
    morpion->libre = 9;
}

void affichageMorpion(morp morpion) {
    int i = 0, j = 0;
    char temp[3][3];

    for(i = 0; i < 3; i++) {
        for(j = 0; j < 3; j++) {
            if(morpion.tableau[i][j] == 1) {
                temp[i][j] = 'X';
            }
            else if(morpion.tableau[i][j] == 2) {
                temp[i][j] = 'O';
            }
            else {
                temp[i][j] = ' ';
            }
        }
    }

    system("cls");

    printf("\n");
    printf("       1       2       3");
    printf("\n");
    printf("   * * * * * * * * * * * * *\n");
    printf("   *       *       *       *\n");
    printf(" A *   %c   *   %c   *   %c   *   A\n", temp[0][0], temp[0][1], temp[0][2]);
    printf("   *       *       *       *\n");
    printf("   * * * * * * * * * * * * *\n");
    printf("   *       *       *       *\n");
    printf(" B *   %c   *   %c   *   %c   *   B\n", temp[1][0], temp[1][1], temp[1][2]);
    printf("   *       *       *       *\n");
    printf("   * * * * * * * * * * * * *\n");
    printf("   *       *       *       *\n");
    printf(" C *   %c   *   %c   *   %c   *   C\n", temp[2][0], temp[2][1], temp[2][2]);
    printf("   *       *       *       *\n");
    printf("   * * * * * * * * * * * * *\n");
    printf("       1       2       3\n");

}

void joueurMorpion(morp morpion) {
    int joueur = 1, ok = 1;
    do {
        do{
            int i = 0, j = 0;

            if(morpion.libre == 9) {
                printf("\nC'est les X qui commencent.\n");
            }

            if(joueur == 1 && morpion.libre != 9) {
                printf("\nC'est les X qui jouent.\n");
            }

            else if(joueur == 2 && morpion.libre != 9) {
                printf("\nC'est les O qui commencent.\n");
            }

            printf("\nIl reste %d coups\n", morpion.libre);

            do {
                printf("\nSur quelle ligne jouez-vous (chiffre) ?");
                printf("\n1. A");
                printf("\n2. B");
                printf("\n3. C\n ");
                scanf("%d", &i);
                i--;
                affichageMorpion(morpion);
            } while(i != 0 && i != 1 && i != 2);

            do {
                printf("\nSur quelle colonne jouez-vous (chiffre) ?");
                printf("\n1. 1");
                printf("\n2. 2");
                printf("\n3. 3\n ");
                scanf("%d", &j);
                j--;
                affichageMorpion(morpion);
            } while(j != 0 && j != 1 && j != 2);


            if(morpion.tableau[i][j] == 1 || morpion.tableau[i][j] == 2) {
                ok = 0;
                affichageMorpion(morpion);
            }

            else {
                morpion.tableau[i][j] = joueur;
            }

        } while(ok != 1);

        affichageMorpion(morpion);

// On vérifie les conditions de victoire pour les X
        if(morpion.tableau[0][0] == 1 && morpion.tableau[0][1] == 1 && morpion.tableau[0][2] == 1) { // vérifiction 1ere ligne
            printf("\nLes X gagnent\n");
            morpion.libre = 0;
        }
        else if(morpion.tableau[1][0] == 1 && morpion.tableau[1][1] == 1 && morpion.tableau[1][2] == 1) { // vérification 2ème ligne
            printf("\nLes X gagnent\n");
            morpion.libre = 0;
        }

        else if(morpion.tableau[2][0] == 1 && morpion.tableau[2][1] == 1 && morpion.tableau[2][2] == 1) { // vérification 3ème ligne
            printf("\nLes X gagnent\n");
            morpion.libre = 0;
        }

        else if(morpion.tableau[1][0] == 1 && morpion.tableau[1][0] == 1 && morpion.tableau[2][0] == 1) { // vérification 1ere colonne
            printf("\nLes X gagnent\n");
            morpion.libre = 0;
        }

        else if(morpion.tableau[0][1] == 1 && morpion.tableau[1][1] == 1 && morpion.tableau[2][1] == 1) { // vérification 2ème colonne
            printf("\nLes X gagnent\n");
            morpion.libre = 0;
        }

        else if(morpion.tableau[0][2] == 1 && morpion.tableau[1][2] == 1 && morpion.tableau[2][2] == 1) { // vérification 3ème colonne
            printf("\nLes X gagnent\n");
            morpion.libre = 0;
        }

        else if(morpion.tableau[0][0] == 1 && morpion.tableau[1][1] == 1 && morpion.tableau[2][2] == 1) { // vérification 1ère diagonale
            printf("\nLes X gagnent\n");
            morpion.libre = 0;
        }
        else if(morpion.tableau[2][0] == 1 && morpion.tableau[1][1] == 1 && morpion.tableau[0][2] == 1) { // vérification 2sd diagonale
            printf("\nLes X gagnent\n");
            morpion.libre = 0;
        }
// ============================================= //

// On vérifie les conditions de victoire pour les 0
        else if(morpion.tableau[0][0] == 2 && morpion.tableau[0][1] == 2 && morpion.tableau[0][2] == 2) { // vérifiction 1ere ligne
            printf("\nLes O gagnent\n");
            morpion.libre = 0;
        }
        else if(morpion.tableau[1][0] == 2 && morpion.tableau[1][1] == 2 && morpion.tableau[1][2] == 2) { // vérification 2ème ligne
            printf("\nLes O gagnent\n");
            morpion.libre = 0;
        }

        else if(morpion.tableau[2][0] == 2 && morpion.tableau[2][1] == 2 && morpion.tableau[2][2] == 2) { // vérification 3ème ligne
            printf("\nLes O gagnent\n");
            morpion.libre = 0;
        }

        else if(morpion.tableau[1][0] == 2 && morpion.tableau[1][0] == 2 && morpion.tableau[2][0] == 2) { // vérification 1ere colonne
            printf("\nLes O gagnent\n");
            morpion.libre = 0;
        }

        else if(morpion.tableau[0][1] == 2 && morpion.tableau[1][1] == 2 && morpion.tableau[2][1] == 2) { // vérification 2ème colonne
            printf("\nLes O gagnent\n");
            morpion.libre = 0;
        }

        else if(morpion.tableau[0][2] == 2 && morpion.tableau[1][2] == 2 && morpion.tableau[2][2] == 2) { // vérification 3ème colonne
            printf("\nLes O gagnent\n");
            morpion.libre = 0;
        }

        else if(morpion.tableau[0][0] == 2 && morpion.tableau[1][1] == 2 && morpion.tableau[2][2] == 2) { // vérification 1ère diagonale
            printf("\nLes O gagnent\n");
            morpion.libre = 0;
        }
        else if(morpion.tableau[2][0] == 2 && morpion.tableau[1][1] == 2 && morpion.tableau[0][2] == 2) { // vérification 2sd diagonale
            printf("\nLes O gagnent\n");
            morpion.libre = 0;
        }
// ============================================= //

        else {
// On retire un coup possible
            morpion.libre--;

// Match nul
            if(morpion.libre == 0) {
                printf("Match nul\n");
            }

// On change de joueur
            if(joueur == 1) {
                joueur = 2;
            }
            else if(joueur == 2) {
            joueur = 1;
            }
        }

    } while(morpion.libre != 0);
}
