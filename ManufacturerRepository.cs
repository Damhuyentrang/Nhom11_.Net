using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Repositories;
namespace BTL_nhom11_marketPC.Database.Repositories
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>
    {
        public ManufacturerRepository() : base("HangSanXuat", "MaHSX") { }

        // Lấy tất cả các hãng sản xuất
        public new List<Manufacturer> GetAll()
        {
            return base.GetAll(); // Không cần join vì bảng này không có khóa ngoại
        }

        // Kiểm tra mã hãng sản xuất đã tồn tại chưa
        public bool CheckMaHSXExists(int maHSX)
        {
            return CheckExists(maHSX);
        }
    }
}