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
namespace ThemCapNhatHang
{
    public partial class ThemHang : Form

    {
        List<Category> listCategory = new List<Category>();
        public ThemHang()
        {
            InitializeComponent();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThemHang_Load_1(object sender, EventArgs e)
        {
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            ClothesBL clothesBL = new ClothesBL();
            Color_SizeBL color_SizeBL = new Color_SizeBL();
            Clothes clothes = new Clothes();
            clothes.NhomMatHangID = int.Parse(cbbNhomMatHang.SelectedValue.ToString());
            clothes.TenQuanAo=txtTenMatHang.Text;
            clothes.GiaBan=int.Parse(txtGiaBan.Text);
            clothes.GhiChu=txtGhiChu.Text;
            clothes.Enable=ckbEnable.Checked;
            int clothesID = clothesBL.Insert(clothes);
            txtGhiChu.Text = clothesID.ToString();
            Color_Size color_Size = new Color_Size();
            color_Size.QuanAoID = clothesID;
            color_Size.MauSac = txtMau.Text;
            color_Size.SoLuong = 0;
            foreach (var item in cklbSize.CheckedItems)
            {
                color_Size.Size = item.ToString();
                color_SizeBL.Insert(color_Size);
            }
            this.DialogResult= DialogResult.OK;
            this.Close();
        }
    }
}