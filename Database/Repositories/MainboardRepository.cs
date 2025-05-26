using System.Collections.Generic;
using System.Linq;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Repositories;

namespace BTL_nhom11_marketPC.Database.Repositories
{
    public class MainboardRepository : GenericRepository<Mainboard>
    {
        public MainboardRepository() : base("Mainboard", "MaMainboard") { }

        public new List<Mainboard> GetAll()
        {
            return GetAllWithForeignKey("HangSanXuat", "MaHSX", "MaHSX");
        }

        public bool CheckMaHSXExists(string maHSX)
        {
            return CheckForeignKeyExists("HangSanXuat", "MaHSX", maHSX);
        }
        public bool CheckMainboardExists(string maMainboard)
        {
            return CheckExists(maMainboard);
        }
        public string GetNextMaMainboard()
        {
            var mainboards = GetAll();
            if (mainboards == null || !mainboards.Any())
            {
                return "MB001"; // Bắt đầu từ MB001 nếu danh sách rỗng
            }

            var maxMaMainboard = mainboards
                .Select(m => m.MaMainboard)
                .Where(m => m != null && m.StartsWith("MB"))
                .OrderByDescending(m => int.Parse(m.Replace("MB", "")))
                .FirstOrDefault();

            if (maxMaMainboard == null)
            {
                return "MB001";
            }

            int nextNumber = int.Parse(maxMaMainboard.Replace("MB", "")) + 1;
            return $"MB{nextNumber:D3}"; // Định dạng 3 chữ số (MB001, MB002, ...)
        }
    }
}
