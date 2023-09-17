using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiLab
{
    internal class Program
    {
        static List<Vehicle> listVehicle = new List<Vehicle>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Vehicle vehicle = new Vehicle();
            Car xe1 = new Car
            {
                ngaySX = new DateTime(2020, 8, 20),
                bienSo = "0123456789",
                SoChoNgoi = 4,
                DkiKinhDoanhVanTai1 = true
            };

            Car xe2 = new Car
            {
                ngaySX = new DateTime(2022, 9, 21),
                bienSo = "0123456789",
                SoChoNgoi = 7,
                DkiKinhDoanhVanTai1 = false
            };
            Car xe3 = new Car
            {
                ngaySX = new DateTime(2023, 12, 22),
                bienSo = "0123456789",
                SoChoNgoi = 7,
                DkiKinhDoanhVanTai1 = true
            };
            Car xe4 = new Car
            {
                ngaySX = new DateTime(2021, 11, 23),
                bienSo = "0123456789",
                SoChoNgoi = 4,
                DkiKinhDoanhVanTai1 = false
            };

            listVehicle.Add(xe1);
            listVehicle.Add(xe2);
            listVehicle.Add(xe3);
            listVehicle.Add(xe4);

            Truck truck1 = new Truck
            {
                ngaySX = new DateTime(2021, 12, 23),
                bienSo = "0123455555",
                TrongTai = 22,

            }; Truck truck2 = new Truck
            {
                ngaySX = new DateTime(2020, 11, 24),
                bienSo = "0123456789",
                TrongTai = 6,

            }; Truck truck3 = new Truck
            {
                ngaySX = new DateTime(2019, 10, 25),
                bienSo = "0123466669",
                TrongTai = 7,

            }; Truck truck4 = new Truck
            {
                ngaySX = new DateTime(2018, 09, 26),
                bienSo = "0123466678",
                TrongTai = 8,

            };
            listVehicle.Add(truck1);
            listVehicle.Add(truck3);
            listVehicle.Add(truck2);

            listVehicle.Add(truck4);

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Thêm xe ô tô.");
                Console.WriteLine("2. Thêm xe tải.");
                Console.WriteLine("3. Xuất danh sách hiển thị thông tin tất cả các xe.");
                Console.WriteLine("4. Tìm xe ô tô có số chỗ ngồi nhiều nhất.");
                Console.WriteLine("5. Sắp xếp danh sách xe tải theo trọng tải tăng dần.");
                Console.WriteLine("6. Xuất danh sách các biển số xe đẹp.");
                Console.WriteLine("7. Tính số tiền đăng kiểm định kỳ của từng xe đến thời điểm hiện tại.");
                Console.WriteLine("8. Tính thời gian đăng kiểm định kỳ của từng xe sắp tới.");
                Console.WriteLine("9. Tính tổng số tiền đã đăng kiểm.");
                Console.WriteLine("0. Thoát chương trình.");
                Console.Write("Nhập lựa chọn: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        vehicle = new Car();
                        vehicle.nhapTT();
                        listVehicle.Add(vehicle);
                        break;
                    case 2:
                        vehicle = new Truck();
                        vehicle.nhapTT();
                        listVehicle.Add(vehicle);
                        break;
                    case 3:
                        XuatDanhSachXe();
                        break;
                    case 4:
                        TimXeOtoCoSoChoNhieuNhat();
                        break;
                    case 5:
                        SapXepXeTaiTheoTrongTai();
                        break;
                    case 6:
                        XuatDanhSachBienSoXeDep();
                        break;
                    case 7:
                        TinhTienDangKiemXeDenThoiDiemHienTai(listVehicle);
                        break;
                    case 8:
                        TinhThoiGianDangKiemXeSapToi(listVehicle);
                        break;
                    case 9:
                        TinhTongTienDangKiem(listVehicle);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }

        }

        private static void TinhTongTienDangKiem(List<Vehicle> vehicles)
        {
            Console.WriteLine("Nhập ngày hiện tại (yyyy-MM-dd): ");
            DateTime ngayHienTai = DateTime.Parse(Console.ReadLine());

            double tongTien = 0;

            foreach (var xe in vehicles)
            {
                double tienDangKiem = xe.tinhTienDangKiem(ngayHienTai);
                tongTien += tienDangKiem;
            }

            Console.WriteLine($"Tổng số tiền đã đăng kiểm: {tongTien}");
        }

        private static void TinhThoiGianDangKiemXeSapToi(List<Vehicle> vehicles)
        {
            Console.WriteLine("Nhập ngày hiện tại (yyyy-MM-dd): ");
            DateTime ngayHienTai = DateTime.Parse(Console.ReadLine());

            foreach (var xe in vehicles)
            {
                TimeSpan thoiGianConLai = xe.TinhThoiGianDangKiem(ngayHienTai);
                Console.WriteLine($"Biển số: {xe.bienSo} - Thời gian đến đăng kiểm kỳ tiếp theo: {thoiGianConLai.Days} ngày");
            }

        }

        private static void TinhTienDangKiemXeDenThoiDiemHienTai(List<Vehicle> vehicles)
        {
            Console.WriteLine("Nhập ngày hiện tại (yyyy-MM-dd): ");
            DateTime ngayHienTai = DateTime.Parse(Console.ReadLine());

            foreach (var xe in vehicles)
            {
                double tienDangKiem = xe.tinhTienDangKiem(ngayHienTai);
                Console.WriteLine($"Biển số: {xe.bienSo} - Số tiền đăng kiểm: {tienDangKiem}");
            }

        }

        private static void XuatDanhSachBienSoXeDep()
        {
            var bienSoDep = listVehicle.Where(x => x.bienSo.Substring(x.bienSo.Length - 5).Distinct().Count() <= 2);

            Console.WriteLine("Danh sach bien so xe dep");
            foreach (var x in bienSoDep)
            {

                if (bienSoDep.Count() > 0)

                {

                    Console.WriteLine("{0}", x.bienSo);
                }
                else Console.WriteLine("Khong co bien so dep");
            }
        }

        private static void SapXepXeTaiTheoTrongTai()
        {
            var trucks = listVehicle.OfType<Truck>().OrderBy(x => x.TrongTai).ToList();
            Console.WriteLine("Danh sach xe tai sau sap xep theo trong tai tang dan ");
            foreach (var truck in trucks)
            {
                truck.xuatTT();
            }
        }

        private static void TimXeOtoCoSoChoNhieuNhat()
        {
            var maxSeat = listVehicle.OfType<Car>().Max(x => x.SoChoNgoi);
            var cars = listVehicle.OfType<Car>().Where(x => x.SoChoNgoi == maxSeat).ToList();
            if (cars != null)
            {
                Console.WriteLine("Xe o to co cho ngoi nhieu nhat ");
                foreach (var c in cars)
                {
                    c.xuatTT();
                }
            }
            else Console.WriteLine("Khong co xe o to trong danh sach");
        }

        private static void XuatDanhSachXe()
        {
            Console.WriteLine("Danh sach thong tin cac xe ");
            foreach (var v in listVehicle)
            {
                v.xuatTT();
            }
        }


    }
}

