using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Logic
    {
        public static Double Add(Double a, Double b)
        {
            return a + b;
        }

        public static Double Sub(Double a, Double b)
        {
            return a - b;
        }

        public static Double Times(Double a, Double b)
        {
            return a * b;
        }

        public static Double Div(Double a, Double b)
        {
            return a / b;
        }

        public static Double Sqrt(Double a)
        {
            return Math.Sqrt(a);
        }
        public static Double Square(Double a)
        {
            return Math.Pow(a,2);
        }
        public static Double Sin(Double a)
        {
            return Math.Sin((a * Math.PI) / 180);
        }
        public static Double Cos(Double a)
        {
            return Math.Cos((a * Math.PI) / 180);
        }
       
        


    }
}
