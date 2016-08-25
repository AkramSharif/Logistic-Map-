using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticMap
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, g1, g2, a, v;
            int N;
            int l = 0;
            a = 3.6;
            v = 0;

            Random r = new Random();
            x = r.NextDouble();

            Console.WriteLine("Please insert a positive integer:");

            while (!int.TryParse(Console.ReadLine(), out N))
                Console.WriteLine("Your entry was not a positive integer. Please insert a positive integer:");

            double[] M = new double[N + 1];
            M[0] = x;

            Console.WriteLine(" ");

            for (int i = 1; i <= N; i++)
            {
                x = a * x * (1 - x);
                M[i] = x;
                Console.WriteLine("x = {0}", x);
            }

            y = M[N];

            Console.WriteLine("");

            for (int j = 1; j <= N; j++)
            {
                g1 = 0.5 + Math.Sqrt(0.25 - (1 / a) * y);
                g2 = 0.5 - Math.Sqrt(0.25 - (1 / a) * y);

                if (Math.Abs(g1 - M[N - j]) < Math.Abs(g2 - M[N - j]))
                {
                    y = g1;
                }
                else
                {
                    y = g2;
                }

                Console.WriteLine("y = {0}", y);

                if (v < Math.Abs(M[N - j] - y))
                {
                    l = j;
                    v = Math.Abs(M[N - j] - y);
                }


            }

            Console.WriteLine("");
            Console.WriteLine("x(0) = {0}", M[0]);
            Console.WriteLine("y(0) = {0}", y);
            Console.WriteLine("max x(n) - y(n) = {0}", v);
            Console.WriteLine("Index of Maximum = {0}", l);
            Console.ReadKey();

        }
    }
}
