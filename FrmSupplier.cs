using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmSupplier : Form, IViewSupplier
    {
        private SupplierRepository repository;
        private PreSupplier presenter;
        private Supplier selectedSupplier;
        private bool _isEditing;
        public FrmSupplier()
        {
            InitializeComponent();
            repository = new SupplierRepository();
            presenter = new PreSupplier(this, repository);
            dgvSupplier.CellClick += dgvSupplier_CellClick;
            LockTextBoxes(true);
        }

        private void DgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            presenter.LoadSupplier();
        }
        public void UpdateSupplierList(List<Supplier> suppliers)
        {
            dgvSupplier.DataSource = null;
            dgvSupplier.DataSource = suppliers;
            dgvSupplier.Columns["MaNCC"].HeaderText = "Mã NCC";
            dgvSupplier.Columns["TenNCC"].HeaderText = "Tên NCC";
            
            this.Text = "Danh sách Nha Cung Cap";
            this.Size = new System.Drawing.Size(600, 400);
            dgvSupplier.Columns["MaNCC"].Width = 150;
            dgvSupplier.Columns["TenNCC"].Width = 350;
           

        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSupplier.Rows[e.RowIndex];
                selectedSupplier = row.DataBoundItem as Supplier;
                if (selectedSupplier != null)
                {
                    txtMaNCC.Text = selectedSupplier.MaNCC;
                    txtTenNCC.Text = selectedSupplier.TenNCC;
                   
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
            txtMaNCC.ReadOnly = isLocked;
            txtTenNCC.ReadOnly = isLocked;
          
        }
        private void ClearTextBoxes()
        {
            txtMaNCC.Text = string.Empty;
            txtTenNCC.Text = string.Empty;
           
            
        }

        private void ResetValues()
        {
            ClearTextBoxes();
            _isEditing = false;
            LockTextBoxes(true);
        }
        private bool CheckControls()
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                MessageBox.Show("Mã NCC không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNCC.Focus();
                return false;
            }

            if (!txtMaNCC.Text.StartsWith("NCC", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mã NCC phải bắt đầu bằng 'NCC'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNCC.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Tên HSX không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNCC.Focus();
                return false;
            }

            if (txtMaNCC.Text.Length > 50)
            {
                MessageBox.Show("Mã NCC không được vượt quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNCC.Focus();
                return false;
            }

            return true;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditing = false;
            ClearTextBoxes();
            LockTextBoxes(false);
            txtTenNCC.Focus();
            string newMaHSX = repository.GetNextMaNCC();
            txtMaNCC.Text = newMaHSX; // Gán giá trị mới vào textbox
                                    // Cập nhật lại danh sách nếu cần
            presenter?.LoadSupplier();
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

            Supplier supplier = new Supplier
            {
                MaNCC = txtMaNCC.Text,
                TenNCC = txtTenNCC.Text
            };
            try
            {
                if (!_isEditing)
                {
                    if (repository.CheckSupplier(txtMaNCC.Text))
                    {
                        MessageBox.Show("Mã NCC đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    presenter.AddSupplier(supplier);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (selectedSupplier != null && selectedSupplier.MaNCC != txtMaNCC.Text && repository.CheckSupplier(txtMaNCC.Text))
                    {
                        MessageBox.Show("Mã HSX đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    presenter.UpdateSupplier(supplier);
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
            if (selectedSupplier == null || string.IsNullOrWhiteSpace(selectedSupplier.MaNCC))
            {
                MessageBox.Show("Vui lòng chọn một Nha Cung Cap để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa Nha Cung Cap có mã: {selectedSupplier.MaNCC}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    presenter.DeleteSupplier(selectedSupplier.MaNCC);
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
            if (selectedSupplier == null || string.IsNullOrWhiteSpace(selectedSupplier.MaNCC))
            {
                MessageBox.Show("Vui lòng chọn một Mainboard để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isEditing = true;
            LockTextBoxes(false);
            txtMaNCC.ReadOnly = true;
            txtTenNCC.Focus();
        }

        public void UpdateSupplierList(List<IViewSupplier> suppliers)
        {
            throw new NotImplementedException();
        }
    }
}