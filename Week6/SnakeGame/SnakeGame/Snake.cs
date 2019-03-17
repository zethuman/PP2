using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Snake: GameObject
    {
        enum Direction
        {
            NONE,
            UP,
            DOWN,
            RIGHT,
            LEFT
        }

        Direction direction = Direction.NONE;

        public Snake(char sign): base(sign)
        {
            body.Add(new Point {X = 20, Y = 20 });
        }

  
        public void Move()
        {
            Clear();
            if (direction == Direction.NONE)
                return;
          
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            if (direction == Direction.UP)
                body[0].y--;
            if (direction == Direction.DOWN)
                body[0].y++;
            if (direction == Direction.LEFT)
                body[0].x--;
            if (direction == Direction.RIGHT)
                body[0].x++;
        }

        public void ChangeDirection(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            if (keyInfo.Key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            if (keyInfo.Key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            if (keyInfo.Key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
        }

        public bool isCollision(bool gameOver)
        {
            if (body[0].X <= 0 || body[0].X >= 78 || body[0].Y <= 0 || body[0].Y >= 28)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Eat(List<Point> body)
        {
            this.body.Add(new Point { X = body[0].X, Y = body[0].Y });
           
        }


    }
}
