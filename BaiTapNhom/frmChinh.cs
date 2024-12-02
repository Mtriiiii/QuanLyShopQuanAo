using BaiTapNhom.Khách_hàng;
using s6_s10;
using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess;
using BusinessLogic;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Globalization;

namespace BaiTapNhom
{
    public partial class frmChinh : Form
    {
        public Customer customer= new Customer();
        public Employee employee;
        public bool vaiTro = false;
        private bool suppressItemCheck = false;
        List<Color_Size> listMauSize= new List<Color_Size>();
        List<Clothes> listQuanAo= new List<Clothes>();
        List<Category> listNhomMatHang= new List<Category>();
        private string removeIcon = "remove.ico";
        public frmChinh()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Color_SizeBL mauSizeBL = new Color_SizeBL();
            listMauSize = mauSizeBL.GetAll();
            LoadLVMauSize(listMauSize);
            LoadNhomMatHang();
            if (employee.ViTriLV == "Quản lý")
                vaiTro = true;
            if (vaiTro)
                tmiQuanLy.Enabled = true;
            tsslTenNhanVien.Text = employee.HoTen;
            tsslVaiTro.Text = employee.ViTriLV;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Color_Size> result = new List<Color_Size>();
            foreach(ListViewItem item in lvMauSize.Items)
            {
                if (item.SubItems[1].Text.Contains(txtSearchByName.Text))
                    result.Add(listMauSize.Find(x => x.ID == int.Parse(item.SubItems[0].Text)));
            }
            LoadLVMauSize(result);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

      

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if(ckbGiaoHang.Checked) {
                groupbox.Enabled = true;
                txtPhiGiaoHang.Enabled = true;
            }
            else
            {
                groupbox.Enabled = false;
                txtPhiGiaoHang.Enabled = false;
            }    
            
        }


