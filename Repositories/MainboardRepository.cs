using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool CheckMaHSXExists(int maHSX)
        {
            return CheckForeignKeyExists("HangSanXuat", "MaHSX", maHSX);
        }
        public bool CheckMainboardExists(string maMainboard)
        {
            return CheckExists(maMainboard);
        }
    }
}
