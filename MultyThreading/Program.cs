using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine("Введите размерность матрицы: ");
            string val = Console.ReadLine();
            int Mas = Convert.ToInt32(val);

            Matrix usingMx = new Matrix(Mas, Mas);
            usingMx.rand();

            //PLINQ
            var query = from item in usingMx.SeekMin().AsParallel().WithDegreeOfParallelism(2)
                        select MultMin(usingMx.SeekMin());
            var sw = Stopwatch.StartNew();

            // For pure query cost, enumerate and do nothing else.
            foreach (var n in query) { }
            sw.Stop();
            double elapsed = sw.ElapsedMilliseconds; // or sw.ElapsedTicks
            Console.WriteLine("Total query time: {0} ms", elapsed);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            //var query = usingMx.SeekMin().AsParallel().WithDegreeOfParallelism(2).Where(lst.Aggregate((x, y) => x * y)).Select(...)
        }
    }
}
    
