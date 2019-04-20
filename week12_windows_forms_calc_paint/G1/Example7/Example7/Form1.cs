using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example7
{
    public partial class Form1 : Form
    {
        Calculator calc;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            calc = new Calculator(textBox1);
            buttonAdd.Click += calc.Operation_Clicked;
            buttonMult.Click += calc.Operation_Clicked;
            buttonEqual.Click += calc.Equal_Clicked;
            int x = textBox1.Location.X;
            int y = textBox1.Location.Y + textBox1.Height + 5;
            int k = 0;
            int d = 75;
            int ep = 7;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    k++;
                    Button btn = new Button();
                    btn.Text = k.ToString();
                    btn.Size = new Size(d, d);
                    btn.Location = new Point(d * j + x + ep, d * i + y + ep);
                    btn.Click += calc.Number_Clicked;
                    Controls.Add(btn);
                }
            }
        }
    }
}
