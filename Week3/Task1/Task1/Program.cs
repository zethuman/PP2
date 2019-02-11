using System;
using System.IO;

namespace Ex1
{

    class FileManager
    {
        public int cursor;
        public int size;
        public FileManager()
        {
            cursor = 0;
        }

        public void Color(FileSystemInfo fs, int index)
        {
            if (index == cursor)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (fs.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        public void PrintName(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();
            size = fileSystemInfos.Length;
            int index = 0;
            foreach (FileSystemInfo fs in fileSystemInfos)
            {
                Color(fs, index);
                Console.WriteLine(fs.Name);
                index++;
            }
        }
        public void Manager(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            FileSystemInfo fs = null;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                PrintName(path);
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Escape)
                {
                    cursor = 0;
                    directory = directory.Parent;
                    path = directory.FullName;
                }
                if (consoleKey.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                        cursor = size - 1;
                }
                if (consoleKey.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == size)
                        cursor = 0;
                }
                if (consoleKey.Key == ConsoleKey.Enter)
                {
                    int k = 0;
                    for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                    {
                        if (cursor == k)
                        {
                            fs = directory.GetFileSystemInfos()[i];
                            break;
                        }
                        k++;
                    }
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        directory = new DirectoryInfo(fs.FullName);
                        path = fs.FullName;
                    }
                }
                if(consoleKey.Key == ConsoleKey.Delete)
                {
                    int k2 = 0;
                    for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)
                    {
                        if (cursor == k2)
                        {
                            string delpath = directory.FullName;
                            File.Delete(delpath);
                            break;
                        }
                        k2++;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FileManager FileManager = new FileManager();
            string path = "F:/Source/Examples";
            FileManager.Manager(path);
        }
    }
}