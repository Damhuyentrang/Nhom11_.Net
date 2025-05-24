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
    public partial class FrmComputerType : Form, IComputerTypeView
    {
        private readonly RelationshipMapper _mapper = DatabaseContext.RelationshipMapper;
        private readonly PreComputerType _presenter;
        private List<ComputerType> _computerTypes;
        private bool _isEditMode = false;
        public List<ComputerType> ComputerTypes
        {
            set
            {
                _computerTypes = value;
                dgridDSLoaiMayTinh.DataSource = null;
                dgridDSLoaiMayTinh.DataSource = _computerTypes;
            }
        }
        public FrmComputerType()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _presenter = new PreComputerType(this);
            dgridDSLoaiMayTinh.CellClick += dgridDSLoaiMayTinh_CellClick;
        }
        public string MaLoaiMay { get => txtMaLoaiMay.Text; set => txtMaLoaiMay.Text = value; }
        public string TenLoaiMay { get => txtTenLoaiMay.Text; set => txtTenLoaiMay.Text = value; }
        public ComputerType SelectedComputertype
        {
            get => dgridDSLoaiMayTinh.SelectedRows.Count > 0 ? dgridDSLoaiMayTinh.SelectedRows[0].DataBoundItem as ComputerType : null;
            set
            {
                if (value != null)
                {
                    MaLoaiMay = value.MaLoaiMay;
                    TenLoaiMay = value.TenLoaiMay;
                }
            }
        }
        public void SetComputerTypeList(List<ComputerType> computerTypes)
        {
            _computerTypes = computerTypes;
            dgridDSLoaiMayTinh.Columns.Clear();
            dgridDSLoaiMayTinh.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colMaLoaiMay = new DataGridViewTextBoxColumn();
            colMaLoaiMay.HeaderText = "Mã loại máy";
            colMaLoaiMay.DataPropertyName = "MaLoaiMay";
            colMaLoaiMay.Width = 100;
            dgridDSLoaiMayTinh.Columns.Add(colMaLoaiMay);

            DataGridViewTextBoxColumn colTenLoaiMay = new DataGridViewTextBoxColumn();
            colTenLoaiMay.HeaderText = "Tên loại máy";
            colTenLoaiMay.DataPropertyName = "TenLoaiMay";
            colTenLoaiMay.Width = 120;
            dgridDSLoaiMayTinh.Columns.Add(colTenLoaiMay);

            dgridDSLoaiMayTinh.DataSource = computerTypes;
            dgridDSLoaiMayTinh.AllowUserToAddRows = false;
            dgridDSLoaiMayTinh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void FrmComputerType_Load(object sender, EventArgs e)
        {
            LoadDataToComboboxes();
            _presenter.LoadAllComputerTypes();
            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
        }
        private void dgridDSLoaiMayTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgridDSLoaiMayTinh.Rows.Count)
            {
                var selectedComputerType = dgridDSLoaiMayTinh.Rows[e.RowIndex].DataBoundItem as ComputerType;
                if (selectedComputerType != null)
                {
                    SelectComputerType?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private void LoadDataToComboboxes()
        {
            try
            {
                cboLoc.Items.Clear();
                cboLoc.Items.Add("Tất cả Loại máy");
                cboLoc.Items.Add("PC");
                cboLoc.Items.Add("Laptop");
                cboLoc.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi nạp dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ClearInputFields()
        {
            txtMaLoaiMay.Clear();
            txtTenLoaiMay.Clear();
            txtMaLoaiMay.Enabled = false;
            txtTenLoaiMay.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
        }

        public event EventHandler AddComputerType;
        public event EventHandler UpdateComputerType;
        public event EventHandler DeleteComputerType;
        public event EventHandler SelectComputerType;

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearInputFields();
            txtMaLoaiMay.Enabled = true;
            txtTenLoaiMay.Enabled = true;
            txtMaLoaiMay.Focus();
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridDSLoaiMayTinh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn loại máy tính cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditMode = true;
            txtMaLoaiMay.Enabled = false;
            txtTenLoaiMay.Enabled = true;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgridDSLoaiMayTinh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn loại máy tính cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa loại máy tính này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var selectedComputerType = dgridDSLoaiMayTinh.CurrentRow.DataBoundItem as ComputerType;
                if (selectedComputerType != null)
                {
                    DeleteComputerType?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                if (_isEditMode)
                {
                    UpdateComputerType?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    AddComputerType?.Invoke(this, EventArgs.Empty);
                }

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedType = cboLoc.SelectedItem?.ToString();
                if (selectedType == "Tất cả Loại máy")
                {
                    dgridDSLoaiMayTinh.DataSource = _computerTypes;
                }
                else
                {
                    dgridDSLoaiMayTinh.DataSource = _computerTypes?
                        .Where(ct => ct.TenLoaiMay?.ToLower().Contains(selectedType.ToLower()) ?? false)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiMay.Text))
            {
                MessageBox.Show("Mã loại máy không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenLoaiMay.Text))
            {
                MessageBox.Show("Tên loại máy không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
    
}
