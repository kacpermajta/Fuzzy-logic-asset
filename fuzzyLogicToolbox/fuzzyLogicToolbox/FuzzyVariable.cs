using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzyLogicToolbox
{
    public class FuzzyVariable
    {
        FuzzyMemberFcn[] memberFunctions;

      
        public float[] Fuzzify(float input)
        {
            int numMf = memberFunctions.Length;
            float[] output = new float[memberFunctions.Length];
            for(int i=0; i<numMf; i++)
            {
                output[i] = memberFunctions[i].fuzzify(input);

            }
            return output;

        }
        public float Fuzzify(float input, int mfNum)
        {

            return memberFunctions[mfNum].fuzzify(input);


        }


        public FuzzyVariable(FuzzyMemberFcn[] mf)
        {
            memberFunctions = mf;

        }
        public FuzzyVariable()
        {

            memberFunctions = new FuzzyMemberFcn[0];
        }
        public FuzzyVariable(int quantMf)
            :this(quantMf,0,1)
        {}

        public FuzzyVariable(int quantMf, float min, float max)
        {

            memberFunctions = new FuzzyMemberFcn[quantMf];
            if(quantMf==1)
                memberFunctions[0] = new FuzzyMemberFcn((max + min) / 2f, (max + min) / 2f);
            else
                for (int i=0; i<quantMf; i++)
                {
                    memberFunctions[i] = new FuzzyMemberFcn(min + i*(max-min) / (quantMf-1), (max - min) / (quantMf-1));
               }

            //{ new FuzzyMemberFcn(), new FuzzyMemberFcn(),
            //new FuzzyMemberFcn()};
            //memberFunctions[0].shift(-0.5f);
            //memberFunctions[2].shift(0.5f);
        }


    }


}
