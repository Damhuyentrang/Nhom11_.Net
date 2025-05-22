using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using BTL_nhom11_marketPC.Models;

namespace BTL_nhom11_marketPC.Views
{
    public interface IViewManufacturer
    {
        string MaHSX { get; set; }
        string TenHSX { get; set; }

        void UpdateManufacturerList(IEnumerable<Manufacturer> manufacturers);
    
    }
}
