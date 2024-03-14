using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Net.WebRequestMethods;

namespace quanlykhachsan
{
    public partial class themhoadon : Form
    {
        public SqlConnection conn = new SqlConnection();
        function func = new function();
        public themhoadon()
        {
            InitializeComponent();
        }
        string sql;
        string chuoiketnoi = @"";
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        private void update_p_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void themhoadon_Load(object sender, EventArgs e)
        {

            func.HienthiDulieuDG(themhoadon_data, "select * from hoa_don", conn);

        }
        private void themhd_save_Click(object sender, EventArgs e)
        {
            
            /* if (themhd_slp.Text == "" && themhd_slp.Text == "")
             {
                 MessageBox.Show("Vui lòng nhập tên phòng đi, OK????", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 themhd_slp.Focus();
                 themhd_slp.Focus();

             }
             else
             {
                 try
                 {
                     string mhd = themhd_mahd.Text;
                     string ngaylap = themhd_nlap.Value.ToString("MM-dd-yyyy");
                     string mkhachhang = 
                     string tkh = themhd_tenkh.Text;
                     string cccd = themhd_cccd.Text;
                     string sdt = themhd_sdt.Text;
                     string lnv = themhd_lkh.Text;
                     string gtnv =  thd_gt.Text;
                     string nvlap = themhd_nvlap.Text;
                     //string lp = ttp_lp.SelectedValue.ToString();
                     string lnhanvien = themhd_lkh.SelectedValue.ToString();
                     string gtnhanvien = thd_gt.SelectedValue.ToString();


                     string sql_add = "INSERT INTO HOA_DON (hd_ma, hd_ngaylap, kh_ma, ma_phong, dv_ma, dv_thanhtien, httt_ma, nv_ma) VALUES ('" + mhd + "', '" + ngaylap + "', '" + tp + "', '" + ttp + "') ";

                     SqlCommand comd = new SqlCommand(sql_add, conn);
                     comd.ExecuteNonQuery();

                     func.HienthiDulieuDG(ttp_data, "SELECT p.ma_phong as MA_PHONG, lp.ma_loaiphong as MA_LOAI_PHONG, p.ten_phong as TEN_PHONG, lp.ten_loai_phong as LOAI_PHONG, lp.dongia as DON_GIA_PHONG, tt.ten_trangthai as TINH_TRANG from trang_thai tt, phong p, loai_phong lp where tt.ma_trangthai = p.ma_trangthai and p.ma_loaiphong = lp.ma_loaiphong", conn);


                     MessageBox.Show("Đã thêm phòng thành công..!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }
             }*/
         }
         public void HienThi()
         {
             SqlConnection connection = new SqlConnection(chuoiketnoi);
             // thuchien = new SqlCommand("SELECT * FROM HOADON )", connection);
             thuchien.Parameters.AddWithValue("@mahoadon", themhd_mahd.Text);
             thuchien.Parameters.AddWithValue("@ngaylap", themhd_nlap.MinDate);
             thuchien.Parameters.AddWithValue("@loaiphong", themhd_lp.Text);
             thuchien.Parameters.AddWithValue("@sophong", themhd_map.Text);
             thuchien.Parameters.AddWithValue("@dichvu", themhd_tendv.Text);
             thuchien.Parameters.AddWithValue("@soluongphong", themhd_slp.Text);
             thuchien.Parameters.AddWithValue("@dongiaphong", themhd_dgp.Text);
             thuchien.Parameters.AddWithValue("@dongiadichvu", themhd_dgdv.Text);
             thuchien.Parameters.AddWithValue("@thanhtien", themhd_thanhtien.Text);
             thuchien.Parameters.AddWithValue("@hinhthucthanhtoan", themhd_httt.Text);
             thuchien.Parameters.AddWithValue("@tenkhachhang", themhd_tenkh.Text);
             thuchien.Parameters.AddWithValue("@cccd", themhd_cccd.Text);
             thuchien.Parameters.AddWithValue("@sdt", themhd_sdt.Text);
             //thuchien.Parameters.AddWithValue("@loaikhachhang", themhd_lkh.Text);
             thuchien.Parameters.AddWithValue("@nhanvienlap", themhd_nvlap.Text);
             connection.Open();
             thuchien.ExecuteNonQuery();
             connection.Close();


             DataTable dataTable = new DataTable();
             SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM HOA_DON", connection);
             dataAdapter.Fill(dataTable);
             themhoadon_data.DataSource = dataTable;
            

        }

