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
        public static void PrintSpaces(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("     ");
        }

        public static void Folder(DirectoryInfo dir, int level)
        {
            foreach (FileInfo f in dir.GetFiles())
            {
                PrintSpaces(level);
                Console.WriteLine(f.Name);
            }
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                PrintSpaces(level);
                Console.WriteLine(d.Name);
                Folder(d, level + 1);
            }
        }

        static void Main(string[] args)
        {
            // DirectoryInfo dir = new DirectoryInfo("F:/Source/PP2");
            DirectoryInfo path = new DirectoryInfo(Console.ReadLine());
            Folder(path, 0);
            Console.ReadKey();
        }
    }
}
