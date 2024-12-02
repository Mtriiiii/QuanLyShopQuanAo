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
using ThemCapNhatHang;

namespace s6_s10
{
    public partial class frmDanhSachMatHang : Form
    {
        List<Category> listCategory;
        List<Clothes> listClother;
        List<Color_Size> listColorSize;

        public frmDanhSachMatHang()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDanhSachMatHang_Load(object sender, EventArgs e)
        {
            ClothesBL clothesBL = new ClothesBL();
            listClother = clothesBL.GetAll();
            Color_SizeBL colorBL = new Color_SizeBL();
            listColorSize = colorBL.GetAll();
            LoadNhomMatHang();
        }
        void LoadNhomMatHang()
        {
            CategoryBL categoryBL = new CategoryBL();
            listCategory = categoryBL.GetAll();
            cbbNhomMatHang.DataSource = listCategory;
            cbbNhomMatHang.DisplayMember = "TenNhom";
            cbbNhomMatHang.ValueMember = "id";
        }
        private void LoadDSMatHang(Category cat)
        {
            dgvDSMatHang.Rows.Clear();
            if (cat == null) return;
            foreach(var item in listClother)
            {
                string enable = "Không";
                if (item.Enable)
                    enable = "Có";
                if (item.NhomMatHangID==cat.ID)
                {   foreach (var color_Size in listColorSize) 
                    {
                        if (color_Size.QuanAoID == item.ID)
                            dgvDSMatHang.Rows.Add(cat.TenNhom, item.ID, item.TenQuanAo, item.GiaBan, color_Size.MauSac, color_Size.Size, color_Size.SoLuong, enable);
                    }
                }
            }

        }

        private void cbbNhomMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDSMatHang(listCategory.Find(x => x.TenNhom == cbbNhomMatHang.Text));
        }

        private void btnThemLoaiHang_Click(object sender, EventArgs e)
        {
            frmNhomMatHang frm = new frmNhomMatHang();
            if (frm.ShowDialog() == DialogResult.OK)
                LoadNhomMatHang();
        }

        private void btnThemMatHang_Click(object sender, EventArgs e)
        {
            ThemHang frm = new ThemHang();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ClothesBL clothesBL = new ClothesBL();
                listClother = clothesBL.GetAll();
                Color_SizeBL colorBL = new Color_SizeBL();
                listColorSize = colorBL.GetAll();
                LoadNhomMatHang();
            }
        }

        private void frmDanhSachMatHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmDanhSachMatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
