using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            Database.DatabaseContext.GetConnection();
            picBanner.Image = Image.FromFile("D:\\Kì 2 năm 3\\Lập trình NET\\Nhom11_.Net\\assets\\banner.png");
        }

        private void loạiMáyTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmComputerType frmComputerType = new FrmComputerType();
            frmComputerType.MdiParent = this;
            frmComputerType.WindowState = FormWindowState.Maximized;
            frmComputerType.Show();
        }

        private void máyTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmComputer frmComputer = new FrmComputer();
            frmComputer.MdiParent = this;
            AdjustChildFormSize(frmComputer);
            frmComputer.Show();
        }

        private void mainboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmMainboard frmMainboard = new FrmMainboard();
            frmMainboard.MdiParent = this;
            frmMainboard.WindowState = FormWindowState.Maximized;
            frmMainboard.Show();
        }

        private void cPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmCPU frmCPU = new FrmCPU();
            frmCPU.MdiParent = this;
            frmCPU.WindowState = FormWindowState.Maximized;
            frmCPU.Show();
        }

        private void gPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmGPU frmGPU = new FrmGPU();
            frmGPU.MdiParent = this;
            frmGPU.WindowState = FormWindowState.Maximized;
            frmGPU.Show();
        }

        private void rAMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmRAM frmRAM = new FrmRAM();
            frmRAM.MdiParent = this;
            frmRAM.WindowState = FormWindowState.Maximized;
            frmRAM.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmCustomer frmCustomer = new FrmCustomer();
            frmCustomer.MdiParent = this;
            frmCustomer.WindowState = FormWindowState.Maximized;
            frmCustomer.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmEmployee frmEmployee = new FrmEmployee();
            frmEmployee.MdiParent = this;
            frmEmployee.WindowState = FormWindowState.Maximized;
            frmEmployee.Show();
        }

        private void ổCứngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmHardDrive frmHardDrive = new FrmHardDrive();
            frmHardDrive.MdiParent = this;
            frmHardDrive.WindowState = FormWindowState.Maximized;
            frmHardDrive.Show();
        }

        private void cardĐồHọaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmGraphicsCard frmGraphicsCard = new FrmGraphicsCard();
            frmGraphicsCard.MdiParent = this;
            frmGraphicsCard.WindowState = FormWindowState.Maximized;
            frmGraphicsCard.Show();
        }

        private void quảnLýHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmSalesInvoice frmSalesInvoice = new FrmSalesInvoice();
            frmSalesInvoice.MdiParent = this;
            frmSalesInvoice.WindowState = FormWindowState.Maximized;
            frmSalesInvoice.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmSalesRevenue frmSalesRevenue = new FrmSalesRevenue();    
            frmSalesRevenue.MdiParent = this;
            frmSalesRevenue.WindowState = FormWindowState.Maximized;
            frmSalesRevenue.Show();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideBackground();
            FrmUser frmUser = new FrmUser();
            frmUser.MdiParent = this;
            frmUser.WindowState = FormWindowState.Maximized;
            frmUser.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
            ShowBackground();
            this.Refresh();
        }

        private void HideBackground()
        {
            picBanner.Visible = false;
        }

        private void ShowBackground()
        {
            picBanner.Visible = true;
            picBanner.Location = new Point(
                (this.ClientSize.Width - picBanner.Width) / 2,
                (this.ClientSize.Height - picBanner.Height) / 2
            );
        }
        private void AdjustChildFormSize(Form childForm)
        {
            // Lấy kích thước của khu vực hiển thị trong MDI parent
            var clientArea = this.ClientSize;
            childForm.Size = new Size(clientArea.Width, clientArea.Height); // Trừ đi khoảng cách viền
            childForm.Location = new Point(0, 0); // Đặt ở góc trên cùng bên trái
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSession.ClearSession();
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();
            this.Close();
        }
    }
}
