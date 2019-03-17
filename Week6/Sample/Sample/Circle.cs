using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class Circle : ShapeofAll
    {
        public int r;
        public Circle(int x, int y, int r) : base(x, y)
        {
            this.r = r;
        }
    }
}
