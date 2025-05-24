using System.Collections.Generic;
using BTL_nhom11_marketPC.Models;

namespace BTL_nhom11_marketPC.Views
{
    public interface IViewCPU
    {
        void UpdateCPUList(List<CPU> CPUs);
        void UpdateHSXList(List<Manufacturer> manufacturers); // Thêm để cập nhật cboHSX
        void ShowError(string message);
    }
}
