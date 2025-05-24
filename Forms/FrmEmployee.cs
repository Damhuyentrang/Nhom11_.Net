using BTL_nhom11_marketPC.Database;
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
    public partial class FrmEmployee : Form, IEmployeeView
    {
        private readonly PreEmployee _presenter;
        private List<Employee> _employees;
        private bool _isEditMode = false;
        private readonly RelationshipMapper _mapper;

        public FrmEmployee()
        {
            InitializeComponent();
            _presenter = new PreEmployee(this);
            this.WindowState = FormWindowState.Maximized;
        }
        public string MaNV
        {
            get => txtMaNhanVien.Text;
            set => txtMaNhanVien.Text = value;
        }

        public string TenNV
        {
            get => txtTenNhanVien.Text;
            set => txtTenNhanVien.Text = value;
        }

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

        public string DiaChi
        {
            get => txtDiaChi.Text;
            set => txtDiaChi.Text = value;
        }

        public string SoDienThoai
        {
            get => mskSoDienThoai.Text.Replace(" ", "").Trim();
            set => mskSoDienThoai.Text = value;
        }
        public string VaiTro
        {
            get => cboVaiTro.SelectedItem?.ToString();
            set => cboVaiTro.SelectedItem = value;
        }
        public string Username { get; set; }
        public string MatKhau { get; set; }
        public List<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                dgridDSNhanVien.DataSource = null;
                dgridDSNhanVien.DataSource = _employees;
                ConfigureDataGridView();
            }
        }

        public Employee SelectedEmployee
        {
            get => dgridDSNhanVien.SelectedRows.Count > 0 ? dgridDSNhanVien.SelectedRows[0].DataBoundItem as Employee : null;
            set
            {
                if (value != null)
                {
                    MaNV = value.MaNV;
                    TenNV = value.TenNV;
                    NgaySinh = value.NgaySinh;
                    GioiTinh = value.GioiTinh;
                    DiaChi = value.DiaChi;
                    SoDienThoai = value.SoDienThoai;
                    VaiTro = value.VaiTro;
                }
            }
        }
        public event EventHandler AddEmployee;
        public event EventHandler UpdateEmployee;
        public event EventHandler DeleteEmployee;
        public event EventHandler SelectEmployee;

        public void ClearInputFields()
        {
            txtMaNhanVien.Clear();
            txtTenNhanVien.Clear();
            mskNgaySinh.Clear();
            cboGioiTinh.SelectedIndex = -1;
            txtDiaChi.Clear();
            mskSoDienThoai.Clear();
            cboVaiTro.SelectedIndex = -1;
        }
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            // Thiết lập các giá trị cho ComboBox Giới tính
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;

            cboVaiTro.Items.AddRange(new string[] {"Quản Lý","Quản Lý Kho","Nhân Viên Bán Hàng","Nhân Viên Kho","Kế Toán", "Kỹ Thuật Viên" });
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;

            // Thiết lập các giá trị cho ComboBox lọc Vai trò
            cboLocVaiTro.Items.AddRange(new string[] {"Tất Cả", "Quản Lý", "Quản Lý Kho", "Nhân Viên Bán Hàng", "Nhân Viên Kho", "Kế Toán", "Kỹ Thuật Viên" });
            cboLocVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocVaiTro.SelectedIndex = 0;

            // Load danh sách nhân viên
            _presenter.LoadAllEmployees();

            // Vô hiệu hóa các control khi mới mở form
            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaNhanVien.Enabled = false;
        }
        private void ConfigureDataGridView()
        {
            dgridDSNhanVien.AutoGenerateColumns = false;
            dgridDSNhanVien.Columns.Clear();

            dgridDSNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNV",
                HeaderText = "Mã NV",
                Width = 100
            });
            dgridDSNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenNV",
                HeaderText = "Tên Nhân Viên",
                Width = 150
            });
            dgridDSNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgaySinh",
                HeaderText = "Ngày Sinh",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgridDSNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GioiTinh",
                HeaderText = "Giới Tính",
                Width = 80
            });
            dgridDSNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DiaChi",
                HeaderText = "Địa Chỉ",
                Width = 200
            });
            dgridDSNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoDienThoai",
                HeaderText = "Số Điện Thoại",
                Width = 120
            });
            dgridDSNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VaiTro",
                HeaderText = "Vai Trò",
                Width = 120
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

            // Tạo mã nhân viên mới (tự động tăng)
            txtMaNhanVien.Text = GenerateNewMaNV();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridDSNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isEditMode = true;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaNhanVien.Enabled = false; 
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgridDSNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteEmployee?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (_isEditMode)
            {
                UpdateEmployee?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                AddEmployee?.Invoke(this, EventArgs.Empty);
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
            txtMaNhanVien.Enabled = false;
        }

        private void dgridDSNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectEmployee?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TenNV))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (cboVaiTro.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private string GenerateNewMaNV()
        {
            // Lấy ngày và tháng hiện tại theo định dạng ddMM
            string dayMonth = DateTime.Now.ToString("ddMM");
            string prefix = $"NV{dayMonth}_";

            // Lấy danh sách mã nhân viên hiện có
            var employees = _mapper.GetEmployees();

            if (employees == null || !employees.Any())
            {
                return $"{prefix}001";
            }

            // Lọc các mã nhân viên có cùng ngày + tháng
            var todayEmployees = employees
                .Where(emp => emp.MaNV.StartsWith(prefix))
                .ToList();

            if (!todayEmployees.Any())
            {
                return $"{prefix}001";
            }

            // Lấy số thứ tự lớn nhất của mã hiện tại
            int maxNumber = todayEmployees
                .Select(emp => int.Parse(emp.MaNV.Substring(prefix.Length)))
                .Max();

            return $"{prefix}{(maxNumber + 1):D3}";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (_employees == null) return;

            string selectedVaiTro = cboLocVaiTro.SelectedItem?.ToString();
            List<Employee> filteredEmployees;

            // Nếu chọn "Tất cả" hoặc không chọn, hiển thị toàn bộ danh sách
            if (string.IsNullOrEmpty(selectedVaiTro) || selectedVaiTro == "Tất Cả")
            {
                filteredEmployees = _employees;
            }
            else
            {
                // Lọc danh sách theo VaiTro
                filteredEmployees = _employees
                    .Where(emp => emp.VaiTro == selectedVaiTro)
                    .ToList();
            }

            // Cập nhật DataGridView
            dgridDSNhanVien.DataSource = null;
            dgridDSNhanVien.DataSource = filteredEmployees;
            ConfigureDataGridView();
        }
    }
}
