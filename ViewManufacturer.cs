
﻿using System.Collections.Generic;
using BTL_nhom11_marketPC.Models;

namespace BTL_nhom11_marketPC.Views
{
    public interface IViewManufacturer
    {
        void UpdateManufacturerList(List<Manufacturer> manufacturers);
        void ShowError(string message);
    }
}
