using BTL_nhom11_marketPC.Database;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreGraphicsCard
    {
        private readonly IGraphicsCardView _view;
        private readonly RelationshipMapper _mapper;
        private List<GraphicsCard> _allGraphicsCards;

        public PreGraphicsCard(IGraphicsCardView view)
        {
            _view = view;
            _mapper = new RelationshipMapper();

            // Gán các sự kiện từ giao diện
            _view.AddGraphicsCard += OnAddGraphicsCard;
            _view.UpdateGraphicsCard += OnUpdateGraphicsCard;
            _view.DeleteGraphicsCard += OnDeleteGraphicsCard;
            _view.SelectGraphicsCard += OnSelectGraphicsCard;

            // Tải danh sách card đồ họa ban đầu
            LoadGraphicsCards();
        }

        private void LoadGraphicsCards()
        {
            _allGraphicsCards = _mapper.GetGraphicsCard();
            _view.SetGraphicsCardList(_allGraphicsCards);
        }

        private void OnAddGraphicsCard(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(_view.MaCard) || string.IsNullOrEmpty(_view.TenCard))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Mã card, Tên card)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra độ dài các trường
            if (_view.MaCard.Length > 10)
            {
                MessageBox.Show("Mã card không được dài quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_view.TenCard.Length > 50)
            {
                MessageBox.Show("Tên card không được dài quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng GraphicsCard mới
            var newGraphicsCard = new GraphicsCard
            {
                MaCard = _view.MaCard,
                TenCard = _view.TenCard
            };

            // Thêm vào cơ sở dữ liệu
            if (_mapper.AddGraphicsCard(newGraphicsCard))
            {
                MessageBox.Show("Thêm card đồ họa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGraphicsCards();
                _view.ClearInputFields();
            }
            else
            {
                MessageBox.Show("Thêm card đồ họa thất bại! Mã card có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnUpdateGraphicsCard(object sender, EventArgs e)
        {
            if (_view.SelectedGraphicsCard == null)
            {
                MessageBox.Show("Vui lòng chọn một card đồ họa để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(_view.MaCard) || string.IsNullOrEmpty(_view.TenCard))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Mã card, Tên card)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra độ dài các trường
            if (_view.MaCard.Length > 10)
            {
                MessageBox.Show("Mã card không được dài quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_view.TenCard.Length > 50)
            {
                MessageBox.Show("Tên card không được dài quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng GraphicsCard với thông tin đã chỉnh sửa
            var updatedGraphicsCard = new GraphicsCard
            {
                MaCard = _view.MaCard,
                TenCard = _view.TenCard
            };

            // Cập nhật vào cơ sở dữ liệu
            if (_mapper.UpdateGraphicsCard(updatedGraphicsCard))
            {
                MessageBox.Show("Cập nhật card đồ họa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGraphicsCards();
                _view.ClearInputFields();
            }
            else
            {
                MessageBox.Show("Cập nhật card đồ họa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteGraphicsCard(object sender, EventArgs e)
        {
            if (_view.SelectedGraphicsCard == null)
            {
                MessageBox.Show("Vui lòng chọn một card đồ họa để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa card đồ họa {_view.SelectedGraphicsCard.TenCard} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Xóa khỏi cơ sở dữ liệu
            if (_mapper.DeleteGraphicsCard(_view.SelectedGraphicsCard.MaCard))
            {
                MessageBox.Show("Xóa card đồ họa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGraphicsCards();
                _view.ClearInputFields();
            }
            else
            {
                MessageBox.Show("Xóa card đồ họa thất bại! Card có thể đang được sử dụng trong máy tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSelectGraphicsCard(object sender, EventArgs e)
        {
            if (_view.SelectedGraphicsCard != null)
            {
                _view.MaCard = _view.SelectedGraphicsCard.MaCard;
                _view.TenCard = _view.SelectedGraphicsCard.TenCard;
            }
        }

        // Tìm kiếm card đồ họa theo Mã hoặc Tên
        public void SearchGraphicsCards(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                _view.SetGraphicsCardList(_allGraphicsCards);
                return;
            }

            var filteredGraphicsCards = _allGraphicsCards
                .Where(gc => gc.MaCard.ToLower().Contains(keyword.ToLower()) || gc.TenCard.ToLower().Contains(keyword.ToLower()))
                .ToList();

            _view.SetGraphicsCardList(filteredGraphicsCards);
        }
    }
}
