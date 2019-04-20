using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Calculator calculator;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calculator = new Calculator(new ChangeTextDelegate(ChangeText));

            int x = textBox1.Location.X;
            int y = textBox1.Location.Y + textBox1.Height + 5;
            int k = 0;
            int sz = 75;
            int d = 10;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    k++;
                    Button btn = new Button();
                    btn.Font = new Font("Microsoft Sans Serif", 20F);
                    btn.Text = BtnText(k);
                    btn.Size = new Size(sz, sz);
                    btn.Location = new Point(j * sz + x + d, i * sz + y + d);
                    btn.Click += Btn_Cliked;
                    Controls.Add(btn);
                }
            }
        }

        public void ChangeText(String text)
        {
            textBox1.Text = text;
        }

        public String BtnText(int k)
        {
            if (k < 10)
                return k.ToString();
            if (k == 10)
                return "+";
            if (k == 11)
                return "-";
            if (k == 12)
                return "=";
            return "";
        }

        public void Btn_Cliked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calculator.Process(btn.Text);
        }
    }
}
