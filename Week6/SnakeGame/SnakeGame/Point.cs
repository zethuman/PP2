using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Point
    {
        public int x;
        public int y;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = Filter_X(value);
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = Filter_Y(value);
            }
        }
        int Filter_Y(int v)
        {
            if (v < 0)
            {
                v = 27;
            }
            else if (v > 27)
            {
                v = 0;
            }
            return v;
        }
        int Filter_X(int v)
        {
            if (v < 0)
            {
                v = 79;
            }
            else if (v > 79)
            {
                v = 0;
            }
            return v;
        }
    }
}
