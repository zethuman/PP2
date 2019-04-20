using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PointInMove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int flag = 0;
        List<Point> points = new List<Point>();
        SolidBrush sbRed = null;
        SolidBrush sbBackColor = null;

        private void buttonStart_Click(object sender, EventArgs e)
        {
            sbRed = new SolidBrush(Color.Red);
            sbBackColor = new SolidBrush(this.BackColor);
            for (int i = -10; i < ClientRectangle.Width; i++)
            {
                points.Add(new Point(i + 10, (ClientRectangle.Height - (int)Math.Pow((double)i, 2))));
            }
            flag++;
            Graphics g = CreateGraphics();
            g.FillRectangle(sbRed, points[0].X, points[0].Y, 1, 1);
            g.Dispose();
            timerForPointMove.Start();
        }

        private void timerForPointMove_Tick(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.FillRectangle(sbRed, points[flag].X, points[flag].Y, 1, 1);
            g.Dispose();
            Graphics gClear = CreateGraphics();
            gClear.FillRectangle(sbBackColor, points[flag - 1].X, points[flag - 1].Y, 1, 1);
            gClear.Dispose();
            flag++;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerForPointMove.Stop();
        }
    }
}
