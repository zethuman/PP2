using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krug_Timer
{
    public partial class Form1 : Form
    {
        public int x, y, r = 0;
        bool mouseCLicked = false;
        Bitmap bitmap;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Gold, Color.Yellow };
        Random random = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            r += 10;
            int index = random.Next(0, colors.Length - 1);  
            Pen pen = new Pen(colors[index], 3);
            g.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (!mouseCLicked)
            {
                x = e.Location.X;
                y = e.Location.Y;
                r = 1;
                timer1.Start();
                mouseCLicked = true;
            }
            else
            {
                mouseCLicked = false;
                timer1.Stop();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
