using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        int N; double[] probU, probB;
        double a, b;

        int result1, result2;

        private void button1_Click(object sender, EventArgs e)
        {
            N = (int)numericUpDown1.Value;
            probU = new double[N]; 
            probB = new double[N];
            for (int i = 0; i < N; i++)
            {
                
                probU[i] = 1 / (double)N;
                if (i < N / 2) 
                    probB[i] = 1 / (double)N - 0.03;
                else 
                    probB[i] = 1 / (double)N + 0.01;
            }

          
            a = r.NextDouble();
            double summU = 0; double summB = 0;
            for (int k = 0; k <N; k++)
            {
                summU += probU[k];
                if (a <= summU) 
                {
                    result1 = k; 
                    break; 
                }
            }

            b = r.NextDouble();
            for (int k = 0; k < N; k++)
            {
                summB += probB[k];
                if (b <= summB) 
                { 
                    result2 = k; 
                    break; 
                }
            }

            tbUser.Text = result1.ToString();
            tbBot.Text = result2.ToString();
            if (result1 < result2) tbMessage.Text = "Вы проиграли";
            if (result1 > result2) tbMessage.Text = "Вы победили!";
            if (result1 == result2) tbMessage.Text = "Ничья";

        }
    }
}
