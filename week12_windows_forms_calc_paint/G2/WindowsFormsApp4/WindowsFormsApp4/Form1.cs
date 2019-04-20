using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bitmap;
        Graphics gBitmap;
        bool mouseClicked;

        enum Tool
        {
            Pen, 
            Rectangle,
            Ellipse
        }
        Point prevPoint, curPoint;
        Tool tool;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
            prevPoint = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
            if (tool == Tool.Rectangle)
            {
                DrawRectangle(gBitmap);
            }
        }
        Pen pen = new Pen(Color.Black, 1);
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked)
            {               
                if (tool == Tool.Pen)
                {
                    curPoint = e.Location;
                    gBitmap.DrawLine(pen, prevPoint, curPoint);
                    prevPoint = curPoint;
                } else if (tool == Tool.Rectangle)
                {
                    curPoint = e.Location;
                    //gBitmap.DrawRectangle(pen, prevPoint.X, prevPoint.Y, curPoint.X - prevPoint.X, curPoint.Y - prevPoint.Y);
                }
                pictureBox1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = Tool.Pen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tool.Rectangle;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawRectangle(e.Graphics);
        }

        public void DrawRectangle(Graphics g)
        {
            int minX = Math.Min(prevPoint.X, curPoint.X);
            int maxX = Math.Max(prevPoint.X, curPoint.X);
            int minY = Math.Min(prevPoint.Y, curPoint.Y);
            int maxY = Math.Max(prevPoint.Y, curPoint.Y);
            g.DrawRectangle(pen, minX, minY, maxX - minX, maxY - minY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gBitmap = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            mouseClicked = false;
            tool = Tool.Pen;
        }
    }

}
