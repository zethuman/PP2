using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string origin = @"F:\Source\PP2\Week2\Task4\Task4/path";
            string copy = @"F:\Source\PP2\Week2\Task4\Task4\path1";

            string fileName = Console.ReadLine();

            origin = Path.Combine(origin, fileName);
            copy = Path.Combine(copy, fileName);

            File.Create(origin).Close();
            File.Copy(origin, copy);
          
            Console.WriteLine("File Copied");

            File.Delete(origin);

            Console.WriteLine("File deleted in origin");
            Console.ReadKey();


        }
    }
}
