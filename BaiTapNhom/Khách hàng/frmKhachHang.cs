using BusinessLogic;
using DataAccess;
using s6_s10;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapNhom.Khách_hàng
{
    public partial class frmKhachHang : Form
    {
        int sum = 0;
        List<Customer> listCustomer;
        public Customer customer;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmCTKhachHang frm = new frmCTKhachHang();
            //frm.ShowDialog();
            
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            CustomerBL customerBL = new CustomerBL();
            listCustomer=customerBL.GetAll();
            foreach(Customer cus in listCustomer)
            {
                dgvDSKhachHang.Rows.Add(cus.Id.ToString(),cus.HoTen,cus.SDT,cus.DiaChi,cus.TongTienDaMua.ToString());
                ListViewItem item = new ListViewItem(cus.Id.ToString());
                item.SubItems.Add(cus.HoTen);
                item.SubItems.Add(cus.SDT);
                item.SubItems.Add(cus.DiaChi);
                item.SubItems.Add(cus.TongTienDaMua.ToString());
            }    
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvDSKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==5)
            {
                CustomerBL customerBL = new CustomerBL();
                Customer cus = new Customer();
                cus.Id = int.Parse(dgvDSKhachHang[0, e.RowIndex].Value.ToString()) ;
                cus.HoTen = dgvDSKhachHang[1, e.RowIndex].Value.ToString();
                cus.SDT = dgvDSKhachHang[2, e.RowIndex].Value.ToString();
                cus.DiaChi = dgvDSKhachHang[3, e.RowIndex].Value.ToString() ;
                cus.TongTienDaMua = int.Parse(dgvDSKhachHang[4, e.RowIndex].Value.ToString()) ;
                customerBL.Update(cus);
                MessageBox.Show("Cập nhật thông tin khách hàng thành công", "Thành công", MessageBoxButtons.OK);
            }
            
        }

        private void dgvDSKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            txtHoTen.Text = dgvDSKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = dgvDSKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = dgvDSKhachHang.CurrentRow.Cells[3].Value.ToString();
            Customer cus = listCustomer.Find(x => x.Id == int.Parse(dgvDSKhachHang.CurrentRow.Cells[0].Value.ToString()));
            customer = cus;
            LoadLVBill(cus.Id);
        }

        private void lấyThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void LoadLVBill(int id)
        {
            sum = 0;
            lvBill.Items.Clear();
            EmployeeBL employeeBL = new EmployeeBL();
            List<Employee> listNhanVien = employeeBL.GetAll();
            BillBL billBL = new BillBL();
            List<Bill> listBill = billBL.GetBillCustomerID(id,rdTheoNgay.Checked);
            foreach (Bill bill in listBill )
            {
                sum += bill.TongTien - bill.GiamGia;
                ListViewItem item = new ListViewItem(bill.ID.ToString());
                item.SubItems.Add(bill.NgayLapHoaDon.ToShortDateString());
                item.SubItems.Add(listNhanVien.Find(x=>x.Id== bill.NhanVienID).HoTen);
                item.SubItems.Add(bill.TongTien.ToString());
                item.SubItems.Add(bill.GiamGia.ToString());
                item.SubItems.Add((bill.TongTien - bill.GiamGia).ToString());
                item.SubItems.Add(bill.TrangThai);
                lvBill.Items.Add(item);
            }
            lblSum.Text = sum.ToString();
        }
        private void LoadSum()
        {
            
        }
       
        private void rdTheoGia_CheckedChanged_1(object sender, EventArgs e)
        {
            LoadLVBill(customer.Id);
        }
    }
}
