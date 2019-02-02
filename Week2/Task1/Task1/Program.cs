using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../input.txt"); 
            string s = sr.ReadToEnd(); // считал строку из инпута 

          
            int n = s.Length; // присваевал к n чтобы было легче

            for (int i = 0; i < n / 2; i++) // пробегался до половины строки 
            {
                if (s[i] != s[n - i - 1]) // если первая половина не равна на вторую 
                {
                    Console.WriteLine("No"); // вывожу No
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            Console.WriteLine("Yes"); // иначе Yes
            Console.ReadKey();
            sr.Close(); //  закрыл поток 
        }
    }
    
}
