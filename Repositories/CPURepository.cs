using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Repositories;

namespace BTL_nhom11_marketPC.Database.Repositories
{
    public class CPURepository : GenericRepository<CPU>
    {
        public CPURepository() : base("CPU", "MaCPU") { }

        public new List<CPU> GetAll()
        {
            return GetAllWithForeignKey("HangSanXuat", "MaHSX", "MaHSX");
        }

        public bool CheckMaHSXExists(int maHSX)
        {
            return CheckForeignKeyExists("HangSanXuat", "MaHSX", maHSX);
        }
        public bool CheckMaCPUExists(string maCPU)
        {
            return CheckExists(maCPU);
        }
    }
}
