using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Krug
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g;
        public int y1 = 0, dy = 10;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        public int x, y, r = 0;
        Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Yellow, Color.Green };
    
        Random random_cvet = new Random();
        Random random_krug = new Random();

        private void timer2_Tick(object sender, EventArgs e)
        {
            y1 -= dy;
            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x = random_krug.Next(0, pictureBox1.Width);
            y = random_krug.Next(0, pictureBox1.Height);
            r = 10;
            int index = random_cvet.Next(0, colors.Length - 1);
            Pen pen = new Pen(colors[index], 3);
            g.DrawEllipse(pen, x , y , 10, 10);
            timer2.Start();

            pictureBox1.Refresh();
           
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            r = 1;
            timer1.Start();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
