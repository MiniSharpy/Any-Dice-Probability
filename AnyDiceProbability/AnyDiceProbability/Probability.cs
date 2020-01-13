using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDiceProbability
{
    internal class Probability
    {
        List<int> AllOutcomes;
        public Dictionary<int, double> Probabilities { get; private set; }

        public Probability(List<int> allOutcomes, Dictionary<int, double> probabilities)
        {
            AllOutcomes = allOutcomes;
            Probabilities = probabilities;
        }

        public static Probability operator +(Probability a, Probability b)
        {
            List<int> outcomesA = a.AllOutcomes;
            List<int> outcomesB = b.AllOutcomes;

            List<int> cartesianProduct = Dice.CartesianProduct(outcomesA, outcomesB);

            List<int> allOutcomes = cartesianProduct;
            List<int> discreteOutcomes = cartesianProduct.Distinct().ToList();//Distinct == Discrete.

            Dictionary<int, double> probabilities = Dice.CalculateProbabilities(allOutcomes, discreteOutcomes);
            return new Probability(allOutcomes, probabilities);
        }
    }
}