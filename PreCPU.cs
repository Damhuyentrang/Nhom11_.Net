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
    public class PreCPU
    {
        private readonly IViewCPU view;
        private readonly IRepository<CPU> repository;

        public PreCPU(IViewCPU view, IRepository<CPU> repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public void LoadCPUs()
        {
            var CPUs = repository.GetAll();
            view.UpdateCPUList(CPUs);
        }
    }
}
