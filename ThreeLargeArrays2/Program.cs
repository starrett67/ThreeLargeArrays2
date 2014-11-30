using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeLargeArrays2
{
    class Program
    {
        static void Main(string[] args)
        {
            int sameElement = 1055;
            int arraylength = 100;
            int[] a = new int[arraylength], b = new int[arraylength], c = new int[arraylength];

            Random rnd = new Random();
            for (int i = 0; i < arraylength - 1; i++)
            {
                a[i] = rnd.Next(1,10000);
                b[i] = rnd.Next(1, 10000);
                c[i] = rnd.Next(1, 10000);
            }

            a[arraylength - 1] = sameElement;
            b[arraylength - 1] = sameElement;
            c[arraylength - 1] = sameElement;

            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);

            int[] indexes = new int[2] { 0, 0 };
            int match = 0;
            bool stillsearchingb = true;
            bool stillsearchingc = true;

            foreach (int element in a)
            {
                while(b[indexes[0]] < element || c[indexes[1]] < element)
                {
                    if (b[indexes[0]] < element)
                    {
                        indexes[0]++;
                        stillsearchingb = true;
                    }
                    if (c[indexes[1]] < element)
                    {
                        indexes[1]++;
                        stillsearchingc = true;
                    }
                }
                if (c[indexes[1]] == element)
                    stillsearchingc = false;
                if (b[indexes[0]] == element)
                    stillsearchingb = false;
                
                if (!stillsearchingb && !stillsearchingc)
                {
                    match = element;
                    break;
                }

            }
            Console.Write(match);
        }
    }
    class Generator
    {
        public int[] getArray(int l, int e)
        {
            int[] array = new int[l];
            Random numberGenerator = new Random();

            for (int i = 0; i < l - 1; i++)
            {
                array[i] = numberGenerator.Next(10000);
            }

            array[l - 1] = e;
            return array;

        }
    }
}
