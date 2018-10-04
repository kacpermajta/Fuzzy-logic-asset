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

        public RuleEditor()
        {
            InitializeComponent();
        }

        private void RuleEditor_Load(object sender, EventArgs e)
        {
            param = new TextBox[mechanics.numberVar+1];
            modSelect = new ComboBox[mechanics.numberVar];
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
                modSelect[i].Location = new Point(15 + 125 * i, 202);
                Controls.Add(modSelect[i]);

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
            int i;
            for(i = 0; i<mechanics.numberVar; i++)
            {
               // float result;
                float.TryParse(param[i].Text, out tempPar[i]);
                tempMode[i] = (MfMode) modSelect[i].SelectedIndex;

                
            }
            float.TryParse(param[i].Text, out tempPar[i]);
            newRule = new FuzzyRule(tempMode, tempPar);
            mechanics
        }
    }
}
