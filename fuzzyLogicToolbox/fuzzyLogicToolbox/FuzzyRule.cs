using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzyLogicToolbox
{
    public enum MfMode {NON, OR, AND, INC, INCOR, INCAND };
    class FuzzyRule
    {
        public int[] Mf;
        MfMode[] MfMode;
        float[] param;
        bool weighted, incOR, incAND, prioritizeAND;


        //float aggregate (float[] ruleAnte, float[] ruleConse)
        //{

        //}
        public void Resize()
        {
            int size = MfMode.Length;
            Array.Resize(ref MfMode, size + 1);
            Array.Resize(ref param, size + 2);
            param[size + 1] = param[size];
            param[size] = 0f;

        }
        public void Adjust(int numVar)
        {
            int size = MfMode.Length;
            int sizePar = param.Length;
            if (size == numVar && sizePar == numVar + 1)
                return;
            if(size!=numVar)
            {
                Array.Resize(ref MfMode, numVar);
            }

            if (sizePar != numVar+1)
            {
                Array.Resize(ref param, numVar + 1);

            }


        }

        public float antecedent(float[] input)
        {
            //int rawSize = rawInput.Length;
            //float[] input = new float[rawSize];

            //for (int i=0; i<rawSize; i++)
            //{
            //    input[i]=mechanics.mainSystem.
            //}
            int size = MfMode.Length;
            
            if (input.Length < size)
                return 0;


            float strenght = 0;
            float floor = 0;
            float celling = 1;
            int numAv=0;
            float sum=0;
            for (int i = 0; i < size; i++)
            {
                if(input[i]>floor && 
                    (MfMode[i] == fuzzyLogicToolbox.MfMode.OR || MfMode[i] == fuzzyLogicToolbox.MfMode.OR))
                {
                    floor = input[i];
                }
                if (input[i] < celling &&
                    (MfMode[i] == fuzzyLogicToolbox.MfMode.AND || MfMode[i] == fuzzyLogicToolbox.MfMode.INCAND))
                {
                    celling = input[i];
                }
                if(!weighted)
                {
                    if(MfMode[i] >= fuzzyLogicToolbox.MfMode.INC||
                        ( incAND &&MfMode[i] == fuzzyLogicToolbox.MfMode.AND) ||
                        (incOR && MfMode[i] == fuzzyLogicToolbox.MfMode.OR))
                    {
                        numAv++;
                        sum += input[i];
                    }

                }

            }

            if (floor>celling)
            {
                if (prioritizeAND)
                    return celling;
                else
                    return floor;
            }
            else if (numAv == 0 )
            {
                return celling;

            }

            strenght = sum / numAv;

            if (strenght > celling)
                return celling;
            else if (strenght < floor)
                return floor;
            else
                return strenght;
        }

        public float consequent(float[] input)
        {

            float output = 0;
            int size = MfMode.Length;
            if (input.Length < size)
                return 0;
            for (int i = 0; i < size; i++)
            {
                output += param[i] * input[i];
            }
            output += param[size];
            return output;
        }
        public FuzzyRule(MfMode[] mode, float singleton,int[] mfV)
        {
            MfMode = mode;
            Mf = mfV;
            int size = mode.Length;
            param = new float[size+1];
            param[size] = singleton;

        }


        public FuzzyRule(MfMode[] mode, float[] par, int[] mfV)
        {
            int size = mode.Length;
            int numPar = par.Length;
            if (size>=numPar)
            {
                Array.Resize(ref par, size + 1);

            }
            Mf = mfV;
            MfMode = mode;
            param = par;
            incAND = false;
            incOR = false;
            weighted = false;
            prioritizeAND = false;

        }


    }
}
