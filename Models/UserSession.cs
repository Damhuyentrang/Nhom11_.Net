using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_nhom11_marketPC.Models
{
    public static class UserSession
    {
        public static Employee CurrentUser { get; set; }

        public static void ClearSession()
        {
            CurrentUser = null;
        }
    }
}
