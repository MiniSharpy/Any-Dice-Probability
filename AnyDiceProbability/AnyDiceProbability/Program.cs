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
            Probability probability = CreateProbability(1, 6) + CreateProbability(1, 8);

            DisplayCollection(probability.Probabilities);
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

        private static Probability CreateProbability(int diceQuantity, int dieSides)
        {
            Dice dice = new Dice(diceQuantity, dieSides);
            return new Probability(dice.GenerateAllOutcomes(), dice.Probabilities);
        }
    }
}