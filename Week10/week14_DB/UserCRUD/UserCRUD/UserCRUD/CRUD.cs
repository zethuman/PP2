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
    public partial class CRUD : Form
    {
        Database database;
        public CRUD()
        {
            InitializeComponent();
        }

        public void DataBind()
        {
            database = new Database();
            string query = "select * from users";
            dataGridView1.DataSource = database.GetDataTable(query);
        }

        public void InsertData()
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Error");
            }
            else
            {
                string query = "insert into users(firstname, lastname, gender, phone, email) values(" +
                    "'" + txtFirstName.Text + "'," +
                    "'" + txtLastName.Text + "'," +
                    "'" + cbGender.Text + "'," +
                    "'" + txtPhone.Text + "'," +
                    "'" + txtEmail.Text + "')";

                int cnt = database.ExecuteSql(query);
                MessageBox.Show("Insert action completed");
                DataBind();
            }
        }

        public void UpdateData()
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Error");
            }
            else
            {
                string query = "update users set " +
                    "firstname='" + txtFirstName.Text + "'," +
                    "lastname='" + txtLastName.Text + "'," +
                    "gender='" + cbGender.Text + "'," +
                    "phone='" + txtPhone.Text + "'," +
                    "email='" + txtEmail.Text + "' " +
                    "where id=" + label1.Text;

                int cnt = database.ExecuteSql(query);
                MessageBox.Show("Update action completed");
                DataBind();
            }

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (label1.Text == "-")
                InsertData();
            else
                UpdateData();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            database = new Database();
            DataBind();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                label1.Text = row.Cells[0].Value.ToString();
                txtFirstName.Text = row.Cells[1].Value.ToString();
                txtLastName.Text = row.Cells[2].Value.ToString();
                cbGender.Text = row.Cells[3].Value.ToString();
                txtPhone.Text = row.Cells[4].Value.ToString();
                txtEmail.Text = row.Cells[5].Value.ToString();
                //MessageBox.Show(row.Cells[0].Value.ToString() + " " + row.Cells[1].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Text != "-")
            {
                string query = "delete from users where id=" + label1.Text;
                database.ExecuteSql(query);
                MessageBox.Show("Row deleted");
                DataBind();
            }
        }
    }
}
