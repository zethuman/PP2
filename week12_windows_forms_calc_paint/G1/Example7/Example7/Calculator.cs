using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example7
{
    class Calculator
    {
        enum CalcState
        {
            None,
            Number,
            Operation,
            Equal
        }
        public int tempNumber;
        public int resultNumber;
        public String operation;
        CalcState state;
        TextBox textBox;
        public Calculator(TextBox textBox)
        {
            this.textBox = textBox;
            tempNumber = 0;
            resultNumber = 0;
            operation = "";
            state = CalcState.None;
        }

        public void Number_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (state == CalcState.None || state == CalcState.Number)
                textBox.Text += btn.Text;
            else if (state == CalcState.Operation)
            {
                resultNumber = int.Parse(textBox.Text);
                textBox.Text = btn.Text;
            }
            else if (state == CalcState.Equal)
            {
                resultNumber = 0;
                textBox.Text = btn.Text;
            }
            state = CalcState.Number;
        }

        public void Operation_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (state == CalcState.None)
                operation = btn.Text;
            if (state == CalcState.Number)
            {
                if (operation.Length > 0)
                    Calculate();
                operation = btn.Text;
            }
            if (state == CalcState.Operation)
                operation = btn.Text;
            state = CalcState.Operation;
        }

        public void Equal_Clicked(object sender, EventArgs e)
        {
            if (state != CalcState.Equal)
                tempNumber = int.Parse(textBox.Text);
            Calculate();
            state = CalcState.Equal;
        }

        public void Calculate()
        {

            if (state != CalcState.Equal)
            {
                if (operation == "+")
                    resultNumber = resultNumber + int.Parse(textBox.Text);
                if (operation == "-")
                    resultNumber = resultNumber - int.Parse(textBox.Text);
                if (operation == "*")
                    resultNumber = resultNumber * int.Parse(textBox.Text);
                if (operation == "/")
                    resultNumber = resultNumber / int.Parse(textBox.Text);
                textBox.Text = resultNumber.ToString();
            }
            else
            {
                if (operation == "+")
                    resultNumber = tempNumber + int.Parse(textBox.Text);
                if (operation == "-")
                    resultNumber = tempNumber - int.Parse(textBox.Text);
                if (operation == "*")
                    resultNumber = tempNumber * int.Parse(textBox.Text);
                if (operation == "/")
                    resultNumber = tempNumber / int.Parse(textBox.Text);
                textBox.Text = resultNumber.ToString();
            }
        }
    }
}
