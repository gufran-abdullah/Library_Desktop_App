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
    public partial class report_retained_books : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TSHN4BD;Initial Catalog=Library;Integrated Security=True;Pooling=False");

        public report_retained_books()
        {
            InitializeComponent();
        }

        

        private void report_retained_books_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataSet1 ds = new DataSet1();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from issue_books where books_return_date=''";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds.DataTable1);
                CrystalReport1 myreport = new CrystalReport1();
                myreport.SetDataSource(ds);
                crystalReportViewer1.ReportSource = myreport;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
