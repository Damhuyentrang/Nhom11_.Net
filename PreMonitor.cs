using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Repositories.BTL_nhom11_marketPC.Database.Repositories;
using BTL_nhom11_marketPC.Views;

namespace BTL_nhom11_marketPC.Presenters
{
    public class PreMonitor
    {
        private readonly IViewMonitor view;
        private readonly IRepository<Monitor> repository;
        private Forms.FrmMonitor frmMonitor;
        private MonitorRepository repository1;

        public PreMonitor(IViewMonitor view, IRepository<Monitor> repository)
        {
            this.view = view;
            this.repository = repository;
        }

        public PreMonitor(Forms.FrmMonitor frmMonitor, MonitorRepository repository1)
        {
            this.frmMonitor = frmMonitor;
            this.repository1 = repository1;
        }

        public void LoadMonitors()
        {
            var monitors = repository.GetAll();
            view.UpdateMonitorList(monitors);
        }
    }
}