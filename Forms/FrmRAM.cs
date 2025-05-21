using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmRAM : Form, IViewRAM
    {
        private RAMRepository repository;
        private RAM selectedRAM;
        private PreRAM presenter;
        private bool _isEditing;
        public FrmRAM()
        {
            InitializeComponent();
            repository = new RAMRepository();
            presenter = new PreRAM(this, repository);
            dgvRAM.CellClick += dgvRAM_CellClick;
            LockTextBoxes(true);
            txtDungluong.KeyPress += txtDungluong_KeyPress;
            txtBus.KeyPress += txtBus_KeyPress;
        }
        private void txtDungluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtBus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void FrmRAM_Load(object sender, EventArgs e)
        {
            presenter.LoadRAMs();
        }
        public void UpdateRAMList(List<RAM> rams)
        {
            dgvRAM.DataSource = null;
            dgvRAM.DataSource = rams;
            dgvRAM.Columns["MaRAM"].HeaderText = "Mã RAM";
            dgvRAM.Columns["TenRAM"].HeaderText = "Tên RAM";
            dgvRAM.Columns["Bus"].HeaderText = "Bus";
            dgvRAM.Columns["Dungluong"].HeaderText = "Dung lượng";
            dgvRAM.Columns["Mota"].HeaderText = "Mô Tả";
            dgvRAM.Columns["MaHSX"].HeaderText = "Mã HSX"; // Chỉ hiển thị cột MaHSX
            this.Text = "Danh sách RAM";
            this.Size = new System.Drawing.Size(650, 550);
            dgvRAM.Columns["MaRAM"].Width = 50;
            dgvRAM.Columns["TenRAM"].Width = 150;
            dgvRAM.Columns["Bus"].Width = 80;
            dgvRAM.Columns["Dungluong"].Width = 80;
            dgvRAM.Columns["Mota"].Width = 100;
            dgvRAM.Columns["MaHSX"].Width = 100;

            dgvRAM.ReadOnly = true;
            // Hiển thị MaHSX trực tiếp
            dgvRAM.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex == dgvRAM.Columns["DungLuong"].Index && e.RowIndex >= 0)
                {
                    var ram = dgvRAM.Rows[e.RowIndex].DataBoundItem as RAM;
                    e.Value = ram?.Dungluong + "GB";
                }
                else if (e.ColumnIndex == dgvRAM.Columns["MaHSX"].Index && e.RowIndex >= 0)
                {
                    var ram = dgvRAM.Rows[e.RowIndex].DataBoundItem as RAM;
                    e.Value = ram?.MaHSX ?? "";
                }
            };
        }
        private void dgvRAM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRAM.Rows[e.RowIndex];
                selectedRAM = row.DataBoundItem as RAM;
                if (selectedRAM != null)
                {
                    txtMaRAM.Text = selectedRAM.MaRAM ?? "";
                    txtTenRAM.Text = selectedRAM.TenRAM ?? "";
                    txtBus.Text = selectedRAM.Bus.ToString();
                    txtDungluong.Text = selectedRAM.Dungluong.ToString();
                    txtMota.Text = selectedRAM.Mota ?? "";
                    txtHangsanxuat.Text = selectedRAM.MaHSX ?? ""; // Lấy MaHSX trực tiếp
                }
                else
                {
                    ClearTextBoxes();
                    selectedRAM = null;
                }
            }
            else
            {
                ClearTextBoxes();
                selectedRAM = null; // Đặt lại khi nhấp ra ngoài hoặc không hợp lệ
            }
        }
        private void LockTextBoxes(bool isLocked)
        {
            txtMaRAM.ReadOnly = isLocked;
            txtTenRAM.ReadOnly = isLocked;
            txtBus.ReadOnly = isLocked;
            txtDungluong.ReadOnly = isLocked;
            txtMota.ReadOnly = isLocked;
            txtHangsanxuat.ReadOnly = isLocked;
        }

        private void ClearTextBoxes()
        {
            txtMaRAM.Text = string.Empty;
            txtTenRAM.Text = string.Empty;
            txtBus.Text = string.Empty;
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
            if (string.IsNullOrWhiteSpace(txtMaRAM.Text))
            {
                MessageBox.Show("Mã RAM không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaRAM.Focus();
                return false;
            }

            if (!txtMaRAM.Text.StartsWith("RAM", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mã RAM phải bắt đầu bằng 'MB'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaRAM.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenRAM.Text))
            {
                MessageBox.Show("Tên GPU không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenRAM.Focus();
                return false;
            }
            if (!int.TryParse(txtBus.Text, out int bus) || bus <= 0)
            {
                MessageBox.Show("Bus phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (txtMaRAM.Text.Length > 20)
            {
                MessageBox.Show("Mã RAM không được vượt quá 20 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaRAM.Focus();
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

            RAM ram = new RAM
            {
                MaRAM = txtMaRAM.Text.Trim(), 
                TenRAM = txtTenRAM.Text.Trim(),
                Bus = int.Parse(txtBus.Text.Trim()),
                Dungluong = int.Parse(txtDungluong.Text.Trim()),
                Mota = txtMota.Text.Trim(),
                MaHSX = txtHangsanxuat.Text.Trim() // Gán MaHSX trực tiếp từ text box
            };

            try
            {
                if (!_isEditing)
                {
                    if (repository.CheckRAMExists(ram.MaRAM))
                    {
                        MessageBox.Show("Mã RAM đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    repository.Add(ram);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (selectedRAM != null && selectedRAM.MaRAM != ram.MaRAM && repository.CheckRAMExists(ram.MaRAM))
                    {
                        MessageBox.Show("Mã RAM đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    repository.Update(ram);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                presenter.LoadRAMs();
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
            txtMaRAM.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedRAM == null || string.IsNullOrWhiteSpace(selectedRAM.MaRAM))
            {
                MessageBox.Show("Vui lòng chọn một RAM để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa RAM có mã: {selectedRAM.MaRAM}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    repository.Delete(selectedRAM.MaRAM); // Gọi phương thức Delete
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    presenter.LoadRAMs(); // Cập nhật lại DataGridView
                    ResetValues(); // Xóa nội dung các TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedRAM == null || string.IsNullOrWhiteSpace(selectedRAM.MaRAM))
            {
                MessageBox.Show("Vui lòng chọn một GPU để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isEditing = true;
            LockTextBoxes(false);
            txtMaRAM.Focus();
        }
    }
}
