using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Database database;

        public void DataBind(string condition)
        {
            database = new Database();
            string query = "select * from users";
            if (condition != "")
            {
                query += " where firstname like '%" + condition + "%'";
            }
            dataGridView1.DataSource = database.GetDataTable(query);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataBind("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataBind(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUD crud = new CRUD();
            crud.ShowDialog();
        }
    }
}
