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
    public class PreHardDrive
    {
        private readonly IHardDriveView _view;
        private readonly RelationshipMapper _mapper;
        private List<HardDrive> _allHardDrives;

        public PreHardDrive(IHardDriveView view)
        {
            _view = view;
            _mapper = new RelationshipMapper();

            _view.AddHardDrive += AddHardDriveHandler;
            _view.UpdateHardDrive += UpdateHardDriveHandler;
            _view.DeleteHardDrive += DeleteHardDriveHandler;
            _view.SelectHardDrive += SelectHardDriveHandler;

            // Tải danh sách ổ cứng ban đầu
            LoadHardDrives();
        }
        private void LoadHardDrives()
        {
            _allHardDrives = _mapper.GetHardDrived();
            _view.SetHardDriveList(_allHardDrives);
        }
        private void AddHardDriveHandler(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(_view.MaOCung) || string.IsNullOrEmpty(_view.TenOCung) || string.IsNullOrEmpty(_view.LoaiOCung))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Mã ổ cứng, Tên ổ cứng, Loại ổ cứng)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_view.DungLuong <= 0)
            {
                MessageBox.Show("Dung lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra độ dài các trường
            if (_view.MaOCung.Length > 10)
            {
                MessageBox.Show("Mã ổ cứng không được dài quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_view.TenOCung.Length > 50)
            {
                MessageBox.Show("Tên ổ cứng không được dài quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_view.MoTa != null && _view.MoTa.Length > 255)
            {
                MessageBox.Show("Mô tả không được dài quá 255 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng HardDrive mới
            HardDrive newHardDrive = new HardDrive
            {
                MaOCung = _view.MaOCung,
                TenOCung = _view.TenOCung,
                LoaiOCung = _view.LoaiOCung,
                DungLuong = _view.DungLuong,
                MoTa = _view.MoTa ?? ""
            };

            // Thêm vào cơ sở dữ liệu
            if (_mapper.AddHardDrive(newHardDrive))
            {
                MessageBox.Show("Thêm ổ cứng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHardDrives(); // Làm mới danh sách
                _view.ClearInputFields(); // Xóa các trường nhập liệu
            }
            else
            {
                MessageBox.Show("Thêm ổ cứng thất bại! Mã ổ cứng có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện sửa ổ cứng
        private void UpdateHardDriveHandler(object sender, EventArgs e)
        {
            if (_view.SelectedHardDrive == null)
            {
                MessageBox.Show("Vui lòng chọn một ổ cứng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(_view.MaOCung) || string.IsNullOrEmpty(_view.TenOCung) || string.IsNullOrEmpty(_view.LoaiOCung))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Mã ổ cứng, Tên ổ cứng, Loại ổ cứng)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_view.DungLuong <= 0)
            {
                MessageBox.Show("Dung lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra độ dài các trường
            if (_view.MaOCung.Length > 10)
            {
                MessageBox.Show("Mã ổ cứng không được dài quá 10 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_view.TenOCung.Length > 50)
            {
                MessageBox.Show("Tên ổ cứng không được dài quá 50 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_view.MoTa != null && _view.MoTa.Length > 255)
            {
                MessageBox.Show("Mô tả không được dài quá 255 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng HardDrive với thông tin đã chỉnh sửa
            HardDrive updatedHardDrive = new HardDrive
            {
                MaOCung = _view.MaOCung,
                TenOCung = _view.TenOCung,
                LoaiOCung = _view.LoaiOCung,
                DungLuong = _view.DungLuong,
                MoTa = _view.MoTa ?? ""
            };

            // Cập nhật vào cơ sở dữ liệu
            if (_mapper.UpdateHardDrive(updatedHardDrive))
            {
                MessageBox.Show("Cập nhật ổ cứng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHardDrives();
                _view.ClearInputFields();
            }
            else
            {
                MessageBox.Show("Cập nhật ổ cứng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện xóa ổ cứng
        private void DeleteHardDriveHandler(object sender, EventArgs e)
        {
            if (_view.SelectedHardDrive == null)
            {
                MessageBox.Show("Vui lòng chọn một ổ cứng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa ổ cứng {_view.SelectedHardDrive.TenOCung} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            // Xóa khỏi cơ sở dữ liệu
            if (_mapper.DeleteHardDrive(_view.SelectedHardDrive.MaOCung))
            {
                MessageBox.Show("Xóa ổ cứng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHardDrives(); 
                _view.ClearInputFields(); 
            }
            else
            {
                MessageBox.Show("Xóa ổ cứng thất bại! Ổ cứng có thể đang được sử dụng trong máy tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện chọn ổ cứng
        private void SelectHardDriveHandler(object sender, EventArgs e)
        {
            if (_view.SelectedHardDrive != null)
            {
                _view.MaOCung = _view.SelectedHardDrive.MaOCung;
                _view.TenOCung = _view.SelectedHardDrive.TenOCung;
                _view.LoaiOCung = _view.SelectedHardDrive.LoaiOCung;
                _view.DungLuong = _view.SelectedHardDrive.DungLuong;
                _view.MoTa = _view.SelectedHardDrive.MoTa;
            }
        }

        // Tìm kiếm ổ cứng theo Mã hoặc Tên
        public void SearchHardDrives(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                _view.SetHardDriveList(_allHardDrives); // Hiển thị toàn bộ danh sách nếu không có từ khóa
                return;
            }

            var filteredHardDrives = _allHardDrives
                .Where(hd => hd.MaOCung.ToLower().Contains(keyword.ToLower()) || hd.TenOCung.ToLower().Contains(keyword.ToLower()))
                .ToList();

            _view.SetHardDriveList(filteredHardDrives);
        }
    }
}
