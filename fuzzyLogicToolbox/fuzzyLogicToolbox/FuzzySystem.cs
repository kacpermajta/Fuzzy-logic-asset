using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzyLogicToolbox
{
    class FuzzySystem
    {
        FuzzyVariable[] inputVar;
        FuzzyRule[] sysRule;

        public int[] MfOfRule(int i)
        {
            return sysRule[i].Mf;
        }

        public int numRules()
        {
            return sysRule.Length;
        }
        public int numVariables()
        {
            return inputVar.Length;
        }
        public FuzzySystem()
        {
            inputVar = new FuzzyVariable[0];
            sysRule = new FuzzyRule[0];

        }
        public FuzzySystem(int num)
        {
            inputVar = new FuzzyVariable[num];
            sysRule = new FuzzyRule[0];

        }
        public FuzzySystem(int num, int numMf)
        {
            inputVar = new FuzzyVariable[num];
            sysRule = new FuzzyRule[0];
            for (int i =0; i<num; i++)
            {
                inputVar[i] = new FuzzyVariable(numMf);
            }

        }
        public FuzzySystem(FuzzyVariable[] variables)
        {
            inputVar = variables;
            sysRule = new FuzzyRule[0];

        }
        public FuzzySystem(FuzzyVariable[] variables, FuzzyRule[] rules)
        {
            inputVar = variables;
            sysRule = rules;

        }
        public void addVariable()
        {
            Array.Resize(ref inputVar, inputVar.Length + 1);
            ResizeRules();
        }
        public void addVariable(int numMf)
        {
            int size = inputVar.Length;
            Array.Resize(ref inputVar, size + 1);
            inputVar[size] = new FuzzyVariable(numMf);
            ResizeRules();
        }
        public void addVariable(FuzzyVariable newVar)
        {
            int size = inputVar.Length;
            Array.Resize(ref inputVar, size + 1);
            inputVar[size]= newVar;
            ResizeRules();
        }
        public void addRule(FuzzyRule newRule)
        {
            int size = inputVar.Length;
            newRule.Adjust(size);
            size = sysRule.Length;
            Array.Resize(ref sysRule, size + 1);
            sysRule[size] = newRule;
        }
        public void ResizeRules()
        {
            foreach (FuzzyRule rule in sysRule)
            {
                rule.Resize();
            }

        }
        public float[] Fuzzify(int num, float val)
        {
            return inputVar[num].Fuzzify(val);
        }
        public float Fuzzify(int num, int numMf, float val)
        {
            return inputVar[num].Fuzzify(val, numMf);
        }
        public float CalculateRuleA(float[] rawInput, int numRule)
        {
            int size= rawInput.Length;
            float[] input = new float[size];
            for (int i = 0; i<size; i++)
            {
                input[i] = Fuzzify(numRule, sysRule[numRule].Mf[i], rawInput[i]);
            }
            return sysRule[numRule].antecedent(input);

        }
        public float CalculateRuleC(float[] input, int numRule)
        {
            return sysRule[numRule].consequent(input);

        }
        public float Calculate(float [] input)
        {



        }

    }
}
