using System;
using System.IO;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../input.txt");
            String s = sr.ReadToEnd();
            String[] str = s.Split(); // считал и записал все на массив str
            sr.Close();

            List<int> arr = new List<int>(); 
            List<int> Prime = new List<int>();  // Создал список чтобы легче было хранить данные и посчитать сколько их

            foreach(string a in str)
            {
                arr.Add(int.Parse(a));  
            }

            for (int i = 0; i < arr.Count; i++)
            {
                if (IsPrime(arr[i]) == 1) // передал числа из массива в метод IsPrime 
                {
                    Prime.Add(arr[i]); // если наш метод равен 1, то добавляем в список(List) Prime
                }
            }
           
                StreamWriter sw = new StreamWriter("../../output.txt");
                if (Prime.Count >= 1)  // если у в листе есть хотя бы одно простое число 
                {
                    for (int i = 0; i < Prime.Count; i++)
                    {
                        sw.Write(Prime[i] + " "); // то выводил все простые числа
                    }
                }
                else sw.Write("No primes in the array"); // иначе выводил что в массиве нет простых чисел
                sw.Close();
            
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