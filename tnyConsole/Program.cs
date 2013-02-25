using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TnyGames.Morpion;

namespace tnyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Moteur m = new Moteur();
            var d = m.GetValue("200010002");
            Console.WriteLine(d);
            Console.ReadLine();
            d = m.GetValue("100020000");
            Console.WriteLine(d);
            Console.ReadLine();
            d = m.GetValue("200010000");
            Console.WriteLine(d);
            Console.ReadLine();
            d = m.GetValue("100020000");
            Console.WriteLine(d);
            Console.ReadLine();
            d = m.GetValue("200010000");
            Console.WriteLine(d);
            Console.ReadLine();
            d = m.GetValue("100020000");
            Console.WriteLine(d);
            Console.ReadLine();
            d = m.GetValue("000020000");
            Console.WriteLine(d);
            Console.ReadLine();
        }
    }
}
