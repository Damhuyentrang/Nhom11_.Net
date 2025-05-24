using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using BTL_nhom11_marketPC.Models;

namespace BTL_nhom11_marketPC.Database
{
    public class RelationshipMapper
    {
        // Lấy tất cả máy tính với các mối quan hệ (ComputerType, CPU, RAM, v.v.)
        public List<Computer> GetComputersWithRelationships()
        {
            List<Computer> computers = new List<Computer>();
            string query = @"
                SELECT 
                    m.MaMay, m.TenMay, m.HinhAnh, m.GhiChu, m.DonGia, m.SoLuongTon, m.ThoiGianBaoHanh,
                    m.MaLoaiMay, lm.TenLoaiMay,
                    m.MaCPU, cpu.TenCPU, cpu.TocDo, cpu.Socket, cpu.MoTa AS CPUMoTa, cpu.MaHSX AS CPUMaHSX,
                    m.MaRAM, ram.TenRAM, ram.Bus, ram.DungLuong AS RAMDungLuong, ram.MoTa AS RAMMoTa, ram.MaHSX AS RAMMaHSX,
                    m.MaMainboard, main.TenMainboard, main.Socket AS MainSocket, main.MoTa AS MainMoTa, main.MaHSX AS MainMaHSX,
                    m.MaGPU, gpu.LoaiGPU, gpu.DungLuong AS GPUDungLuong, gpu.MoTa AS GPUMoTa, gpu.MaHSX AS GPUMaHSX,
                    m.MaOCung, oc.TenOCung, oc.LoaiOCung, oc.DungLuong AS OCDungLuong, oc.MoTa AS OCMoTa,
                    m.MaManHinh, mh.TenManHinh, mh.DoPhanGiai, mh.KichThuoc, mh.MaHSX AS MHMaHSX,
                    m.MaCard, card.TenCard,
                    m.MaHSX, hsx.TenHSX
                FROM MayTinh m
                LEFT JOIN LoaiMay lm ON m.MaLoaiMay = lm.MaLoaiMay
                LEFT JOIN CPU cpu ON m.MaCPU = cpu.MaCPU
                LEFT JOIN RAM ram ON m.MaRAM = ram.MaRAM
                LEFT JOIN Mainboard main ON m.MaMainboard = main.MaMainboard
                LEFT JOIN GPU gpu ON m.MaGPU = gpu.MaGPU
                LEFT JOIN OCung oc ON m.MaOCung = oc.MaOCung
                LEFT JOIN ManHinh mh ON m.MaManHinh = mh.MaManHinh
                LEFT JOIN CardDoHoa card ON m.MaCard = card.MaCard
                LEFT JOIN HangSanXuat hsx ON m.MaHSX = hsx.MaHSX";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Computer computer = new Computer
                    {
                        MaMay = reader["MaMay"].ToString(),
                        TenMay = reader["TenMay"].ToString(),
                        HinhAnh = reader["HinhAnh"].ToString(),
                        GhiChu = reader["GhiChu"].ToString(),
                        DonGia = (decimal)reader["DonGia"],
                        SoLuongTon = (int)reader["SoLuongTon"],
                        ThoiGianBaoHanh = (int)reader["ThoiGianBaoHanh"],
                        MaLoaiMay = reader["MaLoaiMay"].ToString(),
                        ComputerType = new ComputerType
                        {
                            MaLoaiMay = reader["MaLoaiMay"].ToString(),
                            TenLoaiMay = reader["TenLoaiMay"].ToString()
                        },
                        MaCPU = reader["MaCPU"].ToString(),
                        CPU = new CPU
                        {
                            MaCPU = reader["MaCPU"].ToString(),
                            TenCPU = reader["TenCPU"].ToString(),
                            TocDo = reader["TocDo"].ToString(),
                            Socket = reader["Socket"].ToString(),
                            MoTa = reader["CPUMoTa"].ToString(),
                            MaHSX = reader["CPUMaHSX"].ToString()
                        },
                        MaRAM = reader["MaRAM"].ToString(),
                        RAM = new RAM
                        {
                            MaRAM = reader["MaRAM"].ToString(),
                            TenRAM = reader["TenRAM"].ToString(),
                            Bus = (int)reader["Bus"],
                            DungLuong = (int)reader["RAMDungLuong"],
                            MoTa = reader["RAMMoTa"].ToString(),
                            MaHSX = reader["RAMMaHSX"].ToString()
                        },
                        MaMainboard = reader["MaMainboard"].ToString(),
                        Mainboard = new Mainboard
                        {
                            MaMainboard = reader["MaMainboard"].ToString(),
                            TenMainboard = reader["TenMainboard"].ToString(),
                            Socket = reader["MainSocket"].ToString(),
                            MoTa = reader["MainMoTa"].ToString(),
                            MaHSX = reader["MainMaHSX"].ToString()
                        },
                        MaGPU = reader["MaGPU"].ToString(),
                        GPU = new GPU
                        {
                            MaGPU = reader["MaGPU"].ToString(),
                            LoaiGPU = reader["LoaiGPU"].ToString(),
                            DungLuong = (int)reader["GPUDungLuong"],
                            MoTa = reader["GPUMoTa"].ToString(),
                            MaHSX = reader["GPUMaHSX"].ToString()
                        },
                        MaOCung = reader["MaOCung"].ToString(),
                        HardDrive = new HardDrive
                        {
                            MaOCung = reader["MaOCung"].ToString(),
                            TenOCung = reader["TenOCung"].ToString(),
                            LoaiOCung = reader["LoaiOCung"].ToString(),
                            DungLuong = (int)reader["OCDungLuong"],
                            MoTa = reader["OCMoTa"].ToString()
                        },
                        MaManHinh = reader["MaManHinh"].ToString(),
                        ComputerScreen = new ComputerScreen
                        {
                            MaManHinh = reader["MaManHinh"].ToString(),
                            TenManHinh = reader["TenManHinh"].ToString(),
                            DoPhanGiai = reader["DoPhanGiai"].ToString(),
                            KichThuoc = reader["KichThuoc"].ToString(),
                            MaHSX = reader["MHMaHSX"].ToString()
                        },
                        MaCard = reader["MaCard"].ToString(),
                        GraphicsCard = new GraphicsCard
                        {
                            MaCard = reader["MaCard"].ToString(),
                            TenCard = reader["TenCard"].ToString()
                        },
                        MaHSX = reader["MaHSX"].ToString(),
                        Manufacturer = new Manufacturer
                        {
                            MaHSX = reader["MaHSX"].ToString(),
                            TenHSX = reader["TenHSX"].ToString()
                        }
                    };
                    computers.Add(computer);
                }
            }
            return computers;
        }

        // Lấy tất cả GPU với mối quan hệ Manufacturer
        public List<GPU> GetGPUsWithManufacturer()
        {
            List<GPU> gpus = new List<GPU>();
            string query = @"
                SELECT 
                    g.MaGPU, g.LoaiGPU, g.DungLuong, g.MoTa, g.MaHSX,
                    hsx.TenHSX
                FROM GPU g
                LEFT JOIN HangSanXuat hsx ON g.MaHSX = hsx.MaHSX";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    GPU gpu = new GPU
                    {
                        MaGPU = reader["MaGPU"].ToString(),
                        LoaiGPU = reader["LoaiGPU"].ToString(),
                        DungLuong = (int)reader["DungLuong"],
                        MoTa = reader["MoTa"].ToString(),
                        MaHSX = reader["MaHSX"].ToString(),
                        Manufacturer = new Manufacturer
                        {
                            MaHSX = reader["MaHSX"].ToString(),
                            TenHSX = reader["TenHSX"].ToString()
                        }
                    };
                    gpus.Add(gpu);
                }
            }
            return gpus;
        }

        // Lấy tất cả CPU với mối quan hệ Manufacturer
        public List<CPU> GetCPUsWithManufacturer()
        {
            List<CPU> cpus = new List<CPU>();
            string query = @"
        SELECT 
            c.MaCPU, c.TenCPU, c.TocDo, c.Socket, c.MoTa, c.MaHSX,
            hsx.TenHSX
        FROM CPU c
        LEFT JOIN HangSanXuat hsx ON c.MaHSX = hsx.MaHSX";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    CPU cpu = new CPU
                    {
                        MaCPU = reader["MaCPU"].ToString(),
                        TenCPU = reader["TenCPU"].ToString(),
                        TocDo = reader["TocDo"].ToString(),
                        Socket = reader["Socket"].ToString(),
                        MoTa = reader["MoTa"].ToString(),
                        MaHSX = reader["MaHSX"].ToString(),
                        Manufacturer = new Manufacturer
                        {
                            MaHSX = reader["MaHSX"].ToString(),
                            TenHSX = reader["TenHSX"].ToString()
                        }
                    };
                    cpus.Add(cpu);
                }
            }
            return cpus;
        }

        // Lấy tất cả RAM với mối quan hệ Manufacturer
        public List<RAM> GetRAMsWithManufacturer()
        {
            List<RAM> rams = new List<RAM>();
            string query = @"SELECT 
            r.MaRAM, r.TenRAM, r.Bus, r.DungLuong, r.MoTa, r.MaHSX,
            hsx.TenHSX
        FROM RAM r
        LEFT JOIN HangSanXuat hsx ON r.MaHSX = hsx.MaHSX";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    RAM ram = new RAM
                    {
                        MaRAM = reader["MaRAM"].ToString(),
                        TenRAM = reader["TenRAM"].ToString(),
                        Bus = (int)reader["Bus"],
                        DungLuong = (int)reader["DungLuong"],
                        MoTa = reader["MoTa"].ToString(),
                        MaHSX = reader["MaHSX"].ToString(),
                        Manufacturer = new Manufacturer
                        {
                            MaHSX = reader["MaHSX"].ToString(),
                            TenHSX = reader["TenHSX"].ToString()
                        }
                    };
                    rams.Add(ram);
                }
            }
            return rams;
        }

        // lấy tất cả Screen với mối quan hệ Manufacturer
        public List<ComputerScreen> GetScreensWithManufacturer()
        {
            List<ComputerScreen> screens = new List<ComputerScreen>();
            string query = @"SELECT 
            mh.MaManHinh, mh.TenManHinh, mh.DoPhanGiai, mh.KichThuoc, mh.MaHSX,
            hsx.TenHSX
        FROM ManHinh mh
        LEFT JOIN HangSanXuat hsx ON mh.MaHSX = hsx.MaHSX";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ComputerScreen screen = new ComputerScreen
                    {
                        MaManHinh = reader["MaManHinh"].ToString(),
                        TenManHinh = reader["TenManHinh"].ToString(),
                        DoPhanGiai = reader["DoPhanGiai"].ToString(),
                        KichThuoc = reader["KichThuoc"].ToString(),
                        MaHSX = reader["MaHSX"].ToString(),
                        Manufacturer = new Manufacturer
                        {
                            MaHSX = reader["MaHSX"].ToString(),
                            TenHSX = reader["TenHSX"].ToString()
                        }
                    };
                    screens.Add(screen);
                }
            }
            return screens;
        }

        // Lấy tất cả Mainboard với mối quan hệ Manufacturer
        public List<Mainboard> GetMainboardWithManufacturer()
        {
            List<Mainboard> mainboards = new List<Mainboard>();
            string query = @"SELECT 
            mb.MaMainboard, mb.TenMainboard, mb.Socket, mb.MoTa, mb.MaHSX,
            hsx.TenHSX
        FROM Mainboard mb
        LEFT JOIN HangSanXuat hsx ON mb.MaHSX = hsx.MaHSX";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Mainboard mainboard = new Mainboard
                    {
                        MaMainboard = reader["MaMainboard"].ToString(),
                        TenMainboard = reader["TenMainboard"].ToString(),
                        Socket = reader["Socket"].ToString(),
                        MoTa = reader["MoTa"].ToString(),
                        MaHSX = reader["MaHSX"].ToString(),
                        Manufacturer = new Manufacturer
                        {
                            MaHSX = reader["MaHSX"].ToString(),
                            TenHSX = reader["TenHSX"].ToString()
                        }
                    };
                    mainboards.Add(mainboard);
                }
            }
            return mainboards;
        }

        // Lấy tất cả HardDrive
        public List<HardDrive> GetHardDrived()
        {
            List<HardDrive> hardDrives = new List<HardDrive>();
            string query = @"SELECT 
            o.MaOCung, o.TenOCung, o.LoaiOCung, o.DungLuong, o.MoTa
        FROM OCung o";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    HardDrive hardDrive = new HardDrive
                    {
                        MaOCung = reader["MaOCung"].ToString(),
                        TenOCung = reader["TenOCung"].ToString(),
                        LoaiOCung = reader["LoaiOCung"].ToString(),
                        DungLuong = (int)reader["DungLuong"],
                        MoTa = reader["MoTa"].ToString(),
                    };
                    hardDrives.Add(hardDrive);
                }
            }
            return hardDrives;
        }

        // Lấy tất cả Card đồ họa
        public List<GraphicsCard> GetGraphicsCard()
        {
            List<GraphicsCard> graphicsCards = new List<GraphicsCard>();
            string query = @"SELECT * FROM CardDoHoa";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    GraphicsCard graphicsCard = new GraphicsCard
                    {
                        MaCard = reader["MaCard"].ToString(),
                        TenCard = reader["TenCard"].ToString(),
                    };
                    graphicsCards.Add(graphicsCard);
                }
            }
            return graphicsCards;
        }

        // Lấy tất cả Manufacturer với các mối quan hệ (GPUs, CPUs, RAMs, v.v.)
        public List<Manufacturer> GetManufacturersWithRelationships()
        {
            var manufacturers = new List<Manufacturer>();

            // Lấy danh sách Manufacturer cơ bản
            string query = "SELECT MaHSX, TenHSX FROM HangSanXuat";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    manufacturers.Add(new Manufacturer
                    {
                        MaHSX = reader["MaHSX"].ToString(),
                        TenHSX = reader["TenHSX"].ToString(),
                        CPUs = new List<CPU>(),
                        RAMs = new List<RAM>(),
                        GPUs = new List<GPU>(),
                        Mainboards = new List<Mainboard>(),
                        ComputerScreens = new List<ComputerScreen>()
                    });
                }
            }

            // Lấy các mối quan hệ
            var cpus = GetCPUsWithManufacturer();
            var rams = GetRAMsWithManufacturer();
            var gpus = GetGPUsWithManufacturer();
            var mainboards = GetMainboardWithManufacturer();
            var screens = GetScreensWithManufacturer();

            // Gán các mối quan hệ
            foreach (var manufacturer in manufacturers)
            {
                manufacturer.CPUs = cpus.Where(c => c.MaHSX == manufacturer.MaHSX).ToList();
                manufacturer.RAMs = rams.Where(r => r.MaHSX == manufacturer.MaHSX).ToList();
                manufacturer.GPUs = gpus.Where(g => g.MaHSX == manufacturer.MaHSX).ToList();
                manufacturer.Mainboards = mainboards.Where(m => m.MaHSX == manufacturer.MaHSX).ToList();
                manufacturer.ComputerScreens = screens.Where(s => s.MaHSX == manufacturer.MaHSX).ToList();
            }

            return manufacturers;
        }

        // Lấy tất cả Computer Type
        public List<ComputerType> GetComputerTypesWithRelationships()
        {
            List<ComputerType> types = new List<ComputerType>();
            string query = "SELECT MaLoaiMay, TenLoaiMay FROM LoaiMay";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    types.Add(new ComputerType
                    {
                        MaLoaiMay = reader["MaLoaiMay"].ToString(),
                        TenLoaiMay = reader["TenLoaiMay"].ToString()
                    });
                }
            }
            return types;
        }

        // Lấy tất cả hóa đơn bán với mối quan hệ
        public List<SalesInvoice> GetSalesInvoicesWithRelationships()
        {
            List<SalesInvoice> invoices = new List<SalesInvoice>();
            string query = @"
        SELECT 
            hdb.MaHDB, hdb.MaKhach, hdb.MaNV, hdb.NgayBan, hdb.TongTien, hdb.TrangThaiDonHang,
            kh.TenKhach, nv.TenNV
        FROM HoaDonBan hdb
        LEFT JOIN KhachHang kh ON hdb.MaKhach = kh.MaKhach
        LEFT JOIN NhanVien nv ON hdb.MaNV = nv.MaNV";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    SalesInvoice invoice = new SalesInvoice
                    {
                        MaHDB = reader["MaHDB"].ToString(),
                        MaKhach = reader["MaKhach"].ToString(),
                        MaNV = reader["MaNV"].ToString(),
                        NgayBan = (DateTime)reader["NgayBan"],
                        TongTien = (decimal)reader["TongTien"],
                        TrangThaiDonHang = reader["TrangThaiDonHang"].ToString(),
                        Customer = new Customer
                        {
                            MaKhach = reader["MaKhach"].ToString(),
                            TenKhach = reader["TenKhach"].ToString()
                        },
                        Employee = new Employee
                        {
                            MaNV = reader["MaNV"].ToString(),
                            TenNV = reader["TenNV"].ToString()
                        },
                        SalesInvoiceDetails = new List<SalesInvoiceDetail>()
                    };
                    invoices.Add(invoice);
                }
            }

            // Lấy chi tiết hóa đơn
            foreach (var invoice in invoices)
            {
                invoice.SalesInvoiceDetails = GetSalesInvoiceDetailsByMaHDB(invoice.MaHDB);
            }

            return invoices;
        }

        // Lấy chi tiết hóa đơn bán theo MaHDB
        public List<SalesInvoiceDetail> GetSalesInvoiceDetailsByMaHDB(string maHDB)
        {
            List<SalesInvoiceDetail> details = new List<SalesInvoiceDetail>();
            string query = @"
        SELECT 
            cthdb.MaCTHDB, cthdb.MaHDB, cthdb.MaMay, cthdb.SoLuong, cthdb.GiaBan, cthdb.ThanhTien, cthdb.MaKhuyenMai,
            mt.TenMay, km.TenKhuyenMai
        FROM ChiTietHDB cthdb
        LEFT JOIN MayTinh mt ON cthdb.MaMay = mt.MaMay
        LEFT JOIN KhuyenMai km ON cthdb.MaKhuyenMai = km.MaKhuyenMai
        WHERE cthdb.MaHDB = @MaHDB";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHDB", maHDB);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SalesInvoiceDetail detail = new SalesInvoiceDetail
                        {
                            MaCTHDB = reader["MaCTHDB"].ToString(),
                            MaHDB = reader["MaHDB"].ToString(),
                            MaMay = reader["MaMay"].ToString(),
                            SoLuong = (int)reader["SoLuong"],
                            GiaBan = (decimal)reader["GiaBan"],
                            ThanhTien = (decimal)reader["ThanhTien"],
                            MaKhuyenMai = reader["MaKhuyenMai"] != DBNull.Value ? reader["MaKhuyenMai"].ToString() : null,
                            Computer = new Computer
                            {
                                MaMay = reader["MaMay"].ToString(),
                                TenMay = reader["TenMay"].ToString()
                            },
                            Promotion = reader["MaKhuyenMai"] != DBNull.Value ? new Promotion
                            {
                                MaKhuyenMai = reader["MaKhuyenMai"].ToString(),
                                TenKhuyenMai = reader["TenKhuyenMai"].ToString()
                            } : null,
                        };
                        details.Add(detail);
                    }
                }
            }
            return details;
        }

        // Lấy danh sách khách hàng
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string query = "SELECT * FROM KhachHang";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        MaKhach = reader["MaKhach"].ToString(),
                        TenKhach = reader["TenKhach"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        NgaySinh = (DateTime)reader["NgaySinh"],
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }
            return customers;
        }

        // Lấy danh sách nhân viên
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string query = "SELECT * FROM NhanVien";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        MaNV = reader["MaNV"].ToString(),
                        TenNV = reader["TenNV"].ToString(),
                        NgaySinh = (DateTime)reader["NgaySinh"],
                        GioiTinh = reader["GioiTinh"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        SoDienThoai = reader["SoDienThoai"].ToString(),
                        VaiTro = reader["VaiTro"].ToString(),
                        Username = reader["Username"].ToString(),
                        MatKhau = reader["MatKhau"].ToString()
                    });
                }
            }
            return employees;
        }

        // Lấy danh sách khuyến mãi
        public List<Promotion> GetPromotions()
        {
            List<Promotion> promotions = new List<Promotion>();
            string query = "SELECT * FROM KhuyenMai";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    promotions.Add(new Promotion
                    {
                        MaKhuyenMai = reader["MaKhuyenMai"].ToString(),
                        TenKhuyenMai = reader["TenKhuyenMai"].ToString(),
                        PhanTramGiam = (int)reader["PhanTramGiam"],
                        NgayBatDau = (DateTime)reader["NgayBatDau"],
                        NgayKetThuc = (DateTime)reader["NgayKetThuc"]
                    });
                }
            }
            return promotions;
        }

        // MÁY TÍNH
        // Thêm mới Máy tính
        public bool AddComputer(Computer computer)
        {
            string query = @"INSERT INTO MayTinh (MaMay, TenMay, HinhAnh, GhiChu, DonGia, SoLuongTon, ThoiGianBaoHanh,
                     MaLoaiMay, MaCPU, MaRAM, MaMainboard, MaGPU, MaOCung, MaManHinh, MaCard, MaHSX)
                     VALUES (@MaMay, @TenMay, @HinhAnh, @GhiChu, @DonGia, @SoLuongTon, @ThoiGianBaoHanh,
                     @MaLoaiMay, @MaCPU, @MaRAM, @MaMainboard, @MaGPU, @MaOCung, @MaManHinh, @MaCard, @MaHSX)";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaMay", computer.MaMay);
                cmd.Parameters.AddWithValue("@TenMay", computer.TenMay);
                cmd.Parameters.AddWithValue("@HinhAnh", computer.HinhAnh ?? "");
                cmd.Parameters.AddWithValue("@GhiChu", computer.GhiChu ?? "");
                cmd.Parameters.AddWithValue("@DonGia", computer.DonGia);
                cmd.Parameters.AddWithValue("@SoLuongTon", computer.SoLuongTon);
                cmd.Parameters.AddWithValue("@ThoiGianBaoHanh", computer.ThoiGianBaoHanh);
                cmd.Parameters.AddWithValue("@MaLoaiMay", computer.MaLoaiMay);
                cmd.Parameters.AddWithValue("@MaCPU", computer.MaCPU);
                cmd.Parameters.AddWithValue("@MaRAM", computer.MaRAM);
                cmd.Parameters.AddWithValue("@MaMainboard", computer.MaMainboard);
                cmd.Parameters.AddWithValue("@MaGPU", computer.MaGPU);
                cmd.Parameters.AddWithValue("@MaOCung", computer.MaOCung);
                cmd.Parameters.AddWithValue("@MaManHinh", computer.MaManHinh);
                cmd.Parameters.AddWithValue("@MaCard", computer.MaCard);
                cmd.Parameters.AddWithValue("@MaHSX", computer.MaHSX);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật máy tính
        public bool UpdateComputer(Computer computer)
        {
            string query = @"UPDATE MayTinh SET TenMay = @TenMay, HinhAnh = @HinhAnh, GhiChu = @GhiChu, DonGia = @DonGia,
                     SoLuongTon = @SoLuongTon, ThoiGianBaoHanh = @ThoiGianBaoHanh, MaLoaiMay = @MaLoaiMay,
                     MaCPU = @MaCPU, MaRAM = @MaRAM, MaMainboard = @MaMainboard, MaGPU = @MaGPU,
                     MaOCung = @MaOCung, MaManHinh = @MaManHinh, MaCard = @MaCard, MaHSX = @MaHSX
                     WHERE MaMay = @MaMay";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaMay", computer.MaMay);
                cmd.Parameters.AddWithValue("@TenMay", computer.TenMay);
                cmd.Parameters.AddWithValue("@HinhAnh", computer.HinhAnh ?? "");
                cmd.Parameters.AddWithValue("@GhiChu", computer.GhiChu ?? "");
                cmd.Parameters.AddWithValue("@DonGia", computer.DonGia);
                cmd.Parameters.AddWithValue("@SoLuongTon", computer.SoLuongTon);
                cmd.Parameters.AddWithValue("@ThoiGianBaoHanh", computer.ThoiGianBaoHanh);
                cmd.Parameters.AddWithValue("@MaLoaiMay", computer.MaLoaiMay);
                cmd.Parameters.AddWithValue("@MaCPU", computer.MaCPU);
                cmd.Parameters.AddWithValue("@MaRAM", computer.MaRAM);
                cmd.Parameters.AddWithValue("@MaMainboard", computer.MaMainboard);
                cmd.Parameters.AddWithValue("@MaGPU", computer.MaGPU);
                cmd.Parameters.AddWithValue("@MaOCung", computer.MaOCung);
                cmd.Parameters.AddWithValue("@MaManHinh", computer.MaManHinh);
                cmd.Parameters.AddWithValue("@MaCard", computer.MaCard);
                cmd.Parameters.AddWithValue("@MaHSX", computer.MaHSX);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa máy tính
        public bool DeleteComputer(string maMay)
        {
            string query = "DELETE FROM MayTinh WHERE MaMay = @MaMay";
            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaMay", maMay);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Tìm kiếm máy tính theo mã hoặc theo tên
        public List<Computer> SearchComputers(string keyword)
        {
            var computers = GetComputersWithRelationships();
            if (string.IsNullOrEmpty(keyword)) return computers;

            keyword = keyword.ToLower();
            return computers.Where(c =>
                (c.MaMay?.ToLower().Contains(keyword) ?? false) ||
                (c.TenMay?.ToLower().Contains(keyword) ?? false)).ToList();
        }

        // LOẠI MÁY TÍNH
        // Thêm mới loại máy tính
        public bool AddComputerType(ComputerType computerType)
        {
            string query = @"INSERT INTO LoaiMay (MaLoaiMay, TenLoaiMay)
                             VALUES (@MaLoaiMay, @TenLoaiMay)";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaLoaiMay", computerType.MaLoaiMay);
                cmd.Parameters.AddWithValue("@TenLoaiMay", computerType.TenLoaiMay);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi trùng khóa chính (MaLoaiMay)
                    {
                        return false; // Trả về false nếu mã loại máy đã tồn tại
                    }
                    throw;
                }
            }
        }

        // Cập nhật loại máy tính
        public bool UpdateComputerType(ComputerType computerType)
        {
            string query = @"UPDATE LoaiMay 
                             SET TenLoaiMay = @TenLoaiMay
                             WHERE MaLoaiMay = @MaLoaiMay";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaLoaiMay", computerType.MaLoaiMay);
                cmd.Parameters.AddWithValue("@TenLoaiMay", computerType.TenLoaiMay);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa loại máy tính
        public bool DeleteComputerType(string maLoaiMay)
        {
            string query = "DELETE FROM LoaiMay WHERE MaLoaiMay = @MaLoaiMay";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaLoaiMay", maLoaiMay);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Lỗi khóa ngoại (có máy tính tham chiếu đến loại máy này)
                    {
                        MessageBox.Show("Không thể xóa loại máy tính này vì có máy tính đang sử dụng nó.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    throw;
                }
            }
        }

        // HÓA ĐƠN
        // Thêm hóa đơn bán
        public bool AddSalesInvoice(SalesInvoice salesInvoice)
        {
            string query = @"INSERT INTO HoaDonBan (MaHDB, MaKhach, MaNV, NgayBan, TongTien, TrangThaiDonHang)
                     VALUES (@MaHDB, @MaKhach, @MaNV, @NgayBan, @TongTien, @TrangThaiDonHang)";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHDB", salesInvoice.MaHDB);
                cmd.Parameters.AddWithValue("@MaKhach", salesInvoice.MaKhach);
                cmd.Parameters.AddWithValue("@MaNV", salesInvoice.MaNV);
                cmd.Parameters.AddWithValue("@NgayBan", salesInvoice.NgayBan);
                cmd.Parameters.AddWithValue("@TongTien", salesInvoice.TongTien);
                cmd.Parameters.AddWithValue("@TrangThaiDonHang", salesInvoice.TrangThaiDonHang);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi trùng khóa chính
                    {
                        return false;
                    }
                    throw;
                }
            }
        }

        // Cập nhật hóa đơn bán
        public bool UpdateSalesInvoice(SalesInvoice salesInvoice)
        {
            string query = @"UPDATE HoaDonBan 
                     SET MaKhach = @MaKhach, MaNV = @MaNV, NgayBan = @NgayBan, 
                         TongTien = @TongTien, TrangThaiDonHang = @TrangThaiDonHang
                     WHERE MaHDB = @MaHDB";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHDB", salesInvoice.MaHDB);
                cmd.Parameters.AddWithValue("@MaKhach", salesInvoice.MaKhach);
                cmd.Parameters.AddWithValue("@MaNV", salesInvoice.MaNV);
                cmd.Parameters.AddWithValue("@NgayBan", salesInvoice.NgayBan);
                cmd.Parameters.AddWithValue("@TongTien", salesInvoice.TongTien);
                cmd.Parameters.AddWithValue("@TrangThaiDonHang", salesInvoice.TrangThaiDonHang);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa hóa đơn bán
        public bool DeleteSalesInvoice(string maHDB)
        {
            string query = "DELETE FROM HoaDonBan WHERE MaHDB = @MaHDB";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHDB", maHDB);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Lỗi khóa ngoại
                    {
                        MessageBox.Show("Không thể xóa hóa đơn này vì có chi tiết hóa đơn liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    throw;
                }
            }
        }

        // Cập nhật tổng tiền hóa đơn
        public void UpdateInvoiceTotal(string maHDB)
        {
            string query = @"
        UPDATE HoaDonBan 
        SET TongTien = COALESCE((SELECT SUM(ThanhTien) FROM ChiTietHDB WHERE MaHDB = @MaHDB), 0)
        WHERE MaHDB = @MaHDB";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHDB", maHDB);
                cmd.ExecuteNonQuery();
            }
        }
        // Lấy tổng tiền
        public decimal GetInvoiceTotal(string maHDB)
        {
            string query = @"
        SELECT COALESCE((SELECT SUM(ThanhTien) FROM ChiTietHDB WHERE MaHDB = @MaHDB), 0)";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHDB", maHDB);
                object result = cmd.ExecuteScalar();
                return (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
            }
        }

        public void VerifyInvoiceTotal(string maHDB)
        {
            decimal chiTietTotal = GetInvoiceTotal(maHDB);
            string query = "SELECT TongTien FROM HoaDonBan WHERE MaHDB = @MaHDB";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHDB", maHDB);
                conn.Open();
                object result = cmd.ExecuteScalar();
                decimal hoaDonTotal = (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;

                if (chiTietTotal != hoaDonTotal)
                {
                    MessageBox.Show($"Tổng tiền không khớp: ChiTietHDB = {chiTietTotal}, HoaDonBan = {hoaDonTotal}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // DOANH THU
        // Tính doanh thu theo khoảng thời gian
        public decimal CalculateRevenue(DateTime startDate, DateTime endDate)
        {
            string query = @"
        SELECT SUM(TongTien)
        FROM HoaDonBan
        WHERE NgayBan BETWEEN @StartDate AND @EndDate
        AND TrangThaiDonHang = 'Hoàn thành'";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                var result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (decimal)result : 0;
            }
        }

        // Lấy danh sách hóa đơn bán theo khoảng thời gian
        public List<SalesInvoice> GetSalesInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            List<SalesInvoice> invoices = new List<SalesInvoice>();
            string query = @"
        SELECT 
            hdb.MaHDB, hdb.MaKhach, hdb.MaNV, hdb.NgayBan, hdb.TongTien, hdb.TrangThaiDonHang,
            kh.TenKhach, nv.TenNV
        FROM HoaDonBan hdb
        LEFT JOIN KhachHang kh ON hdb.MaKhach = kh.MaKhach
        LEFT JOIN NhanVien nv ON hdb.MaNV = nv.MaNV
        WHERE hdb.NgayBan BETWEEN @StartDate AND @EndDate";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SalesInvoice invoice = new SalesInvoice
                        {
                            MaHDB = reader["MaHDB"].ToString(),
                            MaKhach = reader["MaKhach"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            NgayBan = (DateTime)reader["NgayBan"],
                            TongTien = (decimal)reader["TongTien"],
                            TrangThaiDonHang = reader["TrangThaiDonHang"].ToString(),
                            Customer = new Customer
                            {
                                MaKhach = reader["MaKhach"].ToString(),
                                TenKhach = reader["TenKhach"].ToString()
                            },
                            Employee = new Employee
                            {
                                MaNV = reader["MaNV"].ToString(),
                                TenNV = reader["TenNV"].ToString()
                            }
                        };
                        invoices.Add(invoice);
                    }
                }
            }
            return invoices;
        }

        // Lấy top 5 sản phẩm bán chạy theo khoảng thời gian
        public List<(string ProductName, int TotalSold)> GetTopSellingProducts(DateTime startDate, DateTime endDate)
        {
            List<(string ProductName, int TotalSold)> topProducts = new List<(string, int)>();
            string query = @"
        SELECT TOP 5
            mt.TenMay AS ProductName,
            SUM(cthdb.SoLuong) AS TotalSold
        FROM ChiTietHDB cthdb
        INNER JOIN HoaDonBan hdb ON cthdb.MaHDB = hdb.MaHDB
        LEFT JOIN MayTinh mt ON cthdb.MaMay = mt.MaMay
        WHERE hdb.NgayBan BETWEEN @StartDate AND @EndDate
        GROUP BY mt.MaMay, mt.TenMay
        ORDER BY TotalSold DESC";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        topProducts.Add((
                            ProductName: reader["ProductName"].ToString(),
                            TotalSold: (int)reader["TotalSold"]
                        ));
                    }
                }
            }
            return topProducts;
        }


        // CHI TIẾT HÓA ĐƠN
        // Thêm chi tiết hóa đơn bán
        public bool AddSalesInvoiceDetail(SalesInvoiceDetail detail)
        {
            string query = @"INSERT INTO ChiTietHDB (MaCTHDB, MaHDB, MaMay, SoLuong, GiaBan, ThanhTien, MaKhuyenMai)
                     VALUES (@MaCTHDB, @MaHDB, @MaMay, @SoLuong, @GiaBan, @ThanhTien, @MaKhuyenMai)";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaCTHDB", detail.MaCTHDB);
                cmd.Parameters.AddWithValue("@MaHDB", detail.MaHDB);
                cmd.Parameters.AddWithValue("@MaMay", detail.MaMay);
                cmd.Parameters.AddWithValue("@SoLuong", detail.SoLuong);
                cmd.Parameters.AddWithValue("@GiaBan", detail.GiaBan);
                cmd.Parameters.AddWithValue("@ThanhTien", detail.ThanhTien);
                cmd.Parameters.AddWithValue("@MaKhuyenMai", detail.MaKhuyenMai);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi trùng khóa chính
                    {
                        MessageBox.Show("Mã chi tiết hóa đơn đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (ex.Number == 547) // Lỗi khóa ngoại
                    {
                        MessageBox.Show("Mã hóa đơn hoặc mã máy không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    throw;
                }
            }
        }

        // Cập nhật chi tiết hóa đơn bán
        public bool UpdateSalesInvoiceDetail(SalesInvoiceDetail detail)
        {
            string query = @"UPDATE ChiTietHDB 
                     SET MaMay = @MaMay, SoLuong = @SoLuong, GiaBan = @GiaBan, 
                         ThanhTien = @ThanhTien, MaKhuyenMai = @MaKhuyenMai
                     WHERE MaCTHDB = @MaCTHDB";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaCTHDB", detail.MaCTHDB);
                cmd.Parameters.AddWithValue("@MaMay", detail.MaMay);
                cmd.Parameters.AddWithValue("@SoLuong", detail.SoLuong);
                cmd.Parameters.AddWithValue("@GiaBan", detail.GiaBan);
                cmd.Parameters.AddWithValue("@ThanhTien", detail.ThanhTien);
                cmd.Parameters.AddWithValue("@MaKhuyenMai", detail.MaKhuyenMai ?? (object)DBNull.Value);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Lỗi khóa ngoại
                    {
                        MessageBox.Show("Mã máy hoặc mã khuyến mãi không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    throw;
                }
            }
        }

        // Xóa chi tiết hóa đơn bán
        public bool DeleteSalesInvoiceDetail(string maCTHDB)
        {
            string query = "DELETE FROM ChiTietHDB WHERE MaCTHDB = @MaCTHDB";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaCTHDB", maCTHDB);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra số lượng tồn kho trước khi thêm/sửa chi tiết hóa đơn
        public bool CheckInventory(string maMay, int soLuong)
        {
            string query = "SELECT SoLuongTon FROM MayTinh WHERE MaMay = @MaMay";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaMay", maMay);
                var result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return false;

                int soLuongTon = Convert.ToInt32(result);
                return soLuongTon >= soLuong;
            }
        }

        // Cập nhật số lượng tồn kho sau khi thêm/sửa/xóa chi tiết hóa đơn
        public bool UpdateInventory(string maMay, int soLuongChange)
        {
            string query = @"UPDATE MayTinh 
                     SET SoLuongTon = SoLuongTon + @SoLuongChange
                     WHERE MaMay = @MaMay";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaMay", maMay);
                cmd.Parameters.AddWithValue("@SoLuongChange", -soLuongChange); // Giảm số lượng tồn
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        // Tạo mã chi tiết hóa đơn bán
        public int GetNextCTHDBSequence(string maHDB)
        {
            string query = @"
        SELECT COALESCE(MAX(CAST(RIGHT(MaCTHDB, 3) AS INT)), 0) + 1
        FROM ChiTietHDB
        WHERE MaHDB = @MaHDB
        AND MaCTHDB LIKE 'CTHDB' + @MaHDB + '[0-9][0-9][0-9]'";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHDB", maHDB);
                object result = cmd.ExecuteScalar();
                return (result != DBNull.Value) ? Convert.ToInt32(result) : 1;
            }
        }

        // KHÁCH HÀNG
        // Thêm khách hàng
        public bool AddCustomer(Customer customer)
        {
            string query = @"INSERT INTO KhachHang (MaKhach, TenKhach, GioiTinh, NgaySinh, SoDienThoai, DiaChi, Email)
                     VALUES (@MaKhach, @TenKhach, @GioiTinh, @NgaySinh, @SoDienThoai, @DiaChi, @Email)";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhach", customer.MaKhach);
                cmd.Parameters.AddWithValue("@TenKhach", customer.TenKhach);
                cmd.Parameters.AddWithValue("@GioiTinh", customer.GioiTinh ?? "");
                cmd.Parameters.AddWithValue("@NgaySinh", customer.NgaySinh);
                cmd.Parameters.AddWithValue("@SoDienThoai", customer.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", customer.DiaChi ?? "");
                cmd.Parameters.AddWithValue("@Email", customer.Email ?? "");

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi trùng khóa chính
                    {
                        return false;
                    }
                    throw;
                }
            }
        }

        // Cập nhật khách hàng
        public bool UpdateCustomer(Customer customer)
        {
            string query = @"UPDATE KhachHang 
                     SET TenKhach = @TenKhach, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, 
                         SoDienThoai = @SoDienThoai, DiaChi = @DiaChi, Email = @Email
                     WHERE MaKhach = @MaKhach";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhach", customer.MaKhach);
                cmd.Parameters.AddWithValue("@TenKhach", customer.TenKhach);
                cmd.Parameters.AddWithValue("@GioiTinh", customer.GioiTinh ?? "");
                cmd.Parameters.AddWithValue("@NgaySinh", customer.NgaySinh);
                cmd.Parameters.AddWithValue("@SoDienThoai", customer.SoDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", customer.DiaChi ?? "");
                cmd.Parameters.AddWithValue("@Email", customer.Email ?? "");

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa khách hàng
        public bool DeleteCustomer(string maKhach)
        {
            string query = "DELETE FROM KhachHang WHERE MaKhach = @MaKhach";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhach", maKhach);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Lỗi khóa ngoại
                    {
                        MessageBox.Show("Không thể xóa khách hàng do có hóa đơn liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    throw;
                }
            }
        }

        // Lấy thông tin khách hàng bằng id
        public Customer GetCustomerById(string maKhach)
        {
            Customer customer = null;
            string query = "SELECT * FROM KhachHang WHERE MaKhach = @MaKhach";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhach", maKhach);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                MaKhach = reader["MaKhach"].ToString(),
                                TenKhach = reader["TenKhach"].ToString(),
                                DiaChi = reader["DiaChi"]?.ToString(),
                                SoDienThoai = reader["SoDienThoai"]?.ToString()
                            };
                        }
                    }
                }
            }
            return customer;
        }

        // Lấy mã khách từ hóa đơn bán
        public string GetMaKhachFromMaHDB(string maHDB)
        {
            string maKhach = "";
            string query = "SELECT MaKhach FROM HoaDonBan WHERE MaHDB = @MaHDB";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHDB", maHDB);
                    var result = cmd.ExecuteScalar();
                    maKhach = result?.ToString();
                }
            }
            return maKhach;
        }

        // NHÂN VIÊN
        // Thêm nhân viên <khuyết thông tin>
        public bool AddEmployee(Employee employee)
        {
            string query = @"INSERT INTO NhanVien (MaNV, TenNV, NgaySinh, GioiTinh, DiaChi, SoDienThoai, VaiTro)
             VALUES (@MaNV, @TenNV, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @VaiTro)";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", employee.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", employee.TenNV);
                cmd.Parameters.AddWithValue("@NgaySinh", employee.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", employee.GioiTinh ?? "");
                cmd.Parameters.AddWithValue("@DiaChi", employee.DiaChi ?? "");
                cmd.Parameters.AddWithValue("@SoDienThoai", employee.SoDienThoai);
                cmd.Parameters.AddWithValue("@VaiTro", employee.VaiTro ?? "");

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi trùng khóa chính
                    {
                        return false;
                    }
                    throw;
                }
            }
        }

        // Thêm nhân viên <đầy đủ thông tin>
        public bool RegisterEmployee(Employee employee)
        {
            string query = @"INSERT INTO NhanVien (MaNV, TenNV, NgaySinh, GioiTinh, DiaChi, SoDienThoai,Username,MatKhau)
             VALUES (@MaNV, @TenNV, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @Username, @MatKhau)";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", employee.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", employee.TenNV);
                cmd.Parameters.AddWithValue("@NgaySinh", employee.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", employee.GioiTinh ?? "");
                cmd.Parameters.AddWithValue("@DiaChi", employee.DiaChi ?? "");
                cmd.Parameters.AddWithValue("@SoDienThoai", employee.SoDienThoai);
                cmd.Parameters.AddWithValue("@Username", employee.Username);
                cmd.Parameters.AddWithValue("@MatKhau", employee.MatKhau);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Lỗi trùng khóa chính
                    {
                        return false;
                    }
                    // Hiển thị thông báo lỗi chi tiết
                    MessageBox.Show($"Lỗi khi đăng ký nhân viên: {ex.Message}\nMã lỗi: {ex.Number}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    // Xử lý các lỗi không phải SQL
                    MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Cập nhật nhân viên
        public bool UpdateEmployee(Employee employee)
        {
            string query = @"UPDATE NhanVien 
             SET TenNV = @TenNV, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, 
                 DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, VaiTro = @VaiTro
             WHERE MaNV = @MaNV";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", employee.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", employee.TenNV);
                cmd.Parameters.AddWithValue("@NgaySinh", employee.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", employee.GioiTinh ?? "");
                cmd.Parameters.AddWithValue("@DiaChi", employee.DiaChi ?? "");
                cmd.Parameters.AddWithValue("@SoDienThoai", employee.SoDienThoai);
                cmd.Parameters.AddWithValue("@VaiTro", employee.VaiTro ?? "");

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật thông tin người dùng
        public bool UpdateInfo(Employee employee)
        {
            string query = @"UPDATE NhanVien 
                     SET TenNV = @TenNV, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, 
                         DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Username = @Username
                     WHERE MaNV = @MaNV";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", employee.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", employee.TenNV);
                cmd.Parameters.AddWithValue("@NgaySinh", employee.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", employee.GioiTinh ?? "");
                cmd.Parameters.AddWithValue("@DiaChi", employee.DiaChi ?? "");
                cmd.Parameters.AddWithValue("@SoDienThoai", employee.SoDienThoai);
                cmd.Parameters.AddWithValue("@Username", employee.Username);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi SQL, ví dụ: lỗi trùng Username (ràng buộc UNIQUE)
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại! Vui lòng chọn tên đăng nhập khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    MessageBox.Show($"Lỗi khi cập nhật thông tin nhân viên: {ex.Message}\nMã lỗi: {ex.Number}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Xóa nhân viên
        public bool DeleteEmployee(string maNV)
        {
            string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";

            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Lỗi khóa ngoại
                    {
                        MessageBox.Show("Không thể xóa nhân viên do có hóa đơn liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    throw;
                }
            }
        }

        // TÀI KHOẢN
        public bool UpdateAccount(string maNV, string username, string matKhau)
        {
            string query = @"UPDATE NhanVien SET Username = @Username, MatKhau = @MatKhau WHERE MaNV = @MaNV";
            using (SqlConnection conn = DatabaseContext.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                return cmd.ExecuteNonQuery() > 0;
            }
        }


    }
}