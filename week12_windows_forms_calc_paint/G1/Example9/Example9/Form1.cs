using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 100, y = 100, r = 10;
        Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Yellow, Color.Aqua, Color.Beige};

        private void timer1_Tick(object sender, EventArgs e)
        {
            r += 5;
            Refresh();
        }

        Random random = new Random();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int index = random.Next(0, colors.Length - 1);
            Color color = colors[index];
            Pen pen = new Pen(color, 4);
            e.Graphics.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
        }


    }
}
