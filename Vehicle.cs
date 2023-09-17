using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiLab
{
    internal class Vehicle
    {
        public DateTime ngaySX;
        public string bienSo;

        public Vehicle()
        {
        }
        public Vehicle(DateTime ngaySX, string bienSo)
        {
            this.ngaySX = ngaySX;
            this.bienSo = bienSo;
        }
        protected DateTime NgaySX { get => ngaySX; set => ngaySX = value; }
        protected string BienSo { get => bienSo; set => bienSo = value; }
        public virtual void nhapTT()
        {
            Console.WriteLine("Nhap ngay thang nam san xuat yyyy-mm-d");
            NgaySX = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Nhap bien so ");
            BienSo = Console.ReadLine();
        }
        public virtual void xuatTT()
        {
            Console.Write("Ngay san xuat {0}, bien so {1} ,", this.ngaySX, this.bienSo);
        }
        public virtual double tinhTienDangKiem(DateTime ngayHienTai) { return 0; }
        public virtual TimeSpan TinhThoiGianDangKiem(DateTime ngayHienTai)
        {
            return TimeSpan.Zero;
        }


    }
}
