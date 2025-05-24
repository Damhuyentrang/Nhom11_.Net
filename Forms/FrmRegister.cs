using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmRegister : Form, IRegisterView
    {
        private PreRegister _preRegister;
        public FrmRegister()
        {
            InitializeComponent();
            SetPresenter(new PreRegister(this));
            this.WindowState = FormWindowState.Maximized;
        }

        public string TenNV => txtHoTen.Text.Trim();
        public DateTime NgaySinh => DateTime.Parse(mskNgaySinh.Text);
        public string GioiTinh => cboGioiTinh.SelectedItem?.ToString() ?? "Nam";
        public string DiaChi => txtDiaChi.Text.Trim();
        public string SoDienThoai => mskSoDienThoai.Text.Trim();
        public string Username => txtUsername.Text.Trim();
        public string Password => txtPass.Text;
        public string ConfirmPassword => txtConfirmPass.Text;
        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void ClearFields()
        {
            txtHoTen.Text = "";
            mskNgaySinh.Text = "";
            cboGioiTinh.SelectedIndex = 0;
            txtDiaChi.Text = "";
            mskSoDienThoai.Text = "";
            txtUsername.Text = "";
            txtPass.Text = "";
            txtConfirmPass.Text = "";
        }
        public void NavigateToLogin()
        {
            this.Hide(); // Ẩn form hiện tại
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show(); // Hiển thị form đăng nhập
            this.Close(); // Đóng form sau khi đăng nhập form hiện
        }
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cboGioiTinh.SelectedIndex = 0;
            this.picAnhMain.Image = Image.FromFile("D:\\Kì 2 năm 3\\Lập trình NET\\Nhom11_.Net\\assets\\banner.png");
        }
        public void SetPresenter(PreRegister presenter)
        {
            _preRegister = presenter;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            _preRegister.Register();
        }


    }
}
