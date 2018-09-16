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
            Console.WriteLine("*****求素数因子*****\n请输入一个正整数");

            string s = "";
            s = Console.ReadLine();
            int n = Int32.Parse(s);
            if (1 == n)
            {
                Console.WriteLine("数字1没有质因子！");
            }
            else
            {
                int i = 2;
                while (i <= n)
                {
                    if (0 == n % i)
                    {
                        n = n / i;
                        Console.Write(i + "  ");
                    }
                    else
                    {
                        i++;
                    }

                }
            }
        }
    }
}
