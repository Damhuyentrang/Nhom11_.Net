using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface ViewSupplier
    {
        string MaNCC { get; set; }
        string TenNCC { get; set; }
        string DiaChi { get; set; }
        string SoDienThoai { get; set; }
        string Email { get; set; }

        void SetSupplierList(List<Supplier> suppliers);
        void ShowMessage(string message);
    }
}
