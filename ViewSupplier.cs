using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Views
{
    public interface ViewSupplier
    {
        string SupplierID { get; set; }
        string SupplierName { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }

        void SetSupplierList(List<Supplier> suppliers);
        void ShowMessage(string message);
    }
}
