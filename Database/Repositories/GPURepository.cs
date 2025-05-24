using System.Collections.Generic;
using System.Linq;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Repositories;

namespace BTL_nhom11_marketPC.Database.Repositories
{
    public class GPURepository : GenericRepository<GPU>
    {
        public GPURepository() : base("GPU", "MaGPU") { }

        public new List<GPU> GetAll()
        {
            return GetAllWithForeignKey("HangSanXuat", "MaHSX", "MaHSX");
        }

        public bool CheckMaHSXExists(int maHSX)
        {
            return CheckForeignKeyExists("HangSanXuat", "MaHSX", maHSX);
        }
        public bool CheckGPUExists(string maGPU)
        {
            return CheckExists(maGPU);
        }
        public string GetNextGPU()
        {
            var gpus = GetAll();
            if (gpus == null || !gpus.Any())
            {
                return "GPU001";
            }

            var maxMaGPU = gpus
                .Select(m => m.MaGPU)
                .Where(m => m != null && m.StartsWith("GPU"))
                .OrderByDescending(m => int.Parse(m.Replace("GPU", "")))
                .FirstOrDefault();

            if (maxMaGPU == null)
            {
                return "GPU001";
            }

            int nextNumber = int.Parse(maxMaGPU.Replace("GPU", "")) + 1;
            return $"GPU{nextNumber:D3}";
        }
    }
}
