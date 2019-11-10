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
            CalculateAllProbability calculateAllProbability = new CalculateAllProbability();
            List<int> diceOutcome = calculateAllProbability.GenerateDiceOutcome(2, 6);
            List<int> discreteOutcome = calculateAllProbability.GenerateDiscreteOutcome(2, 6);

            WriteList(diceOutcome);
            WriteList(discreteOutcome);

            Console.Read();
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
