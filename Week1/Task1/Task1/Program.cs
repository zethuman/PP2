using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            List<int> Prime = new List<int>();  // Создал список чтобы легче было хранить данные и посчитать сколько их

            string[] str = Console.ReadLine().Split(); //пропускал пробелы и записывал в строку

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = int.Parse(str[i]);  // присвоил массиву строку
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPrime(arr[i]) == 1) // передал числа из массива в метод IsPrime 
                {
                    Prime.Add(arr[i]); // если наш метод равен 1, то добавляем в список(List) Prime
                }
            }

            Console.WriteLine(Prime.Count); // посчитываю количество простых чисел и вывожу

            for (int i = 0; i < Prime.Count; i++)
            {
                Console.Write(Prime[i] + " "); // вывожу данные из списка через пробел 
            }
            Console.ReadLine();
        }

        public static int IsPrime(int num)
        {
            for (int i = 2; i <= num; i++) // перебираем числа от 2 до число которую передали
            {
                if ((i == num) || (i > Math.Sqrt(num))) // проверяем если i равно числу которую мы передали (num) то возвращаем true или 1  
                {                                       // например если 2 = 2 то возвращаем true или 1
                    return 1;                           // нам достаточно проверить до корня числа по Решето Эратосфена
                }
                if (num % i == 0 && i != num || num == 1)  // 1 - не простое число
                {
                    return 0;                           // исключаем числа которые делиться на числа которые меньше их по Решето Эратосфена
                }
            }
            return 0;
        }
    }
}