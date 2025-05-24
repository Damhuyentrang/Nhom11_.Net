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
    public class PreLogin
    {
        private readonly ILoginView _view;
        private readonly RelationshipMapper _mapper;

        public PreLogin(ILoginView view)
        {
            _view = view;
            _mapper = DatabaseContext.RelationshipMapper;
        }

        public void Login()
        {
            string username = _view.Username;
            string password = _view.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                _view.ShowMessage("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu", "Lỗi", MessageBoxIcon.Error);
                return;
            }

            var employees = _mapper.GetEmployees();
            var employee = employees.FirstOrDefault(emp => emp.Username == username);

            if (employee == null)
            {
                _view.ShowMessage("Tên đăng nhập không tồn tại!", "Lỗi", MessageBoxIcon.Error);
                return;
            }

            if (BCrypt.Net.BCrypt.Verify(password, employee.MatKhau))
            {
                UserSession.CurrentUser = employee;
                _view.NavigateToMainMenu();
            }
            else
            {
                _view.ShowMessage("Mật khẩu không đúng!", "Lỗi", MessageBoxIcon.Error);
            }
        }
    }
}
