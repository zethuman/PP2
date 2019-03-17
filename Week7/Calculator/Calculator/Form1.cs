using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double result_value = 0;
        String operation_performed = "";
        bool isoperation_performed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || isoperation_performed)
                textBox_Result.Clear();

            isoperation_performed = false;
            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if(!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            else
            textBox_Result.Text = textBox_Result.Text + button.Text; 
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (result_value != 0)
            {
                button15.PerformClick();
                operation_performed = button.Text;
                labelCurrentOperation.Text = result_value + " " + operation_performed;
                isoperation_performed = true;
            }
            else
            {
                operation_performed = button.Text;
                result_value = Double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = result_value + " " + operation_performed;
                isoperation_performed = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            result_value = 0;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            switch(operation_performed)
            {
                case "+":
                    textBox_Result.Text = (result_value + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (result_value - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (result_value / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (result_value * Double.Parse(textBox_Result.Text)).ToString();
                    break;
            }
            result_value = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
        }
    }
}
