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
    public partial class RuleEditor : Form
    {
        TextBox[] param;
        ComboBox[] modSelect;
        ComboBox[] mfSelect;

        public RuleEditor()
        {
            InitializeComponent();
        }

        private void RuleEditor_Load(object sender, EventArgs e)
        {
            param = new TextBox[mechanics.numberVar+1];
            modSelect = new ComboBox[mechanics.numberVar];
            mfSelect = new ComboBox[mechanics.numberVar];
            int i;
            for (i=0; i<mechanics.numberVar; i++)
            {
                param[i] = new TextBox();
                param[i].Name = "textBox"+i;
                param[i].Text = "0";
                param[i].Location= new Point(15+125*i, 175);
                Controls.Add(param[i]);
                modSelect[i] = new ComboBox();
                modSelect[i].Name = "comboBox" + i;
                modSelect[i].Items.AddRange(new object[] { "NON", "OR", "AND", "INC", "INCOR", "INCAND" });
                modSelect[i].SelectedIndex = 0;
                modSelect[i].Location = new Point(15 + 125 * i, 202);
                Controls.Add(modSelect[i]);

                mfSelect[i] = new ComboBox();
                mfSelect[i].Name = "comboBoxmf" + i;
                mfSelect[i].Items.AddRange(new object[] { "mf1", "mf2", "mf3"});
                mfSelect[i].SelectedIndex = 0;
                mfSelect[i].Location = new Point(15 + 125 * i, 229);
                Controls.Add(mfSelect[i]);

            }
            param[i] = new TextBox();
            param[i].Name = "textBox" + i;
            param[i].Text = "0";
            param[i].Location = new Point(15 + 125 * i, 175);
            Controls.Add(param[i]);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            FuzzyRule newRule;
            MfMode[] tempMode=new MfMode[mechanics.numberVar];
            float[] tempPar = new float[mechanics.numberVar+1];
            int[] tempMf= new int[mechanics.numberVar];
            int i;
            for(i = 0; i<mechanics.numberVar; i++)
            {
               // float result;
                float.TryParse(param[i].Text, out tempPar[i]);
                tempMode[i] = (MfMode)modSelect[i].SelectedIndex;
                tempMf[i] = mfSelect[i].SelectedIndex;


            }
            float.TryParse(param[i].Text, out tempPar[i]);
            newRule = new FuzzyRule(tempMode, tempPar, tempMf);
            mechanics.mainSystem.addRule(newRule);
        }
    }
}
