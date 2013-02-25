using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TnyGames.Morpion
{
    public enum Motif {Vide = 0,Croix = 1,Rond = 2 }
    public class Case
    {
        public int Position { get; set; }
        public Motif motif { get; set; }
    }
}
