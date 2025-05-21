using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;
using BTL_nhom11_marketPC.Database.Repositories;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmCPU : Form, IViewCPU
    {
        private CPURepository repository;
        private CPU selectedCPU;
        private PreCPU presenter;
        private bool _isEditing;
        public FrmCPU()
        {
            InitializeComponent();
            repository = new CPURepository();
            presenter = new PreCPU(this, repository);
            dgvCPU.CellClick += dgvCPU_CellClick;
            LockTextBoxes(true);
        }

        private void FrmCPU_Load(object sender, EventArgs e)
        {
            presenter.LoadCPUs();
        }
        public void UpdateCPUList(List<CPU> CPUs)
        {
            dgvCPU.DataSource = null;
            dgvCPU.DataSource = CPUs;
            dgvCPU.Columns["MaCPU"].HeaderText = "Mã CPU";
            dgvCPU.Columns["TenCPU"].HeaderText = "Tên CPU";
            dgvCPU.Columns["Tocdo"].HeaderText = "Tốc độ";
            dgvCPU.Columns["Socket"].HeaderText = "Socket";
            dgvCPU.Columns["Mota"].HeaderText = "Mô Tả";
            dgvCPU.Columns["MaHSX"].HeaderText = "Mã HSX"; // Chỉ hiển thị cột MaHSX
            this.Text = "Danh sách CPU";
            this.Size = new System.Drawing.Size(600, 450);
            dgvCPU.Columns["MaCPU"].Width = 50;
            dgvCPU.Columns["TenCPU"].Width = 150;
            dgvCPU.Columns["Tocdo"].Width = 80;
            dgvCPU.Columns["Socket"].Width = 80;
            dgvCPU.Columns["Mota"].Width = 100;
            dgvCPU.Columns["MaHSX"].Width = 100;
            //chỉ đọc
            dgvCPU.ReadOnly = true;
            // Hiển thị MaHSX trực tiếp
            dgvCPU.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex == dgvCPU.Columns["MaHSX"].Index && e.RowIndex >= 0)
                {
                    var cpu = dgvCPU.Rows[e.RowIndex].DataBoundItem as CPU;
                    e.Value = cpu?.MaHSX ?? ""; // Hiển thị MaHSX trực tiếp
                }
            };
        }

        private void dgvCPU_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCPU.Rows[e.RowIndex];
                selectedCPU = row.DataBoundItem as CPU;
                if (selectedCPU != null)
                {
                    txtMacpu.Text = selectedCPU.MaCPU?? "";
                    txtTenCPU.Text = selectedCPU.TenCPU ?? "";
                    txtTocdo.Text = selectedCPU.Tocdo ?? "";
                    txtSocket.Text = selectedCPU.Socket ?? "";
                    txtMota.Text = selectedCPU.Mota ?? "";
                    txtHangsanxuat.Text = selectedCPU.MaHSX ?? ""; // Lấy MaHSX trực tiếp
                }
                else
                {
                    ClearTextBoxes();
                    selectedCPU = null;
                }
            }
            else
            {
                ClearTextBoxes();
                selectedCPU = null; // Đặt lại khi nhấp ra ngoài hoặc không hợp lệ
            }
        }
        private void LockTextBoxes(bool isLocked)
        {
            txtMacpu.ReadOnly = isLocked;
            txtTenCPU.ReadOnly = isLocked;
            txtTocdo.ReadOnly = isLocked;
            txtSocket.ReadOnly = isLocked;
            txtMota.ReadOnly = isLocked;
            txtHangsanxuat.ReadOnly = isLocked;
        }

        private void ClearTextBoxes()
        {
            txtMacpu.Text = string.Empty;
            txtTenCPU.Text = string.Empty;
            txtTocdo.Text= string.Empty;
            txtSocket.Text = string.Empty;
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
            if (string.IsNullOrWhiteSpace(txtMacpu.Text))
            {
                MessageBox.Show("Mã CPU không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMacpu.Focus();
                return false;
            }

            if (!txtMacpu.Text.StartsWith("CPU", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mã CPU phải bắt đầu bằng 'MB'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMacpu.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenCPU.Text))
            {
                MessageBox.Show("Tên CPU không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenCPU.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTocdo.Text))
            {
                MessageBox.Show("Tốc không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTocdo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSocket.Text))
            {
                MessageBox.Show("Socket không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSocket.Focus();
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

            if (txtMacpu.Text.Length > 20)
            {
                MessageBox.Show("Mã CPU không được vượt quá 20 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMacpu.Focus();
                return false;
            }
            return true;
        }
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BTL_nhom11_marketPC.Database.DatabaseContext.CloseConnection();
                Application.Exit();
            }
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            _isEditing = false;
            ClearTextBoxes();
            LockTextBoxes(false);
            txtMacpu.Focus();
        }

        private void btnHuybo_Click_1(object sender, EventArgs e)
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

            CPU cpu = new CPU
            {
                MaCPU= txtMacpu.Text.Trim(), 
                TenCPU = txtTenCPU.Text.Trim(), 
                Tocdo= txtTocdo.Text.Trim(),
                Socket = txtSocket.Text.Trim(),
                Mota = txtMota.Text.Trim(),
                MaHSX = txtHangsanxuat.Text.Trim() // Gán MaHSX trực tiếp từ text box
            };

            try
            {
                if (!_isEditing)
                {
                    if (repository.CheckMaCPUExists(cpu.MaCPU))
                    {
                        MessageBox.Show("Mã CPU đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    repository.Add(cpu);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (selectedCPU != null && selectedCPU.MaCPU != cpu.MaCPU && repository.CheckMaCPUExists(cpu.MaCPU))
                    {
                        MessageBox.Show("Mã CPU đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    repository.Update(cpu);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                presenter.LoadCPUs();
                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedCPU == null || string.IsNullOrWhiteSpace(selectedCPU.MaCPU))
            {
                MessageBox.Show("Vui lòng chọn một CPU để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isEditing = true;
            LockTextBoxes(false);
            txtMacpu.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedCPU == null || string.IsNullOrWhiteSpace(selectedCPU.MaCPU))
            {
                MessageBox.Show("Vui lòng chọn một CPU để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa CPU có mã: {selectedCPU.MaCPU}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    repository.Delete(selectedCPU.MaCPU); // Gọi phương thức Delete
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    presenter.LoadCPUs(); // Cập nhật lại DataGridView
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
