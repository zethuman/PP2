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

namespace Example8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Blue, 8);

            HatchBrush hBrush = new HatchBrush(HatchStyle.Cross, Color.Red, Color.FromArgb(255, 128, 255, 255));

            g.DrawLine(pen, 100, 100, 200, 200);
            g.DrawEllipse(new Pen(Color.Red), 10, 10, 100, 100);
            
            g.FillEllipse(hBrush, 15, 15, 90, 90);
            //g.DrawRectangle(pen, 10, 10, 100, 100);
        }
    }
}
