using System;
using System.IO;
using System.Linq;

namespace Project3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements: ");
            int element = Convert.ToInt32(Console.ReadLine());
            Random r = new Random();
            int[] integers = new int[element];
            double[] normalizationArray = new double[element];

            int min;
            int max;

            int[] checkMin = new int[integers.Length];
            int[] checkMax = new int[integers.Length];

            // Creating integers element with the distinct random numbers
            for (int i = 0; i < integers.Length; i++)
            {
                // distinct random number check
                var number = r.Next(1, 10000);
                while (integers.Any(n => n == number))
                {
                    number = r.Next(1, 10000);
                }

                integers[i] = number;

                min = integers.Where(num => num > 0).Min();
                max = integers.Max();

                checkMin[i] = min;
                checkMax[i] = max;

                normalizationArray[i] = normalization(integers[i], min, max);

                if (i > 0)
                {
                    if (checkMin[i - 1] != min || checkMax[i - 1] != max)
                    {
                        for (int item = 0; item < integers.Length; item++)
                        {
                            if (integers[item] != 0)
                            {
                                normalizationArray[item] = normalization(integers[item], min, max);
                            }
                        }
                    }
                }
            }

            static double normalization(double number, int min, int max)
            {
                double value = (number - min) / (max - min);
                return value;
            }

            Console.WriteLine("DONE!...Output text file can be found in Project3->bin->Debug->netcoreapp3.1->Output.txt");
            FileStream fs = new FileStream("Output.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            Console.SetOut(sw);

            for (int i = 0; i < integers.Length; i++)
            {
                Console.Write("{0}.Dizi Elemanı = {1} ", i, integers[i] + ", ");
                Console.WriteLine("Normalizasyon: " + normalizationArray[i]);
            }

            sw.Close();

        }
    }
}
