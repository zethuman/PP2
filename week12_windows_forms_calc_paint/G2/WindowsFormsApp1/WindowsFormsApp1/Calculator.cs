using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    enum CalcState
    {
        Zero,
        AccumulateDigit,
        Operation,
        Result
    }
    public delegate void ChangeTextDelegate(String text);
    class Calculator
    {
        public CalcState state;
        public String tempNumber;
        public String resultNumber;
        public String operation;
        public ChangeTextDelegate textDelegate;

        public Calculator(ChangeTextDelegate textDelegate)
        {
            state = CalcState.Zero;
            this.textDelegate = textDelegate;
            tempNumber = "";
            resultNumber = "";
            operation = "";
        }

        public void Process(String input)
        {
            switch (state)
            {
                case CalcState.Zero:
                    Zero(input, false);
                    break;
                case CalcState.AccumulateDigit:
                    AccumulateDigit(input, false);
                    break;
                case CalcState.Operation:
                    Operation(input, false);
                    break;
                case CalcState.Result:
                    Result(input, false);
                    break;
                default:
                    break;
            }
        }

        public void Zero(String msg, bool input)
        {
            if (input)
            {
                state = CalcState.Zero;
            } else
            {
                if (Rules.IsNonZeroDigit(msg))
                    AccumulateDigit(msg, true);
            }
        }

        public void AccumulateDigit(String msg, bool input)
        {
            if (input)
            {
                state = CalcState.AccumulateDigit;
                tempNumber += msg;
                textDelegate.Invoke(tempNumber);
            } else
            {
                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);
                if (Rules.IsOperation(msg))
                    Operation(msg, true);
                if (Rules.IsEqual(msg))
                    Result(msg, true);
            }            
        }

        public void Operation(String msg, bool input)
        {
            if (input)
            {
                state = CalcState.Operation;
                if (operation.Length > 0)
                {
                    Calculate();
                    textDelegate.Invoke(resultNumber);
                } else
                {
                    resultNumber = tempNumber;
                }
                tempNumber = "";
                operation = msg;
            } else
            {
                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);
            }
        }

        public void Result(String msg, bool input)
        {
            if (input)
            {
                state = CalcState.Result;
                Calculate();
                textDelegate.Invoke(resultNumber);
            } else
            {
                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);                
            }
        }

        public void Calculate()
        {
            if (operation == "+")
                resultNumber = (int.Parse(resultNumber) + int.Parse(tempNumber)).ToString();
            if (operation == "-")
                resultNumber = (int.Parse(resultNumber) - int.Parse(tempNumber)).ToString();
        }
    }
}
