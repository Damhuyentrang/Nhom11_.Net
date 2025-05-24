
namespace BTL_nhom11_marketPC.Forms
{
    partial class FrmCPU
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
            this.cboHSX = new System.Windows.Forms.ComboBox();
            this.txtSocket = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.txtTocdo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuybo = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenCPU = new System.Windows.Forms.TextBox();
            this.txtMacpu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvCPU = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCPU)).BeginInit();
            this.SuspendLayout();
            // 
            // cboHSX
            // 
            this.cboHSX.FormattingEnabled = true;
            this.cboHSX.Location = new System.Drawing.Point(144, 222);
            this.cboHSX.Name = "cboHSX";
            this.cboHSX.Size = new System.Drawing.Size(218, 24);
            this.cboHSX.TabIndex = 94;
            // 
            // txtSocket
            // 
            this.txtSocket.Location = new System.Drawing.Point(144, 188);
            this.txtSocket.Name = "txtSocket";
            this.txtSocket.Size = new System.Drawing.Size(218, 22);
            this.txtSocket.TabIndex = 93;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 92;
            this.label6.Text = "Socket";
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(500, 78);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(263, 132);
            this.txtMota.TabIndex = 91;
            // 
            // txtTocdo
            // 
            this.txtTocdo.Location = new System.Drawing.Point(144, 153);
            this.txtTocdo.Name = "txtTocdo";
            this.txtTocdo.Size = new System.Drawing.Size(218, 22);
            this.txtTocdo.TabIndex = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 89;
            this.label5.Text = "Tốc Độ";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoat.Image = global::BTL_nhom11_marketPC.Properties.Resources.exit;
            this.btnThoat.Location = new System.Drawing.Point(666, 462);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(97, 44);
            this.btnThoat.TabIndex = 88;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuybo
            // 
            this.btnHuybo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHuybo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuybo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHuybo.Image = global::BTL_nhom11_marketPC.Properties.Resources.cancel;
            this.btnHuybo.Location = new System.Drawing.Point(521, 462);
            this.btnHuybo.Name = "btnHuybo";
            this.btnHuybo.Size = new System.Drawing.Size(117, 44);
            this.btnHuybo.TabIndex = 87;
            this.btnHuybo.Text = "Hủy bỏ";
            this.btnHuybo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuybo.UseVisualStyleBackColor = false;
            this.btnHuybo.Click += new System.EventHandler(this.btnHuybo_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLuu.Image = global::BTL_nhom11_marketPC.Properties.Resources.diskette;
            this.btnLuu.Location = new System.Drawing.Point(402, 462);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(89, 44);
            this.btnLuu.TabIndex = 86;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.SteelBlue;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoa.Image = global::BTL_nhom11_marketPC.Properties.Resources.trash;
            this.btnXoa.Location = new System.Drawing.Point(283, 462);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(89, 44);
            this.btnXoa.TabIndex = 85;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSua.Image = global::BTL_nhom11_marketPC.Properties.Resources.office_material;
            this.btnSua.Location = new System.Drawing.Point(165, 462);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 44);
            this.btnSua.TabIndex = 84;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(451, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 83;
            this.label12.Text = "Mô tả";
            // 
            // txtTenCPU
            // 
            this.txtTenCPU.Location = new System.Drawing.Point(144, 117);
            this.txtTenCPU.Name = "txtTenCPU";
            this.txtTenCPU.Size = new System.Drawing.Size(218, 22);
            this.txtTenCPU.TabIndex = 82;
            // 
            // txtMacpu
            // 
            this.txtMacpu.Location = new System.Drawing.Point(144, 78);
            this.txtMacpu.Name = "txtMacpu";
            this.txtMacpu.Size = new System.Drawing.Size(218, 22);
            this.txtMacpu.TabIndex = 81;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.Image = global::BTL_nhom11_marketPC.Properties.Resources.add;
            this.btnThem.Location = new System.Drawing.Point(30, 462);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(108, 44);
            this.btnThem.TabIndex = 80;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvCPU
            // 
            this.dgvCPU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCPU.Location = new System.Drawing.Point(30, 262);
            this.dgvCPU.Name = "dgvCPU";
            this.dgvCPU.RowHeadersWidth = 51;
            this.dgvCPU.RowTemplate.Height = 24;
            this.dgvCPU.Size = new System.Drawing.Size(733, 185);
            this.dgvCPU.TabIndex = 79;
            this.dgvCPU.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCPU_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 78;
            this.label4.Text = "Tên CPU";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 77;
            this.label3.Text = "Hãng sản xuất";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 76;
            this.label2.Text = "Mã CPU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Netron", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(348, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 35);
            this.label1.TabIndex = 75;
            this.label1.Text = "CPU";
            // 
            // FrmCPU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.cboHSX);
            this.Controls.Add(this.txtSocket);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMota);
            this.Controls.Add(this.txtTocdo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuybo);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTenCPU);
            this.Controls.Add(this.txtMacpu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvCPU);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCPU";
            this.Text = "FrmCPU";
            this.Load += new System.EventHandler(this.FrmCPU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCPU)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboHSX;
        private System.Windows.Forms.TextBox txtSocket;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.TextBox txtTocdo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuybo;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTenCPU;
        private System.Windows.Forms.TextBox txtMacpu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvCPU;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}