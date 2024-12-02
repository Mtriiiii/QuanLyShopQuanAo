using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s6_s10
{
    public partial class frmHoaDonBanHang : Form
    {
        List<Bill> listBill = new List<Bill>();
        List<BillDetail> listBillDetail = new List<BillDetail>();
        List<Customer> listCustomer = new List<Customer>();
        List<Employee> listEmployee = new List<Employee>();
        List<Clothes> listClothes = new List<Clothes>();
        List<Color_Size> listColor_Size = new List<Color_Size>();
        public frmHoaDonBanHang()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {}

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {}

        private void frmHoaDonBanHang_Load(object sender, EventArgs e)
        {

            LoadNhanVien();
            LoadBillToListView();
            rdChuaThanhToan.Checked = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBillToListView();
            List<ListViewItem> list = new List<ListViewItem>();
            foreach(ListViewItem item in lvHoaDon.Items)
            {
                if (item.SubItems[2].Text==cbbLapBoi.Text)
                    list.Add(item);
            }
            LoadListView(list);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public void LoadBillToListView()
        {
            //Gọi đối tượng FoodBL từ tầng BusinessLogic
            BillBL billBL = new BillBL();
            listBill = billBL.GetAll();
            CustomerBL customerBL = new CustomerBL();
            listCustomer = customerBL.GetAll();
            EmployeeBL empBL = new EmployeeBL();
            listEmployee = empBL.GetAll();
            lvHoaDon.Items.Clear();
            foreach (var bill in listBill)
            {
                ListViewItem item = lvHoaDon.Items.Add(bill.ID.ToString());
                item.SubItems.Add(listCustomer.Find(x => x.Id == bill.KhachHangID).HoTen);
                item.SubItems.Add(listEmployee.Find(x => x.Id == bill.NhanVienID).HoTen);
                item.SubItems.Add(bill.NgayLapHoaDon.ToShortDateString());
                item.SubItems.Add(bill.TrangThai);
                item.SubItems.Add(bill.LoaiHoaDon?"Hóa đơn nhập hàng":"Hóa đơn bán hàng");
                item.SubItems.Add(bill.TongTien.ToString());
                item.SubItems.Add(bill.GiamGia.ToString());
                item.SubItems.Add((bill.TongTien-bill.GiamGia).ToString());
            }

        }
        void LoadListView(List<ListViewItem> items)
        {
            lvHoaDon.Items.Clear();
            foreach (ListViewItem item in items)
            {
                lvHoaDon.Items.Add(item);
            }
        }
        private void LoadNhanVien()
        {
            EmployeeBL employeeBL = new EmployeeBL();
            listEmployee = employeeBL.GetAll();
            cbbLapBoi.DataSource = listEmployee;
            cbbLapBoi.ValueMember = "ID";
            cbbLapBoi.DisplayMember = "HoTen";
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            LocTheoNgay();
        }

        void LocTheoNgay()
        {
            List<ListViewItem> list = new List<ListViewItem>();
            DateTime start = Convert.ToDateTime(dtpTuNgay.Value);
            DateTime end=Convert.ToDateTime(dtpDenNgay.Value);
            foreach (ListViewItem item in lvHoaDon.Items)
            {
                if (Convert.ToDateTime(item.SubItems[3].Text)>=start && Convert.ToDateTime(item.SubItems[3].Text) <= end)
                    list.Add(item);
            }
            
            LoadListView(list);
        }
       
        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rdAll.Checked) { LoadBillToListView(); }
        }

        private void rdHoanThanh_CheckedChanged(object sender, EventArgs e)
        {
            LoadBillToListView();
            List<ListViewItem> list = new List<ListViewItem>();
            if (rdHoanThanh.Checked)
            {
                foreach (ListViewItem item in lvHoaDon.Items)
                {
                    if (item.SubItems[4].Text == "Hoàn thành")
                        list.Add(item);
                }
            }
            LoadListView(list);
        }

        private void rdChuaThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            LoadBillToListView();
            List<ListViewItem> list = new List<ListViewItem>(); 
            if(rdChuaThanhToan.Checked)
                foreach (ListViewItem item in lvHoaDon.Items)
                {
                    if (item.SubItems[4].Text == "Chưa thanh toán")
                        list.Add(item);
                }
            LoadListView(list);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadBillToListView();
            List<ListViewItem> list = new List<ListViewItem>();
            foreach (ListViewItem item in lvHoaDon.Items)
            {
                if (item.SubItems[1].Text.ToLower().Contains(txtKhachHang.Text.ToLower()))
                    list.Add(item);
            }
            LoadListView(list);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadBillToListView();
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            LocTheoNgay();
        }

        private void lvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHoaDon.SelectedItems.Count > 0)
            {
                BillDetailBL billDetailBL = new BillDetailBL();
                //txtKhachHang.Text = lvHoaDon.SelectedItems[0].SubItems[0].ToString();
                listBillDetail = billDetailBL.GetFromBillID(int.Parse(lvHoaDon.SelectedItems[0].SubItems[0].Text));
                LoadBillDetail(listBillDetail);
            }
        }
        void LoadBillDetail(List<BillDetail> list)
        {
            lvBillDetail.Items.Clear();
            ClothesBL clothesBL = new ClothesBL();
            listClothes = clothesBL.GetAll();
            Color_SizeBL color_SizeBL = new Color_SizeBL();
            listColor_Size = color_SizeBL.GetAll();
            foreach (BillDetail billDetail in list)
            {
                Color_Size color_Size = listColor_Size.Find(x => x.ID == billDetail.MauSizeID);
                ListViewItem item = lvBillDetail.Items.Add(billDetail.ID.ToString());
                item.SubItems.Add(listClothes.Find(x => x.ID==color_Size.QuanAoID).TenQuanAo);
                item.SubItems.Add(color_Size.MauSac);
                item.SubItems.Add(color_Size.Size);
                item.SubItems.Add(billDetail.GiaBan.ToString());
                item.SubItems.Add(billDetail.SoLuong.ToString());
                item.SubItems.Add((billDetail.GiaBan * billDetail.SoLuong).ToString());

            }
        }
        private void lvHoaDon_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void lấyThôngTinĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void SetConTextMenu()
        { contextMenuStrip1.Enabled=false; }
        public void SetHoaDonChuaHoanThanh()
        {
            //rdChuaThanhToan.Checked= true;
            groupBox2.Enabled=false;
            //LoadBillToListView();
            //List<ListViewItem> list = new List<ListViewItem>();
            //if (rdChuaThanhToan.Checked)
            //    foreach (ListViewItem item in lvHoaDon.Items)
            //    {
            //        if (item.SubItems[4].Text == "Chưa thanh toán")
            //            list.Add(item);
            //    }
            //LoadListView(list);
        }

        //private void LoaBillList()
        //{
        //    // Giả sử bạn có một dịch vụ để lấy danh sách hóa đơn
        //    var list = Bill.GetAllBill(); // Thay thế bằng phương thức thực tế để lấy danh sách hóa đơn

        //    // Xóa các mục hiện tại trong ListView
        //    lvHoaDon.Items.Clear();

        //    // Thêm các hóa đơn vào ListView
        //    foreach (var bill in list)
        //    {
        //        ListViewItem item = new ListViewItem(bill.Id.ToString());
        //        item.SubItems.Add(bill.);
        //        item.SubItems.Add(bill.CustomerName);
        //        // Thêm các thông tin khác nếu cần
        //        lvHoaDon.Items.Add(item);
        //    }
        //}
    }
}
