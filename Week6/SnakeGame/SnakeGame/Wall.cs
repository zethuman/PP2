using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Wall:GameObject
    {
        public Wall(char sign): base(sign)
        {
            body.Add(new Point { X = 0, Y = 0 });
        }
        
        public void Interface(int height, int weight, string name, int score)
        {

            Console.SetCursorPosition(0, 0);

            Console.SetWindowSize(weight, height + 6);
            Console.SetBufferSize(weight, height + 6);

            for (int i = 1; i < height; i++)
            {
                for (int j = 1; j < weight; j++)
                {
                    if (i == 1 || i == height - 1 || j == 1 || j == weight - 1)
                    {
                        Console.Write('#');
                        body.Add(new Point { x = i, y = j });
                    }
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("             SNAKE GAME --- Author: Zhuman Rakhat          ");
            Console.WriteLine();
            Console.WriteLine("             Player     ---  " + "  " + name);
            Console.WriteLine();
            Console.WriteLine("Your score: " +    "                                        Press S to save scores  ");
            Console.WriteLine("Yout level: " +    "                                        Press L to load scores  ");
            Console.ReadKey();
        }
    }
}
