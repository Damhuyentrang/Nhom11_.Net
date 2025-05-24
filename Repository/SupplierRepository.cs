using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Repositories;
using global::BTL_nhom11_marketPC.Models;
using global::BTL_nhom11_marketPC.Repositories;

namespace BTL_nhom11_marketPC.Database.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>
    {
        public SupplierRepository() : base("NhaCungCap", "MaNCC") { }

        // Lấy tất cả nhà cung cấp
        public new List<Supplier> GetAll()
        {
            return base.GetAll(); // Không cần join vì không có khóa ngoại
        }

        // Kiểm tra mã nhà cung cấp đã tồn tại chưa
        public bool CheckMaNCCExists(int maNCC)
        {
            return CheckExists(maNCC);
        }
    }
}