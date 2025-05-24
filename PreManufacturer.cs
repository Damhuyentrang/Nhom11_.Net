using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreManufacturer
    {
        private readonly IViewManufacturer view;
        private readonly IRepository<Manufacturer> repository;

        public PreManufacturer(IViewManufacturer view, IRepository<Manufacturer> repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void LoadManufacturers()
        {
            var manufacturers = repository.GetAll();
            view.UpdateManufacturerList(manufacturers);
        }
    }
}
