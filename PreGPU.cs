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
    public class PreGPU
    {
        private readonly IViewGPU view;
        private readonly IRepository<GPU> repository;

        public PreGPU(IViewGPU view, IRepository<GPU> repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void LoadGPUs()
        {
            var gpus = repository.GetAll();
            view.UpdateGPUList(gpus);
        }
    }
}
