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
    public partial class Themphong : Form
    {
        public SqlConnection conn = new SqlConnection();
        function func = new function();
        public Themphong()
        {
            InitializeComponent();
        }

        private void add_p_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void themp_update_Click(object sender, EventArgs e)
        {
            updatephong forupp = new updatephong();
            forupp.Show();
            this.Close();
        }

        private void tp_search_TextChanged(object sender, EventArgs e)
        {
            string keysearch = tp_search.Text;
            string search = "SELECT p.ma_phong, p.ten_phong, lp.ten_loai_phong, tt.ten_trangthai FROM trang_thai tt, phong p, loai_phong lp where   p.ma_loaiphong = lp.ma_loaiphong and tt.ma_trangthai = p.ma_trangthai and ( p.ten_phong like '%" + keysearch + "%' OR lp.ten_loai_phong like '%" + keysearch + "%' OR tt.ten_trangthai like '%" + keysearch + "%' )";
            func.HienthiDulieuDG(themphong_data, search, conn);
        }

        private void Themphong_Load(object sender, EventArgs e)
        {
            func.Ketnoi(conn);

            func.HienthiDulieuDG(themphong_data, "SELECT p.ma_phong, p.ten_phong, lp.ten_loai_phong, tt.ten_trangthai from trang_thai tt, phong p, loai_phong lp where tt.ma_trangthai = p.ma_trangthai and p.ma_loaiphong = lp.ma_loaiphong", conn);
        }

        private void themphong_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            them_mp.Enabled = false;
            
            them_mp.Text = themphong_data.Rows[e.RowIndex].Cells[0].Value.ToString();
            them_tenphong.Text = themphong_data.Rows[e.RowIndex].Cells[1].Value.ToString();
            //tb_ten_kh.Text = dgv_khachhang.Rows[i].Cells[2].Value.ToString();
           // tb_cccd_kh.Text = dgv_khachhang.Rows[i].Cells[3].Value.ToString();
           // ngaysinh_kh.Text = dgv_khachhang.Rows[i].Cells[4].Value.ToString();
           // cb_gioitinh_kh.Text = dgv_khachhang.Rows[i].Cells[5].Value.ToString();
            
        }
    }
}
