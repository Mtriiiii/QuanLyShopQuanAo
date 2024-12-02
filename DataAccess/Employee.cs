using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Employee
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string SoCCCD { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string ViTriLV {  get; set; }
        public string SoDienThoai {  get; set; }
        public int Luong {  get; set; }
        public bool Enable {  get; set; }
        public string TenTaiKhoan {  get; set; }
        public string Password {  get; set; }
    }
}
