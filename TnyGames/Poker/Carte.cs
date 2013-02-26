using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TnyGames.Poker
{
    public enum Couleur { Pique, Coeur, Carreau, Trefle }
    public enum Valeur { Deux, Trois, Quatre, Cinq,Six,Sept,Huit,Neuf,Dix,Valet,Dame,Roi,As }
    public class Carte
    {
        public Couleur Couleur { get; set; }
        public Valeur Valeur { get; set; }
    }
}
