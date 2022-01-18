#include <stdio.h>
#include <stdlib.h>
#include "morpion.h"

int main()
{
    int continuer = 1;
    do {
        morp monMorpion;
        initialiserTableau(&monMorpion);
        affichageMorpion(monMorpion);
        joueurMorpion(monMorpion);

        printf("Souhaitez-vous recommencer ?");
        printf("\n 1. Oui");
        printf("\n 2. Non\n ");
        scanf("%d", &continuer);
    } while(continuer != 2);

}
