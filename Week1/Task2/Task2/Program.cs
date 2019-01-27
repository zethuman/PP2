using System;

namespace Program
{
    class Student
    {
        public string name;
        public string id;
        public int year;

        public Student()
        {
            name = Console.ReadLine();
            id = Console.ReadLine();
            year = int.Parse(Console.ReadLine());
        }

        public Student(string name, string id)
        {
            this.name = name;
            this.id = id;
        }

        public Student(string name, string id, int year)
        {
            this.name = name;
            this.id = id;
            this.year = year;
        }

        public void Init(string name, string id, int year)
        {
            this.name = name;
            this.id = id;
            this.year = year;
        }

        public void Print()
        {
            Console.WriteLine(name + " " + id + " " + year);
        }

        public override string ToString()
        {
            return name + " " + id + " " + year;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("aaa", "bbb", 3.0);
            //st1.Init("aaa", "bbb", 3.0);

            Student st2 = new Student("qqq", "ccc");
            st2.year = 3.2;

            Student st3 = new Student();
            //st1.Print();
            //st2.Print();
            Console.WriteLine(st1);
            Console.WriteLine(st2);
            Console.WriteLine(st3);

        }
    }
}