using System;
using System.Collections.Generic;
using BTL_nhom11_marketPC.Models;

namespace BTL_nhom11_marketPC.Views
{
    public interface IViewPromotion
    {
        // Thuộc tính cần thiết để thêm khuyến mãi
        string MaKhuyenMai { get; }
        string TenKhuyenMai { get; }
        int PhanTramGiam { get; }
        DateTime NgayBatDau { get; }
        DateTime NgayKetThuc { get; }

        // Cập nhật danh sách khuyến mãi trong view
        void SetPromotionList(List<IViewPromotion> promotions);
        void SetPromotionList(List<Promotion> promotionList);

        // Hiển thị thông báo
        void ShowMessage(string message);
    }
}