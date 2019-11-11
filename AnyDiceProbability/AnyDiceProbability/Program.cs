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
            ProbabilityCalculator ProbabilityCalculator = new ProbabilityCalculator();



            
            var s1 = new[] { 1, 2 };

            IEnumerable<int> product = GenerateDiceOutcome(s1, 2);

            foreach (var item in product)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            int count = 0;
            foreach (var item in product)
            {
                if (item == 3)
                {
                    count++;
                }
            }
            double number = (double)count / ProbabilityCalculator.AmountOfOutcomes(2,6);
            Console.WriteLine(number*100 + "%");


            Console.Read();
        }

        private static IEnumerable<int> GenerateDiceOutcome(int[] dieSides, int diceQuantity, int[] lastProduct = null)
        {
            if(lastProduct == null)
            {
                lastProduct = new int[dieSides.Length];
                dieSides.CopyTo(lastProduct, 0);
            }

            diceQuantity --;

            IEnumerable<int> product; //Cartesian Product
            product = 
                from first in dieSides
                from second in lastProduct
                select first + second;

            if (diceQuantity > 0)
            {
                List<int> list = new List<int>();
                foreach (var item in product)
                {
                    list.Add(item);
                }
                lastProduct = new int[list.Count];
                list.ToArray().CopyTo(lastProduct, 0);

                GenerateDiceOutcome(dieSides, diceQuantity, lastProduct);
            }

            return product;

        }

        private static void WriteList<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
        }
    }
}
