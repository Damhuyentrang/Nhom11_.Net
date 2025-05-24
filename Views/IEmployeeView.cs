using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface IEmployeeView
    {
        // Thuộc tính để lấy/gán giá trị từ giao diện
        string MaNV { get; set; }
        string TenNV { get; set; }
        DateTime NgaySinh { get; set; }
        string GioiTinh { get; set; }
        string DiaChi { get; set; }
        string SoDienThoai { get; set; }
        string VaiTro {  get; set; }

        string Username {  get; set; }
        string MatKhau { get; set; }

        // Thuộc tính để hiển thị danh sách nhân viên
        List<Employee> Employees { set; }

        // Thuộc tính để lấy nhân viên được chọn
        Employee SelectedEmployee { get; set; }


        // Sự kiện cho các hành động của người dùng
        event EventHandler AddEmployee;
        event EventHandler UpdateEmployee;
        event EventHandler DeleteEmployee;
        event EventHandler SelectEmployee;

        // Phương thức để xóa dữ liệu nhập trên giao diện
        void ClearInputFields();
    }
}
