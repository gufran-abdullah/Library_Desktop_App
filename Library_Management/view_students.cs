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
using System.IO;

namespace Library_Management
{
    public partial class view_students : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TSHN4BD;Initial Catalog=Library;Integrated Security=True;Pooling=False");
        string pwd = Class1.GetRandomPassword(20);
        string path_wanted;
        DialogResult result;

        public view_students()
        {
            InitializeComponent();
        }

        private void view_students_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            LoadStudent();
        }

        public void LoadStudent()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            int i = 0;
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from students_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                Bitmap img;
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.HeaderText = "Student Image";
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageCol.Width = 100;
                dataGridView1.Columns.Add(imageCol);

                foreach(DataRow dr in dt.Rows)
                {
                    img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                    dataGridView1.Rows[i].Cells[8].Value = img;
                    dataGridView1.Rows[i].Height = 100;
                    i = i + 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            int i = 0;
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from students_info where student_name like('%"+ textBox1.Text +"%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                Bitmap img;
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.HeaderText = "Student Image";
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageCol.Width = 100;
                dataGridView1.Columns.Add(imageCol);

                foreach (DataRow dr in dt.Rows)
                {
                    img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                    dataGridView1.Rows[i].Cells[8].Value = img;
                    dataGridView1.Rows[i].Height = 100;
                    i = i + 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            int i = 0;
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from students_info where student_name like('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                Bitmap img;
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.HeaderText = "Student Image";
                imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imageCol.Width = 100;
                dataGridView1.Columns.Add(imageCol);

                foreach (DataRow dr in dt.Rows)
                {
                    img = new Bitmap(@"..\..\" + dr["student_image"].ToString());
                    dataGridView1.Rows[i].Cells[8].Value = img;
                    dataGridView1.Rows[i].Height = 100;
                    i = i + 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            groupBox1.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from students_info where id="+i+"";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["student_name"].ToString();
                textBox3.Text = dr["student_roll_no"].ToString();
                textBox4.Text = dr["student_department"].ToString();
                textBox5.Text = dr["studetnt_semester"].ToString();
                textBox6.Text = dr["student_contact"].ToString();
                textBox7.Text = dr["student_email"].ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path_wanted = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (result == DialogResult.OK)
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                string img_path;
                File.Copy(openFileDialog1.FileName, path_wanted + "\\student_images\\" + pwd + ".jpg");
                img_path = "student_images\\" + pwd + ".jpg";

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update students_info set student_name='"+textBox2.Text+"',student_image='"+img_path.ToString()+ "',student_roll_no='"+textBox3.Text+ "',student_department='"+textBox4.Text+ "',studetnt_semester='"+textBox5.Text+ "',student_contact='"+textBox6.Text+ "',student_email='"+textBox7.Text+"' where id=" + i + "";
                cmd.ExecuteNonQuery();
                LoadStudent();
                MessageBox.Show("Student record updated Successfully..!","Record Updation Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
            else if(result == DialogResult.Cancel)
            {
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update students_info set student_name='" + textBox2.Text + "',student_roll_no='" + textBox3.Text + "',student_department='" + textBox4.Text + "',studetnt_semester='" + textBox5.Text + "',student_contact='" + textBox6.Text + "',student_email='" + textBox7.Text + "' where id=" + i + "";
                cmd.ExecuteNonQuery();
                LoadStudent();
                MessageBox.Show("Student record updated Successfully..!", "Record Updation Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox1.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from students_info where id=" + i + "";
                cmd.ExecuteNonQuery();
                LoadStudent();
                MessageBox.Show("Student record deleted successfully..!", "Record Deletion Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
