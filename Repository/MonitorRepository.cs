using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Repositories;


namespace BTL_nhom11_marketPC.Repositories
{
    using System.Collections.Generic;
    namespace BTL_nhom11_marketPC.Database.Repositories
    {
        public class MonitorRepository : GenericRepository<Monitor>
        {
            public MonitorRepository() : base("ManHinh", "MaManHinh") { }

            // Trả về tất cả màn hình kèm tên hãng sản xuất
            public new List<Monitor> GetAll()
            {
                return GetAllWithForeignKey("HangSanXuat", "MaHSX", "TenHSX");
            }

            // Kiểm tra mã hãng sản xuất có tồn tại không
            public bool CheckMaHSXExists(int maHSX)
            {
                return CheckForeignKeyExists("HangSanXuat", "MaHSX", maHSX);
            }

            // Kiểm tra mã màn hình có tồn tại không
            public bool CheckMaManHinhExists(string maManHinh)
            {
                return CheckExists(maManHinh);
            }
        }
    }
}
