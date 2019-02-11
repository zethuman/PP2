﻿using System;
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
            Explorer FileManager = new Explorer();
            FileManager.Start(@"F:\Source");
        }
    }
    class Explorer
    {
        public int cursor;
        public int size;
        public Explorer()
        {
            cursor = 0;
        }

        public void Color(FileSystemInfo file, int index)
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
        public void Show(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] files = directory.GetFileSystemInfos();
            size = files.Length;
            int index = 0;
            foreach (FileSystemInfo fs in files)
            {
                Color(fs, index);
                Console.WriteLine(fs.Name);
                index++;
            }
        }
        public void Start(string path)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            FileSystemInfo fs = null;
            while (key.Key != ConsoleKey.E)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Show(path);
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
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
        }
    }
}