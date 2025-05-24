using BTL_nhom11_marketPC.Database;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmComputer : Form, IComputerView
    {
        private readonly RelationshipMapper _mapper = DatabaseContext.RelationshipMapper;
        private readonly PreComputer _presenter;
        private List<Computer> _computers;
        private bool _isEditMode = false;
        private string _imagePath;

        public List<Computer> Computers
        {
            set
            {
                _computers = value;
                dgridDSMayTinh.DataSource = null;
                dgridDSMayTinh.DataSource = _computers;
                ConfigureDataGridView();
            }
        }      

        public Computer SelectedComputer
        {
            get => dgridDSMayTinh.SelectedRows.Count > 0 ? dgridDSMayTinh.SelectedRows[0].DataBoundItem as Computer : null;
            set
            {
                if (value != null)
                {
                    txtMaMay.Text = value.MaMay;
                    txtTenMay.Text = value.TenMay;
                    _imagePath = value.HinhAnh;
                    if (!string.IsNullOrEmpty(_imagePath) && File.Exists(_imagePath))
                    {
                        picAnh.Image = Image.FromFile(_imagePath);
                    }
                    else
                    {
                        picAnh.Image = null;
                    }
                    txtGhiChu.Text = value.GhiChu;
                    txtDonGia.Text = value.DonGia.ToString();
                    txtSoLuongTon.Text = value.SoLuongTon.ToString();
                    txtThoiGianBH.Text = value.ThoiGianBaoHanh.ToString();
                    cboLoaiMayTinh.SelectedValue = value.MaLoaiMay;
                    cboCPU.SelectedValue = value.MaCPU;
                    cboRAM.SelectedValue = value.MaRAM;
                    cboMainboard.SelectedValue = value.MaMainboard;
                    cboGPU.SelectedValue = value.MaGPU;
                    cboOCung.SelectedValue = value.MaOCung;
                    cboManHinh.SelectedValue = value.MaManHinh;
                    cboCard.SelectedValue = value.MaCard;
                    cboHSX.SelectedValue = value.MaHSX;
                }
            }
        }

        // Implement ViewComputer interface properties
        // Input field properties
        public string MaMay { get => txtMaMay.Text; set => txtMaMay.Text = value; }
        public string TenMay { get => txtTenMay.Text; set => txtTenMay.Text = value; }

        public string HinhAnh
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                if (!string.IsNullOrEmpty(value) && File.Exists(value))
                {
                    picAnh.Image = Image.FromFile(value);
                }
                else
                {
                    picAnh.Image = null;
                }
            }
        }

        public string GhiChu { get => txtGhiChu.Text; set => txtGhiChu.Text = value; }
        public decimal DonGia { get => decimal.TryParse(txtDonGia.Text, out var result) ? result : 0; set => txtDonGia.Text = value.ToString(); }
        public int SoLuongTon { get => int.TryParse(txtSoLuongTon.Text, out var result) ? result : 0; set => txtSoLuongTon.Text = value.ToString(); }
        public int ThoiGianBaoHanh { get => int.TryParse(txtThoiGianBH.Text, out var result) ? result : 0; set => txtThoiGianBH.Text = value.ToString(); }
        public string MaLoaiMay { get => cboLoaiMayTinh.SelectedValue?.ToString(); set => cboLoaiMayTinh.SelectedValue = value; }
        public string MaCPU { get => cboCPU.SelectedValue?.ToString(); set => cboCPU.SelectedValue = value; }
        public string MaRAM { get => cboRAM.SelectedValue?.ToString(); set => cboRAM.SelectedValue = value; }
        public string MaMainboard { get => cboMainboard.SelectedValue?.ToString(); set => cboMainboard.SelectedValue = value; }
        public string MaGPU { get => cboGPU.SelectedValue?.ToString(); set => cboGPU.SelectedValue = value; }
        public string MaOCung { get => cboOCung.SelectedValue?.ToString(); set => cboOCung.SelectedValue = value; }
        public string MaManHinh { get => cboManHinh.SelectedValue?.ToString(); set => cboManHinh.SelectedValue = value; }
        public string MaCard { get => cboCard.SelectedValue?.ToString(); set => cboCard.SelectedValue = value; }
        public string MaHSX { get => cboHSX.SelectedValue?.ToString(); set => cboHSX.SelectedValue = value; }

        // Events
        public event EventHandler AddComputer;
        public event EventHandler UpdateComputer;
        public event EventHandler DeleteComputer;
        public event EventHandler SelectComputer;
        public bool IsEditMode => _isEditMode;


        public FrmComputer()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _presenter = new PreComputer(this);
            dgridDSMayTinh.CellFormatting += dgridDSMayTinh_CellFormatting;
        }


        private void FrmComputer_Load(object sender, EventArgs e)
        {
            LoadDataToComboboxes();
            _presenter.LoadAllComputers();
            _presenter.LoadReferenceData();
            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnAnh.Visible = false;
        }


        private void LoadDataToComboboxes()
        {
            try
            {
                cboLocCPU.Items.Clear();
                cboLocCPU.Items.Add("Tất cả CPU");
                cboLocCPU.SelectedIndex = -1;

                cboLocRAM.Items.Clear();
                cboLocRAM.Items.Add("Tất cả RAM");
                cboLocRAM.SelectedIndex = -1;

                cboLocHSX.Items.Clear();
                cboLocHSX.Items.Add("Tất cả HSX");
                cboLocHSX.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nạp dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {

            try
            {
                if (_computers == null || !_computers.Any())
                {
                    dgridDSMayTinh.DataSource = null;
                    return;
                }

                // Let the DataGridView auto-generate columns first
                dgridDSMayTinh.AutoGenerateColumns = true;
                dgridDSMayTinh.DataSource = _computers;

                dgridDSMayTinh.AutoGenerateColumns = false;
                dgridDSMayTinh.Columns.Clear();

                // Add columns with proper DataPropertyNames for nested objects
                AddColumn("MaMay", "Mã Máy", 100);
                AddColumn("TenMay", "Tên Máy", 150);
                AddColumn("TenLoaiMay", "Loại Máy", 120);
                AddColumn("TenCPU", "CPU", 120);
                AddColumn("TenRAM", "RAM", 120);
                AddColumn("TenMainboard", "Mainboard", 120);
                AddColumn("TenGPU", "GPU", 120);
                AddColumn("TenOCung", "Ổ Cứng", 120);
                AddColumn("TenManHinh", "Màn Hình", 120);
                AddColumn("TenCard", "Card Đồ Họa", 120);
                AddColumn("TenHSX", "Hãng SX", 120);
                AddColumn("GhiChu", "Ghi Chú", 150);
                AddColumn("DonGia", "Đơn Giá", 100, "C0"); // Format as currency
                AddColumn("SoLuongTon", "Số Lượng Tồn", 120);
                AddColumn("ThoiGianBaoHanh", "Thời Gian BH", 120);

                dgridDSMayTinh.AllowUserToAddRows = false;
                dgridDSMayTinh.EditMode = DataGridViewEditMode.EditProgrammatically;
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

            dgridDSMayTinh.Columns.Add(col);
        }
        private void dgridDSMayTinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var computer = dgridDSMayTinh.Rows[e.RowIndex].DataBoundItem as Computer;
            if (computer == null) return;

            switch (dgridDSMayTinh.Columns[e.ColumnIndex].DataPropertyName)
            {
                case "TenLoaiMay":
                    e.Value = computer.ComputerType?.TenLoaiMay ?? "";
                    break;
                case "TenCPU":
                    e.Value = computer.CPU?.TenCPU ?? "";
                    break;
                case "TenRAM":
                    e.Value = computer.RAM?.TenRAM ?? "";
                    break;
                case "TenMainboard":
                    e.Value = computer.Mainboard?.TenMainboard ?? "";
                    break;
                case "TenGPU":
                    e.Value = computer.GPU?.LoaiGPU ?? "";
                    break;
                case "TenOCung":
                    e.Value = computer.HardDrive?.TenOCung ?? "";
                    break;
                case "TenManHinh":
                    e.Value = computer.ComputerScreen?.TenManHinh ?? "";
                    break;
                case "TenCard":
                    e.Value = computer.GraphicsCard?.TenCard ?? "";
                    break;
                case "TenHSX":
                    e.Value = computer.Manufacturer?.TenHSX ?? "";
                    break;
            }
        }
        public void ClearInputFields()
        {
            txtMaMay.Clear();
            txtTenMay.Clear();
            picAnh.Image = null;
            txtGhiChu.Clear();
            txtDonGia.Clear();
            txtSoLuongTon.Clear();
            txtThoiGianBH.Clear();
            cboLoaiMayTinh.SelectedIndex = -1;
            cboCPU.SelectedIndex = -1;
            cboRAM.SelectedIndex = -1;
            cboMainboard.SelectedIndex = -1;
            cboGPU.SelectedIndex = -1;
            cboOCung.SelectedIndex = -1;
            cboManHinh.SelectedIndex = -1;
            cboCard.SelectedIndex = -1;
            cboHSX.SelectedIndex = -1;
            txtMaMay.Enabled = false;
            txtSoLuongTon.Enabled = false;
            txtDonGia.Enabled = false;
            txtThoiGianBH.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnAnh.Enabled = false;
        }

        // Bộ lọc
        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                var filteredComputers = _computers.AsEnumerable();

                // Lọc CPU
                string selectedCPU = cboLocCPU.SelectedItem?.ToString();
                if (selectedCPU != "Tất cả CPU" && !string.IsNullOrEmpty(selectedCPU))
                {
                    filteredComputers = filteredComputers.Where(c => c.CPU?.TenCPU == selectedCPU);
                }

                // Lọc RAM
                string selectedRAM = cboLocRAM.SelectedItem?.ToString();
                if (selectedRAM != "Tất cả RAM" && !string.IsNullOrEmpty(selectedRAM))
                {
                    filteredComputers = filteredComputers.Where(c => c.RAM?.TenRAM == selectedRAM);
                }

                // Lọc Hãng sản xuất
                string selectedHSX = cboLocHSX.SelectedItem?.ToString();
                if (selectedHSX != "Tất cả HSX" && !string.IsNullOrEmpty(selectedHSX))
                {
                    filteredComputers = filteredComputers.Where(c => c.Manufacturer?.TenHSX == selectedHSX);
                }

                // Update DataGridView
                dgridDSMayTinh.DataSource = filteredComputers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgridDSMayTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgridDSMayTinh.Rows.Count)
            {
                var selectedComputer = dgridDSMayTinh.Rows[e.RowIndex].DataBoundItem as Computer;
                if (selectedComputer != null)
                {
                    SelectComputer?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        // Các phương thức khác của ViewComputer interface
        public void SetComputerTypes(List<ComputerType> computerTypes)
        {
            cboLoaiMayTinh.DataSource = computerTypes;
            cboLoaiMayTinh.DisplayMember = "TenLoaiMay";
            cboLoaiMayTinh.ValueMember = "MaLoaiMay";
        }

        public void SetCPUs(List<CPU> cpus)
        {
            cboCPU.DataSource = cpus;
            cboCPU.DisplayMember = "TenCPU";
            cboCPU.ValueMember = "MaCPU";

            // Update filter dropdown
            cboLocCPU.Items.Clear();
            cboLocCPU.Items.Add("Tất cả CPU");
            foreach (var cpu in cpus)
            {
                cboLocCPU.Items.Add(cpu.TenCPU);
            }
            cboLocCPU.SelectedIndex = 0;
        }

        public void SetRAMs(List<RAM> rams)
        {
            cboRAM.DataSource = rams;
            cboRAM.DisplayMember = "TenRAM";
            cboRAM.ValueMember = "MaRAM";

            cboLocRAM.Items.Clear();
            cboLocRAM.Items.Add("Tất cả RAM");
            foreach (var ram in rams)
            {
                cboLocRAM.Items.Add(ram.TenRAM);
            }
            cboLocRAM.SelectedIndex = 0;
        }

        public void SetMainboards(List<Mainboard> mainboards)
        {
            cboMainboard.DataSource = mainboards;
            cboMainboard.DisplayMember = "TenMainboard";
            cboMainboard.ValueMember = "MaMainboard";
        }

        public void SetGPUs(List<GPU> gpus)
        {
            cboGPU.DataSource = gpus;
            cboGPU.DisplayMember = "LoaiGPU";
            cboGPU.ValueMember = "MaGPU";
        }

        public void SetHardDrives(List<HardDrive> hardDrives)
        {
            cboOCung.DataSource = hardDrives;
            cboOCung.DisplayMember = "TenOCung";
            cboOCung.ValueMember = "MaOCung";
        }

        public void SetComputerScreens(List<ComputerScreen> screens)
        {
            cboManHinh.DataSource = screens;
            cboManHinh.DisplayMember = "TenManHinh";
            cboManHinh.ValueMember = "MaManHinh";
        }

        public void SetGraphicsCards(List<GraphicsCard> graphicsCards)
        {
            cboCard.DataSource = graphicsCards;
            cboCard.DisplayMember = "TenCard";
            cboCard.ValueMember = "MaCard";
        }

        public void SetManufacturers(List<Manufacturer> manufacturers)
        {
            cboHSX.DataSource = manufacturers;
            cboHSX.DisplayMember = "TenHSX";
            cboHSX.ValueMember = "MaHSX";

            cboLocHSX.Items.Clear();
            cboLocHSX.Items.Add("Tất cả HSX");
            foreach (var hsx in manufacturers)
            {
                cboLocHSX.Items.Add(hsx.TenHSX);
            }
            cboLocHSX.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearInputFields();
            txtMaMay.Enabled = true;
            txtMaMay.Focus();
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnAnh.Visible = true;
            btnAnh.Enabled = true;
            txtDonGia.Enabled = true;
            txtGhiChu.Enabled = true;
            txtSoLuongTon.Enabled = true;
            txtThoiGianBH.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridDSMayTinh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn máy tính cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditMode = true;
            txtMaMay.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnAnh.Visible = true;
            btnAnh.Enabled = true;
            txtDonGia.Enabled = true;
            txtGhiChu.Enabled = true;
            txtSoLuongTon.Enabled = true;
            txtThoiGianBH.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgridDSMayTinh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn máy tính cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa máy tính này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var selectedComputer = dgridDSMayTinh.CurrentRow.DataBoundItem as Computer;
                if (selectedComputer != null)
                {
                    if (selectedComputer != null)
                    {
                        DeleteComputer?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate()) return;

                var computer = new Computer
                {
                    MaMay = MaMay,
                    TenMay = TenMay,
                    DonGia = DonGia,
                    SoLuongTon = SoLuongTon,
                    ThoiGianBaoHanh = ThoiGianBaoHanh,
                    GhiChu = GhiChu,
                    HinhAnh = HinhAnh,
                    MaLoaiMay = MaLoaiMay,
                    MaCPU = MaCPU,
                    MaRAM = MaRAM,
                    MaMainboard = MaMainboard,
                    MaGPU = MaGPU,
                    MaOCung = MaOCung,
                    MaManHinh = MaManHinh,
                    MaCard = MaCard,
                    MaHSX = MaHSX
                };

                bool result;

                if (_isEditMode)
                {
                    UpdateComputer?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    AddComputer?.Invoke(this, EventArgs.Empty);
                }

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            var results = _mapper.SearchComputers(keyword);
            dgridDSMayTinh.DataSource = results;
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                Title = "Chọn hình ảnh máy tính"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                HinhAnh = openFileDialog.FileName;
                picAnh.Image = Image.FromFile(HinhAnh);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaMay.Text))
            {
                MessageBox.Show("Mã máy không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenMay.Text))
            {
                MessageBox.Show("Tên máy không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DonGia <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (SoLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn không được âm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (ThoiGianBaoHanh < 0)
            {
                MessageBox.Show("Thời gian bảo hành không được âm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboLoaiMayTinh.SelectedIndex == -1 || cboCPU.SelectedIndex == -1 || cboRAM.SelectedIndex == -1 ||
                cboMainboard.SelectedIndex == -1 || cboGPU.SelectedIndex == -1 || cboOCung.SelectedIndex == -1 ||
                cboManHinh.SelectedIndex == -1 || cboCard.SelectedIndex == -1 || cboHSX.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

    }
}