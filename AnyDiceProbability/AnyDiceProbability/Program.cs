using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDiceProbability
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dice dice = new Dice(1, 6) + new Dice(1, 8) + new Dice(1, 10);

            DisplayCollection(dice.Probabilities);
        }

        private static void DisplayCollection(ICollection Collection)
        {
            Console.WriteLine();
            foreach (var item in Collection)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}