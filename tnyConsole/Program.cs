using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TnyGames.Morpion;
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
            var d = m.GetValue("121000002",2);
            Console.WriteLine(d);
            t.Stop();
            Console.WriteLine(t.Elapsed);

            Console.ReadLine();


            t = new Stopwatch();
            t.Start();
            m = new Moteur();
             d = m.GetValue("212000001",2);
            Console.WriteLine(d);
            t.Stop();
            Console.WriteLine(t.Elapsed);

            Console.ReadLine();

            t = new Stopwatch();
            t.Start();
            m = new Moteur();
            d = m.GetValue("000010000");
            Console.WriteLine(d);
            t.Stop();
            Console.WriteLine(t.Elapsed);

            Console.ReadLine();

            t = new Stopwatch();
            t.Start();
            m = new Moteur();
            d = m.GetValue("000010000");
            Console.WriteLine(d);
            t.Stop();
            Console.WriteLine(t.Elapsed);

            Console.ReadLine();


            t = new Stopwatch();
            t.Start();
            m = new Moteur();
            d = m.GetValue("000000000");
            Console.WriteLine(d);
            t.Stop();
            Console.WriteLine(t.Elapsed);


            Console.ReadLine();
        }
    }
}
