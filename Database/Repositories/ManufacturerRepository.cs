using System.Collections.Generic;
using System.Linq;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Repositories;

namespace BTL_nhom11_marketPC.Database.Repositories
{
    public class ManufacturerRepository : GenericRepository<Manufacturer>
    {
        public ManufacturerRepository() : base("HangSanXuat", "MaHSX") { }
        public bool CheckManufacturerExists(string maHSX)
        {
            return CheckExists(maHSX);
        }
        public new List<Manufacturer> GetAll()
        {
            return base.GetAll();
        }
        public string GetNextMaHSX()
        {
            var manufacturers = GetAll();
            if (manufacturers == null || !manufacturers.Any())
            {
                return "HSX001"; // Bắt đầu từ HSX001 nếu danh sách rỗng
            }

            var maxMaHSX = manufacturers
                .Select(m => m.MaHSX)
                .Where(m => m != null && m.StartsWith("HSX"))
                .OrderByDescending(m => int.Parse(m.Replace("HSX", "")))
                .FirstOrDefault();

            if (maxMaHSX == null)
            {
                return "HSX001";
            }

            int nextNumber = int.Parse(maxMaHSX.Replace("HSX", "")) + 1;
            return $"HSX{nextNumber:D3}"; // Định dạng 3 chữ số (HSX001, HSX002, ...)
        }
    }


}
