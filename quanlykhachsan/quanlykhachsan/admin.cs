using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Runtime.Remoting.Messaging;
using System.Net.NetworkInformation;

namespace quanlykhachsan
{

    public partial class admin : Form

    {
        SqlConnection connection;
        SqlCommand command;
        string str = "SERVER = DESKTOP-1JAA108\\SQLEXPRESS; database = quanlykhachsan; integrated Security = True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void load_data()
        {
            command = connection.CreateCommand();
            connection = new SqlConnection(str);
            connection.Open();
            command.CommandText = "SELECT * FROM khachhang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_khachhang.DataSource = table;
        }



        string ma_phong = "";
        //kn sql
        public SqlConnection conn = new SqlConnection();
        function func = new function();

        //load anh
        public string auto_link = AppDomain.CurrentDomain.BaseDirectory + "\\img\\";

        
        
        public admin()
        {
            InitializeComponent();
        }

        private void quảnLýNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
           

        }

       //------------------------THONG TIN PHONG------------------------------------------
        //button tabpage
        private void btn_ttphong_Click(object sender, EventArgs e)
        {
            //chuyen tab page
            view.SelectedTab = phong;
            phong.Focus();

            //hien thi data
            func.HienthiDulieuDG(ttp_data, "SELECT p.ma_phong as MA_PHONG, lp.ma_loaiphong as MA_LOAI_PHONG, p.ten_phong as TEN_PHONG, lp.ten_loai_phong as LOAI_PHONG, lp.dongia as DON_GIA_PHONG, tt.ten_trangthai as TINH_TRANG, p.hinhanh as HINH_ANH from trang_thai tt, phong p, loai_phong lp where tt.ma_trangthai = p.ma_trangthai and p.ma_loaiphong = lp.ma_loaiphong", conn);



        }

        private void btn_lhd_Click(object sender, EventArgs e)
        {
            view.SelectedTab = hoadon;
            hoadon.Focus();

            string sql_loadhd = "select * from hoa_don hd, khachhang kh, phong p, dich_vu dv, hinh_thuc_thanh_toan httt, nhan_vien nv where hd.kh_ma = kh.kh_ma and hd.ma_phong = p.ma_phong and hd.dv_ma = dv.dv_ma and hd.httt_ma = httt.httt_ma and hd.nv_ma = nv.nv_ma";
            //func.HienthiDulieuDG(lhp_data, )

            //hien thi data
            string sql_qldt = "select hd.hd_ma, hd.hd_ngaylap, kh.KH_TEN, kh.kh_cccd, kh.kh_sdt, lkh.lkh_ten as LKH , p.ten_phong, lp.ten_loai_phong as LP, dv.dv_ten as DICH_VU, lp.dongia as DONGIA_PHONG, dv.dv_dongia as DG_DICHVU, hd.hd_thanhtien, httt.httt_ten, nv.nv_ten as TENNHANVIEN " +
                "from hoa_don hd, khachhang kh, loaikhachhang lkh , phong p, loai_phong lp, dich_vu dv, hinh_thuc_thanh_toan httt, nhan_vien nv " +
                "where hd.kh_ma=kh.kh_ma and kh.lkh_ma=lkh.lkh_ma and hd.ma_phong = p.ma_phong and p.ma_loaiphong = lp.ma_loaiphong and hd.dv_ma = dv.dv_ma and hd.httt_ma = httt.httt_ma and hd.nv_ma = nv.nv_ma";
            func.HienthiDulieuDG(lhp_data, sql_qldt, conn);
        }


        private void btn_pdp_Click(object sender, EventArgs e)
        {
            view.SelectedTab = phieudat;
            phieudat.Focus();
        }

        private void btn_qlns_Click(object sender, EventArgs e)
        {
            view.SelectedTab = nhansu;
            nhansu.Focus();

            func.HienthiDulieuDG(nv_data, "select NV_MA, NV_TEN, NV_CCCD, NV_SDT, NV_NGAYSINH, NV_GIOITINH, NV_DIACHI, NV_HINHANH from nhan_vien", conn);



        }

        private void btn_qldt_Click(object sender, EventArgs e)
        {
            view.SelectedTab = doanhthu;
            doanhthu.Focus();

            //load data hoa don

            string sql_qldt = "select hd.hd_ma,hd.hd_ngaylap, kh.KH_TEN,kh.kh_cccd, kh.kh_sdt, lkh.lkh_ten as LKH , p.ten_phong, lp.ten_loai_phong as LP, dv.dv_ten as DICH_VU, lp.dongia as DONGIA_PHONG, dv.dv_dongia as DG_DICHVU, hd.hd_thanhtien, httt.httt_ten, nv.nv_ten as TENNHANVIEN from hoa_don hd, khachhang kh, loaikhachhang lkh , phong p, loai_phong lp, dich_vu dv, hinh_thuc_thanh_toan httt, nhan_vien nv WHERE hd.kh_ma=kh.kh_ma and kh.lkh_ma=lkh.lkh_ma and hd.ma_phong = p.ma_phong and p.ma_loaiphong = lp.ma_loaiphong and hd.dv_ma = dv.dv_ma and hd.httt_ma = httt.httt_ma and hd.nv_ma = nv.nv_ma";

            func.HienthiDulieuDG(qldt_data, sql_qldt, conn);

          
        }
        private void qldt_tdt_Click(object sender, EventArgs e)
        {
            string sql_tdt = "SELECT sum(hd_thanhtien) as TONG_DOANH_THU from hoa_don ";
            func.HienthiDulieuDG(qldt_data, sql_tdt, conn);

            //string tdt_time = "";
        }

