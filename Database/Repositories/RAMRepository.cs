using System.Collections.Generic;
using System.Linq;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Repositories;

namespace BTL_nhom11_marketPC.Database.Repositories
{
    public class RAMRepository : GenericRepository<RAM>
    {
        public RAMRepository() : base("RAM", "MaRAM") { }

        public new List<RAM> GetAll()
        {
            return GetAllWithForeignKey("HangSanXuat", "MaHSX", "MaHSX");
        }

        public bool CheckMaHSXExists(int maHSX)
        {
            return CheckForeignKeyExists("HangSanXuat", "MaHSX", maHSX);
        }
        public bool CheckRAMExists(string maRAM)
        {
            return CheckExists(maRAM);
        }
        public string GetNextRAM()
        {
            var rams = GetAll();
            if (rams == null || !rams.Any())
            {
                return "RAM001";
            }

            var maxMaRAM = rams
                .Select(m => m.MaRAM)
                .Where(m => m != null && m.StartsWith("RAM"))
                .OrderByDescending(m => int.Parse(m.Replace("RAM", "")))
                .FirstOrDefault();

            if (maxMaRAM == null)
            {
                return "RAM001";
            }

            int nextNumber = int.Parse(maxMaRAM.Replace("RAM", "")) + 1;
            return $"RAM{nextNumber:D3}";
        }
    }
}
