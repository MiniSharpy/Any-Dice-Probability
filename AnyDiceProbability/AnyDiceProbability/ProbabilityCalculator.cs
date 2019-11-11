using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDiceProbability
{
    public class ProbabilityCalculator
    {
        Dictionary<int, int> CalculateFrequency(List<int> discreteOutcome, List<List<int>> diceOutcome)
        {
            Dictionary<int, int> frequencies = new Dictionary<int, int>();

            foreach (var dieDiscreteOutcome in diceOutcome)
            {
                foreach (var dieSide in dieDiscreteOutcome)
                {

                }
            }

            return frequencies;
        }

        public List<int> GenerateDiscreteOutcome(int diceQuantity, int dieSides)
        {
            List<int> discreteOutcome = new List<int>();
            int minimumOutcome = diceQuantity;
            int maximumOutcome = diceQuantity * dieSides;

            for (int i = minimumOutcome; i < maximumOutcome+1; i++)
            {
                discreteOutcome.Add(i);
            }

            return discreteOutcome;
        }

        public double AmountOfOutcomes(int diceQuantity, int dieSides)//Uses a list of a list so that when calculating frequency for loop can be used maybe.
        {
            return Math.Pow(dieSides, diceQuantity);
        }

        public List<int> GenerateDieSides(int dieSides)
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
