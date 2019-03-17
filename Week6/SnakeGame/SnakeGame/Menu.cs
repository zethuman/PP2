using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Menu
    {
        Snake snake = new Snake('0');
        public int height = 30;
        public int width = 80;
        public int score;
        public string name;
        Wall wall = new Wall('#');

        public int Score(int score)
        {
            return score;
        }

        public void Banner()
        {
            Console.SetCursorPosition(0, 0);
            Console.SetWindowSize(width, height + 5);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;

            Console.WriteLine("||========================================================||");
            Console.WriteLine("||--------------------------------------------------------||");
            Console.WriteLine("||---------------- Welcome to Snake Game -----------------||");
            Console.WriteLine("||--------------------------------------------------------||");
            Console.WriteLine("||========================================================||");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("           Enter username then press any key                ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("     Controller:  - Use Arrow buttons to move the snake     ");
            Console.WriteLine("                  - Press L to load scores                  ");
            Console.WriteLine("                  - Press S to save scores                  ");
            Console.WriteLine("                  - Press ESC to quit game                  ");
            Console.WriteLine();
            Console.Write("     Username:     ");
            name = Console.ReadLine();

            ConsoleKeyInfo keypress = Console.ReadKey();
            if (keypress.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            
            wall.Interface(height, width, name, Score(score));
        }
         
       
        public void  GameOverFunc(ConsoleKeyInfo keypress)
        {
            if(keypress.Key == ConsoleKey.R)
            {
                Console.Clear();
                GameState game = new GameState('0');
                game.Start();
            }
        }

    }
}
