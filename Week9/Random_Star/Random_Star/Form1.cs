using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Random_Star
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            int i = 0;
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(path);
            if (directoryInfo.Exists)
            {
                i += directoryInfo.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly).Length;
                i += directoryInfo.GetFiles("*.*", System.IO.SearchOption.AllDirectories).Length;
            }
            Pen pen = new Pen(coloe.Red, 2);
            g.FillEllipse(pen.Brush )
           
        }
    }
}
