using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiLab
{
    internal class Car : Vehicle
    {
        private int soChoNgoi;
        private bool DkiKinhDoanhVanTai;

        public Car(DateTime ngaySX, string bienSo, int soChoNgoi, bool dkiKinhDoanhVanTai) : base(ngaySX, bienSo)
        {
            this.soChoNgoi = soChoNgoi;
            DkiKinhDoanhVanTai = dkiKinhDoanhVanTai;
        }

        public Car()
        {
        }

        public int SoChoNgoi { get => soChoNgoi; set => soChoNgoi = value; }
        public bool DkiKinhDoanhVanTai1 { get => DkiKinhDoanhVanTai; set => DkiKinhDoanhVanTai = value; }
        public override void nhapTT()
        {
            base.nhapTT();
            Console.WriteLine("Nhap so cho ngoi ");
            SoChoNgoi = int.Parse(Console.ReadLine());
            Console.WriteLine("Co dang ki giao thong van tai khong (1-->Co, 0-->Khong)");
            DkiKinhDoanhVanTai = int.Parse(Console.ReadLine()) == 1;
        }
        public override void xuatTT()
        {
            base.xuatTT();
            Console.WriteLine("So cho ngoi {0}, Dang ki kinh doanh van chuyen {1}", this.soChoNgoi, this.DkiKinhDoanhVanTai == true ? "Co" : "Khong");

        }
        public override double tinhTienDangKiem(DateTime ngayHienTai)
        {
            int kiemDinhDinhKy = 0;
            int soNamSanXuat = ngayHienTai.Year - NgaySX.Year;

            if (soNamSanXuat <= 7)
            {
                kiemDinhDinhKy = DkiKinhDoanhVanTai1 ? 12 : 24;
            }
            else
            {
                kiemDinhDinhKy = 6;
            }

            double giaDangKiem = SoChoNgoi <= 10 ? 240000 : 320000;

            return kiemDinhDinhKy * giaDangKiem;
        }
        public override TimeSpan TinhThoiGianDangKiem(DateTime ngayHienTai)
        {
            int kiemDinhDinhKy = 0;
            int soNamSanXuat = ngayHienTai.Year - NgaySX.Year;

            if (soNamSanXuat <= 7)
            {
                kiemDinhDinhKy = DkiKinhDoanhVanTai ? 12 : 24;
            }
            else
            {
                kiemDinhDinhKy = 6;
            }

            int thangConLai = kiemDinhDinhKy - ((ngayHienTai.Year - ngaySX.Year) * 12 + ngayHienTai.Month - NgaySX.Month);

            return new TimeSpan(thangConLai * 30, 0, 0, 0);
        }
    }

}
