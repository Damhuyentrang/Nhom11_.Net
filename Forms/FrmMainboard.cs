using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;
using BTL_nhom11_marketPC.Database.Repositories;


namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmMainboard : Form, IViewMainboard
    {
        private MainboardRepository repository;
        private ManufacturerRepository manufacturerRepository;
        private Mainboard selectedMainboard;
        private PreMainbroad presenter;
        private bool _isEditing;

        public FrmMainboard()
        {
            InitializeComponent();
            repository = new MainboardRepository();
            manufacturerRepository = new ManufacturerRepository();
            presenter = new PreMainbroad(this, repository, manufacturerRepository);
            dgvMainboard.CellClick += dgvMainboard_CellClick;
            LockTextBoxes(true);
        }

        private void FrmMainboard_Load(object sender, EventArgs e)
        {
            presenter.LoadManufacturers();
            presenter.LoadMainboards();
        }

        public void UpdateMainboardList(List<Mainboard> mainboards)
        {
            dgvMainboard.DataSource = null;
            dgvMainboard.DataSource = mainboards;
            dgvMainboard.Columns["MaMainboard"].HeaderText = "Mã Mainboard";
            dgvMainboard.Columns["TenMainboard"].HeaderText = "Tên Mainboard";
            dgvMainboard.Columns["Socket"].HeaderText = "Socket";
            dgvMainboard.Columns["Mota"].HeaderText = "Mô Tả";
            dgvMainboard.Columns["MaHSX"].HeaderText = "Mã HSX"; // Chỉ hiển thị cột MaHSX
            this.Text = "Danh sách Mainboard";
            this.Size = new System.Drawing.Size(650, 550);
            dgvMainboard.Columns["MaMainboard"].Width = 50;
            dgvMainboard.Columns["TenMainboard"].Width = 150;
            dgvMainboard.Columns["Socket"].Width = 80;
            dgvMainboard.Columns["Mota"].Width = 100;
            dgvMainboard.Columns["MaHSX"].Width = 100;

            dgvMainboard.ReadOnly = true;

            dgvMainboard.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex == dgvMainboard.Columns["MaHSX"].Index && e.RowIndex >= 0)
                {
                    var mainboard = dgvMainboard.Rows[e.RowIndex].DataBoundItem as Mainboard;
                    e.Value = mainboard?.MaHSX ?? "";
                }
            };
        }
        public void UpdateHSXList(List<Manufacturer> manufacturers)
        {
            cboHSX.Items.Clear();
            foreach (var manufacturer in manufacturers)
            {
                cboHSX.Items.Add(manufacturer.MaHSX);
            }
            if (cboHSX.Items.Count > 0)
            {
                cboHSX.SelectedIndex = 0; // Chọn mục đầu tiên nếu danh sách không rỗng
            }
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvMainboard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMainboard.Rows[e.RowIndex];
                selectedMainboard = row.DataBoundItem as Mainboard;
                if (selectedMainboard != null)
                {
                    txtMamainboard.Text = selectedMainboard.MaMainboard ?? "";
                    txtTenmainboard.Text = selectedMainboard.TenMainboard ?? "";
                    txtSocket.Text = selectedMainboard.Socket ?? "";
                    txtMota.Text = selectedMainboard.Mota ?? "";
                    cboHSX.Text = selectedMainboard.MaHSX ?? ""; // Lấy MaHSX trực tiếp
                }
                else
                {
                    ClearTextBoxes();
                    selectedMainboard = null;
                }
            }
            else
            {
                ClearTextBoxes();
                selectedMainboard = null; // Đặt lại khi nhấp ra ngoài hoặc không hợp lệ
            }
        }

        private void LockTextBoxes(bool isLocked)
        {
            txtMamainboard.ReadOnly = isLocked || _isEditing;
            txtTenmainboard.ReadOnly = isLocked;
            txtSocket.ReadOnly = isLocked;
            txtMota.ReadOnly = isLocked;
            cboHSX.Enabled = !isLocked;
        }

        private void ClearTextBoxes()
        {
            txtMamainboard.Text = string.Empty;
            txtTenmainboard.Text = string.Empty;
            txtSocket.Text = string.Empty;
            txtMota.Text = string.Empty;
            cboHSX.Text = string.Empty;
        }

        private void ResetValues()
        {
            ClearTextBoxes();
            _isEditing = false;
            LockTextBoxes(true);
        }

        private bool CheckTextBox()
        {
            if (string.IsNullOrWhiteSpace(txtTenmainboard.Text))
            {
                MessageBox.Show("Tên Mainboard không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenmainboard.Focus();
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
            return true;
        }  
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            _isEditing = false;
            ClearTextBoxes();
            LockTextBoxes(false);
            txtTenmainboard.Focus();
            string newMaMainboard = repository.GetNextMaMainboard();
            txtMamainboard.Text = newMaMainboard;
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (selectedMainboard == null || string.IsNullOrWhiteSpace(selectedMainboard.MaMainboard))
            {
                MessageBox.Show("Vui lòng chọn một Mainboard để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isEditing = true;
            LockTextBoxes(false);
            txtMamainboard.ReadOnly = true; // Không cho phép sửa MaMainboard
            txtTenmainboard.Focus();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (selectedMainboard == null || string.IsNullOrWhiteSpace(selectedMainboard.MaMainboard))
            {
                MessageBox.Show("Vui lòng chọn một Mainboard để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa Mainboard có mã: {selectedMainboard.MaMainboard}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    repository.Delete(selectedMainboard.MaMainboard); // Gọi phương thức Delete
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    presenter.LoadMainboards(); // Cập nhật lại DataGridView
                    ResetValues(); // Xóa nội dung các TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (!CheckTextBox())
            {
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            Mainboard mainboard = new Mainboard
            {
                MaMainboard = txtMamainboard.Text.Trim(), // Loại bỏ khoảng trắng thừa
                TenMainboard = txtTenmainboard.Text.Trim(), // Loại bỏ khoảng trắng thừa
                Socket = txtSocket.Text.Trim(),
                Mota = txtMota.Text.Trim(),
                MaHSX = cboHSX.Text // Gán MaHSX trực tiếp từ text box
            };

            try
            {
                if (!_isEditing)
                {
                    repository.Add(mainboard);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    repository.Update(mainboard);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                presenter.LoadMainboards();
                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuybo_Click_1(object sender, EventArgs e)
        {
            ResetValues();
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
    }
}