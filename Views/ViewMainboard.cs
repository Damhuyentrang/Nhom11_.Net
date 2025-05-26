using System.Collections.Generic;
using BTL_nhom11_marketPC.Models;

namespace BTL_nhom11_marketPC.Views
{
    public interface IViewMainboard
    {
        void UpdateMainboardList(List<Mainboard> mainboards);
        void UpdateHSXList(List<Manufacturer> manufacturers); // Thêm để cập nhật cboHSX
        void ShowError(string message);
    }
}
