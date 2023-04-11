using System;
using System.Diagnostics;

namespace MultyThreading
{
    class Program
    {
        public static double CountThreads(int n, Matrix mx)
        {
            mx.rand();
            //PLINQ
            var sw = Stopwatch.StartNew();
            mx.SeekMinProdInColumn(n);
            sw.Stop();
            double elapsed = sw.ElapsedMilliseconds;
            return (elapsed / 1000);
        }
        static void Main(string[] args)
        {
            int Mas = 10000;

            Matrix usingMx = new Matrix(Mas, Mas);


            double cnt = CountThreads(1, usingMx);

            Console.WriteLine("1 поток: \n Время выполнения {0: 0.###}", cnt);
            Console.WriteLine("=====================================");
            Console.WriteLine("6 потоков: \n Время выполнения {0}\n Ускорение: {1: 0.###} \n Эффективность: {2: 0.###}", CountThreads(6, usingMx), cnt / CountThreads(6, usingMx), (cnt / CountThreads(6, usingMx)) / 6);
            Console.WriteLine("=====================================");

            Console.ReadKey();
        }
    }
}
//using System;
//using System.Threading;
//using System.Linq;

//public static class Program
//{
//    static void Main(string[] args)
//    {
//        Enumerable.Range(0, 10)
//            .AsParallel()
//            .ForAll((int a) => Console.WriteLine($"Привет, из потока { Thread.CurrentThread.ManagedThreadId}"));
//    }
//}