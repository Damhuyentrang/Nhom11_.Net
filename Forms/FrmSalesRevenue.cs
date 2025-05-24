using BTL_nhom11_marketPC.Database;
using BTL_nhom11_marketPC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BTL_nhom11_marketPC.Forms
{
    public partial class FrmSalesRevenue : Form
    {
        private readonly RelationshipMapper _mapper;

        public FrmSalesRevenue()
        {
            InitializeComponent();
            _mapper = new RelationshipMapper();
        }

        private void FrmSalesRevenue_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadSalesData();
        }

        private void btnCalculateRevenue_Click(object sender, EventArgs e)
        {
            LoadSalesData();
        }

        private void LoadSalesData()
        {
            // Kiểm tra ngày hợp lệ
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tính tổng doanh thu
            decimal totalRevenue = _mapper.CalculateRevenue(dtpStartDate.Value, dtpEndDate.Value);
            lblTotalRevenue.Text = $"Tổng doanh thu: {totalRevenue:N0} VNĐ";

            // Lấy danh sách hóa đơn
            var invoices = _mapper.GetSalesInvoicesByDateRange(dtpStartDate.Value, dtpEndDate.Value) ?? new List<SalesInvoice>();
            if (invoices.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Tạo biểu đồ tổng doanh thu theo tháng
            LoadOrdersByMonthChart(invoices);

            // Tạo biểu đồ sản phẩm bán chạy
            LoadTopProductsChart(invoices);

            // Tạo biểu đồ đơn hàng theo ngày
            LoadDailyRevenueChart(invoices);
        }

        private void LoadOrdersByMonthChart(List<SalesInvoice> invoices)
        {
            // Gom nhóm hóa đơn theo tháng và tính tổng doanh thu
            var monthlyRevenue = invoices
                .Where(i => i.TrangThaiDonHang == "Hoàn Thành") // Chỉ tính hóa đơn hoàn thành
                .GroupBy(i => new { i.NgayBan.Year, i.NgayBan.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalRevenue = g.Sum(i => i.TongTien)
                })
                .OrderBy(g => g.Year).ThenBy(g => g.Month)
                .ToList();

            // Tạo nhãn cho biểu đồ (tháng/năm)
            var labels = monthlyRevenue.Select(m => $"{m.Month:D2}/{m.Year}").ToArray();
            var data = monthlyRevenue.Select(m => (double)m.TotalRevenue).ToArray();

            // Khởi tạo biểu đồ
            var chart = new Chart
            {
                Width = panelChartMonthly.Width - 20,
                Height = panelChartMonthly.Height - 20
            };

            // Thiết lập vùng vẽ
            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Thêm series cho doanh thu
            var series = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Line, // Sử dụng Line cho biểu đồ đường
                Color = Color.DodgerBlue,
                BorderWidth = 2
            };
            series.Points.DataBindXY(labels, data);

            chart.Series.Add(series);

            // Thiết lập trục X
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.Title = "Tháng/Năm";
            chartArea.AxisX.LabelStyle.Angle = -45; // Xoay nhãn 45 độ để tránh chồng lấn

            // Thiết lập trục Y
            chartArea.AxisY.Title = "Doanh thu (VNĐ)";
            chartArea.AxisY.Interval = 10000000; // Khoảng cách 1 triệu VNĐ
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = data.Max() + 1000000; // Thêm khoảng đệm
            chartArea.AxisY.LabelStyle.Format = "{0:N0}"; // Định dạng số với dấu phân cách hàng nghìn

            // Thêm tiêu đề
            chart.Titles.Add(new Title("Tổng doanh thu theo tháng", Docking.Top, new Font("Arial", 12), Color.Black));

            // Thêm biểu đồ vào panel
            panelChartMonthly.Controls.Clear();
            panelChartMonthly.Controls.Add(chart);
        }

        private void LoadTopProductsChart(List<SalesInvoice> invoices)
        {
            // Lấy top 5 sản phẩm bán chạy từ RelationshipMapper
            var topProducts = _mapper.GetTopSellingProducts(dtpStartDate.Value, dtpEndDate.Value);

            // Nếu không có sản phẩm nào, hiển thị thông báo và thoát
            if (topProducts == null || topProducts.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm bán chạy nào trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelTopProducts.Controls.Clear();
                return;
            }

            // Sắp xếp sản phẩm theo số lượng bán giảm dần
            var sortedProducts = topProducts.OrderByDescending(p => p.TotalSold).ToList();

            // Tạo nhãn và dữ liệu cho biểu đồ
            var labels = sortedProducts.Select(p => p.ProductName).ToArray();
            var data = sortedProducts.Select(p => p.TotalSold).ToArray();

            // Khởi tạo biểu đồ
            var chart = new Chart
            {
                Width = panelTopProducts.Width - 20,
                Height = panelTopProducts.Height - 20
            };

            // Thiết lập vùng vẽ
            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Thiết lập biểu đồ cột ngang
            chartArea.AxisY.Title = "Số lượng bán";
            chartArea.AxisX.Title = "Sản phẩm";

            // Thêm series
            var series = new Series("Số lượng bán")
            {
                ChartType = SeriesChartType.Bar, // Sử dụng Bar cho cột ngang
                Color = Color.DodgerBlue,
                IsValueShownAsLabel = true // Hiển thị giá trị số lượng trên thanh
            };
            series.Points.DataBindY(data);

            chart.Series.Add(series);

            // Thiết lập trục X (danh sách sản phẩm)
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Enabled = true;
            chartArea.AxisX.LabelStyle.Font = new Font("Arial", 8f);
            chartArea.AxisX.CustomLabels.Clear();
            for (int i = 0; i < labels.Length; i++)
            {
                chartArea.AxisX.CustomLabels.Add(i + 0.5, i + 1.5, labels[i]);
            }

            // Thiết lập trục Y (số lượng bán)
            chartArea.AxisY.Interval = 1;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = data.Max() + 1;

            //// Thêm tiêu đề
            //chart.Titles.Add(new Title("Top sản phẩm bán chạy", Docking.Top, new Font("Arial", 12), Color.Black));

            // Thêm biểu đồ vào panel
            panelTopProducts.Controls.Clear();
            panelTopProducts.Controls.Add(chart);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadSalesData();
        }

        private void LoadDailyRevenueChart(List<SalesInvoice> invoices)
        {
            // Lấy hóa đơn trong ngày dtpEndDate
            var dailyOrders = invoices
                .Where(i => i.NgayBan.Date == dtpEndDate.Value.Date) // Chỉ lấy hóa đơn trong ngày dtpEndDate
                .GroupBy(i => i.TrangThaiDonHang)
                .Select(g => new
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .ToList();

            // Nếu không có dữ liệu, hiển thị thông báo và thoát
            if (dailyOrders.Count == 0)
            {
                MessageBox.Show($"Không có đơn hàng nào trong ngày {dtpEndDate.Value:dd/MM/yyyy}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelDailyRevenue.Controls.Clear();
                return;
            }

            // Tạo nhãn và dữ liệu cho biểu đồ
            var labels = dailyOrders.Select(s => s.Status).ToArray();
            var data = dailyOrders.Select(s => (double)s.Count).ToArray();

            // Khởi tạo biểu đồ
            var chart = new Chart
            {
                Width = panelDailyRevenue.Width - 20,
                Height = panelDailyRevenue.Height - 20
            };

            // Thiết lập vùng vẽ
            var chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Thêm series cho số lượng đơn hàng theo trạng thái
            var series = new Series("Trạng thái đơn hàng")
            {
                ChartType = SeriesChartType.Pie, // Sử dụng Pie cho biểu đồ tròn
                IsValueShownAsLabel = true // Hiển thị giá trị trên từng phần
            };

            for (int i = 0; i < labels.Length; i++)
            {
                series.Points.AddXY(labels[i], data[i]);
                series.Points[i].LegendText = $"{labels[i]} ({data[i]})"; // Hiển thị nhãn và giá trị trong legend
                series.Points[i].Color = GetColorForStatus(labels[i]); // Màu sắc theo trạng thái
            }

            chart.Series.Add(series);

            // Thiết lập legend
            chart.Legends.Add(new Legend("Legend") { Docking = Docking.Bottom });

            // Thêm tiêu đề
            chart.Titles.Add(new Title($"Đơn hàng trong ngày {dtpEndDate.Value:dd/MM/yyyy}", Docking.Top, new Font("Arial", 12), Color.Black));

            // Thêm biểu đồ vào panel
            panelDailyRevenue.Controls.Clear();
            panelDailyRevenue.Controls.Add(chart);
        }
        private Color GetColorForStatus(string status)
        {
            if (status == "Hoàn Thành")
                return Color.Green;
            else if (status == "Đang Xử Lý")
                return Color.Yellow;
            else if (status == "Hủy")
                return Color.Red;
            else
                return Color.Gray; // Mặc định cho trạng thái khác (nếu có)
        }
    }
}