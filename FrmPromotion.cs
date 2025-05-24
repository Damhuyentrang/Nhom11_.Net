using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Database.Repositories;
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

        public string MaNCC => txtMaNCC.Text.Trim();
        public string TenNCC => txtTenNCC.Text.Trim();
        public string DiaChi => txtDiaChi.Text.Trim();
        public string SoDT => txtSoDT.Text.Trim();
        public string Email => txtEmail.Text.Trim();

        public FrmSupplier()
        {
            InitializeComponent();
            repository = new SupplierRepository();
            presenter = new PreSupplier(this, repository);
            dgvSupplier.CellClick += dgvSupplier_CellClick;
            LockControls(true);
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            presenter.LoadSuppliers();
        }

        public void UpdateSupplierList(List<Supplier> list)
        {
            dgvSupplier.DataSource = null;
            dgvSupplier.DataSource = list;

            dgvSupplier.Columns["MaNCC"].HeaderText = "Mã NCC";
            dgvSupplier.Columns["TenNCC"].HeaderText = "Tên Nhà Cung Cấp";
            dgvSupplier.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvSupplier.Columns["SoDT"].HeaderText = "Số Điện Thoại";
            dgvSupplier.Columns["Email"].HeaderText = "Email";
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedSupplier = dgvSupplier.Rows[e.RowIndex].DataBoundItem as Supplier;
                if (selectedSupplier != null)
                {
                    txtMaNCC.Text = selectedSupplier.MaNCC;
                    txtTenNCC.Text = selectedSupplier.TenNCC;
                    txtDiaChi.Text = selectedSupplier.DiaChi;
                    txtSoDT.Text = selectedSupplier.SoDT;
                    txtEmail.Text = selectedSupplier.Email;
                }
            }
        }

        private void LockControls(bool isLocked)
        {
            txtMaNCC.ReadOnly = isLocked;
            txtTenNCC.ReadOnly = isLocked;
            txtDiaChi.ReadOnly = isLocked;
            txtSoDT.ReadOnly = isLocked;
            txtEmail.ReadOnly = isLocked;
        }

        private void ClearControls()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSoDT.Text = "";
            txtEmail.Text = "";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(MaNCC))
            {
                MessageBox.Show("Mã NCC không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNCC.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TenNCC))
            {
                MessageBox.Show("Tên NCC không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNCC.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditing = false;
            ClearControls();
            LockControls(false);
            txtMaNCC.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedSupplier == null)
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isEditing = true;
            LockControls(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedSupplier == null)
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa mã: {selectedSupplier.MaNCC}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    repository.Delete(selectedSupplier.MaNCC);
                    presenter.LoadSuppliers();
                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var ncc = new Supplier
            {
                MaNCC = MaNCC,
                TenNCC = TenNCC,
                DiaChi = DiaChi,
                SoDT = SoDT,
                Email = Email
            };

            try
            {
                if (!_isEditing)
                {
                    if (repository.CheckExists(ncc.MaNCC))
                    {
                        MessageBox.Show("Mã NCC đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    repository.Add(ncc);
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                }
                else
                {
                    repository.Update(ncc);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }

                presenter.LoadSuppliers();
                ClearControls();
                LockControls(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            ClearControls();
            LockControls(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn thoát?", "Thoát", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                BTL_nhom11_marketPC.Database.DatabaseContext.CloseConnection();
                Application.Exit();
            }
        }
    }
}
}