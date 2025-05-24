using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface ICustomerView
    {
        // Thuộc tính để lấy/gán giá trị từ giao diện
        string MaKhach { get; set; }
        string TenKhach { get; set; }
        string GioiTinh { get; set; }
        DateTime NgaySinh { get; set; }
        string SoDienThoai { get; set; }
        string DiaChi { get; set; }
        string Email { get; set; }

        // Thuộc tính để hiển thị danh sách khách hàng
        List<Customer> Customers { set; }

        // Thuộc tính để lấy khách hàng được chọn
        Customer SelectedCustomer { get; set; }


        // Sự kiện cho các hành động của người dùng
        event EventHandler AddCustomer;
        event EventHandler UpdateCustomer;
        event EventHandler DeleteCustomer;
        event EventHandler SelectCustomer;

        // Phương thức để xóa dữ liệu nhập trên giao diện
        void ClearInputFields();
    }
}
