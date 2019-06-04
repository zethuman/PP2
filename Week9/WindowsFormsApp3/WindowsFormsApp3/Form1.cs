using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
                         
namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
     
        Bitmap bitmap;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        public int x, y, r = 0;
        Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Gold, Color.Gray };
        Random random = new Random();
        Random random_krug = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
                r += 3;
                int index = random.Next(0, colors.Length - 1);
                Pen pen = new Pen(colors[index], 3);
                g.FillEllipse(pen.Brush, x - r, y - r, 2 * r, 2 * r);
            if(r == 20)
            {
                timer1.Stop();
            }
                pictureBox1.Refresh();
        }

        public void Change_direction()
        {
            if (r != 20)
            {
                x = random_krug.Next(0, pictureBox1.Width);
                y = random_krug.Next(0, pictureBox1.Height);
                r = 1;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Change_direction();
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
