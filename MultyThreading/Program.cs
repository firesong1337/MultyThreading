using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace MultyThreading
{
    class Program
    {
        public static double CountThreads(int n, Matrix mx)
        {
            mx.rand();
            //PLINQ
            var query = from item in mx.SeekMin().AsParallel().WithDegreeOfParallelism(n)
                        select MultMin(mx.SeekMin());
            var sw = Stopwatch.StartNew();

            // For pure query cost, enumerate and do nothing else.
            foreach (var i in query) { }
            sw.Stop();
            double elapsed = sw.ElapsedMilliseconds;
            return (elapsed/1000);
        }
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
            

            double cnt = CountThreads(1, usingMx);

            Console.WriteLine("1 поток: \n Время выполнения {0}", cnt);
            Console.WriteLine("=====================================");
            Console.WriteLine("4 потокa: \n Время выполнения {0}\n Ускорение: {1} \n Эффективность: {2}", CountThreads(4, usingMx), cnt/CountThreads(4, usingMx), (cnt / CountThreads(4, usingMx)) / 4);
            Console.WriteLine("=====================================");
            Console.WriteLine("8 потокa: \n Время выполнения {0}\n Ускорение: {1} \n Эффективность: {2}", CountThreads(8, usingMx), cnt / CountThreads(8, usingMx), (cnt / CountThreads(8, usingMx)) / 8);
            Console.WriteLine("=====================================");
            Console.WriteLine("16 потокa: \n Время выполнения {0}\n Ускорение: {1} \n Эффективность: {2}", CountThreads(16, usingMx), cnt / CountThreads(16, usingMx), (cnt / CountThreads(16, usingMx)) / 16);

            Console.ReadKey();
        }
    }
}
    
