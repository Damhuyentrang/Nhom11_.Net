
namespace BTL_nhom11_marketPC.Forms
{
    partial class FrmRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picAnhMain = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.mskNgaySinh = new System.Windows.Forms.MaskedTextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.mskSoDienThoai = new System.Windows.Forms.MaskedTextBox();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMain)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1062, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1062, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày sinh";
            // 
            // picAnhMain
            // 
            this.picAnhMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picAnhMain.Location = new System.Drawing.Point(1, -2);
            this.picAnhMain.Name = "picAnhMain";
            this.picAnhMain.Size = new System.Drawing.Size(939, 1474);
            this.picAnhMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhMain.TabIndex = 12;
            this.picAnhMain.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1218, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 36);
            this.label3.TabIndex = 13;
            this.label3.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1062, 492);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "Giới tính";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1062, 564);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 32);
            this.label5.TabIndex = 15;
            this.label5.Text = "Địa chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1062, 630);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 32);
            this.label6.TabIndex = 16;
            this.label6.Text = "Số điện thoại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1062, 706);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 32);
            this.label7.TabIndex = 17;
            this.label7.Text = "Username";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1062, 781);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 32);
            this.label8.TabIndex = 18;
            this.label8.Text = "Mật khẩu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1062, 852);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(242, 32);
            this.label9.TabIndex = 19;
            this.label9.Text = "Nhập lại mật khẩu";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(1318, 334);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(390, 38);
            this.txtHoTen.TabIndex = 20;
            // 
            // mskNgaySinh
            // 
            this.mskNgaySinh.Location = new System.Drawing.Point(1318, 409);
            this.mskNgaySinh.Mask = "00/00/0000";
            this.mskNgaySinh.Name = "mskNgaySinh";
            this.mskNgaySinh.Size = new System.Drawing.Size(390, 38);
            this.mskNgaySinh.TabIndex = 21;
            this.mskNgaySinh.ValidatingType = typeof(System.DateTime);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(1318, 558);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(390, 38);
            this.txtDiaChi.TabIndex = 22;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(1318, 700);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(390, 38);
            this.txtUsername.TabIndex = 23;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(1318, 778);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(390, 38);
            this.txtPass.TabIndex = 24;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(1318, 846);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(390, 38);
            this.txtConfirmPass.TabIndex = 25;
            this.txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // mskSoDienThoai
            // 
            this.mskSoDienThoai.Location = new System.Drawing.Point(1318, 624);
            this.mskSoDienThoai.Mask = "(999) 000-0000";
            this.mskSoDienThoai.Name = "mskSoDienThoai";
            this.mskSoDienThoai.Size = new System.Drawing.Size(390, 38);
            this.mskSoDienThoai.TabIndex = 26;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Location = new System.Drawing.Point(1318, 489);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(390, 39);
            this.cboGioiTinh.TabIndex = 27;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(1068, 976);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(652, 79);
            this.btnRegister.TabIndex = 28;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1778, 1336);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.mskSoDienThoai);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.mskNgaySinh);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picAnhMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmRegister";
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picAnhMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.MaskedTextBox mskNgaySinh;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.MaskedTextBox mskSoDienThoai;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Button btnRegister;
    }
}