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
        }

        private void giaoDịchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void mainboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmMainboard frmMainboard = new Forms.FrmMainboard();
            frmMainboard.StartPosition = FormStartPosition.CenterScreen;
            frmMainboard.ShowDialog();
        }

        private void cPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmCPU frmCPU = new Forms.FrmCPU();
            frmCPU.StartPosition = FormStartPosition.CenterScreen;
            frmCPU.ShowDialog();
        }

        private void gPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FrmGPU frmGPU = new Forms.FrmGPU();
            frmGPU.StartPosition = FormStartPosition.CenterScreen;
            frmGPU.ShowDialog();
        }

        private void rAMToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Forms.FrmRAM frmRAM = new Forms.FrmRAM();
            frmRAM.StartPosition = FormStartPosition.CenterScreen;
            frmRAM.ShowDialog();
        }
    }
}
