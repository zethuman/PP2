using System;

namespace Example3
{
    class Program
    {
        public static Calculator calculator;
        static void Main(string[] args)
        {
            calculator = new Calculator(new ChangeTextDelegate(PrintResult));
            calculator.a = int.Parse(Console.ReadLine());
            calculator.b = int.Parse(Console.ReadLine());
            calculator.Calc();
            Console.ReadKey();
        }

        public static void PrintResult(String msg)
        {
            Console.WriteLine(msg);
        }
    }
}
