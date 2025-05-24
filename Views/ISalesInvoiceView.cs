using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface ISalesInvoiceView
    {
        // Thuộc tính để hiển thị danh sách hóa đơn bán
        List<SalesInvoice> SalesInvoices { set; }

        // Thuộc tính để lấy chi tiết hóa đơn bán được chọn
        SalesInvoice SelectedSalesInvoice { get; set; }

        string MaHDB { get; set; }
        string MaKhach { get; set; }
        string MaNV { get; set; }
        DateTime NgayBan { get; set; }
        decimal TongTien { get; set; }
        string TrangThaiDonHang { get; set; }

        // Phương thức để thiết lập dữ liệu cho các dropdown liên quan
        void SetCustomers(List<Customer> customers);
        void SetEmployees(List<Employee> employees);

        // Sự kiện cho các hành động của người dùng
        event EventHandler AddSalesInvoice;
        event EventHandler UpdateSalesInvoice;
        event EventHandler DeleteSalesInvoice;
        event EventHandler SelectSalesInvoice;

        void ClearInputFields();
    }
}
