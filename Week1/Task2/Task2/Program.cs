using System;

namespace Program
{
    class Student // создаю класс 
    {
        public string name; 
        public string id;  // идентифицироваю

        public Student(string name, string id)
        {
            this.name = name; 
            this.id = id;  // обеспечиваю доступ к текущему экземпляру класса с помощью ключевого слова this
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student(Console.ReadLine(),Console.ReadLine()); // считываю с консоли name, потом id и передаю в класс

            int year = int.Parse(Console.ReadLine());  
            
            Console.Write(st1.name + " " + st1.id + " " + ++year); // вывожу с инкрементом year
            Console.ReadKey();
        }
    }
}