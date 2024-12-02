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
    public partial class frmPrintPreview : Form
    {
        public frmPrintPreview()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {
            frmDanhSachMatHang frm = new frmDanhSachMatHang();
            frm.ShowDialog();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
