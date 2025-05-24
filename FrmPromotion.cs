using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmPromotion : Form
    {
        SqlConnection conn;
        SqlDataAdapter da;
        DataTable dt;
        string connectionString = "Data Source=.;Initial Catalog=CuaHangPhanMemMayTinh;Integrated Security=True";

        public FrmPromotion()
        {
            InitializeComponent();
            LoadData();
        }
        private void txtMaKhuyenMai_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void KetNoi()
        {
            if (conn == null)
                conn = new SqlConnection(connectionString);
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        private void DongKetNoi()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void LoadData()
        {
            KetNoi();
            string sql = "SELECT * FROM KhuyenMai";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvMaKhuyenMai.DataSource = dt;
            DongKetNoi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKhuyenMai.Clear();
            txtTenKhuyenMai.Clear();
            numPhanTramGiam.Value=0;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
            txtMaKhuyenMai.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKhuyenMai.Text == "" || txtTenKhuyenMai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            KetNoi();
            string sql = "INSERT INTO KhuyenMai (MaKhuyenMai, TenKhuyenMai, PhanTramGiam, NgayBatDau, NgayKetThuc) " +
                         "VALUES (@MaKhuyenMai, @TenKhuyenMai, @PhanTramGiam, @NgayBatDau, @NgayKetThuc)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKhuyenMai", txtMaKhuyenMai.Text);
            cmd.Parameters.AddWithValue("@TenKhuyenMai", txtTenKhuyenMai.Text);
            cmd.Parameters.AddWithValue("@PhanTramGiam", numPhanTramGiam.Text);
            cmd.Parameters.AddWithValue("@NgayBatDau", dtpNgayBatDau.Value);
            cmd.Parameters.AddWithValue("@NgayKetThuc", dtpNgayKetThuc.Value);
            cmd.ExecuteNonQuery();
            DongKetNoi();
            LoadData();
            MessageBox.Show("Đã lưu khuyến mãi thành công.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKhuyenMai.Text == "")
            {
                MessageBox.Show("Vui lòng chọn mã khuyến mãi cần sửa.");
                return;
            }

            KetNoi();
            string sql = "UPDATE KhuyenMai SET TenKhuyenMai = @TenKhuyenMai, PhanTramGiam = @PhanTramGiam, " +
                         "NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc WHERE MaKhuyenMai = @MaKhuyenMai";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKhuyenMai", txtMaKhuyenMai.Text);
            cmd.Parameters.AddWithValue("@TenKhuyenMai", txtTenKhuyenMai.Text);
            cmd.Parameters.AddWithValue("@PhanTramGiam", numPhanTramGiam.Text);
            cmd.Parameters.AddWithValue("@NgayBatDau", dtpNgayBatDau.Value);
            cmd.Parameters.AddWithValue("@NgayKetThuc", dtpNgayKetThuc.Value);
            cmd.ExecuteNonQuery();
            DongKetNoi();
            LoadData();
            MessageBox.Show("Đã sửa thành công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKhuyenMai.Text == "")
            {
                MessageBox.Show("Vui lòng chọn mã khuyến mãi cần xóa.");
                return;
            }

            KetNoi();
            string sql = "DELETE FROM KhuyenMai WHERE MaKhuyenMai = @MaKhuyenMai";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaKhuyenMai", txtMaKhuyenMai.Text);
            cmd.ExecuteNonQuery();
            DongKetNoi();
            LoadData();
            MessageBox.Show("Đã xóa thành công.");
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaKhuyenMai.Clear();
            txtTenKhuyenMai.Clear();
            numPhanTramGiam.Value=0;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvMaKhuyenMai.CurrentRow.Index;
            txtMaKhuyenMai.Text = dgvMaKhuyenMai.Rows[i].Cells[0].Value.ToString();
            txtTenKhuyenMai.Text =dgvMaKhuyenMai.Rows[i].Cells[1].Value.ToString();
            numPhanTramGiam.Text =dgvMaKhuyenMai.Rows[i].Cells[2].Value.ToString();
            dtpNgayBatDau.Value = Convert.ToDateTime(dgvMaKhuyenMai.Rows[i].Cells[3].Value);
            dtpNgayKetThuc.Value = Convert.ToDateTime(dgvMaKhuyenMai.Rows[i].Cells[4].Value);
        }
    }
}
