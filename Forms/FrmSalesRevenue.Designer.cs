namespace BTL_nhom11_marketPC.Forms
{
    partial class FrmSalesRevenue
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
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCalculateRevenue = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.panelChartMonthly = new System.Windows.Forms.Panel();
            this.panelTopProducts = new System.Windows.Forms.Panel();
            this.panelDailyRevenue = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ ngày";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(280, 62);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(250, 38);
            this.dtpStartDate.TabIndex = 4;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(687, 62);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(312, 38);
            this.dtpEndDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(533, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đến ngày";
            // 
            // btnCalculateRevenue
            // 
            this.btnCalculateRevenue.Location = new System.Drawing.Point(1036, 39);
            this.btnCalculateRevenue.Name = "btnCalculateRevenue";
            this.btnCalculateRevenue.Size = new System.Drawing.Size(257, 88);
            this.btnCalculateRevenue.TabIndex = 7;
            this.btnCalculateRevenue.Text = "Tính doanh thu";
            this.btnCalculateRevenue.UseVisualStyleBackColor = true;
            this.btnCalculateRevenue.Click += new System.EventHandler(this.btnCalculateRevenue_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Tomato;
            this.label3.Location = new System.Drawing.Point(42, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 32);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Tomato;
            this.label4.Location = new System.Drawing.Point(261, 855);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(457, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "TỔNG DOANH THU THEO THÁNG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Tomato;
            this.label5.Location = new System.Drawing.Point(1342, 841);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(375, 32);
            this.label5.TabIndex = 10;
            this.label5.Text = "TOP SẢN PHẨM BÁN CHẠY";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1526, 39);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(191, 88);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Location = new System.Drawing.Point(464, 162);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(0, 32);
            this.lblTotalRevenue.TabIndex = 12;
            // 
            // panelChartMonthly
            // 
            this.panelChartMonthly.Location = new System.Drawing.Point(48, 901);
            this.panelChartMonthly.Name = "panelChartMonthly";
            this.panelChartMonthly.Size = new System.Drawing.Size(888, 649);
            this.panelChartMonthly.TabIndex = 13;
            // 
            // panelTopProducts
            // 
            this.panelTopProducts.Location = new System.Drawing.Point(1118, 892);
            this.panelTopProducts.Name = "panelTopProducts";
            this.panelTopProducts.Size = new System.Drawing.Size(986, 658);
            this.panelTopProducts.TabIndex = 14;
            // 
            // panelDailyRevenue
            // 
            this.panelDailyRevenue.Location = new System.Drawing.Point(506, 256);
            this.panelDailyRevenue.Name = "panelDailyRevenue";
            this.panelDailyRevenue.Size = new System.Drawing.Size(888, 534);
            this.panelDailyRevenue.TabIndex = 15;
            // 
            // FrmSalesRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2134, 1562);
            this.ControlBox = false;
            this.Controls.Add(this.panelDailyRevenue);
            this.Controls.Add(this.panelTopProducts);
            this.Controls.Add(this.panelChartMonthly);
            this.Controls.Add(this.lblTotalRevenue);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCalculateRevenue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label1);
            this.Name = "FrmSalesRevenue";
            this.Text = "Doanh thu bán hàng";
            this.Load += new System.EventHandler(this.FrmSalesRevenue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCalculateRevenue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Panel panelChartMonthly;
        private System.Windows.Forms.Panel panelTopProducts;
        private System.Windows.Forms.Panel panelDailyRevenue;
    }
}