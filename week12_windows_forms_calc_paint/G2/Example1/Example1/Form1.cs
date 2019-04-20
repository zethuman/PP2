using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Calculator calculator;
        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeTextDelegate chDelegate = new ChangeTextDelegate(ChangeTextBoxText);
            calculator = new Calculator(chDelegate);
        }

        public void ChangeTextBoxText(String text)
        {
            label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculator.a = int.Parse(textBox1.Text);
            calculator.b = int.Parse(textBox2.Text);
            calculator.Calc();
        }
    }
}
