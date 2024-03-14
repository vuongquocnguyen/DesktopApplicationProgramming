using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace quanlykhachsan
{
    public partial class Login : Form
    {
       

        function func = new function();
        public SqlConnection conn = new SqlConnection();

        public Login()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            func.Ketnoi(conn);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //show form admin 
       
        
        private void btn_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string tendn = username_textbox.Text;
            string mk = pwd_textbox.Text;
            string sql_dn = "SELECT nv_ma, nv_pasword FROM nhan_vien where nv_ma ='" + tendn + "' and nv_pasword='" + mk + "'";

            SqlCommand comd = new SqlCommand(sql_dn, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                admin ad = new admin(tendn);
                ad.Show();
            }
            else
            {
                MessageBox.Show("Gần đúng rồi nhập lại đi!!!!");
            }
            reader.Close();
        }
    }
}
