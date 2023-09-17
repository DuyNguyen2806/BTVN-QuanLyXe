using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiLab
{
    internal class Truck : Vehicle
    {
        private double trongTai;

        public Truck()
        {
        }

        public Truck(DateTime ngaySX, string bienSo, double trongTai) : base(ngaySX, bienSo)
        {
            this.TrongTai = trongTai;
        }

        public double TrongTai { get => trongTai; set => trongTai = value; }
        public override void nhapTT()
        {
            base.nhapTT();
            Console.WriteLine("Nhap trong tai ");
            TrongTai = double.Parse(Console.ReadLine());

        }
        public override void xuatTT()
        {
            base.xuatTT();
            Console.WriteLine("Trong tai {0} tan", this.TrongTai);

        }
        public override double tinhTienDangKiem(DateTime ngayHienTai)
        {
            int kiemDinhDinhKy = 0;
            int soNamSanXuat = ngayHienTai.Year - NgaySX.Year;

            if (soNamSanXuat <= 20)
            {
                if (TrongTai > 20)
                {
                    kiemDinhDinhKy = 3;
                }
                else if (TrongTai >= 7)
                {
                    kiemDinhDinhKy = 6;
                }
                else
                {
                    kiemDinhDinhKy = 12;
                }
            }
            else
            {
                kiemDinhDinhKy = 6;
            }

            double giaDangKiem = TrongTai > 20 ? 560000 : (TrongTai >= 7 ? 350000 : 320000);

            return kiemDinhDinhKy * giaDangKiem;
        }

        public override TimeSpan TinhThoiGianDangKiem(DateTime ngayHienTai)
        {
            int kiemDinhDinhKy = 0;
            int soNamSanXuat = ngayHienTai.Year - ngaySX.Year;

            if (soNamSanXuat <= 20)
            {
                if (TrongTai > 20)
                {
                    kiemDinhDinhKy = 3;
                }
                else if (TrongTai >= 7)
                {
                    kiemDinhDinhKy = 6;
                }
                else
                {
                    kiemDinhDinhKy = 12;
                }
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