        private void themhd_reset_Click(object sender, EventArgs e)
        {
            themhd_mahd.Text = "";
            themhd_lp.Text = "";
            themhd_map.Text = "";
            themhd_tendv.Text = "";
            themhd_slp.Text = "";
            themhd_dgp.Text = "";
            themhd_dgdv.Text = "";
            themhd_thanhtien.Text = "";
            themhd_httt.Text = "";
            themhd_tenkh.Text = "";
            themhd_cccd.Text = "";
            themhd_sdt.Text = "";
            //themhd_lkh.Text = "";
            themhd_nvlap.Text = "";

        }

        

        

        private void themhd_thanhtien_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void themhoadon_Load_1(object sender, EventArgs e)
        {
            func.Ketnoi(conn);
            func.HienthiDulieuDG(themhoadon_data, "select * from hoa_don", conn);

            

            /*func.Ketnoi(conn);
            string sql_thd = "select hd.hd_ma, hd.hd_ngaylap, kh.KH_TEN, kh.kh_cccd, kh.kh_sdt, lkh.lkh_tenloai as LKH , p.ten_phong, lp.ten_loai_phong as LP, dv.dv_ten as DICH_VU, lp.dongia as DONGIA_PHONG, dv.dv_dongia as DG_DICHVU, hd.hd_thanhtien, httt.httt_ten, nv.nv_ten as TENNHANVIEN, kh.kh_gioitinh as GIOITINH " +
                "from hoa_don hd, khach_hang kh, loai_khach_hang lkh , phong p, loai_phong lp, dich_vu dv, hinh_thuc_thanh_toan httt, nhan_vien nv " +
                "where hd.kh_ma=kh.kh_ma and kh.lkh_ma=lkh.lkh_ma and hd.ma_phong = p.ma_phong and p.ma_loaiphong = lp.ma_loaiphong and hd.dv_ma = dv.dv_ma and hd.httt_ma = httt.httt_ma and hd.nv_ma = nv.nv_ma";
            func.HienthiDulieuDG(themhoadon_data, sql_thd, conn);*/
        }

        

        private void themhd_map_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (themhd_map.Text == "")
            {
                themhd_dgp.Text = "";
                themhd_lp.Text = "";
            }
            themhd_lp.Enabled = false;
            //"SELECT p.ma_phong, lp.ma_loaiphong, p.ten_phong, lp.ten_loai_phong, lp.dongia, tt.ten_trangthai, p.hinhanh from trang_thai tt, phong p, loai_phong lp where tt.ma_trangthai = p.ma_trangthai and p.ma_loaiphong = lp.ma_loaiphong"
            string themhd_mpllp = "SELECT ten_loai_phong FROM trang_thai tt, phong p, loai_phong lp where   p.ma_loaiphong = lp.ma_loaiphong and tt.ma_trangthai = p.ma_trangthai and p.ten_phong = '" + themhd_map.SelectedValue + "' ";
                
            func.LoadComb(themhd_lp, themhd_mpllp, conn, hienthi: "ten_loai_phong", giatri: "ten_loai_phong");
            




        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            
            themhd_lp.Text = "";
            themhd_map.Text = "";
            themhd_mahd.Text = "";
            themhd_slp.Text = "1";
            themhd_dgdv.Text = "0";
            themhd_dgp.Text = "0";
            themhd_thanhtien.Text = "";
            
            themhd_tenkh.Text = "";
            themhd_cccd.Text = "";
            themhd_sdt.Text = "";
            thd_gt.Text = "";
            themhd_nvlap.Text = "";
            //string sql_cbxp = "SELECT p.ma_phong, p.ten_phong, lp.ma_loaiphong, lp.ten_loai_phong, lp.dongia, p.ma_trangthai FROM trang_thai tt, phong p, loai_phong lp where   p.ma_loaiphong = lp.ma_loaiphong and tt.ma_trangthai = p.ma_trangthai and p.ma_trangthai = 'CP'";

