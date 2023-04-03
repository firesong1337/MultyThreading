using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MultyThreading
{
    class Program
    {
        public static int MultMin(List<int> lst)
        {
           return lst.Aggregate((x, y) => x * y);
        }
        static void Main(string[] args)
        {
            Matrix usingMx = new Matrix(4, 4);

            usingMx.rand();
            Console.WriteLine(String.Join(',',usingMx.SeekMin()));
            Console.WriteLine(MultMin(usingMx.SeekMin()));

        }
    }
}
    
