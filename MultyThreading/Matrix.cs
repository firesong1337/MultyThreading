using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public List<int> SeekMin()
        {
            List<int> x = new List<int>(M);
            for (int j = 0; j < M; j++)
            {
                int minHeight = A[0, j];
                for (int i = 0; i < N; i++)
                {
                    if (A[i, j] < minHeight)
                    {
                        minHeight = A[i, j]; 
                    }
                }
                x.Add(minHeight);
                //Console.WriteLine("столбец {0}, значение: {1}", j, minHeight);
            }
            return x;
        }

    }
}
