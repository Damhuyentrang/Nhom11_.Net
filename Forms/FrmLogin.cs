using BTL_nhom11_marketPC.Database;
using BTL_nhom11_marketPC.Models;
using BTL_nhom11_marketPC.Presenters;
using BTL_nhom11_marketPC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmLogin : Form, ILoginView
    {
        private PreLogin _preLogin;

        public FrmLogin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            SetPresenter(new PreLogin(this));
        }
        public string Username => txtUsername.Text.Trim();
        public string Password => txtPassword.Text;
        public bool ShowPassword
        {
            get => !txtPassword.UseSystemPasswordChar;
            set => txtPassword.UseSystemPasswordChar = !value;
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void NavigateToMainMenu()
        {
            FrmMainMenu mainForm = new FrmMainMenu();
            mainForm.Show();
            this.Hide();
        }

        public void ClearFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            chkShowPassword.Checked = false;
        }

        public void SetPresenter(PreLogin presenter)
        {
            _preLogin = presenter;
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.picAnhMain.Image = Image.FromFile("D:\\Kì 2 năm 3\\Lập trình NET\\Nhom11_.Net\\assets\\banner.png");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _preLogin.Login();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister register = new FrmRegister();
            register.Show();
            this.Hide();
        }
    }
}
