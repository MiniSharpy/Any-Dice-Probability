using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDiceProbability
{
    class Program
    {
        static void Main(string[] args)
        {
            var final = ProbabilityCalculator.CalculateFrequency(3, 6);
           

            Console.WriteLine();

            foreach (var item in final)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }

        //private static void WriteList<T>(List<T> list)
        //{
        //    foreach (var item in list)
        //    {
        //        Console.Write(item + " ");
        //    }
        //    Console.Write("\n");
        //}
    }
}
