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
    public partial class FrmHardDrive : Form, IHardDriveView
    {
        private PreHardDrive _presenter;
        private List<HardDrive> _drives;
        private bool _isEditMode = false;

        public FrmHardDrive()
        {
            InitializeComponent();
            _presenter = new PreHardDrive(this);
            this.WindowState = FormWindowState.Maximized;
        }

        public List<HardDrive> HardDrives
        {
            set => dgridDSOCung.DataSource = value;
        }

        public HardDrive SelectedHardDrive
        {
            get => dgridDSOCung.CurrentRow?.DataBoundItem as HardDrive;
            set { } // Setter không cần thiết, chỉ dùng để tuân thủ giao diện
        }

        public string MaOCung { get => txtMaOCung.Text; set => txtMaOCung.Text = value; }
        public string TenOCung { get => txtTenOCung.Text; set => txtTenOCung.Text = value; }
        public string LoaiOCung { get => txtLoaiOCung.Text; set => txtLoaiOCung.Text = value; }
        public int DungLuong
        {
            get => int.TryParse(txtDungLuong.Text, out var result) ? result : 0;
            set => txtDungLuong.Text = value.ToString();
        }
        public string MoTa { get => txtMoTa.Text; set => txtMoTa.Text = value; }

        public void SetHardDriveList(List<HardDrive> hardDrives)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<HardDrive>>(SetHardDriveList), hardDrives);
                return;
            }
            _drives = hardDrives;
            dgridDSOCung.DataSource = null;
            dgridDSOCung.Columns.Clear();
            dgridDSOCung.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colMaOCung = new DataGridViewTextBoxColumn();
            colMaOCung.HeaderText = "Mã ổ cứng";
            colMaOCung.DataPropertyName = "MaOCung";
            colMaOCung.Width = 100;
            dgridDSOCung.Columns.Add(colMaOCung);

            DataGridViewTextBoxColumn colTenOCung = new DataGridViewTextBoxColumn();
            colTenOCung.HeaderText = "Tên ổ cứng";
            colTenOCung.DataPropertyName = "TenOCung";
            colTenOCung.Width = 120;
            dgridDSOCung.Columns.Add(colTenOCung);

            DataGridViewTextBoxColumn colLoaiOCung = new DataGridViewTextBoxColumn();
            colLoaiOCung.HeaderText = "Loại ổ cứng";
            colLoaiOCung.DataPropertyName = "LoaiOCung";
            colLoaiOCung.Width = 120;
            dgridDSOCung.Columns.Add(colLoaiOCung);

            DataGridViewTextBoxColumn colDungLuong = new DataGridViewTextBoxColumn();
            colDungLuong.HeaderText = "Dung lượng";
            colDungLuong.DataPropertyName = "DungLuong";
            colDungLuong.Width = 120;
            dgridDSOCung.Columns.Add(colDungLuong);

            DataGridViewTextBoxColumn colMoTa = new DataGridViewTextBoxColumn();
            colMoTa.HeaderText = "Mô tả";
            colMoTa.DataPropertyName = "MoTa";
            colMoTa.Width = 120;
            dgridDSOCung.Columns.Add(colMoTa);

            dgridDSOCung.DataSource = hardDrives;
            dgridDSOCung.AllowUserToAddRows = false;
            dgridDSOCung.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public event EventHandler AddHardDrive;
        public event EventHandler UpdateHardDrive;
        public event EventHandler DeleteHardDrive;
        public event EventHandler SelectHardDrive;

        public void ClearInputFields()
        {
            txtMaOCung.Clear();
            txtTenOCung.Clear();
            txtLoaiOCung.Clear();
            txtDungLuong.Clear();
            txtMoTa.Clear();
            txtSearch.Clear();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            _isEditMode = false;
            txtMaOCung.Enabled = true;
        }

        private void FrmHardDrive_Load(object sender, EventArgs e)
        {
            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaOCung.Enabled = false;
        }

        private void dgridDSOCung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgridDSOCung.Rows.Count)
            {
                SelectHardDrive?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearInputFields();
            txtMaOCung.Enabled = true;
            txtTenOCung.Enabled = true;
            txtMoTa.Focus();
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridDSOCung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một ổ cứng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditMode = true;
            txtMaOCung.Enabled = false;
            txtTenOCung.Enabled = true;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgridDSOCung.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một ổ cứng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa ổ cứng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteHardDrive?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                if (_isEditMode)
                {
                    UpdateHardDrive?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    AddHardDrive?.Invoke(this, EventArgs.Empty);
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
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaOCung.Text))
            {
                MessageBox.Show("Mã ổ cứng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenOCung.Text))
            {
                MessageBox.Show("Tên ổ cứng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLoaiOCung.Text))
            {
                MessageBox.Show("Loại ổ cứng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DungLuong <= 0)
            {
                MessageBox.Show("Dung lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMaOCung.Text.Length > 10)
            {
                MessageBox.Show("Mã ổ cứng không được dài quá 10 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTenOCung.Text.Length > 50)
            {
                MessageBox.Show("Tên ổ cứng không được dài quá 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMoTa.Text?.Length > 255)
            {
                MessageBox.Show("Mô tả không được dài quá 255 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.SearchHardDrives(txtSearch.Text);
        }
    }
}