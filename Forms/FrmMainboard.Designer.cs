
namespace BTL_nhom11_marketPC.Forms
{
    partial class FrmMainboard
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
            this.txtMota = new System.Windows.Forms.TextBox();
            this.txtSocket = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuybo = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenmainboard = new System.Windows.Forms.TextBox();
            this.txtHangsanxuat = new System.Windows.Forms.TextBox();
            this.txtMamainboard = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvMainboard = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainboard)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(512, 78);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(271, 132);
            this.txtMota.TabIndex = 54;
            // 
            // txtSocket
            // 
            this.txtSocket.Location = new System.Drawing.Point(164, 153);
            this.txtSocket.Name = "txtSocket";
            this.txtSocket.Size = new System.Drawing.Size(218, 22);
            this.txtSocket.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 52;
            this.label5.Text = "Socket";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoat.Image = global::BTL_nhom11_marketPC.Properties.Resources.exit;
            this.btnThoat.Location = new System.Drawing.Point(683, 442);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 43);
            this.btnThoat.TabIndex = 51;
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
            this.btnHuybo.Location = new System.Drawing.Point(539, 442);
            this.btnHuybo.Name = "btnHuybo";
            this.btnHuybo.Size = new System.Drawing.Size(108, 43);
            this.btnHuybo.TabIndex = 50;
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
            this.btnLuu.Location = new System.Drawing.Point(419, 442);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(87, 43);
            this.btnLuu.TabIndex = 49;
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
            this.btnXoa.Location = new System.Drawing.Point(298, 442);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 43);
            this.btnXoa.TabIndex = 48;
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
            this.btnSua.Location = new System.Drawing.Point(175, 442);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(96, 43);
            this.btnSua.TabIndex = 47;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(457, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 46;
            this.label12.Text = "Mô tả";
            // 
            // txtTenmainboard
            // 
            this.txtTenmainboard.Location = new System.Drawing.Point(164, 117);
            this.txtTenmainboard.Name = "txtTenmainboard";
            this.txtTenmainboard.Size = new System.Drawing.Size(218, 22);
            this.txtTenmainboard.TabIndex = 45;
            // 
            // txtHangsanxuat
            // 
            this.txtHangsanxuat.Location = new System.Drawing.Point(164, 188);
            this.txtHangsanxuat.Name = "txtHangsanxuat";
            this.txtHangsanxuat.Size = new System.Drawing.Size(218, 22);
            this.txtHangsanxuat.TabIndex = 44;
            // 
            // txtMamainboard
            // 
            this.txtMamainboard.Location = new System.Drawing.Point(164, 78);
            this.txtMamainboard.Name = "txtMamainboard";
            this.txtMamainboard.Size = new System.Drawing.Size(218, 22);
            this.txtMamainboard.TabIndex = 43;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.Image = global::BTL_nhom11_marketPC.Properties.Resources.add;
            this.btnThem.Location = new System.Drawing.Point(45, 442);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(101, 43);
            this.btnThem.TabIndex = 42;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvMainboard
            // 
            this.dgvMainboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainboard.Location = new System.Drawing.Point(50, 238);
            this.dgvMainboard.Name = "dgvMainboard";
            this.dgvMainboard.RowHeadersWidth = 51;
            this.dgvMainboard.RowTemplate.Height = 24;
            this.dgvMainboard.Size = new System.Drawing.Size(733, 185);
            this.dgvMainboard.TabIndex = 41;
            this.dgvMainboard.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMainboard_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 40;
            this.label4.Text = "Tên Mainboard";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Hãng sản xuất";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "Mã Mainboard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Netron", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 35);
            this.label1.TabIndex = 37;
            this.label1.Text = "MAINBOARD";
            // 
            // FrmMainboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 510);
            this.Controls.Add(this.txtMota);
            this.Controls.Add(this.txtSocket);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuybo);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTenmainboard);
            this.Controls.Add(this.txtHangsanxuat);
            this.Controls.Add(this.txtMamainboard);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvMainboard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMainboard";
            this.Text = "FrmMainboard";
            this.Load += new System.EventHandler(this.FrmMainboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.TextBox txtSocket;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuybo;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTenmainboard;
        private System.Windows.Forms.TextBox txtHangsanxuat;
        private System.Windows.Forms.TextBox txtMamainboard;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvMainboard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}