using System;

namespace BTL_nhom11_marketPC.Forms
{
    partial class FrmPromotion
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaKM = new System.Windows.Forms.TextBox();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.numPhanTramKM = new System.Windows.Forms.NumericUpDown();
            this.dgvPromotion = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuybo = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPhanTramKM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(583, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "PROMOTION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ma Khuyen Mai";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ten Khuyen Mai";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngay Bat Dau";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 37);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngay Ket Thuc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(76, 473);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 37);
            this.label6.TabIndex = 5;
            this.label6.Text = "Phan Tram Giam";
            // 
            // txtMaKM
            // 
            this.txtMaKM.Location = new System.Drawing.Point(375, 180);
            this.txtMaKM.Name = "txtMaKM";
            this.txtMaKM.Size = new System.Drawing.Size(510, 31);
            this.txtMaKM.TabIndex = 6;
            this.txtMaKM.TextChanged += new System.EventHandler(this.txtMaKM_TextChanged);
            // 
            // txtTenKM
            // 
            this.txtTenKM.Location = new System.Drawing.Point(375, 252);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(510, 31);
            this.txtTenKM.TabIndex = 7;
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.Location = new System.Drawing.Point(375, 326);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(510, 31);
            this.dtpBatDau.TabIndex = 8;
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.Location = new System.Drawing.Point(375, 403);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(510, 31);
            this.dtpKetThuc.TabIndex = 9;
            // 
            // numPhanTramKM
            // 
            this.numPhanTramKM.Location = new System.Drawing.Point(375, 480);
            this.numPhanTramKM.Name = "numPhanTramKM";
            this.numPhanTramKM.Size = new System.Drawing.Size(510, 31);
            this.numPhanTramKM.TabIndex = 10;
            // 
            // dgvPromotion
            // 
            this.dgvPromotion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromotion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvPromotion.Location = new System.Drawing.Point(137, 546);
            this.dgvPromotion.Name = "dgvPromotion";
            this.dgvPromotion.RowHeadersWidth = 82;
            this.dgvPromotion.RowTemplate.Height = 33;
            this.dgvPromotion.Size = new System.Drawing.Size(1083, 344);
            this.dgvPromotion.TabIndex = 11;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ma Khuyen Mai";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ten Khuyen Mai";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ngay Bat Dau";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ngay Ket Thuc";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Phan Tram Giam";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(68, 952);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(151, 46);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Them";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(283, 952);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(151, 46);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sua";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(540, 952);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(151, 46);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xoa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(824, 952);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(151, 46);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Luu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnHuybo
            // 
            this.btnHuybo.Location = new System.Drawing.Point(1095, 952);
            this.btnHuybo.Name = "btnHuybo";
            this.btnHuybo.Size = new System.Drawing.Size(151, 46);
            this.btnHuybo.TabIndex = 16;
            this.btnHuybo.Text = "Huy bo";
            this.btnHuybo.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1387, 952);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(151, 46);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // FrmPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1569, 1034);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuybo);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvPromotion);
            this.Controls.Add(this.numPhanTramKM);
            this.Controls.Add(this.dtpKetThuc);
            this.Controls.Add(this.dtpBatDau);
            this.Controls.Add(this.txtTenKM);
            this.Controls.Add(this.txtMaKM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmPromotion";
            this.Text = "FrmPromotion";
            ((System.ComponentModel.ISupportInitialize)(this.numPhanTramKM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtMaKM_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaKM;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.NumericUpDown numPhanTramKM;
        private System.Windows.Forms.DataGridView dgvPromotion;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuybo;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}
