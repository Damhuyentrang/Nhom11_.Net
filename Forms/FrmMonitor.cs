using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Repositories.BTL_nhom11_marketPC.Database.Repositories;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmMonitor : Form, IViewMonitor
    {
        private MonitorRepository repository;
        private Monitor selectedMonitor;
        private PreMonitor presenter;
        private bool _isEditing;


        public string MaManHinh => throw new NotImplementedException();

        public string TenManHinh => throw new NotImplementedException();

        public string MaHSX => throw new NotImplementedException();

        public object txtKichthuoc { get; private set; }

        public FrmMonitor()
        {
            InitializeComponent();
            repository = new MonitorRepository();
            presenter = new PreMonitor(this, repository);
            dgvMonitor.CellClick += dgvMonitor_CellClick;
            LockTextBoxes(true);
        }

        private void FrmMonitor_Load(object sender, EventArgs e)
        {
            presenter.LoadMonitors();
        }

        public void UpdateMonitorList(List<Monitor> monitors)
        {
            dgvMonitor.DataSource = null;
            dgvMonitor.DataSource = monitors;
            dgvMonitor.Columns["MaManHinh"].HeaderText = "Mã Màn Hình";
            dgvMonitor.Columns["TenManHinh"].HeaderText = "Tên Màn Hình";
            dgvMonitor.Columns["MaHSX"].HeaderText = "Mã HSX";

            dgvMonitor.ReadOnly = true;

            dgvMonitor.Columns["MaManHinh"].Width = 100;
            dgvMonitor.Columns["TenManHinh"].Width = 150;
            dgvMonitor.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex == dgvMonitor.Columns["MaHSX"].Index && e.RowIndex >= 0)
                {
                    var monitor = dgvMonitor.Rows[e.RowIndex].DataBoundItem as Monitor;
                    e.Value = monitor?.MaHSX ?? "";
                }
            };
        }

        private void dgvMonitor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedMonitor = dgvMonitor.Rows[e.RowIndex].DataBoundItem as Monitor;
                if (selectedMonitor != null)
                {
                    txtMa.Text = selectedMonitor.MaManHinh ?? "";
                    txtTen.Text = selectedMonitor.TenManHinh ?? "";

                 txtHangSX.Text = selectedMonitor.MaHSX ?? "";
                }
            }
            else
            {
                ClearTextBoxes();
                selectedMonitor = null;
            }
        }
        private void LockTextBoxes(bool isLocked)
        {
            txtMa.ReadOnly = isLocked;
            txtTen.ReadOnly = isLocked;

            txtHangSX.ReadOnly = isLocked;
        }

        private void ClearTextBoxes()
        {
            txtMa.Text = "";
            txtTen.Text = "";

            txtHangSX.Text = "";
        }

        private void ResetValues()
        {
            ClearTextBoxes();
            _isEditing = false;
            LockTextBoxes(true);
        }

        private bool CheckTextBox()
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show("Mã Màn Hình không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMa.Focus();
                return false;
            }

            if (!txtMa.Text.StartsWith("MH", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mã Màn Hình phải bắt đầu bằng 'MH'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMa.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show("Tên Màn Hình không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return false;
            }





            if (string.IsNullOrWhiteSpace(txtHangSX.Text))
            {
                MessageBox.Show("Mã Hãng Sản Xuất không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHangSX.Focus();
                return false;
            }

            if (!txtHangSX.Text.StartsWith("HSX", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Mã Hãng Sản Xuất phải bắt đầu bằng 'HSX'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHangSX.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditing = false;
            ClearTextBoxes();
            LockTextBoxes(false);
            txtMa.Focus();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckTextBox())
                return;

            if (!repository.CheckForeignKeyExists("HangSanXuat", "MaHSX", txtHangSX.Text))
            {
                MessageBox.Show("Mã Hãng Sản Xuất không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHangSX.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn lưu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Monitor monitor = new Monitor
            {
                MaManHinh = txtMa.Text.Trim(),
                TenManHinh = txtTen.Text.Trim(),

                MaHSX = txtHangSX.Text.Trim()
            };

            try
            {
                if (!_isEditing)
                {
                    if (repository.CheckMaMonitorExists(monitor.MaManHinh))
                    {
                        MessageBox.Show("Mã Màn Hình đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    repository.Add(monitor);
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    repository.Update(monitor);
                    MessageBox.Show("Cập nhật thành công!");
                }

                presenter.LoadMonitors();
                ResetValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedMonitor == null || string.IsNullOrWhiteSpace(selectedMonitor.MaManHinh))
            {
                MessageBox.Show("Vui lòng chọn một Màn Hình để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _isEditing = true;
            LockTextBoxes(false);
            txtMa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMonitor == null || string.IsNullOrWhiteSpace(selectedMonitor.MaManHinh))
            {
                MessageBox.Show("Vui lòng chọn một Màn Hình để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa Màn Hình {selectedMonitor.MaManHinh}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    repository.Delete(selectedMonitor.MaManHinh);
                    MessageBox.Show("Xóa thành công!");
                    presenter.LoadMonitors();
                    ResetValues();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BTL_nhom11_marketPC.Database.DatabaseContext.CloseConnection();
                Application.Exit();
            }
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void UpdateMonitorList(List<Manufacturer> monitors)
        {
            throw new NotImplementedException();
        }

       

    }
}
