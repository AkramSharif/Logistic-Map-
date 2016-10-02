using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmp_minimum_prod4
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, g1, g2, a, v, w;
            double prodR_x, prodR_y, R_x, R_y;
            int N, l_max, mR_x_min, mR_y_min;

            a = 3.6;
            v = 0;
            l_max = 0;


            Random r = new Random();
            x = r.NextDouble();

            Console.WriteLine("Please type in the number of iterations:");

            while (!int.TryParse(Console.ReadLine(), out N))
                Console.WriteLine("Your entry was not a positive integer. Please insert again the number of iterations:");

            // declaration and allocation of the needed arrays

            double[] M1 = new double[N + 1];
            M1[0] = x;

            double[] M2 = new double[N + 1];
            M2[0] = Math.Log(Math.Abs(a * (1 - 2 * M1[0])));

            double[] M3 = new double[N + 1];

            double[] M4 = new double[N + 1];

            Console.WriteLine(" ");



            // forward-iteration

            for (int i = 1; i <= N; i++)
            {
                x = a * x * (1 - x);
                M1[i] = x;
            }

            y = M1[N];
            M3[N] = M1[N];



            // backward-iteration

            for (int j = 1; j <= N; j++)
            {
                g1 = 0.5 + Math.Sqrt(0.25 - (1 / a) * y);
                g2 = 0.5 - Math.Sqrt(0.25 - (1 / a) * y);

                if (Math.Abs(g1 - M1[N - j]) < Math.Abs(g2 - M1[N - j]))
                {
                    y = g1;
                    M3[N - j] = y;
                }
                else
                {
                    y = g2;
                    M3[N - j] = y;
                }

                if (v < Math.Abs(M1[N - j] - y))
                {
                    l_max = N-j;
                    v = Math.Abs(M1[N - j] - y);
                }

            }



            // filling in the needed arrays for the calculation of R_x and R_y

            for (int j2 = 0; j2 <= N; j2++)
            {
                M2[j2] = Math.Abs(a * (1 - 2 * M1[j2]));
            }

            for (int j4 = 0; j4 <= N; j4++)
            {
                M4[j4] = Math.Abs(a * (1 - 2 * M3[j4]));
            }


            prodR_x = 1;
            prodR_y = 1;
            R_x = M2[l_max];
            R_y = M4[l_max];
            mR_x_min = 0;
            mR_y_min = 0;


            // calculation of R_x and R_y, as well as their corresponding indexes m_x_min and m_y_min

            for (int m1 = 0; m1 <= N - l_max; m1++)
            {

                prodR_x = prodR_x * M2[l_max + m1];
                prodR_y = prodR_y * M4[l_max + m1];

                if (prodR_x < R_x)
                {
                    R_x = prodR_x;
                    mR_x_min = m1;
                }

                if (prodR_y < R_y)
                {
                    R_y = prodR_y;
                    mR_y_min = m1;
                }

            }

            w = Math.Abs(M1[l_max] - M3[l_max]);


            Console.WriteLine("");
            Console.WriteLine("N = {0}", N);
            Console.WriteLine("");
            Console.WriteLine("x(0) = {0}", M1[0]);
            Console.WriteLine("y(0) = {0}", M3[0]);
            Console.WriteLine("max x(n) - y(n) = {0}", v);
            Console.WriteLine("l_max = {0}", l_max);
            Console.WriteLine("");
            //Console.WriteLine("x(l_max) = {0}", M1[l_max]);
            //Console.WriteLine("y(l_max) = {0}", M3[l_max]);
            //Console.WriteLine("x(l_max) - y(l_max) = {0}", w);
            //Console.WriteLine("Df(x(l_max)) = {0}", M2[l_max]);
            //Console.WriteLine("Df(y(l_max)) = {0}", M4[l_max]);
            //Console.WriteLine("");
            Console.WriteLine("Index of R_x = {0}", mR_x_min);
            Console.WriteLine("Index of R_y = {0}", mR_y_min);
            Console.WriteLine("R_x = {0}", R_x);
            Console.WriteLine("R_y = {0}", R_y);
            Console.WriteLine("max x(n) - y(n) / R_x = {0}", v / R_x);
            Console.WriteLine("max x(n) - y(n) / R_y = {0}", v / R_y);
            Console.ReadKey();
        }
    }
}
