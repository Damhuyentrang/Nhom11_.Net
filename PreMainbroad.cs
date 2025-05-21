using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Database;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreMainbroad
    {
        private readonly IViewMainboard view;
        private readonly IRepository<Mainboard> repository;

        public PreMainbroad(IViewMainboard view, IRepository<Mainboard> repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void LoadMainboards()
        {
            var mainboards = repository.GetAll();
            view.UpdateMainboardList(mainboards);
        }
    }
}