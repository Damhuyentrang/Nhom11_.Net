using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmGPU : Form, IViewGPU
    {
        private GPURepository repository;
        private GPU selectedGPU;
        private PreGPU presenter;
        private bool _isEditing;
        public FrmGPU()
        {
            InitializeComponent();
            repository = new GPURepository();
            presenter = new PreGPU(this, repository);
            dgvGPU.CellClick += dgvGPU_CellClick;
            LockTextBoxes(true);
            txtDungluong.KeyPress += txtDungluong_KeyPress;
        }
        private void txtDungluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void FrmGPU_Load(object sender, EventArgs e)
        {
            presenter.LoadGPUs();
        }
        public void UpdateGPUList(List<GPU> gpus)
        {
            dgvGPU.DataSource = null;
            dgvGPU.DataSource = gpus;
            dgvGPU.Columns["MaGPU"].HeaderText = "Mã GPU";
            dgvGPU.Columns["LoaiGPU"].HeaderText = "Loại GPU";
            dgvGPU.Columns["Dungluong"].HeaderText = "Dung lượng";
            dgvGPU.Columns["Mota"].HeaderText = "Mô Tả";
            dgvGPU.Columns["MaHSX"].HeaderText = "Mã HSX"; // Chỉ hiển thị cột MaHSX
            this.Text = "Danh sách GPU";
            this.Size = new System.Drawing.Size(600, 450);
            dgvGPU.Columns["MaGPU"].Width = 50;
            dgvGPU.Columns["LoaiGPU"].Width = 150;
            dgvGPU.Columns["Dungluong"].Width = 80;
            dgvGPU.Columns["Mota"].Width = 100;
            dgvGPU.Columns["MaHSX"].Width = 100;

            dgvGPU.ReadOnly = true;
            // Hiển thị MaHSX trực tiếp
            dgvGPU.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex == dgvGPU.Columns["DungLuong"].Index && e.RowIndex >= 0)
                {
                    var gpu = dgvGPU.Rows[e.RowIndex].DataBoundItem as GPU;
                    e.Value = gpu?.Dungluong + "GB";
                }
                else if (e.ColumnIndex == dgvGPU.Columns["MaHSX"].Index && e.RowIndex >= 0)
                {
                    var gpu = dgvGPU.Rows[e.RowIndex].DataBoundItem as GPU;
                    e.Value = gpu?.MaHSX ?? "";
                }
            };
        }

        private void dgvGPU_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGPU.Rows[e.RowIndex];
                selectedGPU = row.DataBoundItem as GPU;
                if (selectedGPU != null)
                {
                    txtMaGPU.Text = selectedGPU.MaGPU ?? "";
                    txtLoaiGPU.Text = selectedGPU.LoaiGPU ?? "";
                    txtDungluong.Text = selectedGPU.Dungluong.ToString();
                    txtMota.Text = selectedGPU.Mota ?? "";
                    txtHangsanxuat.Text = selectedGPU.MaHSX ?? ""; // Lấy MaHSX trực tiếp
                }
                else
                {
                    ClearTextBoxes();
                    selectedGPU = null;
                }
            }
            else
            {
                ClearTextBoxes();
                selectedGPU = null; // Đặt lại khi nhấp ra ngoài hoặc không hợp lệ
            }
        }
        private void LockTextBoxes(bool isLocked)
        {
            txtMaGPU.ReadOnly = isLocked;
            txtLoaiGPU.ReadOnly = isLocked;
            txtDungluong.ReadOnly = isLocked;
            txtMota.ReadOnly = isLocked;
            txtHangsanxuat.ReadOnly = isLocked;
        }

        private void ClearTextBoxes()
        {
            txtMaGPU.Text = string.Empty;
            txtLoaiGPU.Text = string.Empty;
            txtDungluong.Text = string.Empty;
            txtMota.Text = string.Empty;
            txtHangsanxuat.Text = string.Empty;
        }

        private void ResetValues()
        {
            ClearTextBoxes();
            _isEditing = false;
            LockTextBoxes(true);
        }
        private bool CheckTextBox()
        {
            if (string.IsNullOrWhiteSpace(txtMaGPU.Text))
            {
                MessageBox.Show("Mã GPU không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaGPU.Focus();
                return false;
            }

            if (!txtMaGPU.Text.StartsWith("GPU", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mã GPU phải bắt đầu bằng 'MB'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaGPU.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLoaiGPU.Text))
            {
                MessageBox.Show("Tên GPU không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoaiGPU.Focus();
                return false;
            }

            if (!int.TryParse(txtDungluong.Text, out int dungLuong) || dungLuong <= 0)
            {
                MessageBox.Show("Dung lượng phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMota.Text))
            {
                MessageBox.Show("Mô tả không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMota.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHangsanxuat.Text))
            {
                MessageBox.Show("Mã Hãng Sản Xuất không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHangsanxuat.Focus();
                return false;
            }

            if (!txtHangsanxuat.Text.StartsWith("HSX", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mã Hãng Sản Xuất phải bắt đầu bằng 'HSX'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHangsanxuat.Focus();
                return false;
            }

            if (txtMaGPU.Text.Length > 20)
            {
                MessageBox.Show("Mã GPU không được vượt quá 20 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaGPU.Focus();
                return false;
            }
            return true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BTL_nhom11_marketPC.Database.DatabaseContext.CloseConnection();
                Application.Exit();
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckTextBox())
            {
                return;
            }

            if (!repository.CheckForeignKeyExists("HangSanXuat", "MaHSX", txtHangsanxuat.Text))
            {
                MessageBox.Show("Mã Hãng Sản Xuất không tồn tại trong bảng HangSanXuat!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHangsanxuat.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            GPU gpu = new GPU
            {
                MaGPU = txtMaGPU.Text.Trim(), // Loại bỏ khoảng trắng thừa
                LoaiGPU = txtLoaiGPU.Text.Trim(), // Loại bỏ khoảng trắng thừa
                Dungluong = int.Parse(txtDungluong.Text.Trim()),
                Mota = txtMota.Text.Trim(),
                MaHSX = txtHangsanxuat.Text.Trim() // Gán MaHSX trực tiếp từ text box
            };

            try
            {
                if (!_isEditing)
                {
                    if (repository.CheckGPUExists(gpu.MaGPU))
                    {
                        MessageBox.Show("Mã GPU đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    repository.Add(gpu);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (selectedGPU != null && selectedGPU.MaGPU != gpu.MaGPU && repository.CheckGPUExists(gpu.MaGPU))
                    {
                        MessageBox.Show("Mã GPU đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    repository.Update(gpu);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                presenter.LoadGPUs();
                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditing = false;
            ClearTextBoxes();
            LockTextBoxes(false);
            txtMaGPU.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedGPU == null || string.IsNullOrWhiteSpace(selectedGPU.MaGPU))
            {
                MessageBox.Show("Vui lòng chọn một GPU để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isEditing = true;
            LockTextBoxes(false);
            txtMaGPU.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedGPU == null || string.IsNullOrWhiteSpace(selectedGPU.MaGPU))
            {
                MessageBox.Show("Vui lòng chọn một GPU để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa GPU có mã: {selectedGPU.MaGPU}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    repository.Delete(selectedGPU.MaGPU); // Gọi phương thức Delete
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    presenter.LoadGPUs(); // Cập nhật lại DataGridView
                    ResetValues(); // Xóa nội dung các TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
    }
}
