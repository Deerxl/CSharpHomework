using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrNum = { 3, 2, 42, 5, 2, 1, 4, 9, 32 };
            int n = arrNum.Length;

            int nMax = arrNum.Max();
            Console.WriteLine("数组的最大值是：" + nMax);

            int nMin = arrNum.Min();
            Console.WriteLine("数组的最小值是：" + nMin);

            int nSum = arrNum.Sum();
            Console.WriteLine("数组的和是：" + nSum);

            double nAvr = arrNum.Average();
            Console.WriteLine("数组的平均值是：" + nAvr);
        }
    }
}
