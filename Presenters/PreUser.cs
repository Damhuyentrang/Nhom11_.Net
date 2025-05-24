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
    public class PreUser
    {
        private readonly IViewUser _view;
        private readonly RelationshipMapper _mapper;

        public PreUser(IViewUser view)
        {
            _view = view;
            _mapper = DatabaseContext.RelationshipMapper;

            _view.UpdateEmployee += UpdateEmployeeHandler;

            LoadUserInfo();
        }

        // Hiển thị thông tin người đăng nhập
        public void LoadUserInfo()
        {
            if (UserSession.CurrentUser == null)
            {
                MessageBox.Show("Không tìm thấy thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Employee currentUser = UserSession.CurrentUser;
            _view.MaNV = currentUser.MaNV;
            _view.TenNV = currentUser.TenNV;
            _view.NgaySinh = currentUser.NgaySinh;
            _view.GioiTinh = currentUser.GioiTinh;
            _view.DiaChi = currentUser.DiaChi;
            _view.SoDienThoai = currentUser.SoDienThoai;
            _view.VaiTro = currentUser.VaiTro;
            _view.Username = currentUser.Username;
        }
        private void UpdateEmployeeHandler(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_view.TenNV) || string.IsNullOrEmpty(_view.SoDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra định dạng số điện thoại
            if (!IsValidPhoneNumber(_view.SoDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập số điện thoại chỉ chứa chữ số.", "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ngày sinh
            if (_view.NgaySinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được trong tương lai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo đối tượng Employee từ thông tin trên giao diện
            Employee updatedEmployee = new Employee
            {
                MaNV = _view.MaNV, // Không cho phép chỉnh sửa
                TenNV = _view.TenNV,
                NgaySinh = _view.NgaySinh,
                GioiTinh = _view.GioiTinh,
                DiaChi = _view.DiaChi,
                SoDienThoai = _view.SoDienThoai,
                VaiTro = _view.VaiTro, // Không cho phép chỉnh sửa
                Username = _view.Username,
                MatKhau = UserSession.CurrentUser.MatKhau // Giữ nguyên mật khẩu cũ
            };

            if (_mapper.UpdateInfo(updatedEmployee))
            {
                // Cập nhật lại UserSession
                UserSession.CurrentUser = updatedEmployee;
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý đổi mật khẩu
        public void ChangePassword()
        {
            using (Form changePasswordForm = new Form())
            {
                changePasswordForm.Text = "Đổi Mật Khẩu";
                changePasswordForm.Size = new System.Drawing.Size(300, 200);
                changePasswordForm.StartPosition = FormStartPosition.CenterParent;

                Label lblNewPassword = new Label { Text = "Mật khẩu mới:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
                TextBox txtNewPassword = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 150, PasswordChar = '*' };
                Label lblConfirmPassword = new Label { Text = "Xác nhận mật khẩu:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
                TextBox txtConfirmPassword = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 150, PasswordChar = '*' };
                Button btnConfirm = new Button { Text = "Xác nhận", Location = new System.Drawing.Point(120, 100), Width = 80 };

                changePasswordForm.Controls.AddRange(new Control[] { lblNewPassword, txtNewPassword, lblConfirmPassword, txtConfirmPassword, btnConfirm });

                btnConfirm.Click += (s, e) =>
                {
                    string newPassword = txtNewPassword.Text;
                    string confirmPassword = txtConfirmPassword.Text;

                    if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu mới và xác nhận mật khẩu!", "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (newPassword != confirmPassword)
                    {
                        MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (newPassword.Length > 72)
                    {
                        MessageBox.Show("Mật khẩu không được dài quá 72 ký tự!", "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Mã hóa mật khẩu mới
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

                    // Cập nhật mật khẩu trong cơ sở dữ liệu
                    if (_mapper.UpdateAccount(UserSession.CurrentUser.MaNV, UserSession.CurrentUser.Username, hashedPassword))
                    {
                        // Cập nhật lại UserSession
                        UserSession.CurrentUser.MatKhau = hashedPassword;
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changePasswordForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                changePasswordForm.ShowDialog();
            }
        }

        // Phương thức kiểm tra định dạng số điện thoại
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string cleanedNumber = new string(phoneNumber.Where(char.IsDigit).ToArray());
            return cleanedNumber.Length >= 10 && cleanedNumber.Length <= 15 && !string.IsNullOrEmpty(cleanedNumber);
        }
    }
}
