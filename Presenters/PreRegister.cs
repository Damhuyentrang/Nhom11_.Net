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
    public class PreRegister
    {
        private readonly IRegisterView _view;
        private readonly RelationshipMapper _mapper;

        public PreRegister(IRegisterView view)
        {
            _view = view;
            _mapper = DatabaseContext.RelationshipMapper;
        }

        public void Register()
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(_view.TenNV) || string.IsNullOrEmpty(_view.SoDienThoai) ||
                string.IsNullOrEmpty(_view.Username) || string.IsNullOrEmpty(_view.Password))
            {
                _view.ShowMessage("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxIcon.Warning);
                return;
            }

            if (_view.Password != _view.ConfirmPassword)
            {
                _view.ShowMessage("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số điện thoại
            if (!IsValidPhoneNumber(_view.SoDienThoai))
            {
                _view.ShowMessage("Số điện thoại không hợp lệ! Vui lòng nhập số điện thoại chỉ chứa chữ số.", "Lỗi", MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra độ dài các trường
            if (_view.TenNV.Length > 50)
            {
                _view.ShowMessage("Tên nhân viên không được dài quá 50 ký tự!", "Lỗi", MessageBoxIcon.Warning);
                return;
            }
            if (_view.Username.Length > 50)
            {
                _view.ShowMessage("Tên đăng nhập không được dài quá 50 ký tự!", "Lỗi", MessageBoxIcon.Warning);
                return;
            }
            if (_view.Password.Length > 255)
            {
                _view.ShowMessage("Mật khẩu không được dài quá 255 ký tự!", "Lỗi", MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ngày sinh
            if (_view.NgaySinh > DateTime.Now)
            {
                _view.ShowMessage("Ngày sinh không được trong tương lai!", "Lỗi", MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(_view.Password);

            Employee newEmployee = new Employee
            {
                MaNV = GenerateNewMaNV(),
                TenNV = _view.TenNV,
                NgaySinh = _view.NgaySinh,
                GioiTinh = _view.GioiTinh,
                DiaChi = _view.DiaChi,
                SoDienThoai = _view.SoDienThoai,
                Username = _view.Username,
                MatKhau = hashedPassword
            };

            if (_mapper.RegisterEmployee(newEmployee))
            {
                _view.ShowMessage("Đăng ký thành công!", "Thông báo", MessageBoxIcon.Information);
                _view.ClearFields();
                _view.NavigateToLogin();
            }
            else
            {
                _view.ShowMessage("Mã nhân viên hoặc tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxIcon.Error);
            }
        }
        private string GenerateNewMaNV()
        {
            // Lấy ngày và tháng hiện tại theo định dạng ddMM
            string dayMonth = DateTime.Now.ToString("ddMM");
            string prefix = $"NV{dayMonth}_";

            // Lấy danh sách mã nhân viên hiện có
            var employees = _mapper.GetEmployees();

            if (employees == null || !employees.Any())
            {
                return $"{prefix}001";
            }

            // Lọc các mã nhân viên có cùng ngày + tháng
            var todayEmployees = employees
                .Where(emp => emp.MaNV.StartsWith(prefix))
                .ToList();

            if (!todayEmployees.Any())
            {
                return $"{prefix}001";
            }

            // Lấy số thứ tự lớn nhất của mã hiện tại
            int maxNumber = todayEmployees
                .Select(emp => int.Parse(emp.MaNV.Substring(prefix.Length)))
                .Max();

            return $"{prefix}{(maxNumber + 1):D3}";
        }
        // Phương thức kiểm tra định dạng số điện thoại
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Loại bỏ các ký tự không phải số
            string cleanedNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());

            // Kiểm tra độ dài sau khi loại bỏ ký tự không phải số
            if (cleanedNumber.Length < 10 || cleanedNumber.Length > 15)
            {
                return false;
            }

            // Đảm bảo không rỗng sau khi làm sạch
            return !string.IsNullOrEmpty(cleanedNumber);
        }

    }
}
