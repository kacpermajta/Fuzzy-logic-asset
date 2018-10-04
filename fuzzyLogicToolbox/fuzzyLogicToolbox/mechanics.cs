using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzyLogicToolbox
{
    static class mechanics
    {
        public static FuzzySystem mainSystem;
        public static int numberVar;
        
        public static void Initialize(int numVar)
        {
            mainSystem = new FuzzySystem(numVar, 3);
            numberVar = numVar;
        }
        public static void AddRule(FuzzyRule newRule)
        {
            mainSystem.addRule(newRule);
        }
        public static int NumRules()
        {
            return mainSystem.numRules();
        }
    }
}
