using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Graph_Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmap;
        Graphics gbitmap;
        bool mouse_Clicked;

        enum Tool
        {
            Circle,
            Rectangle,
            Star,
            Triangle,
            Hexagon,
            Erase,
            Clear
        }

        Point prevpoint, curpoint;
        Tool tool;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_Clicked = true;
            prevpoint = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_Clicked = false;
            if(tool == Tool.Rectangle)
            {
                DrawRectangle(gbitmap);
                
            }
            else if(tool == Tool.Circle)
            {
                DrawCircle(gbitmap);
            }
            else if(tool == Tool.Star)
            {
                DrawStar(gbitmap);
            }
        }
  
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (mouse_Clicked)
            {
                if (tool == Tool.Rectangle)
                {
                    curpoint = e.Location;
                   
                }
                else if (tool == Tool.Circle)
                {
                    curpoint = e.Location;
               
                }
                else if (tool == Tool.Triangle)
                {
                    curpoint = e.Location;
                  
                }
                else if (tool == Tool.Star)
                {
                    curpoint = e.Location;
                
                }
                else if(tool == Tool.Erase)
                {
                    curpoint = e.Location;
                    gbitmap.DrawLine(new Pen(pictureBox1.BackColor, 10), prevpoint, curpoint);
                    prevpoint = curpoint;

                }
                else if(tool == Tool.Clear)
                {
                    gbitmap.Clear(pictureBox1.BackColor);
                    pictureBox1.Refresh();
                }
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = Tool.Circle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tool.Rectangle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool = Tool.Star;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tool = Tool.Triangle;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tool = Tool.Hexagon;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tool = Tool.Clear;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tool = Tool.Erase;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (tool == Tool.Rectangle)
            {
                DrawRectangle(e.Graphics);
            }
            else if (tool == Tool.Circle)
            {
                DrawCircle(e.Graphics);
            }
            else if (tool == Tool.Star)
            {
                DrawStar(e.Graphics);
            }

        }

        public void DrawRectangle(Graphics g)
        {
            int minX = Math.Min(prevpoint.X, curpoint.X);
            int maxX = Math.Max(prevpoint.X, curpoint.X);
            int minY = Math.Min(prevpoint.Y, curpoint.Y);
            int maxY = Math.Max(prevpoint.Y, curpoint.Y);
            g.DrawRectangle(new Pen(Color.Yellow, 2), minX, minY, maxX - minX, maxY - minY);
        }

        public void DrawStar(Graphics g)
        {
                Point[] p = new Point[8];
                p[0] = new Point(0  + prevpoint.X, 25 + curpoint.X);
                p[1] = new Point(20 + prevpoint.X, 20 + curpoint.X);
                p[2] = new Point(25 + prevpoint.X, 0 + curpoint.X);
                p[3] = new Point(30 + prevpoint.X, 20 + curpoint.X);
                p[4] = new Point(50 + prevpoint.X, 25 + curpoint.X);
                p[5] = new Point(30 + prevpoint.X, 30 + curpoint.X);
                p[6] = new Point(25 + prevpoint.X, 50 + curpoint.X);
                p[7] = new Point(20 + prevpoint.X, 30 + curpoint.X);
                Pen pen = new Pen(Color.DarkRed, 2);
                GraphicsPath path = new GraphicsPath();
                path.AddPolygon(p);
                g.DrawPath(pen, path);
        }

        public void DrawCircle(Graphics g)
        {
            int minX = Math.Min(prevpoint.X, curpoint.X);
            int maxX = Math.Max(prevpoint.X, curpoint.X);
            int minY = Math.Min(prevpoint.Y, curpoint.Y);
            int maxY = Math.Max(prevpoint.Y, curpoint.Y);
            g.DrawEllipse(new Pen(Color.White, 2), minX, minX, maxX - minX, maxX - minX);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gbitmap = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            mouse_Clicked = false;
            tool = Tool.Circle;

        }
    }
}
