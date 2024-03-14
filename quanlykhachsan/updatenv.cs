using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace quanlykhachsan
{
    public partial class updatenv : Form
    {
        public updatenv()
        {
            InitializeComponent();
        }

        public SqlConnection conn = new SqlConnection();
        function func = new function();

        private void upnv_ns_ValueChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(upnv_data.Rows[upnv_data.CurrentCell.RowIndex].Cells[0].Value);
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-1JAA108\\SQLEXPRESS; Initial Catalog = quanlykhachsan; Intergated Security = True");
            con.Open();
            string sql = "UPDATE nhanvien SET manv = '" + upnv_mnv.Text + "' tennv='" + upnv_tnv.Text + "', cccd='" + upnv_cccd.Text + "', diachi='" + upnv_dc.Text + "', sdt='" + upnv_sdt.Text + "' , gioitinh=" + (upnv_ns.Checked ? 1 : 0) + " WHERE ID=" + ID;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery(); con.Close();
            MessageBox.Show("Save successfully !!!");
        }

  
        private void updatenv_Load(object sender, EventArgs e)
        {
            func.Ketnoi(conn);
            
            func.HienthiDulieuDG(upnv_data, "select * from nhan_vien", conn);

    }

        private void upnv_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            upnv_mnv.Text = upnv_data.Rows[e.RowIndex].Cells[0].Value.ToString();
            upnv_tnv.Text = upnv_data.Rows[e.RowIndex].Cells[1].Value.ToString();
            upnv_cccd.Text = upnv_data.Rows[e.RowIndex].Cells[2].Value.ToString();
            upnv_dc.Text = upnv_data.Rows[e.RowIndex].Cells[3].Value.ToString();
            upnv_sdt.Text = upnv_data.Rows[e.RowIndex].Cells[4].Value.ToString();
            upnv_ns.Text = upnv_data.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (upnv_data.Rows[e.RowIndex].Cells[6].Value.ToString() == "Nam")
            {
                upnv_gt_nam.Checked = true;
            }
            else
            {
                upnv_gt_nu.Checked = true;

            }

            upnv_pass.Text = upnv_data.Rows[e.RowIndex].Cells[7].Value.ToString();
            upnv_link.Text = upnv_data.Rows[e.RowIndex].Cells[8].Value.ToString();
            string path = upnv_data.Rows[e.RowIndex].Cells[8].Value.ToString();
            try
            {
                upnv_pic.Image = Image.FromFile(path);
            }
            catch (FileNotFoundException)
            {
                // Handle the exception by displaying a default image or showing an error message
                //pictureBox1.Image = Properties.Resources.DefaultImage;
                //  pictureBox1.Image = Properties.Resources.chi08;
                MessageBox.Show("Anh khong duoc tim thay.", "Lỗi rồi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void upnv_reset_Click(object sender, EventArgs e)
        {
            upnv_mnv.Text = "";
            upnv_tnv.Text = "";
            upnv_cccd.Text = "";
            upnv_dc.Text = "";
            upnv_sdt.Text = "";
            upnv_ns.Text = "";
            upnv_gt_nam.Checked = false;
            upnv_pass.Text = "";
            upnv_pic.Text = "";
            MessageBox.Show("Reseted all Information !!!");
        }

       
        private void upnv_uploads_Click(object sender, EventArgs e)
        {
            string file = "";
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose Image(*.jpg;*.jpeg;*.tif;*.jfif;*.png)|*.jpg;*.jpeg;*.tif;*.jfif";
            if (op.ShowDialog() == DialogResult.OK)
            {
                upnv_pic.Image = new Bitmap(op.FileName);
                file = op.FileName;
                upnv_link.Text = file;
            }
        }

        private void upnv_save_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source = DESKTOP-1JAA108\\SQLEXPRESS; Initial Catalog = quanlykhachsan; Intergated Security = True");
            //con.Open();
            if (upnv_tnv.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên");
            }
            else if (upnv_cccd.Text == "")
            {
                MessageBox.Show("Vui lòng nhập cccd");
            }
            else if (upnv_dc.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ");
            }
            else if (upnv_sdt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
            }
            else if (upnv_pass.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Pass");
            }
            else
            {
                try
                {
                    string upmnv = upnv_mnv.Text;
                    string uptnv = upnv_tnv.Text;
                    string cccd_nv = upnv_cccd.Text;
                    string sdt_nv = upnv_sdt.Text;
                    string updcnv = upnv_dc.Text;
                    string uppassnv = upnv_pass.Text;
                    string nsnv = upnv_ns.Value.ToString("yyyy-MM-dd");

                    string gender = "";
                    if (upnv_gt_nam.Checked == true)
                    { gender = "Nam"; }
                    else if (upnv_gt_nu.Checked == true) { gender = "Nữ"; };
                    string upnvlink = upnv_link.Text;

                    if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string Sql = "UPDATE nhan_vien SET nv_ten = N'" + uptnv + "', nv_cccd = '" + cccd_nv + "', nv_diachi = N'" + updcnv + "', nv_sdt = '" + sdt_nv + "', nv_ngaysinh = '" + nsnv + "', nv_gioitinh = N'" + gender + "', nv_pasword = '" + uppassnv + "', nv_hinhanh = N'" + upnvlink + "' WHERE (nv_ma = '" + upmnv + "') ";
                        func.CapNhat(Sql, conn);
                        func.HienthiDulieuDG(upnv_data, "select * from nhan_vien", conn);
                        MessageBox.Show("Saved: " + upnv_tnv.Text + " sucessfully !!!");

                    }

                }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                

                
            }
        }

        private void upnv_xoa_Click(object sender, EventArgs e)
        {
            try
            {

                int CurrentIndex = upnv_data.CurrentCell.RowIndex;
                string del_column_nv = Convert.ToString(upnv_data.Rows[CurrentIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa?", "Verify delete it ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string deletedStr = "delete from nhan_vien where nv_ma='" + del_column_nv + "'";
                    string del_nv = "select * from nhan_vien";
                    SqlCommand deletedCmd = new SqlCommand(deletedStr, conn);
                    deletedCmd.CommandType = CommandType.Text;
                    deletedCmd.ExecuteNonQuery();
                    func.CapNhat(deletedStr, conn);
                    func.HienthiDulieuDG(upnv_data, del_nv, conn);

                    MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                    conn.Close();
                    upnv_mnv.Text = "";
                    upnv_tnv.Text = "";
                    upnv_cccd.Text = "";
                    upnv_dc.Text = "";
                    upnv_sdt.Text = "";
                    upnv_gt_nam.Checked = false;
                    upnv_gt_nu.Checked = false;
                    upnv_pass.Text = "";

                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void upnv_search_TextChanged(object sender, EventArgs e)
        {
            string keysr = upnv_search.Text;
            string sqlnv = "select * from nhan_vien where (nv_ma like '%" + keysr + "%' or nv_ten like N'%" + keysr + "%' OR nv_cccd like '%" + keysr + "%' OR nv_diachi like N'%" + keysr + "' OR nv_sdt like '%" + keysr + "')";
            func.HienthiDulieuDG(upnv_data, sqlnv, conn);
        }
    }
}