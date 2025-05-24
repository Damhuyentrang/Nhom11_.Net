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
    public partial class FrmSalesInvoice : Form, ISalesInvoiceView
    {
        private readonly PreSalesInvoice _presenter;
        private bool _isEditMode = false;
        private RelationshipMapper _mapper;
        private List<SalesInvoice> _salesInvoices;
        public FrmSalesInvoice()
        {
            InitializeComponent();
            _presenter = new PreSalesInvoice(this);

            dgridHoaDonBan.CellClick += dgridHoaDonBan_CellClick;
        }
        // Triển khai interface ISalesInvoiceView
        public string MaHDB { get => txtMaHoaDon.Text; set => txtMaHoaDon.Text = value; }
        public string MaKhach { get => cboTenKhachHang.SelectedValue?.ToString(); set => cboTenKhachHang.SelectedValue = value; }
        public string MaNV { get => cboTenNhanVien.SelectedValue?.ToString(); set => cboTenNhanVien.SelectedValue = value; }
        public DateTime NgayBan { get => mskNgayBan.Text != "" ? DateTime.Parse(mskNgayBan.Text) : DateTime.Now; set => mskNgayBan.Text = value.ToString("dd/MM/yyyy"); }
        public decimal TongTien {
            get
            {
                if (!string.IsNullOrEmpty(MaHDB) && _presenter != null && _mapper != null)
                {
                    return _mapper.GetInvoiceTotal(MaHDB);
                }
                // Nếu không lấy được từ DB, lấy từ giao diện
                string cleanText = txtTongTien.Text.Replace(".", "").Replace(" đ", "").Trim();
                return decimal.TryParse(cleanText, out decimal d) ? d : 0;
            }
            set
            {
                txtTongTien.Text = value.ToString("N0") + " đ";
                txtTongTien.Refresh();
                if (!string.IsNullOrEmpty(MaHDB) && _presenter != null && _mapper != null)
                {
                    _mapper.UpdateInvoiceTotal(MaHDB); 
                }
            }
        }
        public string TrangThaiDonHang { get => cboTrangThai.SelectedItem?.ToString(); set => cboTrangThai.SelectedItem = value; }

        public string DiaChi { get => txtDiaChi.Text; set => txtDiaChi.Text = value; }
        public string SoDienThoai { get => mskSoDienThoai.Text; set => mskSoDienThoai.Text = value; }
        public List<SalesInvoice> SalesInvoices
        {
            set
            {
                _salesInvoices = value;
                dgridHoaDonBan.DataSource = null;
                dgridHoaDonBan.DataSource = value;
                ConfigureDataGridView();
            }
        }

        public SalesInvoice SelectedSalesInvoice
        {
            get => dgridHoaDonBan.SelectedRows.Count > 0 ? dgridHoaDonBan.SelectedRows[0].DataBoundItem as SalesInvoice : null;
            set
            {
                if (value != null)
                {
                    txtMaHoaDon.Text = value.MaHDB;
                    cboTenKhachHang.SelectedValue = value.MaKhach;
                    cboTenNhanVien.SelectedValue = value.MaNV;
                    mskNgayBan.Text = value.NgayBan.ToString("dd/MM/yyyy");
                    txtTongTien.Text = value.TongTien.ToString();

                    string trangThai = value.TrangThaiDonHang?.Trim();
                    if (!string.IsNullOrEmpty(trangThai) && cboTrangThai.Items.Contains(trangThai))
                    {
                        cboTrangThai.SelectedItem = trangThai;
                    }
                    else
                    {
                        cboTrangThai.SelectedIndex = -1;
                    }

                    var customer = _presenter.GetCustomers().FirstOrDefault(c => c.MaKhach == value.MaKhach);
                    //if (customer != null)
                    //{
                    //    txtDiaChi.Text = customer.DiaChi ?? "";
                    //    mskSoDienThoai.Text = customer.SoDienThoai ?? "";
                    //}
                }
            }
        }
        public bool IsEditMode => _isEditMode;

        // Sự kiện
        public event EventHandler AddSalesInvoice;
        public event EventHandler UpdateSalesInvoice;
        public event EventHandler DeleteSalesInvoice;
        public event EventHandler SelectSalesInvoice;

        public void SetCustomers(List<Customer> customers)
        {
            cboTenKhachHang.DataSource = customers;
            cboTenKhachHang.DisplayMember = "TenKhach";
            cboTenKhachHang.ValueMember = "MaKhach";
        }

        public void SetEmployees(List<Employee> employees)
        {
            cboTenNhanVien.DataSource = employees;
            cboTenNhanVien.DisplayMember = "TenNV";
            cboTenNhanVien.ValueMember = "MaNV";
        }

        private void FrmSalesInvoice_Load(object sender, EventArgs e)
        {
            cboTrangThai.Items.AddRange(new string[] { "Hoàn Thành","Đang Xử Lý", "Hủy" });
            cboLocTrangThai.Items.AddRange(new string[] {"Tất cả" ,"Hoàn Thành", "Đang Xử Lý", "Hủy" });
            cboLocTrangThai.SelectedIndex = 0;
            dtpFromDate.Value = DateTime.Today.AddDays(-7);  // 7 ngày trước
            dtpToDate.Value = DateTime.Today;
            _presenter.LoadAllSalesInvoices();
            _presenter.LoadReferenceData();
            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            txtDiaChi.Enabled = false;
            mskSoDienThoai.Enabled = false;
            txtTongTien.Enabled = false;
        }

        private void ConfigureDataGridView()
        {

            try
            {
                if (_salesInvoices == null || !_salesInvoices.Any())
                {
                    dgridHoaDonBan.DataSource = null;
                    return;
                }

                // Let the DataGridView auto-generate columns first
                dgridHoaDonBan.AutoGenerateColumns = true;
                dgridHoaDonBan.DataSource = _salesInvoices;

                dgridHoaDonBan.AutoGenerateColumns = false;
                dgridHoaDonBan.Columns.Clear();

                AddColumn("MaHDB", "Mã HĐB", 100);
                AddColumn("TenKhach", "Tên khách hàng", 150);
                AddColumn("TenNV", "Tên nhân viên", 120);
                AddColumn("NgayBan", "Ngày bán", 120);
                AddColumn("TongTien", "Tổng tiền", 120);
                AddColumn("TrangThaiDonHang", "Trạng thái đơn hàng", 120);


                dgridHoaDonBan.AllowUserToAddRows = false;
                dgridHoaDonBan.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cấu hình DataGridView: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddColumn(string dataProperty, string header, int width, string format = null)
        {
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataProperty,
                HeaderText = header,
                Width = width
            };

            if (!string.IsNullOrEmpty(format))
            {
                col.DefaultCellStyle.Format = format;
            }

            dgridHoaDonBan.Columns.Add(col);
        }

        private void dgridHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectSalesInvoice?.Invoke(this, EventArgs.Empty);
                var selectedInvoice = SelectedSalesInvoice;
                if (selectedInvoice != null)
                {
                    var customer = _presenter.GetCustomers().FirstOrDefault(c => c.MaKhach == selectedInvoice.MaKhach);
                    if (customer != null)
                    {
                        txtDiaChi.Text = customer.DiaChi ?? "";
                        mskSoDienThoai.Text = customer.SoDienThoai ?? "";
                    }
                }
            }
        }

        private void dgridHoaDonBan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && _salesInvoices != null && e.RowIndex < _salesInvoices.Count)
            {
                //var invoice = _salesInvoices[e.RowIndex];
                var saleinvoice = dgridHoaDonBan.Rows[e.RowIndex].DataBoundItem as SalesInvoice;

                if (dgridHoaDonBan.Columns[e.ColumnIndex].DataPropertyName == "TenKhach")
                {
                    e.Value = saleinvoice.Customer?.TenKhach ?? "N/A";
                    e.FormattingApplied = true;
                }

                if (dgridHoaDonBan.Columns[e.ColumnIndex].DataPropertyName == "TenNV")
                {
                    e.Value = saleinvoice.Employee?.TenNV ?? "N/A";
                    e.FormattingApplied = true;
                }

                if (dgridHoaDonBan.Columns[e.ColumnIndex].DataPropertyName == "NgayBan")
                {
                    e.Value = saleinvoice.NgayBan.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }

                if (dgridHoaDonBan.Columns[e.ColumnIndex].DataPropertyName == "TongTien")
                {
                    e.Value = saleinvoice.TongTien.ToString("C0");
                }
            }
        }

        public void ClearInputFields()
        {
            txtMaHoaDon.Clear();
            cboTenKhachHang.SelectedIndex = -1;
            cboTenNhanVien.SelectedIndex = -1;
            mskNgayBan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTongTien.Clear();
            cboTrangThai.SelectedIndex = -1;
            txtMaHoaDon.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearInputFields();
            txtMaHoaDon.Enabled = true;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTongTien.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridHoaDonBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _isEditMode = true;
            txtMaHoaDon.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (dgridHoaDonBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedInvoice = SelectedSalesInvoice;
            string tenKhach = selectedInvoice?.Customer?.TenKhach ?? "N/A";
            string maHDB = txtMaHoaDon.Text;
            if (string.IsNullOrWhiteSpace(maHDB))
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra và gán MdiParent là form menu (MDI parent)
            if (this.MdiParent == null)
            {
                MessageBox.Show("Không tìm thấy MDI Parent! Đảm bảo form này được mở trong form menu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmSalesInvoiceDetail detailForm = new FrmSalesInvoiceDetail(maHDB, tenKhach)
            {
                MdiParent = this.MdiParent // Gán MDI parent của form hiện tại
            };

            detailForm.InvoiceUpdated += (s, args) =>
            {
                _presenter.LoadAllSalesInvoices(); // Làm mới danh sách hóa đơn
                ClearInputFields();
            };

            detailForm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgridHoaDonBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteSalesInvoice?.Invoke(this, EventArgs.Empty);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var salesInvoice = new SalesInvoice
            {
                MaHDB = MaHDB,
                MaKhach = MaKhach,
                MaNV = MaNV,
                NgayBan = NgayBan,
                TongTien = TongTien,
                TrangThaiDonHang = TrangThaiDonHang
            };

            if (_isEditMode)
            {
                UpdateSalesInvoice?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                AddSalesInvoice?.Invoke(this, EventArgs.Empty);
            }

            ClearInputFields();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text) && !_isEditMode)
            {
                MessageBox.Show("Mã hóa đơn không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboTenKhachHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboTenNhanVien.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void cboTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenKhachHang.SelectedValue != null)
            {
                string maKhach = cboTenKhachHang.SelectedValue.ToString();
                var customers = _presenter.GetCustomers();
                var customer = customers?.FirstOrDefault(c => c.MaKhach == maKhach);
                if (customer != null)
                {
                    txtDiaChi.Text = customer.DiaChi ?? "";
                    mskSoDienThoai.Text = customer.SoDienThoai ?? "";
                }
                else
                {
                    txtDiaChi.Text = "";
                    mskSoDienThoai.Text = "";
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;
            string status = cboLocTrangThai.SelectedItem?.ToString();
            if (dtpToDate.Value < dtpFromDate.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _presenter.LoadFilteredSalesInvoices(fromDate, toDate, status);
        }
    }
}
