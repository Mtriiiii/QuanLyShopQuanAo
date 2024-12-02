using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Clothes
    {
        public int ID {  get; set; }    
        public string TenQuanAo { get; set; }
        public int NhomMatHangID {  get; set; }
        public int GiaBan {  get; set; }
        public string DVT {  get; set; }
        public string GhiChu {  get; set; }
        public bool Enable {  get; set; }
    }
}
