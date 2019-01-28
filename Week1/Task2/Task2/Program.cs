using System;

namespace Program
{
    class Student
    {
        public string name;
        public string id;

        public Student(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student(Console.ReadLine(),Console.ReadLine());

            int year = int.Parse(Console.ReadLine());
            
            Console.Write(st1.name + " " + st1.id + " " + ++year);
            Console.ReadLine();
        }
    }
}