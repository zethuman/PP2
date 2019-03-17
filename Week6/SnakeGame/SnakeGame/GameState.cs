using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading;

namespace SnakeGame
{
     class GameState:GameObject
    {
        public bool ok = true;
        public bool gameOver = false;
        public int score = 0;
        public int currentlevel = 1;
        public int save_score = 0;
        public int save_level = 0;
        List<GameObject> g_objects;
        Snake snake = new Snake('0');
        Food food = new Food('@');
        Wall wall = new Wall('#');

       public GameState(char sign):base(sign)
        {
            g_objects = new List<GameObject>();
            g_objects.Add(snake);
            g_objects.Add(food);
        }

    public void Draw()
        {
            snake.Draw();
            food.Draw();
            wall.Draw();
        }

     
        
        public bool CheckCollisionofWall()
        {
            if (snake.isCollision(false))
            {
                return true;
            }
            return false;
        }

        public void Spam()
        {
            if (snake.IsCollisionWithObject(food))
            {
                snake.body.Add(new Point { x = 0, y = 0 });
                while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                    food.GenerateLocationofFood();
            }
        }

        public void Start()
        {
            Menu startmenu = new Menu();
            startmenu.Banner();

            ConsoleKeyInfo keypress = Console.ReadKey();

            Thread thread = new Thread(MoveSnake);
            thread.Start();

                while(keypress.Key != ConsoleKey.Escape)
                {
                    if (!CheckCollisionofWall())
                    {
                    keypress = Console.ReadKey();
                    snake.ChangeDirection(keypress);
                    score = snake.body.Count * 5;
                    Score(keypress,score);
                    }
                    else
                    {
                       GameOver(keypress, startmenu);
                    }
                }
            
        }

        public void MoveSnake()
        {
            while (!CheckCollisionofWall())
            {
                snake.Move();
                Spam();
                Draw();
                Thread.Sleep(100);
            }
        }

        public void Score(ConsoleKeyInfo keypress, int score)
        {
            if (keypress.Key == ConsoleKey.S || keypress.Key == ConsoleKey.Escape)
            {
                SaveObj(score, "score");
                SaveObj(currentlevel, "currentlevel");
            }
            if (score >= 20)
                currentlevel = 2;
            if (score >= 100)
                currentlevel = 3;
            if (score >= 150)
                currentlevel = 4;
            TheNextLevel(currentlevel);

            if (keypress.Key == ConsoleKey.L)
            {
                score = 0;
                currentlevel = 0;
                save_score = LoadObj("score");
                save_level = LoadObj("currentlevel");
            }
            else
            {
                int whole_score = score + save_score;
                int whole_level = currentlevel + save_level;
                Console.SetCursorPosition(12, 33);
                Console.Write(whole_score);
                Console.SetCursorPosition(12, 34);
                Console.Write(whole_level);
                Console.SetCursorPosition(15, 33);
                Console.Write(save_score + "  " + save_level);
            }
        }

        public void TheNextLevel(int currentlevel)
        {
            if(currentlevel == 2)
            {
                Thread.Sleep(80);
            }
            if(currentlevel == 3)
            {
                Thread.Sleep(60);
            }
            if(currentlevel == 3)
            {
                Thread.Sleep(40);
            }
            if (currentlevel == 4)
            {
                Thread.Sleep(20);
            }
        }
        
        public void GameOver(ConsoleKeyInfo keypress, Menu startmenu)
        {
            Console.Clear();
            Console.SetWindowSize(40, 20);
            Console.SetBufferSize(40, 20);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 1; i < 15; i++)
            {
                for (int j = 1; j < 40; j++)
                {
                    if (i == 1 || i == 14 || j == 1 || j == 39)
                    {
                        Console.Write('*');
                    }
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(10, 5);
            Console.Write(" Game Over !!! ");
            Console.WriteLine();
            Console.SetCursorPosition(10, 7);
            Console.Write(" Press R to restart game");
            Console.WriteLine();
            Console.SetCursorPosition(10, 9);
            Console.Write(" Press Esc to quit game ");
            keypress = Console.ReadKey();
            startmenu.GameOverFunc(keypress);
        }


        void SaveObj(int k, string fname)
        {
            FileStream fs = new FileStream(@"../../Serialization\" + fname + ".txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(k);

            sw.Close();
            fs.Close();

        }

         int LoadObj(string fname)
        {
            FileStream fs = new FileStream(@"../../Serialization\" + fname + ".txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            int val = int.Parse(sr.ReadLine());

            sr.Close();
            fs.Close();

            return val;
        }


    }
}

