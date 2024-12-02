using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Bill
    {
        public int ID { get; set; }
        public int KhachHangID { get; set; }
        public int NhanVienID {  get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public int TongTien {  get; set; }
        public string TrangThai {  get; set; }
        public bool LoaiHoaDon { get; set; }
        public int GiamGia {  get; set; }
    }
}
