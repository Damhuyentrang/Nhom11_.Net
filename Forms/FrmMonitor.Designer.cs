using System;
using System.Windows.Forms;

namespace BTL_nhom11_marketPC.Forms
{
    partial class FrmMonitor
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
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtHangSX = new System.Windows.Forms.TextBox();
            this.dgvMonitor = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ma Man Hinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ten Man Hinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ma HSX";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(347, 149);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(396, 31);
            this.txtMa.TabIndex = 5;
            this.txtMa.TextChanged += new System.EventHandler(this.txtMa_TextChanged);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(347, 228);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(396, 31);
            this.txtTen.TabIndex = 6;
            // 
            // txtHangSX
            // 
            this.txtHangSX.Location = new System.Drawing.Point(347, 305);
            this.txtHangSX.Name = "txtHangSX";
            this.txtHangSX.Size = new System.Drawing.Size(396, 31);
            this.txtHangSX.TabIndex = 9;
            // 
            // dgvMonitor
            // 
            this.dgvMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvMonitor.Location = new System.Drawing.Point(151, 526);
            this.dgvMonitor.Name = "dgvMonitor";
            this.dgvMonitor.RowHeadersWidth = 82;
            this.dgvMonitor.RowTemplate.Height = 33;
            this.dgvMonitor.Size = new System.Drawing.Size(1116, 299);
            this.dgvMonitor.TabIndex = 10;
            this.dgvMonitor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonitor_CellContentClick);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(43, 941);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(134, 35);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Them";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(247, 941);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(134, 35);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Sua";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(484, 941);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(134, 35);
            this.btnXoa.TabIndex = 13;
            this.btnXoa.Text = "Xoa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(689, 941);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(134, 35);
            this.btnLuu.TabIndex = 14;
            this.btnLuu.Text = "Luu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnBoqua
            // 
            this.btnBoqua.Location = new System.Drawing.Point(907, 941);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(134, 35);
            this.btnBoqua.TabIndex = 15;
            this.btnBoqua.Text = "Huy bo";
            this.btnBoqua.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1133, 941);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(134, 35);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "Thoat";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ma Man Hinh";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ten Man Hinh";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ma HSX";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // FrmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 1000);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvMonitor);
            this.Controls.Add(this.txtHangSX);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMonitor";
            this.Text = "FrmMonitor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonitor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dgvMonitor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtHangSX;
        private System.Windows.Forms.DataGridView dgvMonitor;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnThoat;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
    }
}