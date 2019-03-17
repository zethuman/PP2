using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Food : GameObject
    {
        public Food(char sign) : base(sign)
        {
            GenerateLocationofFood();
        }

        public void GenerateLocationofFood()
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);
            body.Add(new Point { X = random.Next(1, 78), Y = random.Next(1, 28) });
        }

    }
}
