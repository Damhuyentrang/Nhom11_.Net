using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Repositories;
using global::BTL_nhom11_marketPC.Models;
using global::BTL_nhom11_marketPC.Repositories;

namespace BTL_nhom11_marketPC.Database.Repositories
{
    public class PromotionRepository : GenericRepository<Promotion>
    {
        public PromotionRepository() : base("KhuyenMai", "MaKhuyenMai") { }

        // Trả về tất cả khuyến mãi (có thể mở rộng với join bảng khác nếu cần)
        public new List<Promotion> GetAll()
        {
            return base.GetAll();
        }

        // Kiểm tra mã khuyến mãi có tồn tại không
        public bool CheckMaKhuyenMaiExists(string maKhuyenMai)
        {
            return CheckExists(maKhuyenMai);
        }
    }
}
