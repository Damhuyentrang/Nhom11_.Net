using System.Collections.Generic;
using System.Linq;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Repositories;

namespace BTL_nhom11_marketPC.Database.Repositories
{
    public class CPURepository : GenericRepository<CPU>
    {
        public CPURepository() : base("CPU", "MaCPU") { }

        public new List<CPU> GetAll()
        {
            return GetAllWithForeignKey("HangSanxuat", "MaHSX", "MaHSX");
        }

        public bool CheckMaHSXExists(int maHSX)
        {
            return CheckForeignKeyExists("HangSanXuat", "MaHSX", maHSX);
        }
        public bool CheckMaCPUExists(string maCPU)
        {
            return CheckExists(maCPU);
        }
        public string GetNextCPU()
        {
            var cpus = GetAll();
            if (cpus == null || !cpus.Any())
            {
                return "CPU001"; 
            }

            var maxMaCPU = cpus
                .Select(m => m.MaCPU)
                .Where(m => m != null && m.StartsWith("CPU"))
                .OrderByDescending(m => int.Parse(m.Replace("CPU", "")))
                .FirstOrDefault();

            if (maxMaCPU == null)
            {
                return "CPU001";
            }

            int nextNumber = int.Parse(maxMaCPU.Replace("CPU", "")) + 1;
            return $"CPU{nextNumber:D3}"; 
        }

    }
}
