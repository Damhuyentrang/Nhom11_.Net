using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface ISalesInvoiceDetailView
    {
        // Thuộc tính để lấy/gán giá trị từ giao diện
        string MaCTHDB { get; set; }
        string MaHDB { get; set; }
        string MaMay { get; set; }
        int SoLuong { get; set; }
        decimal GiaBan { get; set; }
        decimal ThanhTien { get; set; }
        string MaKhuyenMai { get; set; }
        decimal TongTien { get; set; }

        // Thuộc tính để hiển thị danh sách chi tiết hóa đơn bán
        List<SalesInvoiceDetail> SalesInvoiceDetails { set; }

        // Thuộc tính để lấy chi tiết hóa đơn bán được chọn
        SalesInvoiceDetail SelectedSalesInvoiceDetail { get; set; }

        // Phương thức để thiết lập dữ liệu cho các dropdown liên quan
//        void SetSalesInvoices(List<SalesInvoice> salesInvoices);
        void SetComputers(List<Computer> computers);
        void SetPromotions(List<Promotion> promotions);

        event EventHandler AddSalesInvoiceDetail; 
        event EventHandler UpdateSalesInvoiceDetail;
        event EventHandler DeleteSalesInvoiceDetail;
        event EventHandler SelectSalesInvoiceDetail;

        void ClearInputFields(); // Xóa các trường nhập liệu
    }
}
