using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmPromotion : Form, IViewPromotion
    {
        private PromotionRepository repository;
        private PrePromotion presenter;
        private Promotion selectedPromotion;
        private bool _isEditing;

        public string MaKhuyenMai => throw new NotImplementedException();

        public string TenKhuyenMai => throw new NotImplementedException();

        public int PhanTramGiam => throw new NotImplementedException();

        public DateTime NgayBatDau => throw new NotImplementedException();

        public DateTime NgayKetThuc => throw new NotImplementedException();

        public FrmPromotion()
        {
            InitializeComponent();
            repository = new PromotionRepository();
            presenter = new PrePromotion(this, repository);
            dgvPromotion.CellClick += dgvPromotion_CellClick;
            LockControls(true);
        }

        private void FrmPromotion_Load(object sender, EventArgs e)
        {
            presenter.LoadPromotions();
        }

        public void UpdatePromotionList(List<Promotion> list)
        {
            dgvPromotion.DataSource = null;
            dgvPromotion.DataSource = list;

            dgvPromotion.Columns["MaKM"].HeaderText = "Mã KM";
            dgvPromotion.Columns["TenKM"].HeaderText = "Tên Khuyến Mãi";
            dgvPromotion.Columns["PhanTramKM"].HeaderText = "Phần Trăm KM";

            dgvPromotion.Columns["MaKM"].Width = 100;
            dgvPromotion.Columns["TenKM"].Width = 200;
            dgvPromotion.Columns["PhanTramKM"].Width = 120;
        }

        private void dgvPromotion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedPromotion = dgvPromotion.Rows[e.RowIndex].DataBoundItem as Promotion;
                if (selectedPromotion != null)
                {
                    txtMaKM.Text = selectedPromotion.MaKM ?? "";
                    txtTenKM.Text = selectedPromotion.TenKM ?? "";
                    numPhanTramKM.Value = selectedPromotion.PhanTramKM;
                }
            }
        }

        private void LockControls(bool isLocked)
        {
            txtMaKM.ReadOnly = isLocked;
            txtTenKM.ReadOnly = isLocked;
            numPhanTramKM.Enabled = !isLocked;
        }

        private void ClearControls()
        {
            txtMaKM.Text = "";
            txtTenKM.Text = "";
            numPhanTramKM.Value = 0;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaKM.Text))
            {
                MessageBox.Show("Mã KM không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKM.Focus();
                return false;
            }

            if (!txtMaKM.Text.StartsWith("KM", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mã KM phải bắt đầu bằng 'KM'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKM.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenKM.Text))
            {
                MessageBox.Show("Tên khuyến mãi không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKM.Focus();
                return false;
            }

            if (numPhanTramKM.Value <= 0 || numPhanTramKM.Value > 100)
            {
                MessageBox.Show("Phần trăm khuyến mãi phải trong khoảng 1-100!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numPhanTramKM.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditing = false;
            ClearControls();
            LockControls(false);
            txtMaKM.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedPromotion == null)
            {
                MessageBox.Show("Vui lòng chọn một khuyến mãi để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isEditing = true;
            LockControls(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedPromotion == null)
            {
                MessageBox.Show("Vui lòng chọn một khuyến mãi để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc muốn xóa mã: {selectedPromotion.MaKM}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    repository.Delete(selectedPromotion.MaKM);
                    presenter.LoadPromotions();
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

            var km = new Promotion
            {
                MaKM = txtMaKM.Text.Trim(),
                TenKM = txtTenKM.Text.Trim(),
                PhanTramKM = (int)numPhanTramKM.Value
            };

            try
            {
                if (!_isEditing)
                {
                    if (repository.CheckExists(km.MaKM))
                    {
                        MessageBox.Show("Mã KM đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    repository.Add(km);
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                }
                else
                {
                    repository.Update(km);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }

                presenter.LoadPromotions();
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

        private void txtMaKM_TextChanged(object sender, EventArgs e)
        {

        }

        public void SetPromotionList(List<IViewPromotion> promotions)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void SetPromotionList(List<Promotion> promotionList)
        {
            throw new NotImplementedException();
        }
    }
}
