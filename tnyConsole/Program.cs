using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TnyGames.Poker;
using System.Diagnostics;

namespace tnyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            Moteur m = new Moteur();
            var d = m.GetValue("01001S8S9?????");
            Console.WriteLine(d);
            t.Stop();
            Console.WriteLine(t.Elapsed);

            Console.ReadLine();
        }
    }
}
