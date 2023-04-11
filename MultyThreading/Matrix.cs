using System;
using System.Collections.Generic;
using System.Linq;

namespace MultyThreading
{
    class Matrix
    {
        public int N { get; set; }
        public int M { get; set; }
        public int[,] A { get; set; }
        public Matrix(int n, int m)
        {
            this.N = n;
            this.M = m;
            A = new int[n, m];
        }
        public void rand()
        {
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    A[i, j] = rnd.Next(1, 9);
                    //Console.Write("{0}\t", A[i, j]);

                }
                //Console.WriteLine();
            }
        }

        public IEnumerable<int> GetColumn(int index)
        {
            for (int i = 0; i < M; i++)
            {
                yield return A[index, i];
            }
        }


        public int SeekMinProdInColumn(int threads) =>
            ParallelEnumerable.Range(0, N)
            .WithDegreeOfParallelism(threads)
            .Select(item => GetColumn(item).AsParallel().WithDegreeOfParallelism(threads).Min())
            .Aggregate((acc, item) => acc * item);

    }
}
