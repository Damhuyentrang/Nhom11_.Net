using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmManufacturer : Form, IViewManufacturer
    {
        private ManufacturerRepository repository;
        private PreManufacturer presenter;
        private Manufacturer selectedManufacturer;
        private bool _isEditing;
        public FrmManufacturer()
        {
            InitializeComponent();
            repository = new ManufacturerRepository();
            presenter = new PreManufacturer(this, repository);
            dgvHSX.CellClick += dgvHSX_CellClick;
            LockTextBoxes(true);
        }

        private void FrmManufacturer_Load(object sender, EventArgs e)
        {
            presenter.LoadManufacturers();
        }
        public void UpdateManufacturerList(List<Manufacturer> manufacturers)
        {
            dgvHSX.DataSource = null;
            dgvHSX.DataSource = manufacturers;
            dgvHSX.Columns["MaHSX"].HeaderText = "Mã HSX";
            dgvHSX.Columns["TenHSX"].HeaderText = "Tên HSX";
            this.Text = "Danh sách Hãng Sản Xuất";
            this.Size = new System.Drawing.Size(600, 400);
            dgvHSX.Columns["MaHSX"].Width = 150;
            dgvHSX.Columns["TenHSX"].Width = 350;
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHSX.Rows[e.RowIndex];
                selectedManufacturer = row.DataBoundItem as Manufacturer;
                if (selectedManufacturer != null)
                {
                    txtHSX.Text = selectedManufacturer.MaHSX;
                    txtTenHSX.Text = selectedManufacturer.TenHSX;
                    _isEditing = true;
                }
                else
                {
                    ClearTextBoxes();
                }
            }
        }
        private void LockTextBoxes(bool isLocked)
        {
            txtHSX.ReadOnly = isLocked;
            txtTenHSX.ReadOnly = isLocked;
        }
        private void ClearTextBoxes()
        {
            txtHSX.Text = string.Empty;
            txtTenHSX.Text = string.Empty;
        }

        private void ResetValues()
        {
            ClearTextBoxes();
            _isEditing = false;
            LockTextBoxes(true);
        }
        private bool CheckControls()
        {
            if (string.IsNullOrWhiteSpace(txtHSX.Text))
            {
                MessageBox.Show("Mã HSX không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHSX.Focus();
                return false;
            }

            if (!txtHSX.Text.StartsWith("HSX", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mã HSX phải bắt đầu bằng 'HSX'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHSX.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenHSX.Text))
            {
                MessageBox.Show("Tên HSX không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenHSX.Focus();
                return false;
            }

            if (txtHSX.Text.Length > 50)
            {
                MessageBox.Show("Mã HSX không được vượt quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHSX.Focus();
                return false;
            }

            return true;
        }
       

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditing = false;
            ClearTextBoxes();
            LockTextBoxes(false);
            txtTenHSX.Focus();
            string newMaHSX = repository.GetNextMaHSX();
            txtHSX.Text = newMaHSX; // Gán giá trị mới vào textbox
                                      // Cập nhật lại danh sách nếu cần
            presenter?.LoadManufacturers();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckControls())
            {
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            Manufacturer manufacturer = new Manufacturer
            {
                MaHSX = txtHSX.Text,
                TenHSX = txtTenHSX.Text
            };
            try
            {
                if (!_isEditing)
                {
                    if (repository.CheckManufacturerExists(txtHSX.Text))
                    {
                        MessageBox.Show("Mã HSX đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    presenter.AddManufacturer(manufacturer);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (selectedManufacturer != null && selectedManufacturer.MaHSX != txtHSX.Text && repository.CheckManufacturerExists(txtHSX.Text))
                    {
                        MessageBox.Show("Mã HSX đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    presenter.UpdateManufacturer(manufacturer);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedManufacturer == null || string.IsNullOrWhiteSpace(selectedManufacturer.MaHSX))
            {
                MessageBox.Show("Vui lòng chọn một Hãng Sản Xuất để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa Hãng Sản Xuất có mã: {selectedManufacturer.MaHSX}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    presenter.DeleteManufacturer(selectedManufacturer.MaHSX);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValues();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedManufacturer == null || string.IsNullOrWhiteSpace(selectedManufacturer.MaHSX))
            {
                MessageBox.Show("Vui lòng chọn một Mainboard để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isEditing = true;
            LockTextBoxes(false);
            txtHSX.ReadOnly = true;
            txtTenHSX.Focus();
        }
    }
}
