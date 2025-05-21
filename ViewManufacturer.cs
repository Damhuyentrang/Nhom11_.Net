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
    public interface ManufacturerView
    {
        string ManufacturerID { get; set; }
        string ManufacturerName { get; set; }

        void SetManufacturerList(List<Manufacturer> manufacturers);
        void ShowMessage(string message);
    }
}