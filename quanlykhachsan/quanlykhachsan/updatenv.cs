using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "\"\\\\Mac\\Home\\Downloads\\quanlykhachsan (1)\\img\\hinhanhnhanvien1.jpg\"";
            openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.jpeg, *.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                upnv_pic.Image = Image.FromFile(filePath);
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

                    if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string Sql = "UPDATE nhan_vien SET nv_ten = N'" + uptnv + "', nv_cccd = '" + cccd_nv + "', nv_diachi = N'" + updcnv + "', nv_sdt = '" + sdt_nv + "', nv_ngaysinh = '" + nsnv + "', nv_gioitinh = N'" + gender + "', nv_pasword = '" + uppassnv + "' WHERE (nv_ma = '" + upmnv + "') ";
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
            int currentnv = upnv_data.CurrentCell.RowIndex;
            string ID = Convert.ToString(upnv_data.Rows[currentnv].Cells[0].Value.ToString());
            DialogResult result = MessageBox.Show("Do you want to delete this customer?", "Verify delete it ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                string sql = "DELETE FROM nhan_vien WHERE nv_ma = '" + ID + "' ";
                string sql_s = "select * from nhan_vien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                
                func.CapNhat(sql, conn);
                func.HienthiDulieuDG(upnv_data, sql_s, conn);
                MessageBox.Show("Deleted Sucessfully!!!");

            }
        }
    }
}