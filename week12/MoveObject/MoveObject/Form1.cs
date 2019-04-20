using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveObject
{
    public partial class Form1 : Form
    {
        Graphics g;
        SolidBrush brush;
        int x = 0, dx = 10;
        int y = 0, dy = 10;


        enum Direction
        {
            None,
            Right,
            Left,
            Up,
            Down
        }

        Direction dir;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            brush = new SolidBrush(Color.Red);
            //timer1.Interval = 100;
            timer1.Enabled = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.FillEllipse(brush, x, y, 100, 100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dir = Direction.Right;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
            dir = Direction.Right;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dir = Direction.Up;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dir = Direction.Down;
        }

        //private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    switch(e.KeyChar.ToString())
        //    {
        //        case "8":
        //            dir = Direction.Up;
        //            break;
        //        case "2":
        //            dir = Direction.Down;
        //            break;
        //        case "4":
        //            dir = Direction.Left;
        //        case "6"

        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            dir = Direction.Left;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(dir == Direction.Right)
            {
                x += dx;
            }
            else if(dir == Direction.Left)
            {
                x -= dx;
            }

            else if(dir == Direction.Up)
            {
                y -= dy;
            }
            else if(dir == Direction.Down)
            {
                y += dy;
            }
            if (x + 100 > Width)
                dx = -10;
            else if (x < 0)
                dx = 10;

 

            if (y + 100 > Height)
                dy = -10;
            else if (y < 0)
                dy = 10;

            Refresh();

        }


    }
}
