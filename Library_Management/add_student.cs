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
    public partial class add_student : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TSHN4BD;Initial Catalog=Library;Integrated Security=True;Pooling=False");
        string pwd = Class1.GetRandomPassword(20);
        string path_wanted;


        public add_student()
        {
            InitializeComponent();
        }

        private void add_student_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            path_wanted = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DialogResult result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if(result == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string img_path;
                File.Copy(openFileDialog1.FileName, path_wanted + "\\student_images\\" + pwd + ".jpg");
                img_path = "student_images\\" + pwd + ".jpg";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into students_info values('"+ textBox1.Text +"','"+ img_path.ToString() +"','"+ textBox2.Text + "','"+ textBox3.Text + "','"+ textBox4.Text + "','"+ textBox5.Text + "','"+ textBox6.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student added Successfully..!","Record Insertion Message",MessageBoxButtons.OK,MessageBoxIcon.Information);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
