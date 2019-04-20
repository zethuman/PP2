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
        public Double memory = 0;
        Double result_value = 0;
        String operation_performed = "";
        String operation = "";
        bool isoperation_performed = false;
        bool iszero = false;

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
            if (button.Text == ",")
            {
                if (!textBox_Result.Text.Contains(","))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            else
            {
                textBox_Result.Text = textBox_Result.Text + button.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e) // C
        {
            textBox_Result.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e) //CE
        {
            textBox_Result.Clear();
            result_value = 0;
            equation.Text = "";
        }

        private void button28_Click(object sender, EventArgs e) // +-
        {
            textBox_Result.Text = (-Double.Parse(textBox_Result.Text)).ToString();
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (result_value != 0)
            {
                equal.PerformClick();
                isoperation_performed = true;
                operation_performed = button.Text;
                equation.Text = result_value + " " + operation_performed;
            }
            else
            {
                operation_performed = button.Text;
                result_value = Double.Parse(textBox_Result.Text);
                isoperation_performed = true;
                equation.Text = result_value + " " + operation_performed;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
            if (operation_performed == "+")
            {
                textBox_Result.Text = Logic.Add(result_value, Double.Parse(textBox_Result.Text)).ToString();
            }
            else if(operation_performed == "Cop")
            {
                textBox_Result.Text = Logic.Cop(Int32.Parse(result_value+""), Int32.Parse(textBox_Result.Text)).ToString();
            }
            else if (operation_performed == "-")
            {
                textBox_Result.Text = Logic.Sub(result_value ,Double.Parse(textBox_Result.Text)).ToString();
            }
            else if (operation_performed == "÷")
            {
                if (Double.Parse(textBox_Result.Text) != 0)
                {
                    textBox_Result.Text = Logic.Div(result_value , Double.Parse(textBox_Result.Text)).ToString();
                }
                else
                {
                    iszero = true;
                }
            }
            else if (operation_performed == "X")
            {
                textBox_Result.Text = Logic.Times(result_value , Double.Parse(textBox_Result.Text)).ToString();
            }

            if (!iszero)
            {
                result_value = Double.Parse(textBox_Result.Text);
            }
            else if (iszero)
            {
                textBox_Result.Text = "Учи матан!";
            }
            operation_performed = "";
        }

        public void one_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;

            if (operation == "%")
            {
                textBox_Result.Text = ((Double.Parse(textBox_Result.Text) / 100)).ToString();
            }
            else if(operation == "Bin")
            {
                int i = Convert.ToInt32(textBox_Result.Text);
                textBox_Result.Text = Convert.ToString(i,2);
            }
            else if (operation == "√")
            {
                textBox_Result.Text = Logic.Sqrt(Double.Parse(textBox_Result.Text)).ToString();
            }
            else if (operation == "x^2")
            {
                textBox_Result.Text = Logic.Square(Double.Parse(textBox_Result.Text)).ToString();
            }
            else if (operation == "sin")
            {
                textBox_Result.Text = Logic.Sin(Double.Parse(textBox_Result.Text)).ToString();
            }
            else if (operation == "cos")
            {
                textBox_Result.Text = Logic.Cos(Double.Parse(textBox_Result.Text)).ToString();
            }
            else if (operation == "MS")
            {
                memory = (Double.Parse(textBox_Result.Text));
            }
            else if (operation == "M+")
            {
                memory += ((Double.Parse(textBox_Result.Text)));
            }
            else if (operation == "M-")
            {
                memory = ((Double.Parse(textBox_Result.Text) - memory));
            }
            else if (operation == "MR")
            {
                textBox_Result.Clear();
                textBox_Result.Text = memory + "";
            }
            else if (operation == "MC")
            {
                memory = 0;
            }

            result_value = Double.Parse(textBox_Result.Text);
            equation.Text = "";
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            equal.Focus();
            switch(e.KeyChar.ToString())
            {
                case "0":
                    zero.PerformClick();
                    break;
                case "1":
                    one.PerformClick();
                    break;
                case "2":
                    two.PerformClick();
                    break;
                case "3":
                    three.PerformClick();
                    break;
                case "4":
                    four.PerformClick();
                    break;
                case "5":
                    five.PerformClick();
                    break;
                case "6":
                    six.PerformClick();
                    break;
                case "7":
                    seven.PerformClick();
                    break;
                case "8":
                    eight.PerformClick();
                    break;
                case "9":
                    nine.PerformClick();
                    break;
                case ".":
                    dec.PerformClick();
                    break;
                case "*":
                    times.PerformClick();
                    break;
                case "/":
                    div.PerformClick();
                    break;
                case "+":
                    plus.PerformClick();
                    break;
                case "-":
                    minus.PerformClick();
                    break;
                case "ENTER":
                    equal.PerformClick();
                    break;
                default:
                    break;
            }
        }

        
    }
}
