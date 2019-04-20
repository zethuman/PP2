using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = 5;
            int y = textBox1.Location.Y + textBox1.Height + 10;
            int k = 0;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++)
                {
                    k++;
                    Button btn = new Button();
                    btn.Click += Btn_Clicked;
                    btn.Size = new Size(75, 75);
                    btn.Text = k.ToString();
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.Location = new Point(j * 75 + x + 4, i * 75 + y + 4);
                    Controls.Add(btn);
                }
            }
        }
        public void Btn_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text = textBox1.Text + btn.Text;
        }
    }

    
}
