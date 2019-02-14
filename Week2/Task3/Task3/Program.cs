using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public static void Spaces(int level)
        {
            for (int i = 0; i < level; i++)//до заданного уровня выводит пробел
                Console.Write("     ");
        }

        public static void Folder(DirectoryInfo dir, int level)
        {
            foreach (FileInfo f in dir.GetFiles()) // показывает файлы из директории
            {
                Spaces(level);  // передал уровень в метод Spaces
                Console.WriteLine(f.Name); // вывожу имена папок
            }
            foreach (DirectoryInfo d in dir.GetDirectories()) // показывает каталог из директории
            {
                Spaces(level); // передал уровень в метод Spaces
                Console.WriteLine(d.Name);   // 
                Folder(d, level + 1); // рекурсивно вызывает метод Folder чтобы показать другие файлы и папки
            }
        }

        static void Main(string[] args)
        {
            // string path = Console.ReadLine();
            // DirectoryInfo path = new DirectoryInfo(path); можно и самому через консоль указать путь 
            DirectoryInfo path = new DirectoryInfo(@"F:\Source/Example1"); // создал директорию
            Folder(path, 0); // передал в метод путь
            Console.ReadKey();
        }
    }
}
