using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management
{
    public partial class add_books : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TSHN4BD;Initial Catalog=Library;Integrated Security=True;Pooling=False");

        public add_books()
        {
            InitializeComponent();
        }

        private void add_books_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books_info values('"+textBox1.Text+"','"+ textBox2.Text + "','"+ textBox3.Text + "','"+ Convert.ToDateTime(dateTimePicker1.Text) + "',"+ textBox5.Text + ","+ textBox6.Text + "," + textBox6.Text + ")";
            cmd.ExecuteNonQuery();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox1.Focus();

            MessageBox.Show("Book record addded successfully..!","Record Insertion Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