        private void btn_qlkh_Click(object sender, EventArgs e)
        {
            view.SelectedTab = khachhang;
            khachhang.Focus();
        }

        private void btn_qldv_Click(object sender, EventArgs e)
        {
            view.SelectedTab = dichvu;
            dichvu.Focus();

            func.HienthiDulieuDG(qldv_data, "select * FROM dich_vu", conn);
        }

        

        private void ttp_add_Click(object sender, EventArgs e)
        {
            // Themphong formadd = new Themphong(); // khởi tạo form 
            //formadd.Show(); // hiển thị form 

            
            ttp_malp.Text = "";
            ttp_tenphong.Text = "";
            ttp_lp.Text = "";
            ttp_dg.Text = "";

            ttp_lp.Enabled = false;
            ttp_dg.Enabled = false;
            ttp_malp.Enabled = true;
            ttp_tenphong.Enabled = true;
            ttp_save.Enabled = true;
           
            //sql tim den max ma phong
            string sql_maxttp = "SELECT MAX(SUBSTRING(ma_phong,3,3)) FROM PHONG";
            SqlCommand comd = new SqlCommand(sql_maxttp, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                int max =Convert.ToInt32(reader.GetValue(0).ToString()) +1;
                ttp_mp.Text = "MP00" + max;
            }
            reader.Close();

           //load combobox
           //load loai phong
            string sql_cbx = "SELECT * FROM loai_phong ";
            func.LoadComb(ttp_malp, sql_cbx, conn, hienthi: "ma_loaiphong", giatri: "ma_loaiphong");
            func.LoadComb(ttp_lp, sql_cbx, conn, hienthi: "ten_loai_phong", giatri: "ten_loai_phong");
            func.LoadComb(ttp_dg, sql_cbx, conn, hienthi: "dongia", giatri: "dongia");



            //load trang thai phong
            string sql_lttp = "SELECT * FROM trang_thai";
            func.LoadComb(ttp_ttrang, sql_lttp, conn, hienthi: "ma_trangthai", giatri: "ma_trangthai");


            
        }

        

