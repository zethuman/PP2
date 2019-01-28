using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            int[] arr = new int[n];                   // создал массив
           

            string[] str = Console.ReadLine().Split();

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(str[i]);  // заполнил массив 
            }

            Dup(arr, n); // передал методу Dup

        }

        public static void Dup(int []arr2, int m)
        {
            List<int> repeat = new List<int>(); // создал список

            for(int i = 0; i < m; i++)
            {
                repeat.Add(arr2[i]); 
                repeat.Add(arr2[i]); // заполнил два раза
            }
            
            for(int i = 0; i < repeat.Count; i++)
            {
                Console.Write(repeat[i] + " "); // вывод 
            }
            Console.ReadKey();
        }
    }
}
