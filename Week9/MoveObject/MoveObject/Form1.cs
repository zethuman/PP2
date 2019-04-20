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
        Graphics g1;
        SolidBrush brush;
        int x = 0, dx = 10;
        int y = 0, dy = 10;
        int x1 = 0, dx1 = 10;
        int y1 = 0, dy1 = 10;


        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            g1 = this.CreateGraphics();
            brush = new SolidBrush(Color.Red);
            //timer1.Interval = 100;
            timer1.Enabled = true;
            timer1.Stop();
        }

        Random rnd = new Random();

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.FillEllipse(brush, x, y, 50, 50);
            
            g1.FillEllipse(brush, x1, y1, 50, 50);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

      
        Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Yellow, Color.Green };

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.Location.X;
            y = e.Location.Y;
            x1 = rnd.Next(0, 100);
            y1 = rnd.Next(0, 100);
            timer1.Start();
        }

     

        private void timer1_Tick(object sender, EventArgs e)
        {
        
            if (y + 100 > Height)
                dy = -10;
            else if (y < 0)
                dy = 10;

            y += dy;
            if (y1 + 100 > Height)
                dy1 = -10;
            else if (y1 < 0)
                dy1 = 10;

            y1 += dy1;


            Refresh();

        }


    }
}
