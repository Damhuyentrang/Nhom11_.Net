using BTL_nhom11_marketPC.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Views
{
    public interface ILoginView
    {
        string Username { get; }
        string Password { get; }
        bool ShowPassword { get; set; }
        void ShowMessage(string message, string title, MessageBoxIcon icon);
        void NavigateToMainMenu();
        void ClearFields();
        void SetPresenter(PreLogin presenter);
    }
}
