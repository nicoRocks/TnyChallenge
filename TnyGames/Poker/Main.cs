using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TnyGames.Poker
{
    class Main
    {
        public Carte carte1 { get; set; }
        public Carte carte2 { get; set; }
        public bool Donneur { get; set; }

        public float Pourcentage{ get; set; }

        public bool Push()
        {
            trieCarte();
            //paire de plus de 5
            if (carte1.Valeur == carte2.Valeur && carte1.Valeur >= Valeur.Cinq) return true;

            //As et plus de 7
            if (carte1.Valeur ==  Valeur.As && carte2.Valeur >= Valeur.Sept)return true;

            //roi et plus 10
            if (carte1.Valeur ==  Valeur.Roi && carte2.Valeur >= Valeur.Dix)return true;

            //dame valet
            if (carte1.Valeur ==  Valeur.Dame && carte2.Valeur >= Valeur.Valet)return true;

            //suit conected
            if (carte1.Couleur == carte2.Couleur && (carte1.Valeur - carte2.Valeur == 1 || (carte1.Valeur == Valeur.As && carte2.Valeur == Valeur.Deux))) return true;


            return false;
        }

        private void trieCarte()
        {
            if (carte1.Valeur < carte2.Valeur)
            {
                Carte tmp = carte1;
                carte1 = carte2;
                carte2 = tmp;
            }
        }


    }
}
