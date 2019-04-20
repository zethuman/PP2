using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bitmap;
        Graphics g;

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }
        int x, y, r = 1;
        Color[] colors = new Color[] { Color.Red, Color.Plum, Color.PowderBlue, Color.Purple, Color.RoyalBlue };
        Random random = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            r += 2;
            int index = random.Next(0, colors.Length - 1);
            Pen pen = new Pen(colors[index], 2);
            g.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.Location.X;
            y = e.Location.Y;
            r = 1;
            timer1.Start();
        }
    }
}
