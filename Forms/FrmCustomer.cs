using BTL_nhom11_marketPC.Models;
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
    public partial class FrmCustomer : Form,ICustomerView
    {
        private readonly PreCustomer _presenter;
        private List<Customer> _customers;
        private bool _isEditMode = false;

        public FrmCustomer()
        {
            InitializeComponent();
            _presenter = new PreCustomer(this);
            this.WindowState = FormWindowState.Maximized;
        }
        public string MaKhach
        {
            get => txtMaKhachHang.Text;
            set => txtMaKhachHang.Text = value;
        }

        public string TenKhach
        {
            get => txtTenKhachHang.Text;
            set => txtTenKhachHang.Text = value;
        }

        public string GioiTinh
        {
            get => cboGioiTinh.SelectedItem?.ToString();
            set => cboGioiTinh.SelectedItem = value;
        }

        public DateTime NgaySinh
        {
            get => DateTime.TryParse(mskNgaySinh.Text, out var result) ? result : DateTime.MinValue;
            set => mskNgaySinh.Text = value.ToString("dd/MM/yyyy");
        }

        public string SoDienThoai
        {
            get => mskSoDienThoai.Text.Replace(" ", "").Trim();
            set => mskSoDienThoai.Text = value;
        }

        public string DiaChi
        {
            get => txtDiaChi.Text;
            set => txtDiaChi.Text = value;
        }

        public string Email
        {
            get => txtEmail.Text;
            set => txtEmail.Text = value;
        }

        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                dgridDSKhachHang.DataSource = null;
                dgridDSKhachHang.DataSource = _customers;
                ConfigureDataGridView();
            }
        }

        public Customer SelectedCustomer
        {
            get => dgridDSKhachHang.SelectedRows.Count > 0 ? dgridDSKhachHang.SelectedRows[0].DataBoundItem as Customer : null;
            set
            {
                if (value != null)
                {
                    MaKhach = value.MaKhach;
                    TenKhach = value.TenKhach;
                    GioiTinh = value.GioiTinh;
                    NgaySinh = value.NgaySinh;
                    SoDienThoai = value.SoDienThoai;
                    DiaChi = value.DiaChi;
                    Email = value.Email;
                }
            }
        }

        public event EventHandler AddCustomer;
        public event EventHandler UpdateCustomer;
        public event EventHandler DeleteCustomer;
        public event EventHandler SelectCustomer;

        public void ClearInputFields()
        {
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            mskNgaySinh.Clear();
            cboGioiTinh.SelectedIndex = -1;
            mskSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            // Thiết lập các giá trị cho ComboBox Giới tính
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;

            // Load danh sách khách hàng
            _presenter.LoadAllCustomers();

            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaKhachHang.Enabled = false;
        }
        private void ConfigureDataGridView()
        {
            dgridDSKhachHang.AutoGenerateColumns = false;
            dgridDSKhachHang.Columns.Clear();

            dgridDSKhachHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaKhach",
                HeaderText = "Mã Khách",
                Width = 100
            });
            dgridDSKhachHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenKhach",
                HeaderText = "Tên Khách Hàng",
                Width = 150
            });
            dgridDSKhachHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgaySinh",
                HeaderText = "Ngày Sinh",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgridDSKhachHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GioiTinh",
                HeaderText = "Giới Tính",
                Width = 80
            });
            dgridDSKhachHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoDienThoai",
                HeaderText = "Số Điện Thoại",
                Width = 120
            });
            dgridDSKhachHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DiaChi",
                HeaderText = "Địa Chỉ",
                Width = 200
            });
            dgridDSKhachHang.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Width = 150
            });
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearInputFields();
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Tạo mã khách hàng mới (tự động tăng)
            txtMaKhachHang.Text = GenerateNewMaKhach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridDSKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isEditMode = true;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaKhachHang.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgridDSKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteCustomer?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (_isEditMode)
            {
                UpdateCustomer?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                AddCustomer?.Invoke(this, EventArgs.Empty);
            }

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaKhachHang.Enabled = false;
        }

        private void dgridDSKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectCustomer?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TenKhach))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!DateTime.TryParse(mskNgaySinh.Text, out var ngaySinh) || ngaySinh > DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không hợp lệ hoặc lớn hơn ngày hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cboGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(SoDienThoai) || !mskSoDienThoai.MaskCompleted)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(Email) && !IsValidEmail(Email))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateNewMaKhach()
        {
            // Load danh sách khách hàng để kiểm tra mã hiện có
            _presenter.LoadAllCustomers();
            var customers = Customers;
            if (customers == null || !customers.Any())
            {
                return "KH001";
            }

            // Tìm mã lớn nhất
            int maxNumber = customers
                .Select(cust => int.Parse(cust.MaKhach.Replace("KH", "")))
                .Max();

            return $"KH{(maxNumber + 1):D3}";
        }

    }
}
