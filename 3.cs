
using System;
using System.Linq;

namespace FACK
{
    class Progrqam
    {
        static void Main(string[] args)
        {

            Vector a = new Vector(4);
            a[0] = 0;
            a[1] = 3;
            a[2] = 1;
            a[3] = -4;

            Vector b = new Vector(4);
            b[0] = 1;
            b[1] = 2;
            b[2] = -3;
            b[3] = -1;

            double sum = a + b;
            double product = a * b;
            int zeroCount = a & b;
           

            Console.WriteLine($"Sum of negative elements: {sum}");
            Console.WriteLine($"Product of even-indexed elements: {product}");
            Console.WriteLine($"Number of zero elements: {zeroCount}");
        
        }
        public class Vector
        {
            private double[] data;

            public Vector(int size)
            {
                data = new double[size];
            }

            public double this[int i]
            {
                get { return data[i]; }
                set { data[i] = value; }
            }

            public static double operator +(Vector a, Vector b)
            {
                double sum = 0;
                for (int i = 0; i < a.data.Length; i++)
                {
                    if (a[i] < 0)
                        sum += a[i];

                    if (b[i] < 0)
                        sum += b[i];
                }

                Console.WriteLine($"The sum of negative elements in the two vectors is: {sum}");
                return sum;
            }

            public static double operator *(Vector a, Vector b)
            {
                double product = 1;
                for (int i = 0; i < a.data.Length; i += 2)
                {
                    product *= a[i] * b[i];
                }

                Console.WriteLine($"The product of even-indexed elements in the two vectors is: {product}");
                return product;
            }

            public static int operator &(Vector a, Vector b)
            {
                int count = 0;
                for (int i = 0; i < a.data.Length; i++)
                {
                    if (a[i] == 0)
                        count++;

                    if (b[i] == 0)
                        count++;
                }

                Console.WriteLine($"The number of zero elements in the two vectors is: {count}");
                return count;
            }

           
        }
    }
}