        private void ttp_save_Click(object sender, EventArgs e)
        {
            if (ttp_tenphong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên phòng đi, OK????", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ttp_tenphong.Focus();
                
            }else if(ttp_picture.Image == null)
            {
                MessageBox.Show("Vui lòng chọn hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ttp_picture.Focus();
            }
            else
            {
                try
                {
                    
                    string mp = ttp_mp.Text;
                    string mlp = ttp_malp.Text;
                    string tp = ttp_tenphong.Text;
                    //string lp = ttp_lp.SelectedValue.ToString();
                    float dgp = Convert.ToInt32(ttp_dg.Text);
                    string ttp = ttp_ttrang.SelectedValue.ToString();
                    string linkanh = ttp_linkanh.Text;


                    string sql_add = "INSERT INTO PHONG (ma_phong, ma_loaiphong, ten_phong, ma_trangthai, p.hinhanh) VALUES ('" + mp + "', '" + mlp + "', '" + tp + "', '" + ttp + "', N'" + linkanh + "') ";

                    SqlCommand comd = new SqlCommand(sql_add, conn);
                    comd.ExecuteNonQuery();
                    conn.Close();
                    
                    func.HienthiDulieuDG(ttp_data, "SELECT p.ma_phong as MA_PHONG, lp.ma_loaiphong as MA_LOAI_PHONG, p.ten_phong as TEN_PHONG, lp.ten_loai_phong as LOAI_PHONG, lp.dongia as DON_GIA_PHONG, tt.ten_trangthai as TINH_TRANG , p.hinhanh FROM trang_thai tt, phong p, loai_phong lp where tt.ma_trangthai = p.ma_trangthai and p.ma_loaiphong = lp.ma_loaiphong", conn);

                    
                    MessageBox.Show("Đã thêm phòng thành công..!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
           
        }

        private void ttp_update_Click(object sender, EventArgs e)
        {
            updatephong upp = new updatephong();
            upp.Show();
        }

        private void ttp_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                
                int CurrentIndex = ttp_data.CurrentCell.RowIndex;
                string del_column = Convert.ToString(ttp_data.Rows[CurrentIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa?", "Verify delete it ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string deletedStr = "delete from phong where ma_phong='" + del_column + "'";
                    string del_p = "SELECT p.ma_phong as MA_PHONG, lp.ma_loaiphong as MA_LOAI_PHONG, p.ten_phong as TEN_PHONG, lp.ten_loai_phong as LOAI_PHONG, lp.dongia as DON_GIA_PHONG, tt.ten_trangthai as TINH_TRANG , p.hinhanh FROM trang_thai tt, phong p, loai_phong lp where tt.ma_trangthai = p.ma_trangthai and p.ma_loaiphong = lp.ma_loaiphong";
                    SqlCommand deletedCmd = new SqlCommand(deletedStr, conn);
                    deletedCmd.CommandType = CommandType.Text;
                    deletedCmd.ExecuteNonQuery();
                    func.CapNhat(deletedStr, conn);
                    func.HienthiDulieuDG(ttp_data, del_p, conn);
                    MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                    conn.Close();

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
        private void ttp_reset_Click(object sender, EventArgs e)
        {
            ttp_mp.Text = "";
            ttp_malp.Text = "";
            ttp_tenphong.Text = "";
            ttp_lp.Text = "";
            ttp_dg.Text = "";
            ttp_ttrang.Text = "";
            ttp_picture.Text = "";
        }

        private void lhd_add_Click(object sender, EventArgs e)
        {
            themhoadon formthemhd = new themhoadon();
            formthemhd.Show();
        }

        private void pdp_add_Click(object sender, EventArgs e)
        {
            themphieudat formphieudat = new themphieudat();
            formphieudat.Show();
        }

        private void nv_add_Click(object sender, EventArgs e)
        {
            themnv formnv = new themnv();
            formnv.Show();
        }
        private void nv_update_Click(object sender, EventArgs e)
        {
            updatenv formupnv = new updatenv();
            formupnv.Show();
        }
        private void ttp_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ttp_mp.Text = ttp_data.Rows[e.RowIndex].Cells[0].Value.ToString();
            ttp_malp.Text = ttp_data.Rows[e.RowIndex].Cells[1].Value.ToString();
            ttp_tenphong.Text = ttp_data.Rows[e.RowIndex].Cells[2].Value.ToString();
            ttp_lp.Text = ttp_data.Rows[e.RowIndex].Cells[3].Value.ToString();
            ttp_dg.Text = ttp_data.Rows[e.RowIndex].Cells[4].Value.ToString();
            ttp_ttrang.Text = ttp_data.Rows[e.RowIndex].Cells[5].Value.ToString();
            //ttp_linkanh.Text = ttp_data.Rows[e.RowIndex].Cells[6].Value.ToString();
            string path = ttp_data.Rows[e.RowIndex].Cells[6].Value.ToString();
            try
            {
                ttp_picture.Image = Image.FromFile(path);
            }
            catch (FileNotFoundException)
            {
                // Handle the exception by displaying a default image or showing an error message
                //pictureBox1.Image = Properties.Resources.DefaultImage;
                //  pictureBox1.Image = Properties.Resources.chi08;
                MessageBox.Show("Anh khong duoc tim thay.", "Lỗi rồi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ttp_malp.Enabled = false;
            ttp_tenphong.Enabled = false;
            ttp_ttrang.Enabled = false;
            ttp_uploads.Enabled = false;
            
            ttp_save.Enabled = false;
        }

        private void phong_Click(object sender, EventArgs e)
        {
            
        }

        private void admin_Load(object sender, EventArgs e)
        {
            //load du lieu phong
            func.Ketnoi(conn);
            func.HienthiDulieuDG(ttp_data, "SELECT p.ma_phong as MA_PHONG, lp.ma_loaiphong as MA_LOAI_PHONG, p.ten_phong as TEN_PHONG, lp.ten_loai_phong as LOAI_PHONG, lp.dongia as DON_GIA_PHONG, tt.ten_trangthai as TINH_TRANG, p.hinhanh as HINH_ANH from trang_thai tt, phong p, loai_phong lp where tt.ma_trangthai = p.ma_trangthai and p.ma_loaiphong = lp.ma_loaiphong", conn);
            //string path = "D:\\Workspace\\bg_login.png";
            //ttp_picture.Image = new Bitmap(path);

            //func.HienthiDulieuDG(dgv_khachhang, "SELECT * from khachhang", conn);
            load_khachhang();
            load_phieudatphong();
            //func.HienthiDulieuDG(dgv_phieudatphong, "SELECT * from phieudatphong", conn);
            


        }

        private void ttp_search_TextChanged(object sender, EventArgs e)
        {
           string keysearch = ttp_search.Text;
            string search = "SELECT p.ma_phong as MA_PHONG, lp.ma_loaiphong as MA_LOAI_PHONG, p.ten_phong as TEN_PHONG, lp.ten_loai_phong as LOAI_PHONG, lp.dongia as DON_GIA_PHONG, tt.ten_trangthai as TINH_TRANG FROM trang_thai tt, phong p, loai_phong lp where   p.ma_loaiphong = lp.ma_loaiphong and tt.ma_trangthai = p.ma_trangthai and ( p.ten_phong like '%" + keysearch + "%' OR lp.ten_loai_phong like '%" + keysearch + "%' OR tt.ten_trangthai like '%" + keysearch + "%' )";
            func.HienthiDulieuDG(ttp_data, search, conn);
        }

        

        private void ttp_malp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ttp_malp.Text == "")
            {
                ttp_lp.Text = "";
                ttp_dg.Text = "";
            }
            string cbxlp = "select ten_loai_phong from loai_phong where ma_loaiphong = '" + ttp_malp.SelectedValue + "' ";
            func.LoadComb(ttp_lp, cbxlp, conn, hienthi: "ten_loai_phong", giatri: "ten_loai_phong");

            string cbxdg = "select dongia from loai_phong where ma_loaiphong = '" + ttp_malp.SelectedValue + "' ";
            func.LoadComb(ttp_dg, cbxdg, conn, hienthi: "dongia", giatri: "dongia");
        }

        private void doanhthu_Click(object sender, EventArgs e)
        {
            
        }

        private void qlgt_tdt_TextChanged(object sender, EventArgs e)
        {

        }

        


        private void qldt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string keysearchqldt = qldt_search.Text;
            string sql_searchqldt = "select hd.hd_ma, hd.hd_ngaylap, kh.KH_TEN, kh.kh_cccd, kh.kh_sdt, lkh.lkh_ten , p.ten_phong, lp.ten_loai_phong, dv.dv_ten , lp.dongia , dv.dv_dongia, hd.hd_thanhtien, httt.httt_ten, nv.nv_ten " +
            "from hoa_don hd, khachhang kh, loaikhachhang lkh , phong p, loai_phong lp, dich_vu dv, hinh_thuc_thanh_toan httt, nhan_vien nv " +
            "where hd.kh_ma=kh.kh_ma and kh.lkh_ma=lkh.lkh_ma and hd.ma_phong = p.ma_phong and p.ma_loaiphong = lp.ma_loaiphong and hd.dv_ma = dv.dv_ma and hd.httt_ma = httt.httt_ma and hd.nv_ma = nv.nv_ma " +
            "and ( kh.kh_ten like '%" + keysearchqldt + "%' OR kh.kh_cccd like '%" + keysearchqldt + "%' OR kh.kh_sdt like '%" + keysearchqldt + "%' OR lkh.lkh_ten like '%" + keysearchqldt + "%' OR p.ten_phong like '%" + keysearchqldt + "%' OR lp.ten_loai_phong like '%" + keysearchqldt + "%' OR dv.dv_ten like '%" + keysearchqldt + "%' OR dv.dv_dongia like '%" + keysearchqldt + "%' OR httt.httt_ten like '%" + keysearchqldt + "%' OR nv.nv_ten like '%" + keysearchqldt + "%' )";
            func.HienthiDulieuDG(qldt_data, sql_searchqldt, conn);
            }
        }

        private void nv_xoa_Click(object sender, EventArgs e)
        {
            try
            {

                int CurrentIndex = nv_data.CurrentCell.RowIndex;
                string del_column_nv = Convert.ToString(nv_data.Rows[CurrentIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa?", "Verify delete it ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    string deletedStr = "delete from nhan_vien where nv_ma='" + del_column_nv + "'";
                    string del_nv = "select NV_MA, NV_TEN, NV_CCCD, NV_SDT, NV_NGAYSINH, NV_GIOITINH, NV_DIACHI, NV_HINHANH from nhan_vien";
                    SqlCommand deletedCmd = new SqlCommand(deletedStr, conn);
                    deletedCmd.CommandType = CommandType.Text;
                    deletedCmd.ExecuteNonQuery();
                    func.CapNhat(deletedStr, conn);
                    func.HienthiDulieuDG(nv_data, del_nv, conn);
                    MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                    conn.Close();

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void qldt_thuchien_Click(object sender, EventArgs e)
        {
            string tungay = qldt_timefrom.Value.ToString("MM-dd-yyyy");
            string denngay = qldt_timeto.Value.ToString("MM-dd-yyyy");
            string sql_tttime = "select sum(hd_thanhtien) as TONGDOANHTHU from hoa_don where hd_ngaylap between '" + tungay +"' and '" +denngay +"'";
            func.HienthiDulieuDG(qldt_data, sql_tttime, conn);

        }

        private void qldt_lietke_Click(object sender, EventArgs e)
        {
            string tungay = qldt_timefrom.Value.ToString("MM-dd-yyyy");
            string denngay = qldt_timeto.Value.ToString("MM-dd-yyyy");
            string sql_lietke = "select hd.hd_ma, hd.hd_ngaylap, kh.KH_TEN, kh.kh_cccd, kh.kh_sdt, lkh.lkh_ten as LKH , p.ten_phong, lp.ten_loai_phong as LP, dv.dv_ten as DICH_VU, lp.dongia as DONGIA_PHONG, dv.dv_dongia as DG_DICHVU, hd.hd_thanhtien as THANHTIEN, httt.httt_ten, nv.nv_ten as TENNHANVIEN from hoa_don hd, khachhang kh, loaikhachhang lkh , phong p, loai_phong lp, dich_vu dv, hinh_thuc_thanh_toan httt, nhan_vien nv where hd.kh_ma=kh.kh_ma and kh.lkh_ma=lkh.lkh_ma and hd.ma_phong = p.ma_phong and p.ma_loaiphong = lp.ma_loaiphong and hd.dv_ma = dv.dv_ma and hd.httt_ma = httt.httt_ma and hd.nv_ma = nv.nv_ma and hd.hd_ngaylap between '" + tungay + "' and '" + denngay + "' ";
            func.HienthiDulieuDG(qldt_data, sql_lietke, conn);
        }

        

        private void lhd_search_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void qldt_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void qldv_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            qldv_ma.Text = qldv_data.Rows[e.RowIndex].Cells[0].Value.ToString();
            qldv_ten.Text = qldv_data.Rows[e.RowIndex].Cells[1].Value.ToString();
            qldv_dongia.Text = qldv_data.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }

        

        private void qldv_search_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string txdv = qldv_search.Text;
                string qldv = "select * from dich_vu where (dv_ma like '%" + txdv + "' OR dv_ten like '%" + txdv + "' OR dv_dongia like '%" + txdv + "' )";
                func.HienthiDulieuDG(qldv_data, qldv, conn);
            }
        }

        private void qldv_add_Click(object sender, EventArgs e)
        {
            qldv_ma.Text = "";
            qldv_ten.Text = "";
            qldv_dongia.Text = "";

            string sql_maxdv = "SELECT MAX(SUBSTRING(dv_ma,3,2)) FROM dich_vu";
            SqlCommand comd = new SqlCommand(sql_maxdv, conn);
            SqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                int max = Convert.ToInt32(reader.GetValue(0).ToString()) + 1;
                qldv_ma.Text = "dv" + max;
            }
            reader.Close();

        }

        private void qldv_xoa_Click(object sender, EventArgs e)
        {
            try
            {

                int CurrentIndex = qldv_data.CurrentCell.RowIndex;
                string del_column = Convert.ToString(qldv_data.Rows[CurrentIndex].Cells[0].Value.ToString()) ;
                string deletedStr = "delete from dich_vu where dv_ma = '" + del_column + "'";
                string del_p = "SELECT * from dich_vu";
                SqlCommand deletedCmd = new SqlCommand(deletedStr, conn);
                deletedCmd.CommandType = CommandType.Text;
                deletedCmd.ExecuteNonQuery();
                func.CapNhat(deletedStr, conn);
                func.HienthiDulieuDG(qldv_data, del_p, conn);
                MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void qldv_save_Click(object sender, EventArgs e)
        {
            if (qldv_ten.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ đi, OK????", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                qldv_ten.Focus();

            }
            else
            {
                try
                {
                    string mdv = qldv_ma.Text;
                    string tdv = qldv_ten.Text;
                    int dgdv = Convert.ToInt32(qldv_dongia.Text);
                    

                    string sql_adddv = "INSERT INTO dich_vu (dv_ma, dv_ten, dv_dongia) VALUES ('" + mdv + "', N'" + tdv + "', '" + dgdv + "') ";

                    func.CapNhat(sql_adddv, conn);
                    func.HienthiDulieuDG(qldv_data, "SELECT * from dich_vu", conn);

                    MessageBox.Show("Đã thêm dịch vụ thành công..!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public void showImage(PictureBox PictureBox1, string path)
        {
            string file = "";
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose Image(*.jpg;*.jpeg;*.tif;*.jfif)|*.jpg;*.jpeg;*.tif;*.jfif";
            if (op.ShowDialog() == DialogResult.OK)
            {
                ttp_picture.Image = new Bitmap(op.FileName);
                file = op.FileName;
                ttp_linkanh.Text = file;
            }
        }
        private void ttp_uploads_Click_1(object sender, EventArgs e)
        {
            showImage(ttp_picture, ttp_linkanh.Text);

        }

        private void lhp_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void lhd_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Sql_lll = "SELECT hd.hd_ma, hd.hd_ngaylap, kh.KH_TEN, kh.kh_cccd, kh.kh_sdt, lkh.lkh_ten as LKH , p.ten_phong, lp.ten_loai_phong as LP, dv.dv_ten as DICH_VU, lp.dongia as DONGIA_PHONG, dv.dv_dongia as DG_DICHVU, hd.hd_thanhtien, httt.httt_ten, nv.nv_ten as TENNHANVIEN  FROM  hoa_don hd, khachhang kh, loaikhachhang lkh , phong p, loai_phong lp, dich_vu dv, hinh_thuc_thanh_toan httt, nhan_vien nv  WHERE hd.kh_ma=kh.kh_ma and kh.lkh_ma=lkh.lkh_ma and hd.ma_phong = p.ma_phong and p.ma_loaiphong = lp.ma_loaiphong and hd.dv_ma = dv.dv_ma and hd.httt_ma = httt.httt_ma and hd.nv_ma = nv.nv_ma AND (hd_ma LIKE '%" + lhd_search.Text + "%' OR hd.hd_ngaylap  LIKE '%" + lhd_search.Text + "%' OR kh.kh_ten LIKE '%" + lhd_search.Text + "%' OR kh.kh_cccd LIKE '%" + lhd_search.Text + "%' OR kh.kh_sdt LIKE '%" + lhd_search.Text + "%') ";
    
                func.HienthiDulieuDG(lhp_data, Sql_lll, conn);

            }
        }

        private void qldt_timefrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void qldv_dongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }

        private void ttp_dg_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }
        private void tb_sdt_kh_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }

        private void tb_cccd_kh_KeyPress(object sender, KeyPressEventArgs e)
        {
            func.txtNumber(sender, e);
        }

        private void btn_kh_them_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string lkh_ma = cb_lkh.Text;
            if (lkh_ma == "VIP")
            {
                lkh_ma = "1";
            }
            else
            {
                lkh_ma = "2";
            }
            string kh_ten = tb_ten_kh.Text;
            string kh_cccd = tb_cccd_kh.Text;
            string kh_gioitinh = cb_gioitinh_kh.Text;
            string kh_sdt = tb_sdt_kh.Text;
            string kh_diachi = tb_diachi_kh.Text;
            string kh_ngaysinh = ngaysinh_kh.Value.ToString("yyyy-MM-dd");
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO KHACHHANG (lkh_ma, kh_ten, kh_cccd, kh_ngaysinh, kh_gioitinh, kh_sdt, kh_diachi) values ('" + lkh_ma + "',N'" + kh_ten + "','" + kh_cccd + "','" + kh_ngaysinh + "',N'" + kh_gioitinh + "','" + kh_sdt + "', N'" + kh_diachi + "')";
            command.ExecuteNonQuery();
            MessageBox.Show("Đã thêm khách hàng " + tb_ten_kh.Text + " thành công!");
            load_data();
            // Đóng kết nối
            conn.Close();

        }

        public void load_khachhang()
        {
            func.HienthiDulieuDG(dgv_khachhang, "select kh_ma, kh_ten, kh_cccd, kh_ngaysinh, kh_gioitinh, kh_sdt, kh_diachi, lkh_ten from khachhang a, loaikhachhang b where a.lkh_ma=b.lkh_ma", conn);
        }
        public void load_phieudatphong()
        {
            func.HienthiDulieuDG(dgv_phieudatphong, "select * from phieudatphong", conn);
        }


        private void bt_khoitao_Click(object sender, EventArgs e)
            
        {
            cb_lkh.Text = "";
            tb_ten_kh.Text = "";
            tb_cccd_kh.Text = "";
            cb_gioitinh_kh.Text = "";
            tb_sdt_kh.Text = "";
            tb_diachi_kh.Text = "";
            ngaysinh_kh.Text = "";

            btn_kh_them.Enabled = true;
            


            // Khởi tạo đối tượng SqlCommand
            SqlCommand sqlCommand = new SqlCommand("SELECT max(kh_ma)+1 as max_id FROM KHACHHANG", conn);

            // Khởi tạo đối tượng SqlDataReader 
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            // Kiểm tra nếu có bản ghi trả về
            if (sqlReader.Read())
            {
                // Lấy giá trị trường max_id từ bản ghi trả về và gán cho biến id_max
                int id_max = Convert.ToInt32(sqlReader["max_id"]);

                // In giá trị id_max ra màn hình để kiểm tra
                tb_ma_kh.Text = "" + id_max;
            }
            sqlReader.Close();

            string lkh = "select * from loaikhachhang";
            func.LoadComb(cb_lkh, lkh, conn, hienthi: "lkh_ten", giatri: "lkh_ten");
            // Đóng kết nối
           // conn.Close();
            
            //func.HienthiDulieuDG(dgv_khachhang, "SELECT * from khachhang", conn);
            //load_khachhang();
            
        }

        private void dgv_khachhang_Click(object sender, EventArgs e)
        {
            btn_kh_them.Enabled = false;
            int i;
            i = dgv_khachhang.CurrentRow.Index;
            //kh_ma, kh_ten, kh_cccd, kh_ngaysinh, kh_gioitinh, kh_sdt, kh_diachi, lkh_ten
            tb_ma_kh.Text = dgv_khachhang.Rows[i].Cells[0].Value.ToString();
            tb_ten_kh.Text = dgv_khachhang.Rows[i].Cells[1].Value.ToString();
            tb_cccd_kh.Text = dgv_khachhang.Rows[i].Cells[2].Value.ToString();
            ngaysinh_kh.Text = dgv_khachhang.Rows[i].Cells[3].Value.ToString();
            cb_gioitinh_kh.Text = dgv_khachhang.Rows[i].Cells[4].Value.ToString();
            tb_sdt_kh.Text = dgv_khachhang.Rows[i].Cells[5].Value.ToString();
            tb_diachi_kh.Text = dgv_khachhang.Rows[i].Cells[6].Value.ToString();
            cb_lkh.Text = dgv_khachhang.Rows[i].Cells[7].Value.ToString();
        }

        private void cb_lkh_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_kh_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int CurrentIndex = dgv_khachhang.CurrentCell.RowIndex;
                string del_column = Convert.ToString(dgv_khachhang.Rows[CurrentIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa?", "Verify delete it ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string deletedStr = "delete from khachhang where kh_ma ='" + del_column + "'";
                    string del_kh = "SELECT * from khachhang";
                    SqlCommand deletedCmd = new SqlCommand(deletedStr, conn);
                    deletedCmd.CommandType = CommandType.Text;
                    deletedCmd.ExecuteNonQuery();
                    func.CapNhat(deletedStr, conn);
                    func.HienthiDulieuDG(dgv_khachhang, del_kh, conn);
                    MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                    conn.Close();
                    tb_ma_kh.Text = "";
                    cb_lkh.Text = "";
                    tb_ten_kh.Text = "";
                    tb_cccd_kh.Text = "";
                    cb_gioitinh_kh.Text = "";
                    tb_sdt_kh.Text = "";
                    tb_diachi_kh.Text = "";
                    ngaysinh_kh.Text = "";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btn_kh_sua_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            string lkh_ma = cb_lkh.Text;
            if (lkh_ma == "VIP")
            {
                lkh_ma = "1";
            }
            else
            {
                lkh_ma = "2";
            }
            string kh_ten = tb_ten_kh.Text;
            string kh_ma = tb_ma_kh.Text;
            string kh_cccd = tb_cccd_kh.Text;
            string kh_gioitinh = cb_gioitinh_kh.Text;
            string kh_sdt = tb_sdt_kh.Text;
            string kh_diachi = tb_diachi_kh.Text;
            string kh_ngaysinh = ngaysinh_kh.Value.ToString("yyyy-MM-dd");
            command = connection.CreateCommand();
            //command.CommandText = "INSERT INTO KHACHHANG (lkh_ma, kh_ten, kh_cccd, kh_ngaysinh, kh_gioitinh, kh_sdt, kh_diachi) values ('" + lkh_ma + "',N'" + kh_ten + "','" + kh_cccd + "','" + kh_ngaysinh + "',N'" + kh_gioitinh + "','" + kh_sdt + "', N'" + kh_diachi + "')";
            command.CommandText = "UPDATE KHACHHANG SET lkh_ma=@lkh_ma, kh_ten=@kh_ten, kh_cccd=@kh_cccd, kh_gioitinh=@kh_gioitinh, kh_sdt=@kh_sdt, kh_diachi=@kh_diachi, kh_ngaysinh=@kh_ngaysinh WHERE kh_ma=@kh_ma";
            command.Parameters.AddWithValue("@lkh_ma", lkh_ma);
            command.Parameters.AddWithValue("@kh_ten", kh_ten);
            command.Parameters.AddWithValue("@kh_cccd", kh_cccd);
            command.Parameters.AddWithValue("@kh_gioitinh", kh_gioitinh);
            command.Parameters.AddWithValue("@kh_sdt", kh_sdt);
            command.Parameters.AddWithValue("@kh_diachi", kh_diachi);
            command.Parameters.AddWithValue("@kh_ngaysinh", kh_ngaysinh);
            command.Parameters.AddWithValue("@kh_ma", kh_ma);

            command.ExecuteNonQuery();
            //MessageBox.Show("Đã thêm khách hàng " + tb_ten_kh.Text + " thành công!");
            MessageBox.Show("Đã cập nhật khách hàng " + tb_ten_kh.Text + " thành công!");
            load_data();
            // Đóng kết nối
            //conn.Close();

            //load_data();
            load_khachhang();
            connection.Close();
        }

        private void ttp_lp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_lkh_Click(object sender, EventArgs e)
        {
            string lkh = "select * from loaikhachhang";
            func.LoadComb(cb_lkh, lkh, conn, hienthi: "lkh_ten", giatri: "lkh_ten");

        }

        private void dgv_khachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void dt_pd_ngayvao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgv_phieudatphong_Click(object sender, EventArgs e)
        {
            bt_pd_them.Enabled = false;
            int k;
            k = dgv_phieudatphong.CurrentRow.Index;
            tb_pd_ma.Text = dgv_phieudatphong.Rows[k].Cells[0].Value.ToString();
            cb_pd_phong.Text = dgv_phieudatphong.Rows[k].Cells[1].Value.ToString();
            tb_pd_tenkhachhang.Text = dgv_phieudatphong.Rows[k].Cells[2].Value.ToString();
            cb_pd_gioitinhkhachhang.Text = dgv_phieudatphong.Rows[k].Cells[3].Value.ToString();
            tb_pd_diachikhachhang.Text = dgv_phieudatphong.Rows[k].Cells[4].Value.ToString();
            dt_pd_ngayvao.Text = dgv_phieudatphong.Rows[k].Cells[6].Value.ToString();
            dt_ph_ngayra.Text = dgv_phieudatphong.Rows[k].Cells[7].Value.ToString();
            tb_pd_sdt.Text = dgv_phieudatphong.Rows[k].Cells[8].Value.ToString();

            //
            string pd_map = "select ma_phong from phong where ma_trangthai = 'CP' ";
            func.LoadComb(cb_pd_phong, pd_map, conn, hienthi: "ma_phong", giatri: "ma_phong");
        }

        private void bt_pd_khoitao_Click(object sender, EventArgs e)
        {
            
            tb_pd_tenkhachhang.Text = "";
            dt_pd_ngayvao.Text = "";
            cb_pd_gioitinhkhachhang.Text = "";
            tb_pd_sdt.Text = "";
            tb_pd_diachikhachhang.Text = "";
            dt_ph_ngayra.Text = "";

            btn_kh_them.Enabled = true;



            // Khởi tạo đối tượng SqlCommand
            SqlCommand sqlCommand = new SqlCommand("SELECT max(pd_ma)+1 as max_id FROM phieudatphong", conn);

            // Khởi tạo đối tượng SqlDataReader 
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            // Kiểm tra nếu có bản ghi trả về
            if (sqlReader.Read())
            {
                // Lấy giá trị trường max_id từ bản ghi trả về và gán cho biến id_max
                int id_max = Convert.ToInt32(sqlReader["max_id"]);

                // In giá trị id_max ra màn hình để kiểm tra
                tb_pd_ma.Text = "" + id_max;
            }
            sqlReader.Close();

            string pd_map = "select ma_phong from phong where ma_trangthai = 'CP' ";
            func.LoadComb(cb_pd_phong, pd_map, conn, hienthi: "ma_phong", giatri: "ma_phong");

            conn.Close();
        }

        private void cb_pd_phong_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
        private void bt_pd_them_Click(object sender, EventArgs e)
        {
            
            
            string pd_phong = cb_pd_phong.Text;
            string pd_ten = tb_pd_tenkhachhang.Text;
            string pd_gt = cb_pd_gioitinhkhachhang.Text;
            string pd_dc = tb_pd_diachikhachhang.Text;
           
            string pd_ngv = dt_pd_ngayvao.Value.ToString("yyyy-MM-dd");
            string pd_ngr = dt_ph_ngayra.Value.ToString("yyyy-MM-dd");
            string pd_nlp = pd_nl.Value.ToString("yyyy-MM-dd");

            string pd_sdt = tb_pd_sdt.Text;
            
            
  
            
            
            string sql_addpd = "INSERT INTO phieudatphong ( ma_phong, pd_tenkhachhang, pd_gioitinhkhachhang, pd_diachikhachhang, pd_ngaylapphieu, pd_ngayvao, pd_ngayra, pd_sdt) values ('" + pd_phong + "',N'" + pd_ten + "',N'" + pd_gt + "',N'" + pd_dc + "',N'" + pd_nlp + "','" + pd_ngv + "', N'" + pd_ngr + "', '" + pd_sdt + "')";
            SqlCommand comd = new SqlCommand(sql_addpd, conn);
            string upttp = "update phong set ma_trangthai = 'PDD' where (ma_phong = '" + pd_phong + "') ";
            func.CapNhat(upttp, conn);
            comd.ExecuteNonQuery();

            conn.Close();
            
            MessageBox.Show("Đã thêm khách hàng " + pd_ten + " vào phiếu đặt thành công!");
            func.HienthiDulieuDG(dgv_phieudatphong, "select * from phieudatphong", conn);
            
            
        }

        private void bt_pd_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int CurrentIndex = dgv_phieudatphong.CurrentCell.RowIndex;
                string del_column = Convert.ToString(dgv_phieudatphong.Rows[CurrentIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn có muốn xóa?", "Verify delete it ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string deletedpb = "delete from phieudatphong where pd_ma ='" + del_column + "'";
                    string del_pd = "SELECT * from phieudatphong";
                    SqlCommand deletedCmd = new SqlCommand(deletedpb, conn);
                    deletedCmd.CommandType = CommandType.Text;
                    deletedCmd.ExecuteNonQuery();
                    func.CapNhat(deletedpb, conn);
                    string upttp = "update phong set ma_trangthai = 'CP' where (ma_phong = '" + cb_pd_phong.Text + "') ";
                    func.CapNhat(upttp, conn);
                    func.HienthiDulieuDG(dgv_phieudatphong, del_pd, conn);
                    MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                    conn.Close();
                    tb_pd_ma.Text = "";
                    tb_pd_tenkhachhang.Text = "";
                    tb_pd_sdt.Text = "";
                    cb_pd_phong.Text = "";
                    cb_pd_gioitinhkhachhang.Text = "";
                    dt_pd_ngayvao.Text = "";
                    dt_ph_ngayra.Text = "";
                    tb_pd_diachikhachhang.Text = "";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_pd_sua_Click(object sender, EventArgs e)
        {

        }

        private void cb_pd_phong_Click(object sender, EventArgs e)
        {
            string pd_map = "select ma_phong from phong where ma_trangthai = 'CP' ";
            func.LoadComb(cb_pd_phong, pd_map, conn, hienthi: "ma_phong", giatri: "ma_phong");
        }

        private void ttp_picture_Click(object sender, EventArgs e)
        {

        }
    }
    
}
