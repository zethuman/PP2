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
            int[] arr = new int[n];
            List<int> input = new List<int>();
            string[] str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = int.Parse(str[i]);
            }

            int[] copy1 = (int[])arr.Clone();
            int[] copy = (int[])copy1.Clone();

            for (int i = 0; i < copy.GetLength(0) && i < copy1.GetLength(0); i++)
            {
                Console.Write(copy[i] + " " + copy[1] + " ");
            }
            Console.ReadLine();


            ////for(int i = 0; i < arr.GetLength(0); i++)
            ////{
            ////    Console.Write(arr[i] + " " + arr[i] + " ");
            ////}
            ////Console.ReadLine();

        }

        public static List<int> Dup(List<int> num)
        {
            List<int> result = new List<int>();
            List<int> repeat = new List<int>();
            for (int i = 0; i < num.Count; i++)
            {
                repeat.AddRange(num);
                result.AddRange(num);
                result.AddRange(repeat);
            }
            return result;
        }
    }
}
