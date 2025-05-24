using System.Collections.Generic;
using BTL_nhom11_marketPC.Models;

namespace BTL_nhom11_marketPC.Views
{
    public interface IViewMonitor
    {
        // Thuộc tính đầu vào (được binding từ Form)
        string MaManHinh { get; }
        string TenManHinh { get; }
        string DoPhanGiai { get; }
        string KichThuoc { get; }
        string MaHSX { get; }

        // Hiển thị danh sách
        void UpdateMonitorList(List<Monitor> monitors);

        // Hiển thị thông báo
        void ShowMessage(string message);
        void UpdateMonitorList(List<Manufacturer> monitors);
    }
}
