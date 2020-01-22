using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Look into data models.
namespace AnyDiceProbability
{
    //Need to allow for things such as drop lowest or highest.
    //Need to account for criticals.
    public class Dice
    {
        readonly int DiceQuantity;
        readonly int DieSides;

        List<int> AllOutcomes;

        public Dictionary<int, double> Probabilities { get; private set; }

        public Dice(int diceQuantity, int dieSides)
        {
            DiceQuantity = diceQuantity;
            DieSides = dieSides;

            AllOutcomes = GenerateAllOutcomes();
            List<int> discreteOutcomes = AllOutcomes.Distinct().ToList();//Distinct == Discrete.
            Probabilities = CalculateProbabilities(AllOutcomes, discreteOutcomes);
        }

        private Dice(List<int> allOutcomes, Dictionary<int, double> probabilities)
        {
            AllOutcomes = allOutcomes;
            Probabilities = probabilities;
        }

        public static Dictionary<int, double> CalculateProbabilities(List<int> allOutcomes, List<int> discreteOutcomes)
        {
            Dictionary<int, double> frequencies = new Dictionary<int, double>();
            foreach (int dieSide in discreteOutcomes)
            {
                int count = 0;
                foreach (int currentOutcome in allOutcomes)
                {
                    if (currentOutcome == dieSide)
                    {
                        count++;
                    }
                }
                double possibility = (double)count / allOutcomes.Count() * 100;
                frequencies.Add(dieSide, possibility);
            }

            return frequencies;
        }

        public static List<int> CartesianProduct(List<int> dieDiscreteOutcome, List<int> inputProduct)
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

            return finalList;//ALL outcomes, not just discrete. .Distinct() can remove duplicates.
        }

        public List<int> GenerateAllOutcomes()
        {
            List<int> dieDiscreteOutcome = GenerateDieDiscreteOutcome();

            if (DiceQuantity == 1) { return dieDiscreteOutcome; }

            List<int> product = new List<int>();
            for (int i = 0; i < DiceQuantity - 1; i++)
            {
                product = CartesianProduct(dieDiscreteOutcome, product);//ALL outcomes, not just discrete.
            }

            return product;
        }

        private List<int> GenerateDieDiscreteOutcome()//Generates a range of numbers from 1 through to dieSides.
        {
            List<int> dieDiscreteOutcome = new List<int>();//Could to with a clearer name that shows it's all possible outcomes.
            for (int currentSide = 1; currentSide < DieSides + 1; currentSide++)
            {
                dieDiscreteOutcome.Add(currentSide);
            }

            return dieDiscreteOutcome;
        }

        public static Dice operator +(Dice a, Dice b)
        {
            List<int> outcomesA = a.AllOutcomes;
            List<int> outcomesB = b.AllOutcomes;

            List<int> cartesianProduct = CartesianProduct(outcomesA, outcomesB);

            List<int> allOutcomes = cartesianProduct;
            List<int> discreteOutcomes = cartesianProduct.Distinct().ToList();//Distinct == Discrete.

            Dictionary<int, double> probabilities = Dice.CalculateProbabilities(allOutcomes, discreteOutcomes);
            return new Dice(allOutcomes, probabilities);
        }
    }
}