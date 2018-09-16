using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int m, n;
            Console.WriteLine("Please enter two integer:");
            s = Console.ReadLine();
            m = Int32.Parse(s);
            s = Console.ReadLine();
            n = Int32.Parse(s);
            Console.WriteLine($"{m} * {n} = " + (m * n) + ".");
        }
    }
}
