using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface ViewPromotion
    {
        string MaKhuyenMai { get; }
        string TenKhuyenMai { get; }
        int PhanTramGiam { get; }
        DateTime NgayBatDau { get; }
        DateTime NgayKetThuc { get; }

        void SetPromotionList(List<Promotion> list); 
        void ShowMessage(string message);
    }
}