            string sql_cbxp = "SELECT * FROM trang_thai tt, phong p, loai_phong lp where   p.ma_loaiphong = lp.ma_loaiphong and tt.ma_trangthai = p.ma_trangthai and p.ma_trangthai = 'PDD'  "; 
            func.LoadComb(themhd_map, sql_cbxp, conn, hienthi: "ma_phong", giatri: "ma_phong");
            func.LoadComb(themhd_lp, sql_cbxp, conn, hienthi: "ten_loai_phong", giatri: "ten_loai_phong");
            func.LoadComb(themhd_dgp, sql_cbxp, conn, hienthi: "dongia", giatri: "dongia");

            string load_dv = "select * from dich_vu";
            func.LoadComb(themhd_tendv, load_dv, conn, hienthi: "dv_ma", giatri: "dv_ma");
            func.LoadComb(themhd_dgdv, load_dv, conn, hienthi: "dv_dongia", giatri: "dv_dongia");

            string load_httt = "select * from hinh_thuc_thanh_toan";
            func.LoadComb(themhd_httt, load_httt, conn, hienthi: "httt_ma", giatri: "httt_ma");



            string sql_maxhd = "SELECT MAX(SUBSTRING(hd_ma,3,2)) FROM hoa_don";
            SqlCommand comd = new SqlCommand(sql_maxhd, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                int max = Convert.ToInt32(reader.GetValue(0).ToString()) + 1;
                themhd_mahd.Text = "hd" + max;
            }
            reader.Close();
        }

