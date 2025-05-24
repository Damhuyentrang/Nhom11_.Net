using BTL_nhom11_marketPC.Forms;
using BTL_nhom11_marketPC.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Views
{
    public interface IRegisterView
    {
        string TenNV { get; }
        DateTime NgaySinh { get; }
        string GioiTinh { get; }
        string DiaChi { get; }
        string SoDienThoai { get; }     
        string Username { get; }
        string Password { get; }
        string ConfirmPassword { get; }
        void ShowMessage(string message, string title, MessageBoxIcon icon);
        void ClearFields();
        void SetPresenter(PreRegister presenter);
        void NavigateToLogin();
    }
}
