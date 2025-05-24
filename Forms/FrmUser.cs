using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmUser : Form, IViewUser
    {
        private PreUser _presenter;
        public FrmUser()
        {
            InitializeComponent();
            _presenter = new PreUser(this);
            txtMaNV.Enabled = false;
            txtVaiTro.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
        }
        public string MaNV { get => txtMaNV.Text; set => txtMaNV.Text = value; }
        public string TenNV { get => txtHoTen.Text; set => txtHoTen.Text = value; }
        public DateTime NgaySinh
        {
            get => DateTime.TryParse(mskNgaySinh.Text, out var result) ? result : DateTime.MinValue;
            set => mskNgaySinh.Text = value.ToString("dd/MM/yyyy");
        }
        public string GioiTinh
        {
            get => cboGioiTinh.SelectedItem?.ToString();
            set => cboGioiTinh.SelectedItem = value;
        }
        public string DiaChi { get => txtDiaChi.Text; set => txtDiaChi.Text = value; }
        public string SoDienThoai
        {
            get => mskSoDienThoai.Text.Replace(" ", "").Trim();
            set => mskSoDienThoai.Text = value;
        }
        public string VaiTro { get => txtVaiTro.Text; set => txtVaiTro.Text = value; }
        public string Username { get => txtUsername.Text; set => txtUsername.Text = value; }
        public Employee SelectedEmployee { get; set; }

        public event EventHandler UpdateEmployee;

        private void FrmUser_Load(object sender, EventArgs e)
        {
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            _presenter.LoadUserInfo();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpdateEmployee?.Invoke(this, EventArgs.Empty);
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            _presenter.ChangePassword();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _presenter.LoadUserInfo();
        }
    }
}
