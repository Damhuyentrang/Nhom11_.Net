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
    public partial class FrmGraphicsCard : Form, IGraphicsCardView
    {
        private PreGraphicsCard _presenter;
        private List<GraphicsCard> _graphicsCards;
        private bool _isEditMode = false;

        public FrmGraphicsCard()
        {
            InitializeComponent();
            _presenter = new PreGraphicsCard(this);
            this.WindowState = FormWindowState.Maximized;
        }

        public List<GraphicsCard> GraphicsCards
        {
            set => dgridDSCard.DataSource = value;
        }

        public GraphicsCard SelectedGraphicsCard
        {
            get => dgridDSCard.CurrentRow?.DataBoundItem as GraphicsCard;
            set { }
        }

        public string MaCard { get => txtMaCard.Text; set => txtMaCard.Text = value; }
        public string TenCard { get => txtTenCard.Text; set => txtTenCard.Text = value; }

        public void SetGraphicsCardList(List<GraphicsCard> graphicsCards)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<List<GraphicsCard>>(SetGraphicsCardList), graphicsCards);
                return;
            }
            _graphicsCards = graphicsCards;
            dgridDSCard.DataSource = null;
            dgridDSCard.Columns.Clear();
            dgridDSCard.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colMaCard = new DataGridViewTextBoxColumn();
            colMaCard.HeaderText = "Mã Card";
            colMaCard.DataPropertyName = "MaCard";
            colMaCard.Width = 100;
            dgridDSCard.Columns.Add(colMaCard);

            DataGridViewTextBoxColumn colTenCard = new DataGridViewTextBoxColumn();
            colTenCard.HeaderText = "Tên Card";
            colTenCard.DataPropertyName = "TenCard";
            colTenCard.Width = 150;
            dgridDSCard.Columns.Add(colTenCard);

            dgridDSCard.DataSource = graphicsCards;
            dgridDSCard.AllowUserToAddRows = false;
            dgridDSCard.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public event EventHandler AddGraphicsCard;
        public event EventHandler UpdateGraphicsCard;
        public event EventHandler DeleteGraphicsCard;
        public event EventHandler SelectGraphicsCard;

        public void ClearInputFields()
        {
            txtMaCard.Clear();
            txtTenCard.Clear();
            txtSearch.Clear();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            _isEditMode = false;
            txtMaCard.Enabled = true;
        }

        private void FrmGraphicsCard_Load(object sender, EventArgs e)
        {
            ClearInputFields();
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtMaCard.Enabled = false;
        }

        private void dgridDSCard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgridDSCard.Rows.Count)
            {
                SelectGraphicsCard?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isEditMode = false;
            ClearInputFields();
            txtMaCard.Enabled = true;
            txtTenCard.Enabled = true;
            txtTenCard.Focus();
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgridDSCard.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một card đồ họa để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isEditMode = true;
            txtMaCard.Enabled = false; // Không cho phép sửa mã card
            txtTenCard.Enabled = true;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgridDSCard.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một card đồ họa để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa card đồ họa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteGraphicsCard?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                if (_isEditMode)
                {
                    UpdateGraphicsCard?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    AddGraphicsCard?.Invoke(this, EventArgs.Empty);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.SearchGraphicsCards(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _presenter.SearchGraphicsCards(txtSearch.Text);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaCard.Text))
            {
                MessageBox.Show("Mã card không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenCard.Text))
            {
                MessageBox.Show("Tên card không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMaCard.Text.Length > 10)
            {
                MessageBox.Show("Mã card không được dài quá 10 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtTenCard.Text.Length > 50)
            {
                MessageBox.Show("Tên card không được dài quá 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

    }
}