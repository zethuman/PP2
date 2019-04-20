using System;

namespace Example6
{
    class Program
    {
        public static ChangeTextDelegate textDelegate;
        static void Main(string[] args)
        {
            textDelegate = new ChangeTextDelegate(ChangeTextP);
            DelegateTest delegateTest = new DelegateTest(textDelegate);
            delegateTest.ChangeTextD("Hello world");
            Console.ReadKey();
        }

        public static void ChangeTextP(String msg)
        {
            Console.WriteLine(msg);
        }
    }
}
