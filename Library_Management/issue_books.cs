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
    public partial class issue_books : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TSHN4BD;Initial Catalog=Library;Integrated Security=True;Pooling=False");

        public issue_books()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from students_info where student_roll_no='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("Student record not found..!", "Database Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBox2.Text = dr["student_name"].ToString();
                        textBox3.Text = dr["student_department"].ToString();
                        textBox4.Text = dr["studetnt_semester"].ToString();
                        textBox5.Text = dr["student_contact"].ToString();
                        textBox6.Text = dr["student_email"].ToString();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void issue_books_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            if (e.KeyCode != Keys.Enter)
            {
                try
                {
                    listBox1.Items.Clear();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from books_info where book_name like('%" + textBox7.Text + "%')";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    i = Convert.ToInt32(dt.Rows.Count.ToString());

                    if (i > 0)
                    {
                        listBox1.Visible = true;
                        foreach (DataRow dr in dt.Rows)
                        {
                            listBox1.Items.Add(dr["book_name"]).ToString();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Text = listBox1.SelectedItem.ToString();
                listBox1.Visible = false;
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int books_qty = 0;
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from books_info where book_name='"+ textBox7.Text +"'";
                cmd2.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(dt2);

                foreach (DataRow dr2 in dt2.Rows)
                {
                    books_qty = Convert.ToInt32(dr2["avaiable_qty"].ToString());
                }

                if (books_qty > 0)
                {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into issue_books values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + dateTimePicker1.Value.ToString() + "','')";
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = con.CreateCommand();
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update books_info set avaiable_qty=avaiable_qty-1 where book_name='" + textBox7.Text + "'";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Book issued successfully..!", "Books Issuence Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("Book is not available..!","Books Issuence Message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
