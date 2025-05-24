using BTL_nhom11_marketPC.Database;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmSalesInvoiceDetail : Form, ISalesInvoiceDetailView
    {
        private readonly PreSalesInvoiceDetail _presenter;
        private List<SalesInvoiceDetail> _salesInvoiceDetails;
        private RelationshipMapper _mapper;
        private readonly string _maHDB;
        private readonly string _tenKhach;
        private bool _isEditMode = false;

        public FrmSalesInvoiceDetail(string maHDB, string tenKhach)
        {
            InitializeComponent();
            _maHDB = maHDB;
            _tenKhach = tenKhach;
            _presenter = new PreSalesInvoiceDetail(this);
            this.WindowState = FormWindowState.Maximized;
            _presenter.LoadSalesInvoiceDetails(_maHDB);
            _mapper = new RelationshipMapper();
        }

        public event EventHandler InvoiceUpdated;
        public event EventHandler AddSalesInvoiceDetail;
        public event EventHandler UpdateSalesInvoiceDetail;
        public event EventHandler DeleteSalesInvoiceDetail;
        public event EventHandler SelectSalesInvoiceDetail;
       
        // Triển khai interface ISalesInvoiceDetailView
        public string MaCTHDB { get => txtMaCTHDB.Text; set => txtMaCTHDB.Text = value; }
        public string MaHDB { get => _maHDB; set { } }
        public string MaMay { get => cboMayTinh.SelectedValue?.ToString(); set => cboMayTinh.SelectedValue = value; }
        public int SoLuong { get => int.TryParse(txtSoLuong.Text, out var result) ? result : 0; set => txtSoLuong.Text = value.ToString(); }
        public decimal GiaBan { get => decimal.TryParse(txtGiaBan.Text, out var result) ? result : 0; set => txtGiaBan.Text = value.ToString(); }
        public decimal ThanhTien { get => decimal.TryParse(txtThanhTien.Text, out var result) ? result : 0; set => txtThanhTien.Text = value.ToString(); }
        public string MaKhuyenMai { get => cboKhuyenMai.SelectedValue?.ToString();
            set
            {
                if (value == null)
                {
                    cboKhuyenMai.SelectedIndex = 0; 
                }
                else
                {
                    cboKhuyenMai.SelectedValue = value;
                }
            }
        }
        public decimal TongTien
        {
            get
            {
                if (!string.IsNullOrEmpty(_maHDB))
                {
                    return _mapper.GetInvoiceTotal(_maHDB);
                }
                string cleanText = txtTongTien.Text.Replace(".", "").Replace(" đ", "").Trim();
                return decimal.TryParse(cleanText, out decimal tongTien) ? tongTien : 0;
            }
            set
            {
                txtTongTien.Text = value.ToString("N0") + " đ";
                txtTongTien.Refresh();
            }
        }

        private void FrmSalesInvoiceDetail_Load(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = _maHDB;
            txtKhachHang.Text = _tenKhach;
            TongTien = TongTien;
            _presenter.LoadSalesInvoiceDetails(_maHDB);
            _presenter.LoadReferenceData();
            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaHoaDon.Enabled = false;
            txtMaCTHDB.Enabled = false;
            txtKhachHang.Enabled = false;
            txtGiaBan.Enabled = false;
            txtThanhTien.Enabled = false;
            txtTongTien.Enabled = false;
            lblTongTien.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(TongTien);
        }

        private void ConfigureDataGridView()
        {
            dgridCTHDB.AutoGenerateColumns = false;
            dgridCTHDB.Columns.Clear();

            dgridCTHDB.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaCTHDB", HeaderText = "Mã CTHĐ", Width = 100 });
            dgridCTHDB.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaMay", HeaderText = "Mã Máy", Width = 100 });
            dgridCTHDB.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "Số Lượng", Width = 80 });
            dgridCTHDB.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GiaBan", HeaderText = "Giá Bán", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" } });
            dgridCTHDB.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTien", HeaderText = "Thành Tiền", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" } });
            dgridCTHDB.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaKhuyenMai", HeaderText = "Mã Khuyến Mãi", Width = 120 });
        }
        public List<SalesInvoiceDetail> SalesInvoiceDetails
        {
            get => _salesInvoiceDetails;
            set
            {
                _salesInvoiceDetails = value;
                dgridCTHDB.DataSource = null;
                dgridCTHDB.DataSource = _salesInvoiceDetails;
                ConfigureDataGridView();
            }
        }

        public SalesInvoiceDetail SelectedSalesInvoiceDetail
        {
            get => dgridCTHDB.SelectedRows.Count > 0 ? dgridCTHDB.SelectedRows[0].DataBoundItem as SalesInvoiceDetail : null;
            set
            {
                if (value != null)
                {
                    txtMaCTHDB.Text = value.MaCTHDB;
                    cboMayTinh.SelectedValue = value.MaMay;
                    txtSoLuong.Text = value.SoLuong.ToString();
                    txtGiaBan.Text = value.GiaBan.ToString();
                    txtThanhTien.Text = value.ThanhTien.ToString();
                    cboKhuyenMai.SelectedValue = value.MaKhuyenMai;
                }
            }
        }
        public bool IsEditMode => _isEditMode;

        public void SetComputers(List<Computer> computers)
        {
            cboMayTinh.DataSource = computers;
            cboMayTinh.DisplayMember = "TenMay";
            cboMayTinh.ValueMember = "MaMay";
        }
        public void SetPromotions(List<Promotion> promotions)
        {
            // Lọc các khuyến mãi còn hợp lệ vào ngày hiện tại (23/05/2025)
            var validPromotions = promotions
                .Where(p => p.NgayBatDau <= DateTime.Today && p.NgayKetThuc >= DateTime.Today)
                .ToList();

            // Thêm một mục "Không khuyến mãi" (tùy chọn)
            validPromotions.Insert(0, new Promotion
            {
                MaKhuyenMai = "NONE",
                TenKhuyenMai = "Không khuyến mãi",
                PhanTramGiam = 0,
                NgayBatDau = DateTime.MinValue,
                NgayKetThuc = DateTime.MaxValue
            });

            // Gán danh sách đã lọc vào cboKhuyenMai
            cboKhuyenMai.DataSource = validPromotions;
            cboKhuyenMai.DisplayMember = "TenKhuyenMai";
            cboKhuyenMai.ValueMember = "MaKhuyenMai";
        }

        private void btnQuayVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgridCTHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectSalesInvoiceDetail?.Invoke(this, EventArgs.Empty);
            }
        }
        public void ClearInputFields()
        {
            txtMaCTHDB.Clear();
            cboMayTinh.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtGiaBan.Clear();
            txtThanhTien.Clear();
            cboKhuyenMai.SelectedIndex = -1;
            txtMaCTHDB.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
        }
        private bool ValidateInput()
        {
            if (cboMayTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn máy tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || SoLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void dgridCTHDB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgridCTHDB.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chi tiết hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteSalesInvoiceDetail?.Invoke(this, EventArgs.Empty);

                // Kích hoạt sự kiện sau khi xóa
                InvoiceUpdated?.Invoke(this, EventArgs.Empty);
            }
        }
        private void dgridCTHDB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && _salesInvoiceDetails != null && e.RowIndex < _salesInvoiceDetails.Count)
            {
                var detail = _salesInvoiceDetails[e.RowIndex];

                if (dgridCTHDB.Columns[e.ColumnIndex].DataPropertyName == "MaMay")
                {
                    e.Value = detail.Computer?.TenMay ?? "N/A";
                    e.FormattingApplied = true;
                }

                if (dgridCTHDB.Columns[e.ColumnIndex].DataPropertyName == "MaKhuyenMai")
                {
                    e.Value = detail.Promotion?.TenKhuyenMai ?? "";
                    e.FormattingApplied = true;
                }

                if (dgridCTHDB.Columns[e.ColumnIndex].DataPropertyName == "GiaBan")
                {
                    e.Value = detail.GiaBan.ToString("C0"); // Định dạng tiền tệ (không chữ số thập phân)
                    e.FormattingApplied = true;
                }

                if (dgridCTHDB.Columns[e.ColumnIndex].DataPropertyName == "ThanhTien")
                {
                    e.Value = detail.ThanhTien.ToString("C0");
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearInputFields();
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridCTHDB.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn chi tiết hóa đơn để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _isEditMode = true;
            txtMaCTHDB.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            UpdateThanhTien();

            var detail = new SalesInvoiceDetail
            {
                MaCTHDB = txtMaCTHDB.Text,
                MaHDB = _maHDB,
                MaMay = cboMayTinh.SelectedValue?.ToString(),
                SoLuong = SoLuong,
                GiaBan = GiaBan,
                ThanhTien = ThanhTien,
                MaKhuyenMai = cboKhuyenMai.SelectedValue?.ToString()
            };

            if (!_presenter.CheckPromotion(MaKhuyenMai))
            {
                MessageBox.Show("Mã khuyến mãi đã hết hạn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhuyenMai.SelectedIndex = 0;
            }

            if (_isEditMode)
            {
                UpdateSalesInvoiceDetail?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                AddSalesInvoiceDetail?.Invoke(this, EventArgs.Empty);
            }

            // Kích hoạt sự kiện để thông báo rằng dữ liệu đã thay đổi
            InvoiceUpdated?.Invoke(this, EventArgs.Empty);
            ClearInputFields();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
        }

        private void cboMayTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMayTinh.SelectedIndex >= 0)
            {
                var selectedComputer = cboMayTinh.SelectedItem as Computer;
                if (selectedComputer != null)
                {
                    txtGiaBan.Text = selectedComputer.DonGia.ToString("N0");
                    UpdateThanhTien();
                }
            }
            else
            {
                txtGiaBan.Text = "0";
                UpdateThanhTien();
            }
        }
        private void UpdateThanhTien()
        {
            if (int.TryParse(txtSoLuong.Text, out int soLuong) &&
                decimal.TryParse(txtGiaBan.Text.Replace(".", ""), out decimal giaBan))
            {
                string maKhuyenMai = cboKhuyenMai.SelectedValue?.ToString(); 
                decimal thanhTien = _presenter.CalculateTotalAmount(soLuong, giaBan, maKhuyenMai);
                txtThanhTien.Text = thanhTien.ToString("N0");
            }
            else
            {
                txtThanhTien.Text = "0";
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            UpdateThanhTien();
        }

        private void cboKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateThanhTien();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            if (exApp == null)
            {
                MessageBox.Show("Excel không thể khởi tạo. Vui lòng cài đặt Microsoft Excel!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Excel.Workbook exBook = exApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.ActiveSheet;

            try
            {
                exSheet.Name = "HoaDonBan";

                // Tiêu đề hóa đơn
                exSheet.Cells[1, 1] = "HÓA ĐƠN BÁN HÀNG";
                Range titleRange = exSheet.Range["A1:G1"];
                titleRange.Merge(); // Gộp các ô từ A1 đến E1
                titleRange.Font.Bold = true;
                titleRange.Font.Color = Color.Red;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // Ghi thông tin hóa đơn và khách hàng
                exSheet.Cells[4, 1] = $"Mã hóa đơn: {_maHDB}";
                exSheet.Cells[4, 4] = $"Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                exSheet.Cells[5, 1] = $"Khách hàng: {_tenKhach}";

                // Tiêu đề cột
                exSheet.Cells[9, 1] = "STT";
                exSheet.Cells[9, 2] = "Mã máy";
                exSheet.Cells[9, 3] = "Tên máy";
                exSheet.Cells[9, 4] = "Số lượng";
                exSheet.Cells[9, 5] = "Giá bán";
                exSheet.Cells[9, 6] = "Khuyến mãi";
                exSheet.Cells[9, 7] = "Thành tiền";

                // Định dạng tiêu đề cột
                Range headerRange = exSheet.Range["A9:G9"];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.Color.LightGray;
                headerRange.Borders.LineStyle = XlLineStyle.xlContinuous;

                // Đổ dữ liệu từ _salesInvoiceDetails
                int row = 10;
                int stt = 1;
                foreach (var detail in _salesInvoiceDetails)
                {
                    exSheet.Cells[row, 1] = stt++;
                    exSheet.Cells[row, 2] = detail.MaMay ?? "N/A";
                    exSheet.Cells[row, 3] = detail.Computer?.TenMay ?? "N/A";
                    exSheet.Cells[row, 4] = detail.SoLuong;
                    exSheet.Cells[row, 5] = detail.GiaBan.ToString() + " VNĐ";
                    exSheet.Cells[row, 6] = detail.Promotion?.TenKhuyenMai ?? "Không có";
                    exSheet.Cells[row, 7] = detail.ThanhTien.ToString() + " VNĐ";
                    row++;
                }

                row += 2;
                // Ghi tổng tiền
                exSheet.Cells[row, 6] = "Tổng cộng:";
                exSheet.Cells[row, 7] = TongTien.ToString() + " VNĐ";
                Range totalRange = exSheet.Range[exSheet.Cells[row, 5], exSheet.Cells[row, 6]];
                totalRange.Font.Bold = true;


                // Ghi số tiền bằng chữ
                row++;
                string soTienBangChu = Functions.ChuyenSoSangChu(TongTien);
                exSheet.Cells[row, 6] = $"Bằng chữ: {soTienBangChu}";
                Range textRange = exSheet.Range[exSheet.Cells[row, 6], exSheet.Cells[row, 7]];
                textRange.Merge();
                textRange.Font.Italic = true;
                textRange.HorizontalAlignment = XlHAlign.xlHAlignLeft;


                // Định dạng cột
                exSheet.Columns["A"].ColumnWidth = 5;  // STT
                exSheet.Columns["B"].ColumnWidth = 15; // Mã máy
                exSheet.Columns["C"].ColumnWidth = 25; // Tên máy
                exSheet.Columns["D"].ColumnWidth = 10; // Số lượng
                exSheet.Columns["E"].ColumnWidth = 15; // Giá bán
                exSheet.Columns["F"].ColumnWidth = 25; // Khuyến mãi
                exSheet.Columns["G"].ColumnWidth = 15; // Thành tiền


                // Căn chỉnh dữ liệu trong các cột
                Range dataRange = exSheet.Range[$"A9:G{row}"];
                dataRange.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                exSheet.Range[$"D9:D{row}"].HorizontalAlignment = XlHAlign.xlHAlignCenter;
                exSheet.Range[$"E9:G{row}"].HorizontalAlignment = XlHAlign.xlHAlignRight;

                // Lưu file Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = $"HoaDon_{_maHDB}_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    exBook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("In hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Đóng và giải phóng tài nguyên
                exBook.Close();
                exApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(exSheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo giải phóng tài nguyên
                if (exApp != null)
                {
                    exApp = null;
                }
            }
        }
    }
}