using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TnyGames.Shifumi
{
    public class Moteur
    {
        static Random rnd = new Random();
        static int getRandom(int faces)
        {
            return rnd.Next(faces) + 1;
        }
        public string GetValue(int faces)
        {
            return getRandom(faces).ToString();
        }

    }
}
