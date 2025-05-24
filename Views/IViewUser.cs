using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface IViewUser
    {
        string MaNV { get; set; }
        string TenNV { get; set; }
        DateTime NgaySinh { get; set; }
        string GioiTinh { get; set; }
        string DiaChi { get; set; }
        string SoDienThoai { get; set; }
        string VaiTro { get; set; }

        string Username { get; set; }
        Employee SelectedEmployee { get; set; }

        event EventHandler UpdateEmployee;
    }
}
