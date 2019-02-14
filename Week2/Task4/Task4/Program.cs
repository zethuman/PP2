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

        public static void Start()    
        {
            string origin = @"F:\Source\PP2\Week2\Task4\Task4\path";  // оргинальная папка 
            string fileName = Console.ReadLine();          // имя папки через консоль

            origin = Path.Combine(origin, fileName);   // создал файл в оригинальной папке    

            File.WriteAllText(origin, "ne lyublyu pisat' kommenty");    //  что то пишем

            string copy = @"F:\Source\PP2\Week2\Task4\Task4\path1";     // папка куда будем скопировать 
            string copyfile = Path.Combine(copy, fileName);  //создаем файл на второй папке

            File.Copy(origin, copyfile, true);     //скопируем файл с оригинального на второй

            Delete(origin);        // вызываю метод чтобы удалить оригинальный файл
        }

        public static void Delete(string path)
        {
            if (File.Exists(path))
            {     // если папка существует, удаляю
                File.Delete(path);
            }
        }

        public static void Main(string[] args)
        {
            Start();       //вызываю метод



        }
    }
}
