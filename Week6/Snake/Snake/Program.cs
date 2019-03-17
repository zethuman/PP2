using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace ConsoleApplication2
{
    class Program
    {
        public string name;
        public Random rand = new Random();
        public ConsoleKeyInfo keypress = new ConsoleKeyInfo();

        int score, headX, headY, fruitX, fruitY, nTail;
        int[] TailX = new int[100];
        int[] TailY = new int[100];

        const int height = 30;
        const int width  = 80;

        bool gameOver, reset, isprinted, horizontal, vertical;
        string dir, pre_dir;

        void ShowBanner()
        {
            Console.SetWindowSize(width, height + 6);
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
            Console.WriteLine("                  - Press S to pause                        ");
            Console.WriteLine("                  - Press R to reset game                   ");
            Console.WriteLine("                  - Press ESC to quit game                  ");
            Console.WriteLine();
            Console.Write("     Username:      ");
            name = Console.ReadLine();
            
            if (keypress.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }

        void Setup()
        {
            dir = "RIGHT";
            pre_dir = "";
            score = 0;
            nTail = 0;

            gameOver = false;
            reset = false;
            isprinted = false;

            headX = width / 2;
            headY = height / 2;
            fruitX = rand.Next(1, width - 1);
            fruitY = rand.Next(1, height - 1);
        }

        void CheckInput()
        {
            while (Console.KeyAvailable)
            {
                keypress = Console.ReadKey();
                if (keypress.Key == ConsoleKey.Escape)
                    Environment.Exit(0);

                if (keypress.Key == ConsoleKey.S)
                {
                    pre_dir = dir;
                    dir = "STOP";
                }
                else if (keypress.Key == ConsoleKey.LeftArrow)
                {
                    pre_dir = dir;
                    dir = "LEFT";
                }
                else if (keypress.Key == ConsoleKey.RightArrow)
                {
                    pre_dir = dir;
                    dir = "RIGHT";
                }
                else if (keypress.Key == ConsoleKey.UpArrow)
                {
                    pre_dir = dir;
                    dir = "UP";
                }
                else if (keypress.Key == ConsoleKey.DownArrow)
                {
                    pre_dir = dir;
                    dir = "DOWN";
                }
            }
        }

        void Logic()
        {
            int preX = TailX[0];
            int preY = TailY[0];
            int tempX, tempY;

            if (dir != "STOP")
            {
                TailX[0] = headX;
                TailY[0] = headY;
                for (int i = 1; i < nTail; i++)
                {
                    tempX = TailX[i];
                    tempY = TailY[i];
                    TailX[i] = preX;
                    TailY[i] = preY;
                    preX = tempX;
                    preY = tempY;
                }
            }

            switch (dir)
            {
                case "RIGHT":
                    headX++;
                    break;
                case "LEFT":
                    headX--;
                    break;
                case "UP":
                    headY--;
                    break;
                case "DOWN":
                    headY++;
                    break;
                case "STOP":
                    while (true)
                    {
                        Console.Clear();
                        Console.CursorLeft = width / 2 - 6;
                        Console.WriteLine("GAME PAUSED");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("   - Press S to resume game");
                        Console.WriteLine("   - Press R to reset game");
                        Console.Write("   - Press ESC to quit game");
                        keypress = Console.ReadKey(true);
                        if (keypress.Key == ConsoleKey.Escape)
                            Environment.Exit(0);
                        if (keypress.Key == ConsoleKey.R)
                        {
                            reset = true;
                            break;
                        }
                        if (keypress.Key == ConsoleKey.S)
                            break;
                    }
                    dir = pre_dir;
                    break;
            }

            if (headX <= 0 || headX >= width - 1 || headY <= 0 || headY >= height - 1)
            {
                gameOver = true;
            }
            else
            {
                gameOver = false;
            }

            if (headX == fruitX && headY == fruitY)
            {
                score += 10;
                nTail++;
                fruitX = rand.Next(1, width - 1);
                fruitY = rand.Next(1, height - 1);
            }

            if (((dir == "LEFT" && pre_dir != "UP") && (dir == "LEFT" && pre_dir != "DOWN")) || ((dir == "RIGHT" && pre_dir != "UP") && (dir == "RIGHT" && pre_dir != "DOWN")))
            {
                horizontal = true;
            }
            else
            {
                horizontal = false;
            }

            if (((dir == "UP" && pre_dir != "LEFT") && (dir == "UP" && pre_dir != "RIGHT")) || ((dir == "DOWN" && pre_dir != "LEFT") && (dir == "DOWN" && pre_dir != "RIGHT")))
            {
                vertical = true;
            }
            else
            {
                vertical = false;
            }

            for (int i = 1; i < nTail; i++)
            {
                if (TailX[i] == headX && TailY[i] == headY)
                {
                    if (horizontal || vertical)
                    {
                        gameOver = false;
                    }
                    else
                    {
                        gameOver = true;
                    }
                }
                if (TailX[i] == fruitX && TailY[i] == fruitY)
                {
                    fruitX = rand.Next(1, width - 1);
                    fruitY = rand.Next(1, height - 1);
                }
            }
        }

        void Render()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1)
                    {
                        Console.Write("#");
                    }
                    else if (j == 0 || j == width - 1)
                    {
                        Console.Write("#");
                    }
                    else if (j == fruitX && i == fruitY)
                    {
                        Console.Write("o");
                    }
                    else if (j == headX && i == headY)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        isprinted = false;
                        for (int k = 0; k < nTail; k++)
                        {
                            if (TailX[k] == j && TailY[k] == i)
                            {
                                Console.Write("*");
                                isprinted = true;
                            }
                        }
                        if (!isprinted)
                            Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("             SNAKE GAME --- Author: Zhuman Rakhat          ");
            Console.WriteLine();
            Console.WriteLine("             Player name --- " + name);
            Console.WriteLine();
            Console.WriteLine("Your score: " + score);
            
        }

        void Lose()
        {
            Console.CursorTop = height + 3;
            Console.CursorLeft = width / 2 - 4;
            Console.WriteLine("Game Over");
            Console.WriteLine("Press R to reset game");
            Console.Write("Press ESC to quit game");
            while (true)
            {
                keypress = Console.ReadKey(true);
                if (keypress.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                if (keypress.Key == ConsoleKey.R)
                {
                    reset = true;
                    break;
                }
            }
        }

        void Update()
        {
            while (!gameOver)
            {
                CheckInput();
                Logic();
                Render();
                if (reset)
                    break;
                Thread.Sleep(30);
            }
            if (gameOver)
                Lose();
        }

        static void Main(string[] args)
        {
            Program snake = new Program();
            snake.ShowBanner();
            while (true)
            {
                snake.Setup();
                snake.Update();
                Console.Clear();
            }
        }
    }
}