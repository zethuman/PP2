using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    abstract class GameObject
    {
        public List<Point> body = new List<Point>();
        protected char sign;

        public GameObject(char sign)
        {
            this.sign = sign;
        }

        public void Draw()
        {
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }

        public void Clear()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
        }

        public bool IsCollisionWithObject(GameObject obj)
        {
            foreach (Point p in obj.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }
    }
}
