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
    public class PreRAM
    {
        private readonly IViewRAM view;
        private readonly IRepository<RAM> repository;

        public PreRAM(IViewRAM view, IRepository<RAM> repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void LoadRAMs()
        {
            var rams = repository.GetAll();
            view.UpdateRAMList(rams);
        }
    }
}
