using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDiceProbability
{
    public class CalculateAllProbability
    {
        Dictionary<int, int> CalculateFrequency(List<int> discreteOutcome, List<int> diceOutcome)
        {
            Dictionary<int, int> frequencies = new Dictionary<int, int>();

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

        public List<int> GenerateDiceOutcome(int diceQuantity, int dieSides)//For loop to run diceQuantity times, method returns a list, then use linq to merge.
        {
            List<int> diceOutcome = new List<int>();//diceOutcome
            for (int currentQuantity = 0; currentQuantity < diceQuantity; currentQuantity++)
            {
                List<int> dieDiscreteOutcome = GenerateDieSides(dieSides);
                diceOutcome = diceOutcome.Concat(dieDiscreteOutcome).ToList();
            }

            return diceOutcome;
        }

        private List<int> GenerateDieSides(int dieSides)
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
