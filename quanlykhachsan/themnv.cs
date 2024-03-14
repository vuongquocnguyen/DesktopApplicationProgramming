using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace quanlykhachsan
{
    public partial class themnv : Form
    {
        public SqlConnection conn = new SqlConnection();
        function func = new function();
        public themnv()
        {
            InitializeComponent();
        }

        private void tnv_update_Click(object sender, EventArgs e)
        {
            updatenv formupnv = new updatenv();
            formupnv.Show();
            this.Close();
        }

        private void tnv_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tnv_mnv.Text = tnv_data.Rows[e.RowIndex].Cells[0].Value.ToString();
            tnv_tnv.Text = tnv_data.Rows[e.RowIndex].Cells[1].Value.ToString();
            tnv_cccd.Text = tnv_data.Rows[e.RowIndex].Cells[2].Value.ToString();
            tnv_dc.Text = tnv_data.Rows[e.RowIndex].Cells[3].Value.ToString();
            tnv_sdt.Text = tnv_data.Rows[e.RowIndex].Cells[4].Value.ToString();
            tnv_ns.Text = tnv_data.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (tnv_data.Rows[e.RowIndex].Cells[6].Value.ToString() == "Nam")
            {
                tnv_gt_nam.Checked = true;
            }
            else
            {
                tnv_gt_nu.Checked = true;

            }

            tnv_pass.Text = tnv_data.Rows[e.RowIndex].Cells[7].Value.ToString();
            string path = tnv_data.Rows[e.RowIndex].Cells[8].Value.ToString();
            try
            {
                tnv_pic.Image = Image.FromFile(path);
            }
            catch (FileNotFoundException)
            {
                // Handle the exception by displaying a default image or showing an error message
                //pictureBox1.Image = Properties.Resources.DefaultImage;
                //  pictureBox1.Image = Properties.Resources.chi08;
                MessageBox.Show("Anh khong duoc tim thay.", "Lỗi rồi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tnv_mnv.Enabled = false;
        }

        private void tnv_search_TextChanged(object sender, EventArgs e)
        {
            string keysr = tnv_search.Text;
            string sqlnv = "select * from nhan_vien where (nv_ma like '%"+keysr+"%' or nv_ten like N'%" + keysr + "%' OR nv_cccd like '%" + keysr + "%' OR nv_diachi like N'%" + keysr + "' OR nv_sdt like '%" + keysr + "')";
            func.HienthiDulieuDG(tnv_data, sqlnv, conn);
        }

        private void themnv_Load(object sender, EventArgs e)
        {
            func.Ketnoi(conn);
            tnv_save.Enabled = false;
            func.HienthiDulieuDG(tnv_data, "select * from nhan_vien", conn);
        }

        private void tnv_reset_Click(object sender, EventArgs e)
        {
            tnv_mnv.Text = "";
            tnv_tnv.Text = "";
            tnv_cccd.Text = "";
            tnv_dc.Text = "";
            tnv_sdt.Text = "";
            tnv_gt_nam.Checked = false;
            tnv_gt_nu.Checked = false;
            tnv_pass.Text = "";
            
        }

        private void tnv_ns_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void tnv_sdt_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tnv_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
            
        }

        private void tnv_cccd_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }

        private void tnv_xoa_Click(object sender, EventArgs e)
        {
            
            try
            {

                int CurrentIndex = tnv_data.CurrentCell.RowIndex;
                string del_column_nv = Convert.ToString(tnv_data.Rows[CurrentIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa?", "Verify delete it ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string deletedStr = "delete from nhan_vien where nv_ma='" + del_column_nv + "'";
                    string del_nv = "select * from nhan_vien";
                    SqlCommand deletedCmd = new SqlCommand(deletedStr, conn);
                    deletedCmd.CommandType = CommandType.Text;
                    deletedCmd.ExecuteNonQuery();
                    func.CapNhat(deletedStr, conn);
                    func.HienthiDulieuDG(tnv_data, del_nv, conn);
                    
                    MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                    conn.Close();
                    tnv_mnv.Text = "";
                    tnv_tnv.Text = "";
                    tnv_cccd.Text = "";
                    tnv_dc.Text = "";
                    tnv_sdt.Text = "";
                    tnv_gt_nam.Checked = false;
                    tnv_gt_nu.Checked = false;
                    tnv_pass.Text = "";

                }
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tnv_save_Click(object sender, EventArgs e)
        {
            if (tnv_tnv.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên");
            }
            else if ( tnv_cccd.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập cccd");
            }
            else if( tnv_dc.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập địa chỉ");
            }
            else if ( tnv_sdt.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
            }
            else if ( tnv_pass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Pass");
            }
            else if (tnv_pic.Image == null)
            {
                MessageBox.Show("Vui lòng chọn hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tnv_pic.Focus();
            }else
            {
                string gender = "";
                string cccd_nv = tnv_cccd.Text;
                string sdt_nv = tnv_sdt.Text;

                string nsnv = tnv_ns.Value.ToString("yyyy-MM-dd");
                string linkanh = tnv_link.Text;

                string tnvma = tnv_mnv.Text;
                string tnvten = tnv_tnv.Text;
                string tnvdc = tnv_dc.Text;
                string tnvmk = tnv_pass.Text;

                if (tnv_gt_nam.Checked == true) 
                    { gender = "Nam"; } 
                else if (tnv_gt_nu.Checked == true) { gender = "Nữ"; };

                try
                {
                    string sql_tnv = "insert into nhan_vien (nv_ma, nv_ten, nv_cccd, nv_diachi, nv_sdt, nv_ngaysinh, nv_gioitinh, nv_pasword, nv_hinhanh) values ( '" + tnvma + "', N'" + tnvten + "', '" + cccd_nv + "',N'" + tnvdc + "','" + sdt_nv + "','" + nsnv + "',N'" + gender + "', '" + tnvmk + "', N'" + linkanh + "') ";
                    SqlCommand comd = new SqlCommand(sql_tnv, conn);
                    comd.ExecuteNonQuery();
                    //conn.Close();
                    MessageBox.Show(" Đã thêm nhân viên:  " + tnvten + " thành công");
                    tnv_save.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                func.HienthiDulieuDG(tnv_data, "select * from nhan_vien", conn);
                tnv_reset_Click(sender, e);
            }


        }
        
        private void tnv_khoitao_Click(object sender, EventArgs e)
        {
            tnv_save.Enabled = true;
            tnv_mnv.Text = "";
            tnv_tnv.Text = "";
            tnv_cccd.Text = "";
            tnv_dc.Text = "";
            tnv_sdt.Text = "";
            tnv_gt_nam.Checked = false;
            tnv_gt_nu.Checked = false;
            tnv_pass.Text = "";


            //sql tim den max ma phong
            string sql_maxttp = "SELECT MAX(SUBSTRING(nv_ma,3,1)) FROM nhan_Vien";
            SqlCommand comd = new SqlCommand(sql_maxttp, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                int max = Convert.ToInt32(reader.GetValue(0).ToString()) + 1;
                tnv_mnv.Text = "nv" + max;
            }
            reader.Close();

            
        }
        public void showImage(PictureBox PictureBox1, string path)
        {
            string file = "";
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose Image(*.jpg;*.jpeg;*.tif;*.jfif;*.png)|*.jpg;*.jpeg;*.tif;*.jfif";
            if (op.ShowDialog() == DialogResult.OK)
            {
                tnv_pic.Image = new Bitmap(op.FileName);
                file = op.FileName;
                tnv_link.Text = file;
            }
        }
        private void tnv_uploads_Click(object sender, EventArgs e)
        {
            
            showImage(tnv_pic, tnv_link.Text);
        }

        private void tnv_pic_Click(object sender, EventArgs e)
        {

        }

        private void tnv_cccd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
