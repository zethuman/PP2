using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    public delegate void ChangeTextDelegate(String msg);

    class Calculator
    {
        public int a, b;

        public ChangeTextDelegate changeDelegate;

        public Calculator(ChangeTextDelegate changeTextDelegate)
        {
            this.changeDelegate = changeTextDelegate;
        }

        public void Calc()
        {
            changeDelegate.Invoke((a + b).ToString());            
        }        
    }
}
