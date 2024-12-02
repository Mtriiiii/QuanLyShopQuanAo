using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s6_s10
{
    public partial class frmNhomMatHang : Form
    {
        List<Category> listCategory = new List<Category>();
        public frmNhomMatHang()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmNhomMatHang_Load(object sender, EventArgs e)
        {
            
            LoadDSNhomMatHang();
        }
        void LoadDSNhomMatHang()
        {
            CategoryBL categoryBL = new CategoryBL();
            listCategory = categoryBL.GetAll();
            dgvDSNhomMatHang.Rows.Clear();
            foreach (Category c in listCategory)
            {
                dgvDSNhomMatHang.Rows.Add(c.ID,c.TenNhom,c.Enable,c.GhiChu);
            }
        }

        private void dgvDSNhomMatHang_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNhom.Text = dgvDSNhomMatHang.CurrentRow.Cells[0].Value.ToString();
            txtTenNhom.Text = dgvDSNhomMatHang.CurrentRow.Cells[1].Value.ToString();
            txtNote.Text = dgvDSNhomMatHang.CurrentRow.Cells[3].Value.ToString();
            ckbEnable.Checked = false;
            if (Convert.ToBoolean(dgvDSNhomMatHang.CurrentRow.Cells[2].Value))
                ckbEnable.Checked = true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtMaNhom.Text = "";
            txtTenNhom.Text = "";
            txtNote.Text = "";
            ckbEnable.Checked=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.ID = int.Parse(txtMaNhom.Text);
            cat.TenNhom = txtTenNhom.Text;
            cat.Enable = ckbEnable.Checked;
            cat.GhiChu=txtNote.Text;
            CategoryBL categoryBL = new CategoryBL();
            categoryBL.Update(cat);
            LoadDSNhomMatHang();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.TenNhom=txtTenNhom.Text;
            cat.Enable = ckbEnable.Checked;
            cat.GhiChu = txtNote.Text;
            CategoryBL categoryBL = new CategoryBL();
            categoryBL.Insert(cat);
            LoadDSNhomMatHang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
