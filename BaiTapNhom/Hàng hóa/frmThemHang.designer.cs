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
    partial class ThemHang
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ckbEnable = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbNhomMatHang = new System.Windows.Forms.ComboBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.txtTenMatHang = new System.Windows.Forms.TextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMau = new System.Windows.Forms.TextBox();
            this.cklbSize = new System.Windows.Forms.CheckedListBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ckbEnable
            // 
            this.ckbEnable.AutoSize = true;
            this.ckbEnable.Location = new System.Drawing.Point(375, 31);
            this.ckbEnable.Name = "ckbEnable";
            this.ckbEnable.Size = new System.Drawing.Size(129, 20);
            this.ckbEnable.TabIndex = 58;
            this.ckbEnable.Text = "Đang kinh doanh";
            this.ckbEnable.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 16);
            this.label7.TabIndex = 51;
            this.label7.Text = "Giá sản phẩm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 50;
            this.label6.Text = "Nhóm mặt hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "Màu sắc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 46;
            this.label2.Text = "Tên mặt hàng";
            // 
            // cbbNhomMatHang
            // 
            this.cbbNhomMatHang.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbbNhomMatHang.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cbbNhomMatHang.FormattingEnabled = true;
            this.cbbNhomMatHang.Location = new System.Drawing.Point(140, 27);
            this.cbbNhomMatHang.Name = "cbbNhomMatHang";
            this.cbbNhomMatHang.Size = new System.Drawing.Size(165, 24);
            this.cbbNhomMatHang.TabIndex = 44;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(140, 104);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(165, 22);
            this.txtGiaBan.TabIndex = 39;
            // 
            // txtTenMatHang
            // 
            this.txtTenMatHang.Location = new System.Drawing.Point(141, 67);
            this.txtTenMatHang.Name = "txtTenMatHang";
            this.txtTenMatHang.Size = new System.Drawing.Size(165, 22);
            this.txtTenMatHang.TabIndex = 34;
            // 
            // btnThoat
            // 
            this.btnThoat.AutoSize = true;
            this.btnThoat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThoat.Location = new System.Drawing.Point(190, 276);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 27);
            this.btnThoat.TabIndex = 32;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = true;
            this.btnThem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThem.Location = new System.Drawing.Point(64, 276);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(103, 27);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtMau
            // 
            this.txtMau.Location = new System.Drawing.Point(141, 147);
            this.txtMau.Name = "txtMau";
            this.txtMau.Size = new System.Drawing.Size(165, 22);
            this.txtMau.TabIndex = 61;
            // 
            // cklbSize
            // 
            this.cklbSize.ColumnWidth = 50;
            this.cklbSize.FormattingEnabled = true;
            this.cklbSize.Items.AddRange(new object[] {
            "S",
            "M",
            "L",
            "XL",
            "XXL"});
            this.cklbSize.Location = new System.Drawing.Point(17, 234);
            this.cklbSize.MultiColumn = true;
            this.cklbSize.Name = "cklbSize";
            this.cklbSize.Size = new System.Drawing.Size(275, 21);
            this.cklbSize.TabIndex = 62;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(140, 188);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(165, 22);
            this.txtGhiChu.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "Ghi chú";
            // 
            // ThemHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(634, 376);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cklbSize);
            this.Controls.Add(this.txtMau);
            this.Controls.Add(this.ckbEnable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbNhomMatHang);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.txtTenMatHang);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThem);
            this.Name = "ThemHang";
            this.Text = "Thêm/Cập nhật thông tin mặt hàng";
            this.Load += new System.EventHandler(this.ThemHang_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox ckbEnable;
        private Label label7;
        private Label label6;
        private Label label3;
        private Label label2;
        private ComboBox cbbNhomMatHang;
        private TextBox txtGiaBan;
        private TextBox txtTenMatHang;
        private Button btnThoat;
        private Button btnThem;
        private DateTimePicker dateTimePicker1;
        private TextBox txtMau;
        private CheckedListBox cklbSize;
        private TextBox txtGhiChu;
        private Label label1;
    }
}