        private void themhoadon_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            themhd_mahd.Text = themhoadon_data.Rows[e.RowIndex].Cells[0].Value.ToString();
            themhd_nlap.Text = themhoadon_data.Rows[e.RowIndex].Cells[1].Value.ToString();
            themhd_tenkh.Text = themhoadon_data.Rows[e.RowIndex].Cells[2].Value.ToString();
            themhd_cccd.Text = themhoadon_data.Rows[e.RowIndex].Cells[3].Value.ToString();
            themhd_sdt.Text = themhoadon_data.Rows[e.RowIndex].Cells[4].Value.ToString();
            //themhd_lkh.Text = themhoadon_data.Rows[e.RowIndex].Cells[5].Value.ToString();
            themhd_map.Text = themhoadon_data.Rows[e.RowIndex].Cells[6].Value.ToString();
            themhd_lp.Text = themhoadon_data.Rows[e.RowIndex].Cells[7].Value.ToString();
            themhd_tendv.Text = themhoadon_data.Rows[e.RowIndex].Cells[8].Value.ToString();
            themhd_dgp.Text = themhoadon_data.Rows[e.RowIndex].Cells[9].Value.ToString();
            themhd_dgdv.Text = themhoadon_data.Rows[e.RowIndex].Cells[10].Value.ToString();
            themhd_thanhtien.Text = themhoadon_data.Rows[e.RowIndex].Cells[11].Value.ToString();
            themhd_httt.Text = themhoadon_data.Rows[e.RowIndex].Cells[12].Value.ToString();
            themhd_nvlap.Text = themhoadon_data.Rows[e.RowIndex].Cells[13].Value.ToString();
            thd_gt.Text = themhoadon_data.Rows[e.RowIndex].Cells[14].Value.ToString();
            


        }

        private void btn_tt_Click(object sender, EventArgs e)
        {
            string txtslp = themhd_slp.Text;
            int slp = Int32.Parse(themhd_slp.Text);
            //double tdgp;
            string txtdgp = themhd_dgp.Text;
            string txtdgdv = themhd_dgdv.Text;

            int a = Int32.Parse(txtdgp);
            int b = Int32.Parse(txtdgdv);
            

            if (a > 0 && b > 0 && slp > 0)
            {
                themhd_thanhtien.Text = "" + ((slp * a) + b);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void themhd_mahd_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void themhd_tendv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (themhd_map.Text == "")
            {
                themhd_dgp.Text = "";
                themhd_lp.Text = "";
            }
            themhd_lp.Enabled = false;
            //"SELECT p.ma_phong, lp.ma_loaiphong, p.ten_phong, lp.ten_loai_phong, lp.dongia, tt.ten_trangthai, p.hinhanh from trang_thai tt, phong p, loai_phong lp where tt.ma_trangthai = p.ma_trangthai and p.ma_loaiphong = lp.ma_loaiphong"
            string themhd_mpllp = "SELECT ten_loai_phong FROM trang_thai tt, phong p, loai_phong lp where   p.ma_loaiphong = lp.ma_loaiphong and tt.ma_trangthai = p.ma_trangthai and p.ten_phong = '" + themhd_map.SelectedValue + "' ";

            func.LoadComb(themhd_lp, themhd_mpllp, conn, hienthi: "ten_loai_phong", giatri: "ten_loai_phong");
            //func.LoadComb(themhd_lp, themhd_mpllp, conn, hienthi: "ten_loai_phong", giatri: "ten_loai_phong");



           
        }

        private void themhd_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void themhd_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Sql_lll = "SELECT hd.hd_ma, hd.hd_ngaylap, kh.KH_TEN, kh.kh_cccd, kh.kh_sdt, lkh.lkh_ten as LKH , p.ten_phong, lp.ten_loai_phong as LP, dv.dv_ten as DICH_VU, lp.dongia as DONGIA_PHONG, dv.dv_dongia as DG_DICHVU, hd.hd_thanhtien, httt.httt_ten, nv.nv_ten as TENNHANVIEN  FROM  hoa_don hd, khachhang kh, loaikhachhang lkh , phong p, loai_phong lp, dich_vu dv, hinh_thuc_thanh_toan httt, nhan_vien nv  WHERE hd.kh_cccd=kh.kh_cccd and kh.lkh_ma=lkh.lkh_ma and hd.ma_phong = p.ma_phong and p.ma_loaiphong = lp.ma_loaiphong and hd.dv_ma = dv.dv_ma and hd.httt_ma = httt.httt_ma and hd.nv_ma = nv.nv_ma AND (hd_ma LIKE '%" + themhd_search.Text + "%' OR hd.hd_ngaylap  LIKE '%" + themhd_search.Text + "%' OR kh.kh_ten LIKE '%" + themhd_search.Text + "%' OR kh.kh_cccd LIKE '%" + themhd_search.Text + "%' OR kh.kh_sdt LIKE '%" + themhd_search.Text + "%') ";

                func.HienthiDulieuDG(themhoadon_data, Sql_lll, conn);

            }
        }

        private void themhd_save_Click_1(object sender, EventArgs e)
        {
            string mhd = themhd_mahd.Text;
            DateTime ngaylap = DateTime.Now;
            //string ngaylap = themhd_nlap.Value.ToString("MM-dd-yyyy");
            string tkh = themhd_tenkh.Text;
            string kh_cccd = themhd_cccd.Text;
            string dv_ten = themhd_tendv.Text;
            string ma_phong = themhd_map.Text;
            string hd_thanhtien = themhd_thanhtien.Text;
            string httt_ma = themhd_httt.Text;
            string nv_ma = themhd_nvlap.Text;
            string gtkh = thd_gt.Text;
            string sdtkh = themhd_sdt.Text;

            string slcccd = "select kh_cccd from khachhang";
            if (kh_cccd == null)
            {
                string sqladdkh = "insert into khachhang ( lkh_ma, kh_ten, kh_cccd, kh_gioitinh, kh_sdt) VALUES (2, '" + tkh + "', '" + kh_cccd + "', '" + gtkh + "', '" + sdtkh + "' )";
                SqlCommand cd = new SqlCommand(sqladdkh, conn);
                cd.ExecuteNonQuery();
                
            }else
            {
                string sql = "insert into hoa_don (hd_ma, hd_ngaylap, kh_cccd , ma_phong, dv_ma, hd_thanhtien, httt_ma, nv_ma) VALUES ('" + mhd + "', '" + ngaylap + "', '" + kh_cccd + "', '" + ma_phong + "', '" + dv_ten + "', '" + hd_thanhtien + "', '" + httt_ma + "', '" + nv_ma + "') ";
                SqlCommand cd = new SqlCommand(sql, conn);
                string sql_upp = "update phong set ma_trangthai = 'CP' where (ma_phong = '" + ma_phong + "')";
                func.CapNhat(sql_upp, conn);
                
                cd.ExecuteNonQuery();
                
            }
            
            func.HienthiDulieuDG(themhoadon_data, "select * from hoa_don", conn);
        }

        private void themhd_slp_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }

        private void themhd_dgp_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }

        private void themhd_dgdv_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }

        private void themhd_thanhtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }

        private void themhd_cccd_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }

        private void themhd_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }

        private void themhd_lkh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void themhd_dgp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void themhd_lp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}