using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quiz3
{
    public partial class Form1 : Form
    {
        int x = 60;
        int x2 = 90;

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        int z = 55, z1 = 95;
        int c = 110, c1 = 95;

        SolidBrush br;
        public Form1()
        {
            InitializeComponent();
            br = new SolidBrush(Color.Red);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 10;
            x2 += 10;
            z += 10;
            c += 10;
            //y += 10;
            // x1 += 10;
            // y1 += 10;
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(br, x, 50, 100, 51);
            e.Graphics.FillRectangle(br, x2, 20, 45, 30);
            e.Graphics.FillEllipse(br, z, 95, 50, 50);
            e.Graphics.FillEllipse(br, c, 95, 50, 50);
        }
    }
}
