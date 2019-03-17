using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    class Program
    {
        public static void Interface()
        {
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.CursorVisible = false;
            Console.ReadKey();
        }

        public static void Move(int x, int y)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape || key.Key != ConsoleKey.F4)
            {
                if (key.Key == ConsoleKey.UpArrow)
                {
                    y--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    y++;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    x++;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    x--;
                }
                Console.Clear();
                Wall.Level("../../level1.txt");
                Console.SetCursorPosition(x, y);
                Console.Write("o");
                key = Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            Interface();
            Move(10, 10);

           
        }
    }
}
