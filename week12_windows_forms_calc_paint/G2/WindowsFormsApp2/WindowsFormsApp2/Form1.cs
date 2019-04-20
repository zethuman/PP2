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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            Pen pen = new Pen(Color.Red, 4);
            Pen pen1 = new Pen(Color.Blue, 1);
            //graphics.DrawLine(pen, 10, 10, 200, 200);
            graphics.DrawRectangle(pen, 30, 30, 50, 60);

            //graphics.DrawRectangle(pen1, 30, 100, 50, 60);
            //graphics.DrawEllipse(pen, 30, 100, 50, 60);
            HatchBrush hBrush = new HatchBrush(HatchStyle.Cross, Color.Red, Color.FromArgb(255, 128, 255, 255));
            graphics.FillRectangle(pen.Brush, 0, 0, this.Width, this.Height);
            graphics.FillEllipse(hBrush, 30, 100, 100, 200);
            
        }
    }
}
