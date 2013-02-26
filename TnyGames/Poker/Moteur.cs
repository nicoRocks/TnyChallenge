using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TnyGames.Poker
{
    public class Moteur
    {
        public string GetValue(string p)
        {
            string rang = p.Substring(0, 2);
            string nbCoupsAboutis = p.Substring(2, 2);
            string etape = p.Substring(4, 1);
            
            string lesCartes1= p.Substring(5, 4);
            string lesCartes2 = p.Substring(9, 4);

            Main main = setMain(rang, lesCartes1, lesCartes2);

            return main.Push()?"100":"0";
        }

        private Main setMain(string rang, string lesCartes1, string lesCartes2)
        {
            Main m = new Main();
            m.Donneur = int.Parse(rang) % 2 == 0;
            if (lesCartes2.Contains('?'))
            {
                m.carte1 = transform(lesCartes1.Substring(0, 2));
                m.carte2 = transform(lesCartes1.Substring(2, 2));
            }
            else
            {
                m.carte1 = transform(lesCartes2.Substring(0, 2));
                m.carte2 = transform(lesCartes2.Substring(2, 2));
            }

            return m;
        }

        private Carte transform(string p)
        {
            Carte c = new Carte();
            char couleur = p[0];
            char valeur = p[0];

            switch (couleur)
            {
                case 'S': c.Couleur = Couleur.Pique;
                    break;
                case 'C': c.Couleur = Couleur.Trefle;
                    break;
                case 'H': c.Couleur = Couleur.Coeur;
                    break;
                case 'D': c.Couleur = Couleur.Carreau;
                    break;
            }
            switch (valeur)
            {
                case '2': c.Valeur = Valeur.Deux;
                    break;
                case '3': c.Valeur = Valeur.Trois;
                    break;
                case '4': c.Valeur = Valeur.Quatre;
                    break;
                case '5': c.Valeur = Valeur.Cinq;
                    break;
                case '6': c.Valeur = Valeur.Six;
                    break;
                case '7': c.Valeur = Valeur.Sept;
                    break;
                case '8': c.Valeur = Valeur.Huit;
                    break;
                case '9': c.Valeur = Valeur.Neuf;
                    break;
                case 'T': c.Valeur = Valeur.Dix;
                    break;
                case 'j': c.Valeur = Valeur.Valet;
                    break;
                case 'Q': c.Valeur = Valeur.Dame;
                    break;
                case 'K': c.Valeur = Valeur.Roi;
                    break;
                case '1': c.Valeur = Valeur.As;
                    break;
            }

            return c;
        }
    }
}
