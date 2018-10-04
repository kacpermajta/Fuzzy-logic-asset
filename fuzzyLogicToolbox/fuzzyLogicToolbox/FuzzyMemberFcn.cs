using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzyLogicToolbox
{
    public enum mfShape {tri, triCust, trap };
    //    tri: lower end, center, upper end         
    //    triCust: lower x, center x, upper x, lower y, center y, upper y
    //    trap: lower end, lower top, upper top, upper end 
    public class FuzzyMemberFcn
    {
        //bool type2;
        mfShape shape;
        float[] param;
        public FuzzyMemberFcn()
        {
            //type2 = false;
            shape = mfShape.tri;
            param = new float[] { 0, 0.5f, 1 };
        }
        public FuzzyMemberFcn(float center, float range)
        {
            //type2 = false;
            shape = mfShape.tri;
            param = new float[] { center-range, center, center + range };
        }
        public FuzzyMemberFcn(float[] param, mfShape shape)
        {
            //type2 = false;
            this.shape = shape;
            this.param = param;
        }
        public float fuzzify(float value)
        {
            switch (shape)
            {
                case mfShape.tri:
                    if (value <= param[0] || value >= param[2])
                        return 0;

                    else if (value < param[1])
                        return (value - param[0]) / (param[1] - param[0]);

                    else
                        return (value - param[2]) / (param[1] - param[2]);

                    break;

                case mfShape.triCust:
                    return 1;

                    break;

                case mfShape.trap:
                    if (value <= param[0] || value >= param[3])
                        return 0;

                    else if (value > param[2])
                        return (value - param[3]) / (param[2] - param[3]);

                    else if (value < param[1])
                        return (value - param[0]) / (param[1] - param[0]);
                    else
                        return 1;

                    break;
                default:
                    return 0;
                    break;
            
            }

        }
        public void shift (float dist)
        {
            if (shape == mfShape.triCust)
            {
                for (int i = param.Length/2 - 1; i >= 0; i--)
                {
                    param[i] += dist;
                }
            }
            else
            {
                for (int i = param.Length - 1; i >= 0; i--)
                {
                    param[i] += dist;
                }
            }
            return;
        }

    }
}
