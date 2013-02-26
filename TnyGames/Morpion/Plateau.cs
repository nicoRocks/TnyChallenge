using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TnyGames.Morpion
{
    public class Plateau
    {
        public List<Case> Cases { get; set; }
        public Motif motifMax { get; set; }
        public Motif motifMin { get; set; }
        public Plateau()
        {
            Cases = new List<Case>();
        }
        public Plateau(string liste) : this()
        {
            for (int i = 0; i < liste.Length; i++)
            {
                Cases.Add(new Case{ Position = i+1,motif= (Motif)(int.Parse(liste.Substring(i, 1)))});
            }
            var nbZero = Cases.Where(x => x.motif == Motif.Vide).Count();
            var nbUn = Cases.Where(x => x.motif == Motif.Rond).Count();
            var nbDeux = Cases.Where(x => x.motif == Motif.Croix).Count();
            if ((nbZero + nbUn + nbDeux) != 9)
                throw new Exception("erreur");
            if (Math.Abs(nbUn - nbDeux) > 1)
                throw new Exception("erreur");
            if (nbUn > nbDeux)
            {
                motifMax = Motif.Rond;
                motifMin = Motif.Croix;
            }
            else
            {
                motifMax = Motif.Rond;
                motifMin = Motif.Croix;
            }
        }
        public override string ToString()
        {
            StringBuilder ts = new StringBuilder();
            foreach (var p in Cases)
            {
                string pion = "_";
                if (p.motif == Motif.Rond) pion = "O";
                if (p.motif == Motif.Croix) pion = "X";
                ts.Append(pion);
                if(p.Position % 3 == 0) ts.AppendLine();
             
            } 
            return ts.ToString();
        }

        public bool MotifMaxGagne()
        {
            return MotifGagne(motifMax);
        }
        public bool MotifMinGagne()
        {
            return MotifGagne(motifMin);
        }
        public bool MotifGagne(Motif motif)
        {
            List<string> combinaisonsGagnantes = new List<string> { "123", "456", "789", "147", "258", "369", "159", "357" };
            var croix = Cases.Where(x => x.motif == motif).SelectMany(x => x.Position.ToString()).ToArray();
            foreach (var c in combinaisonsGagnantes)
            {
                if (croix.Contains(c[0]) && croix.Contains(c[1]) && croix.Contains(c[2])) return true;
            }
            return false;
            //return combinaisonsGagnantes.Any(y => y.All(z => croix.Contains(z)));
        }

        public bool IsFull()
        {
            if( Cases.Where(x => x.motif == Motif.Vide).Count() == 0) return true;

            if (MotifMaxGagne() || MotifMinGagne()) return true;

            return false;
        }
    }
}
