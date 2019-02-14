using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            Explorer FileManager = new Explorer();                   // создал новый FileManager
            FileManager.Start(@"F:\Source\PP2\Week3\TestFiles");     // вызвал через путь   
        }
    }
    class Explorer                       // создал новый класс 
    {
        public int cursor;
        public int size;
        public Explorer()
        {
            cursor = 0;
        }

        public void Delete(FileSystemInfo fs)                    // метод для удаления файла --Delete
        {
            if (fs.GetType() == typeof(DirectoryInfo))  
                Directory.Delete(fs.FullName, true);            // удалить файл
            else
            {
                FileInfo file = new FileInfo(fs.FullName);     // удалить файл даже если это папка
                fs.Delete();
            }
        }

        public void TextFile(string path)                     // метод для чтение через enter
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();                                  // очищаем консоль 
            StreamReader sr = new StreamReader(path);         
            string s = sr.ReadToEnd();                        // считываем с файла
            Console.WriteLine(s);                             // вывожу в консоль 
            ConsoleKeyInfo k = Console.ReadKey();
            if (k.Key == ConsoleKey.Escape)                   // закрываю если нажал на клавишу Esc
            {
                sr.Close();                                   // закрываю поток
                return;
            }
            else
                TextFile(path);                               //иначе показываем содержимое 
        }

        public void Color(FileSystemInfo file, int index)     // метод для цветов консоли,текста и курсора
        {
            if (index == cursor)
                Console.BackgroundColor = ConsoleColor.Red;
            else if (file.GetType() == typeof(DirectoryInfo))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void Interface()                             // метод для удобства, подсказки
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            string st = "Press 'R' and rename";
            string str = "Press 'Del' to delete";
            string stri = "Press 'Esc' to exit or come back";
            string strin = "Press 'F4' to close Explorer";
            Console.WriteLine(st + " || " + str + " || " + stri + " || " + strin);
            Console.WriteLine("_________________________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("Explorer");
            Console.WriteLine();
        }

        public void Show(string path)                                 // метод который показывает файлы 
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] files = directory.GetFileSystemInfos();
            size = files.Length;
            int index = 0;
            Interface();
            foreach (FileSystemInfo fs in files)
            {
                Color(fs, index);
                Console.WriteLine(index + 1 + ". " + fs.Name);
                index++;
            }
        }

        public void Start(string path)                                     
        {

            ConsoleKeyInfo key = Console.ReadKey();                  // считывает комманду с консоли 
            FileSystemInfo fs = null;
            while (key.Key != ConsoleKey.F4)                         // работает пока не нажали клавишу f4
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Show(path);                                           // вызываю метод Show
                if (size != 0)
                {
                    key = Console.ReadKey();
                    fs = directory.GetFileSystemInfos()[cursor];
                    if (key.Key == ConsoleKey.Enter)                  // комманды для выполнение 
                    {
                        if (fs.GetType() == typeof(DirectoryInfo))
                        {
                            cursor = 0;
                            path = fs.FullName;
                        }
                        else if (fs.Name.EndsWith(".txt"))
                            TextFile(fs.FullName);

                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        directory = directory.Parent;
                        path = directory.FullName;
                        cursor = 0;
                    }
                    else if (key.Key == ConsoleKey.Delete)
                    {
                        Delete(fs);
                        FileSystemInfo[] files = directory.GetFileSystemInfos();
                        size = files.Length;
                        cursor = 0;
                    }
                    else if (key.Key == ConsoleKey.R)
                    {
                        string s = Console.ReadLine();
                        ConsoleKeyInfo k = Console.ReadKey();
                        s = Path.Combine(directory.FullName, s);
                        if (fs.GetType() == typeof(DirectoryInfo))
                            Directory.Move(fs.FullName, s);         
                        else
                            File.Move(fs.FullName, s);               // чтобы переименовать можем использовать функцию Move
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        cursor--;
                        if (cursor < 0)
                            cursor = size - 1;
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        cursor++;
                        if (cursor == size)
                            cursor = 0;
                    }
                }
                else
                {
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        directory = directory.Parent;
                        path = directory.FullName;
                        cursor = 0;
                    }

                }
            }
        }
    }
}