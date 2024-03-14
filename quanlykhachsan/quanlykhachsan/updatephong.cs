using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace quanlykhachsan
{
    public partial class updatephong : Form
    {
        //sql
        public SqlConnection conn = new SqlConnection();
        //ham
        function func = new function();

        public updatephong()
        {
            InitializeComponent();
        }

        private void update_p_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_mp_TextChanged(object sender, EventArgs e)
        {

        }

        private void updatep_reset_Click(object sender, EventArgs e)
        {
            upp_mp.Text = "";
            upp_malp.Text = "";
            upp_lp.Text = "";
            upp_tenphong.Text = "";
            upp_dg.Text = "";
            upp_ttrang.Text = "";
            upp_picture.Text = "";
        }

        private void updatep_save_Click(object sender, EventArgs e)
        {
            if (upp_tenphong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin đi, OK????", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                upp_tenphong.Focus();

            }
            else
            {
                try
                {
                    string ump = upp_mp.Text;
                    string umlp = upp_malp.SelectedValue.ToString();
                    string utp = upp_tenphong.Text;
                    //string lp = ttp_lp.SelectedValue.ToString();
                    //int udgp = Convert.ToInt32(upp_dg.Text);
                    string uttp = upp_ttrang.SelectedValue.ToString();

                    string sql_update = "UPDATE phong SET ma_loaiphong = '" + umlp + "', ten_phong= '" + utp + "', ma_trangthai = '" + uttp + "' where (ma_phong = '" + ump + "') " ;
                    
                    func.CapNhat(sql_update, conn);
                    func.HienthiDulieuDG(upp_data, "SELECT p.ma_phong, lp.ma_loaiphong, p.ten_phong, lp.ten_loai_phong, lp.dongia, tt.ten_trangthai from trang_thai tt, phong p, loai_phong lp where tt.ma_trangthai = p.ma_trangthai and p.ma_loaiphong = lp.ma_loaiphong", conn);

                    MessageBox.Show("Đã UPDATE phòng thành công..!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void uploads_tp_Click(object sender, EventArgs e)
        {

        }

        private void updatephong_Load(object sender, EventArgs e)
        {
            func.Ketnoi(conn);

            func.HienthiDulieuDG(upp_data, "SELECT p.ma_phong, lp.ma_loaiphong, p.ten_phong, lp.ten_loai_phong, lp.dongia, tt.ten_trangthai from trang_thai tt, phong p, loai_phong lp where tt.ma_trangthai = p.ma_trangthai and p.ma_loaiphong = lp.ma_loaiphong", conn);

            //load combobox
            //load loai phong
            string sql_cbx = "SELECT * FROM loai_phong ";
            func.LoadComb(upp_malp, sql_cbx, conn, hienthi: "ma_loaiphong", giatri: "ma_loaiphong");
            func.LoadComb(upp_lp, sql_cbx, conn, hienthi: "ten_loai_phong", giatri: "ten_loai_phong");
            func.LoadComb(upp_dg, sql_cbx, conn, hienthi: "dongia", giatri: "dongia");



            //load trang thai phong
            string sql_lttp = "SELECT * FROM trang_thai";
            func.LoadComb(upp_ttrang, sql_lttp, conn, hienthi: "ma_trangthai", giatri: "ma_trangthai");
        }

        private void upp_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            upp_mp.Text = upp_data.Rows[e.RowIndex].Cells[0].Value.ToString();
            upp_malp.Text = upp_data.Rows[e.RowIndex].Cells[1].Value.ToString();
            upp_tenphong.Text = upp_data.Rows[e.RowIndex].Cells[2].Value.ToString();
            upp_lp.Text = upp_data.Rows[e.RowIndex].Cells[3].Value.ToString();
            upp_dg.Text = upp_data.Rows[e.RowIndex].Cells[4].Value.ToString();
            upp_ttrang.Text = upp_data.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void updatep_search_TextChanged(object sender, EventArgs e)
        {
            string keysearch = updatep_search.Text;
            string search = "SELECT p.ma_phong, p.ten_phong, lp.ma_loaiphong, lp.ten_loai_phong, lp.dongia, tt.ten_trangthai FROM trang_thai tt, phong p, loai_phong lp where   p.ma_loaiphong = lp.ma_loaiphong and tt.ma_trangthai = p.ma_trangthai and ( p.ten_phong like '%" + keysearch + "%' OR lp.ten_loai_phong like '%" + keysearch + "%' OR tt.ten_trangthai like '%" + keysearch + "%' )";
            func.HienthiDulieuDG(upp_data, search, conn);
        }

        private void upp_malp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (upp_malp.Text == "")
            {
                upp_lp.Text = "";
                upp_dg.Text = "";
            }
            //string cbxmlp = "select ten_loai_phong from loai_phong where ma_loaiphong = '" + upp_malp.SelectedValue + "' ";
            //func.LoadComb(upp_lp, cbxlp, conn, hienthi: "ten_loai_phong", giatri: "ten_loai_phong");

            string cbxlp = "select ten_loai_phong from loai_phong where ma_loaiphong = '" + upp_malp.SelectedValue + "' ";
            func.LoadComb(upp_lp, cbxlp, conn, hienthi: "ten_loai_phong", giatri: "ten_loai_phong");

            string cbxdg = "select dongia from loai_phong where ma_loaiphong = '" + upp_malp.SelectedValue + "' ";
            func.LoadComb(upp_dg, cbxdg, conn, hienthi: "dongia", giatri: "dongia");
        }

        private void upp_dg_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }
    }
}
