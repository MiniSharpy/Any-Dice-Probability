using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDiceProbability
{
    //Need to sort out calculating chances with multiple types of dice. I.E 1d6+2d4
    //Need to allow for things such as drop lowest or highest.
    public class ProbabilityCalculator
    {
        public static Dictionary<int, double> CalculateFrequency(int diceQuantity, int dieSides)
        {
            Dictionary<int, double> frequencies = new Dictionary<int, double>();
            List<int> discreteOutcomes = GenerateDiscreteOutcomes(diceQuantity, dieSides);
            List<int> allOutcomes = GenerateAllOutcomes(diceQuantity, dieSides);

            
            foreach (var dieSide in discreteOutcomes)
            {
                int count = 0;
                foreach (var currentOutcome in allOutcomes)
                {
                    if (currentOutcome == dieSide)
                    {
                        count++;
                    }
                }
                double possibility = (double) count / allOutcomes.Count() * 100;
                frequencies.Add(dieSide, possibility);
            }

            return frequencies;
        }

        public static List<int> GenerateAllOutcomes(int diceQuantity, int dieSides)
        {
            List<int> dieDiscreteOutcome = GenerateDieDiscreteOutcome(dieSides);

            if (diceQuantity == 1) { return dieDiscreteOutcome; }

            List<int> product = new List<int>();
            for (int i = 0; i < diceQuantity-1; i++)
            {
                product = CartesianProduct(dieDiscreteOutcome, product);
            }

            return product;
        }

        private static List<int> CartesianProduct(List<int> dieDiscreteOutcome, List<int> inputProduct)
        {
            if (inputProduct.Count == 0)
            {
                inputProduct = dieDiscreteOutcome;
            }

            IEnumerable<int> product = //Cartesian Product
                from first in inputProduct
                from second in dieDiscreteOutcome
                select first + second;

            List<int> finalList = product.ToList();

            return finalList;
        }

        public static List<int> GenerateDiscreteOutcomes(int diceQuantity, int dieSides)
        {
            List<int> discreteOutcomes = new List<int>();
            int minimumOutcome = diceQuantity;
            int maximumOutcome = diceQuantity * dieSides;

            for (int i = minimumOutcome; i < maximumOutcome+1; i++)
            {
                discreteOutcomes.Add(i);
            }

            return discreteOutcomes;
        }

        public static double AmountOfOutcomes(int diceQuantity, int dieSides)//Uses a list of a list so that when calculating frequency for loop can be used maybe.
        {
            return Math.Pow(dieSides, diceQuantity);
        }

        public static List<int> GenerateDieDiscreteOutcome(int dieSides)//Generates a range of numbers from 1 through to dieSides.
        {
            List<int> dieDiscreteOutcome = new List<int>();//Could to with a clearer name that shows it's all possible outcomes.
            for (int currentSide = 1; currentSide < dieSides + 1; currentSide++)
            {
                dieDiscreteOutcome.Add(currentSide);
            }

            return dieDiscreteOutcome;
        }
    }
}
