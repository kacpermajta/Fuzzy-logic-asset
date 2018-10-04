using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fuzzyLogicToolbox
{
    public partial class Form1 : Form
    {
        FuzzyMemberFcn testMf;
        FuzzyVariable basicVariable;
        FuzzySystem userSystem;
        public Form1()
        {
            InitializeComponent();
            //     public 
            testMf = new FuzzyMemberFcn(4f, 6f);
            basicVariable = new FuzzyVariable(3, 2f, 5f);
         }
    

        private void button1_Click(object sender, EventArgs e)
        {
            //mftri
            //  FuzzyMemberFcn testMf;
            float temp1 = float.Parse(textBox1.Text);
            float temp2 = float.Parse(textBox2.Text);
            float temp3 = float.Parse(textBox3.Text);

            float[] tempPar = new float[] { temp1, temp2,
                temp3};
            testMf = new FuzzyMemberFcn(tempPar, mfShape.tri);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //przelicz mf
            textBox5.Text = (testMf.fuzzify(float.Parse(textBox6.Text))).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //mftrap
            testMf = new FuzzyMemberFcn(new float[] { float.Parse(textBox1.Text), float.Parse(textBox2.Text),
               float.Parse(textBox3.Text),float.Parse(textBox4.Text)}, mfShape.trap);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            float[] effect = (basicVariable.Fuzzify(float.Parse(textBox6.Text)));
            textBox5.Text =effect[0].ToString()+"/ "+ effect[1].ToString()
                +"/ " + effect[2].ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            int numMf = int.Parse(textBox1.Text);
            float minimum = float.Parse(textBox2.Text);
            float maximum = float.Parse(textBox3.Text);
            float xmin = 50;
            float ymin = 50;
            float xmax = 300;
            float ymax = 250;


            basicVariable = new FuzzyVariable(numMf, minimum, maximum);
            Graphics g = this.panel1.CreateGraphics();
            g.FillRectangle(Brushes.Yellow,  xmin,
                      ymin, xmax - xmin, ymax - ymin);
            float[][] output = new float[1000][];

            for (int j=0; j<1000; j++)
            {
                output[j]=basicVariable.Fuzzify(minimum + (maximum - minimum) * j / 1000);
            }
            for (int i=0; i< numMf; i++)
            {
                for (int j=0; j<1000; j++)
                {

                    g.FillRectangle(Brushes.Red, xmin+ (xmax-xmin)*j/1000, 
                        ymax-(ymax-ymin)* output[j][i], 1, 1);  //used 1,1 for a pixel only
                }
                
            }
           




            


        }

        private void newSystem_Click(object sender, EventArgs e)
        {
            int ilosc = int.Parse(variableNum.Text);
            mechanics.Initialize(ilosc);

        }

        private void rules_Click(object sender, EventArgs e)
        {
            RuleEditor popup = new RuleEditor();
            DialogResult dialogresult = popup.ShowDialog();

            if (dialogresult == DialogResult.OK)
            {
                //                Console.WriteLine("You clicked OK");
            }
            else if (dialogresult == DialogResult.Cancel)
            {
                //                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
            
        }

        private void viewRules_Click(object sender, EventArgs e)
        {
            int numR = mechanics.NumRules();
            int numV = mechanics.numberVar;


            panel1.Refresh();
            
            float minimum = 0;
            float maximum = 1;
            float xmin = 50;
            float ymin = 50;
            float xmax = 300;
            float ymax = 250;
            float xsize = xmax - xmin;
            float ysize = ymax - ymin;



            //basicVariable = new FuzzyVariable(numMf, minimum, maximum);

            Graphics g = this.panel1.CreateGraphics();
            float[][][] outputs=new float[1000][][];
            for (int j = 0; j < numV; j++)
            {
                for (int k = 0; k < 1000; k++)
                {
                    outputs[k][j] = mechanics.mainSystem.Fuzzify(j, minimum + (maximum - minimum) * j / 1000);
                }
            }

            float xsmin, ysmin, xssize, yssize;
            int[] antecends;
            
            for (int i = 0; i< numR;i++)
            {

                for (int j = 0; j < numV; j++)
                {
                    xssize = xsize / (numV + 1);
                    yssize = ysize / (numR);

                    xsmin = xmin + j * xssize;
                    ysmin = ymin + i * yssize;

                    g.FillRectangle(Brushes.Yellow, xsmin,
                      ysmin, 0.95f*xsize/(numV+1), 0.95f * ysize / (numR));
                    //float[] output = new float[1000];

                   
                    
                        for (int k = 0; k < 1000; k++)
                        {

                            g.FillRectangle(Brushes.Red, xsmin +  (xssize*0.95f) * j / 1000,
                                ysmin - (yssize * 0.95f) * (outputs[k][][i]-1), 1, 1);  //used 1,1 for a pixel only
                        }


                }

            }
        }
    }
}
