
namespace BTL_nhom11_marketPC.Forms
{
    partial class FrmRAM
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtBus = new System.Windows.Forms.TextBox();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.txtDungluong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuybo = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenRAM = new System.Windows.Forms.TextBox();
            this.txtMaRAM = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvRAM = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRAM)).BeginInit();
            this.SuspendLayout();
            // 
            // cboHSX
            // 
            this.cboHSX.FormattingEnabled = true;
            this.cboHSX.Location = new System.Drawing.Point(150, 213);
            this.cboHSX.Name = "cboHSX";
            this.cboHSX.Size = new System.Drawing.Size(218, 24);
            this.cboHSX.TabIndex = 132;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 16);
            this.label6.TabIndex = 131;
            this.label6.Text = "Bus";
            // 
            // txtBus
            // 
            this.txtBus.Location = new System.Drawing.Point(150, 142);
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(218, 22);
            this.txtBus.TabIndex = 130;
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(497, 71);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(268, 132);
            this.txtMota.TabIndex = 129;
            // 
            // txtDungluong
            // 
            this.txtDungluong.Location = new System.Drawing.Point(150, 178);
            this.txtDungluong.Name = "txtDungluong";
            this.txtDungluong.Size = new System.Drawing.Size(218, 22);
            this.txtDungluong.TabIndex = 128;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 127;
            this.label5.Text = "Dung lượng";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoat.Image = global::BTL_nhom11_marketPC.Properties.Resources.exit;
            this.btnThoat.Location = new System.Drawing.Point(663, 482);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(102, 44);
            this.btnThoat.TabIndex = 126;
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
            this.btnHuybo.Location = new System.Drawing.Point(516, 482);
            this.btnHuybo.Name = "btnHuybo";
            this.btnHuybo.Size = new System.Drawing.Size(112, 44);
            this.btnHuybo.TabIndex = 125;
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
            this.btnLuu.Location = new System.Drawing.Point(407, 482);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(82, 44);
            this.btnLuu.TabIndex = 124;
            this.btnLuu.Text = " Lưu";
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
            this.btnXoa.Location = new System.Drawing.Point(287, 482);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 44);
            this.btnXoa.TabIndex = 123;
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
            this.btnSua.Location = new System.Drawing.Point(164, 482);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 44);
            this.btnSua.TabIndex = 122;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(435, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 121;
            this.label12.Text = "Mô tả";
            // 
            // txtTenRAM
            // 
            this.txtTenRAM.Location = new System.Drawing.Point(150, 107);
            this.txtTenRAM.Name = "txtTenRAM";
            this.txtTenRAM.Size = new System.Drawing.Size(218, 22);
            this.txtTenRAM.TabIndex = 120;
            // 
            // txtMaRAM
            // 
            this.txtMaRAM.Location = new System.Drawing.Point(150, 68);
            this.txtMaRAM.Name = "txtMaRAM";
            this.txtMaRAM.Size = new System.Drawing.Size(218, 22);
            this.txtMaRAM.TabIndex = 119;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.Image = global::BTL_nhom11_marketPC.Properties.Resources.add;
            this.btnThem.Location = new System.Drawing.Point(36, 482);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(99, 44);
            this.btnThem.TabIndex = 118;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvRAM
            // 
            this.dgvRAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRAM.Location = new System.Drawing.Point(36, 257);
            this.dgvRAM.Name = "dgvRAM";
            this.dgvRAM.RowHeadersWidth = 51;
            this.dgvRAM.RowTemplate.Height = 24;
            this.dgvRAM.Size = new System.Drawing.Size(729, 210);
            this.dgvRAM.TabIndex = 117;
            this.dgvRAM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRAM_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 116;
            this.label4.Text = "Tên RAM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 115;
            this.label3.Text = "Hãng sản xuất";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 114;
            this.label2.Text = "Mã RAM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Netron", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(357, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 35);
            this.label1.TabIndex = 113;
            this.label1.Text = "RAM";
            // 
            // FrmRAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.cboHSX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBus);
            this.Controls.Add(this.txtMota);
            this.Controls.Add(this.txtDungluong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuybo);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTenRAM);
            this.Controls.Add(this.txtMaRAM);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvRAM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmRAM";
            this.Text = "FrmRAM";
            this.Load += new System.EventHandler(this.FrmRAM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRAM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboHSX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBus;
        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.TextBox txtDungluong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuybo;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTenRAM;
        private System.Windows.Forms.TextBox txtMaRAM;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvRAM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}