using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 100;
            Boolean[] mark = new Boolean[num + 1];
            //初始化
            mark[0] = false;
            mark[1] = false;
            for (int i = 2; i <= num; i++)
            {
                mark[i] = true;     //假设 2 - 100 之间的数都为 素数
            }

            for (int j = 2; j <= num; j++)  //j 为倍数
            {
                for (int k = 2; k <= num; k++)   //k为元素
                {
                    if (k > j && 0 == k % j)
                    {
                        mark[k] = false;
                    }
                }
            }
            for (int k = 2; k < num; k++)
            {
                if (mark[k] == true)
                {
                    Console.WriteLine(k);
                }

            }
        }
    }
}