        private void hóaĐơnBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDonBanHang frmHoaDonBanHang = new frmHoaDonBanHang();
            frmHoaDonBanHang.ShowDialog();
        }

        private void quảnLýHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSachMatHang frm = new frmDanhSachMatHang();
            frm.ShowDialog();
        }

        private void hóaĐơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemLaiPhieuNhapHang.XemLaiPhieuNhapHang frm = new XemLaiPhieuNhapHang.XemLaiPhieuNhapHang();
            frm.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            frmKhachHang frmKhachHang = new frmKhachHang();
            frmKhachHang.ShowDialog();
        }

        private void sốLượngBánĐượcToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        public void LoadLVMauSize(List<Color_Size> list)
        {
            //Color_SizeBL mauSizeBL = new Color_SizeBL();
            //listMauSize = mauSizeBL.GetAll();
            CategoryBL nhomMatHangBL = new CategoryBL();
            listNhomMatHang = nhomMatHangBL.GetAll();
            ClothesBL quanAoBL = new ClothesBL();
            listQuanAo = quanAoBL.GetAll();
            lvMauSize.Items.Clear();
            foreach(var mausize in list)
            {
                int nhomMatHangID = listQuanAo.Find(x => x.ID == mausize.QuanAoID).NhomMatHangID;
                ListViewItem item = lvMauSize.Items.Add(mausize.ID.ToString());
                item.SubItems.Add(listQuanAo.Find(x => x.ID == mausize.QuanAoID).TenQuanAo);
                item.SubItems.Add(listNhomMatHang.Find(x => x.ID == nhomMatHangID).TenNhom);
                item.SubItems.Add(listQuanAo.Find(x => x.ID == mausize.QuanAoID).GiaBan.ToString());
                item.SubItems.Add(mausize.MauSac);
                item.SubItems.Add(mausize.Size);
                item.SubItems.Add(mausize.SoLuong.ToString());
            }
        }
        void LoadNhomMatHang()
        {
            CategoryBL nhomMatHangBL = new CategoryBL();
            List<int> list = nhomMatHangBL.GetSoLuong();
            foreach(var item in list)
            {
                Button btn = new Button();
                btn.Text = listNhomMatHang.Find(x=>x.ID==item).TenNhom;
                btn.AutoSize = true; // Để button tự điều chỉnh kích thước theo text
                btn.Click += Button_Click;
                // Thêm button vào FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(btn);
            }    
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Lấy thông tin từ Tag
                var tennhom = button.Text;
                if (tennhom == null)
                    return;
                List<Color_Size> result = new List<Color_Size>();
                if (lvMauSize.Items.Count == 0)
                    LoadLVMauSize(listMauSize);
                foreach (ListViewItem item in lvMauSize.Items)
                {
                    if (item.SubItems[2].Text == tennhom)
                        result.Add(listMauSize.Find(x => x.ID == int.Parse(item.SubItems[0].Text)));
                }
                LoadLVMauSize(result);
            }
        }

        private void checkedListBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (checkedListBox1.SelectedItems.Count == 0)
            //    return;
            //List<string> listSize = new List<string>();
            //for (int i = 0; i < checkedListBox1.Items.Count - 1; i++)
            //    if (checkedListBox1.GetItemChecked(i))
            //        listSize.Add(checkedListBox1.Items[i].ToString());
            //textBox3.Text = "";
            //foreach (var item in listSize)
            //{
            //    textBox3.AppendText(item);
            //}
            //Color_SizeBL color_SizeBL = new Color_SizeBL();
            //listMauSize=color_SizeBL.GetBySize(listSize);
            //LoadLVMauSize();


            //if (checkedListBox1.SelectedItems.Count == 0 || checkedListBox1.SelectedItems.Count==checkedListBox1.Items.Count)
            //    return;
            //List<string> listSize = new List<string>();
            //for (int i = 0; i < checkedListBox1.Items.Count - 1; i++)
            //    if (checkedListBox1.GetItemChecked(i))
            //        listSize.Add(checkedListBox1.Items[i].ToString());
            //List<Color_Size> result = new List<Color_Size>();
            //foreach (var item in listSize)
            //    result.AddRange(listMauSize.FindAll(x => x.Size == item));
            //listMauSize=result;
            //LoadLVMauSize(listMauSize);

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (suppressItemCheck)
                return;
            
            this.BeginInvoke(new Action(() =>
            {
                suppressItemCheck = true; // Bắt đầu bỏ qua sự kiện

                string itemName = checkedListBox1.Items[e.Index].ToString();
                if (itemName == "ALL"|| checkedListBox1.CheckedItems.Count == 0)
                {
                    bool state = e.NewValue == CheckState.Checked;
                    for (int i = 0; i < checkedListBox1.Items.Count - 1; i++)
                        checkedListBox1.SetItemChecked(i, state);

                    LoadLVMauSize(listMauSize);
                }
                else
                {
                    List<string> listSize = new List<string>();
                    for (int i = 0; i < checkedListBox1.Items.Count - 1; i++)
                        if (checkedListBox1.GetItemChecked(i))
                            listSize.Add(checkedListBox1.Items[i].ToString());

                    List<Color_Size> result = new List<Color_Size>();
                    foreach (string item in listSize)
                        result.AddRange(listMauSize.FindAll(x => string.Compare(x.Size.Trim(), item) == 0));

                    LoadLVMauSize(result);
                }

                suppressItemCheck = false; // Kích hoạt lại sự kiện
            }));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchByName.Text == "")
                LoadLVMauSize(listMauSize);
        }

        private void lvMauSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvMauSize_DoubleClick(object sender, EventArgs e)
        {
            if (lvMauSize.SelectedItems.Count == 0)
                return;
            AddToBillDetail(lvMauSize.SelectedItems[0]);

        }
        private void AddToBillDetail(ListViewItem item)
        {
            foreach(DataGridViewRow row in dgvViewDetail.Rows)
            {
                if (row.Cells[0].Value.ToString() == item.SubItems[0].Text)
                {
                    row.Cells[6].Value = (int.Parse(row.Cells[6].Value.ToString()) + 1).ToString();
                    return;
                }
            }
            dgvViewDetail.Rows.Add(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[3].Text, item.SubItems[3].Text, 1, item.SubItems[3].Text);
            UpDateSumBillDetail();
        }

        private void dgvViewDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            if(e.ColumnIndex == 5||e.ColumnIndex==6)
            {
                int gia = int.Parse(dgvViewDetail[5,e.RowIndex].Value.ToString());
                int sl = int.Parse(dgvViewDetail[6,e.RowIndex].Value.ToString());

                dgvViewDetail[7,e.RowIndex].Value= (gia*sl).ToString();
            }
            UpDateSumBillDetail();
        }

        private void dgvViewDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
                dgvViewDetail.Rows.RemoveAt(e.RowIndex);
            UpDateSumBillDetail();
        }
        private void UpDateSumBillDetail()
        {
            int sum = 0;
            foreach(DataGridViewRow row in dgvViewDetail.Rows)
            {
                sum += int.Parse(row.Cells[7].Value.ToString());
            }
            lblSumBillDetail.Text = String.Format("{0:0,0}",sum);
            UpdateSumBill();
        }
        private void UpdateSumBill()
        {
            if (lblSumBillDetail.Text == "")
                return;
            int tongTienHang = int.Parse(lblSumBillDetail.Text, NumberStyles.AllowThousands);
            int giamGia = int.Parse(nudGiamGia.Value.ToString())*tongTienHang/100;
            int giaoHang = 0;
            if (txtPhiGiaoHang.Text!=""&&ckbGiaoHang.Checked)
                giaoHang = int.Parse(txtPhiGiaoHang.Text);
            lblSumBill.Text = string.Format("{0:0,0}",tongTienHang-giamGia+giaoHang);

        }

        private void nudGiamGia_ValueChanged(object sender, EventArgs e)
        {
            UpdateSumBill();
        }

        private void txtPhiGiaoHang_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPhiGiaoHang_Validated(object sender, EventArgs e)
        {
            UpdateSumBill();
        }

        private void ckbGiaoHang_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSumBill() ;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChiKhachHang.Text = "";
            ckbGiaoHang.Checked = false;
            txtDiaChiGiaoHang.Text = "";
            dtpNgayGiao.Value=DateTime.Now;
            dgvViewDetail.Rows.Clear();
            nudGiamGia.Value=0;
            txtPhiGiaoHang.Text="0";
        }

        private void dgvViewDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpDateSumBillDetail();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if(dgvViewDetail.Rows.Count == 0) return;
            if(ckbKhachHangMoi.Checked)
            {
                CustomerBL customerBL = new CustomerBL();
                Customer cus = new Customer();
                cus.HoTen = txtTenKhachHang.Text;
                cus.SDT=txtSoDienThoai.Text;
                cus.DiaChi = txtDiaChiKhachHang.Text;
                cus.TongTienDaMua = 0;
                if(lblSumBill.Text!="")
                    cus.TongTienDaMua = int.Parse(lblSumBill.Text);
                int kq = customerBL.Insert(cus);
            } 
            BillBL billBL = new BillBL();
            Bill bill = new Bill();
            bill.NhanVienID = employee.Id;
            bill.KhachHangID=3;///////////////////////////////////////////
            bill.NgayLapHoaDon = DateTime.Now;
            bill.LoaiHoaDon = false;
            bill.TongTien = int.Parse(lblSumBill.Text, NumberStyles.AllowThousands);
            bill.GiamGia = int.Parse(lblSumBillDetail.Text, NumberStyles.AllowThousands) *int.Parse(nudGiamGia.Value.ToString())/100;
            bill.TrangThai = "Chưa thanh toán";
            billBL.Insert(bill);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Khách hàng đã thnah toán số tiền " + lblSumBill.Text + " đồng", "Xác nhận thanh toán", MessageBoxButtons.OKCancel);
        }
    }
}
