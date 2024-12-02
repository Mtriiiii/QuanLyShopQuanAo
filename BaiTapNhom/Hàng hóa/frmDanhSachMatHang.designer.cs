namespace s6_s10
{
    partial class frmDanhSachMatHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemMatHang = new System.Windows.Forms.Button();
            this.btnThemLoaiHang = new System.Windows.Forms.Button();
            this.cbbNhomMatHang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDSMatHang = new System.Windows.Forms.DataGridView();
            this.nhomMatHangColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maSoColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenMatHangColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaBanLeColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangThaiColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.luuYColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSMatHang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThemMatHang);
            this.groupBox1.Controls.Add(this.btnThemLoaiHang);
            this.groupBox1.Controls.Add(this.cbbNhomMatHang);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1286, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lọc và tìm kiếm";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnThemMatHang
            // 
            this.btnThemMatHang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThemMatHang.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMatHang.Location = new System.Drawing.Point(998, 34);
            this.btnThemMatHang.Name = "btnThemMatHang";
            this.btnThemMatHang.Size = new System.Drawing.Size(126, 27);
            this.btnThemMatHang.TabIndex = 25;
            this.btnThemMatHang.Text = "Thêm mặt hàng";
            this.btnThemMatHang.UseVisualStyleBackColor = true;
            this.btnThemMatHang.Click += new System.EventHandler(this.btnThemMatHang_Click);
            // 
            // btnThemLoaiHang
            // 
            this.btnThemLoaiHang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThemLoaiHang.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLoaiHang.Location = new System.Drawing.Point(851, 34);
            this.btnThemLoaiHang.Name = "btnThemLoaiHang";
            this.btnThemLoaiHang.Size = new System.Drawing.Size(116, 27);
            this.btnThemLoaiHang.TabIndex = 24;
            this.btnThemLoaiHang.Text = "Thêm loại hàng";
            this.btnThemLoaiHang.UseVisualStyleBackColor = true;
            this.btnThemLoaiHang.Click += new System.EventHandler(this.btnThemLoaiHang_Click);
            // 
            // cbbNhomMatHang
            // 
            this.cbbNhomMatHang.FormattingEnabled = true;
            this.cbbNhomMatHang.Location = new System.Drawing.Point(128, 36);
            this.cbbNhomMatHang.Name = "cbbNhomMatHang";
            this.cbbNhomMatHang.Size = new System.Drawing.Size(131, 25);
            this.cbbNhomMatHang.TabIndex = 3;
            this.cbbNhomMatHang.SelectedIndexChanged += new System.EventHandler(this.cbbNhomMatHang_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhóm mặt hàng:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDSMatHang);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1286, 595);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách mặt hàng";
            // 
            // dgvDSMatHang
            // 
            this.dgvDSMatHang.AllowUserToAddRows = false;
            this.dgvDSMatHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDSMatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSMatHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDSMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSMatHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nhomMatHangColumn1,
            this.maSoColumn1,
            this.tenMatHangColumn1,
            this.giaBanLeColumn1,
            this.Column1,
            this.Column2,
            this.soLuongColumn1,
            this.trangThaiColumn1,
            this.luuYColumn1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSMatHang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSMatHang.GridColor = System.Drawing.Color.White;
            this.dgvDSMatHang.Location = new System.Drawing.Point(6, 24);
            this.dgvDSMatHang.Name = "dgvDSMatHang";
            this.dgvDSMatHang.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDSMatHang.RowHeadersVisible = false;
            this.dgvDSMatHang.RowHeadersWidth = 51;
            this.dgvDSMatHang.RowTemplate.Height = 24;
            this.dgvDSMatHang.Size = new System.Drawing.Size(1274, 565);
            this.dgvDSMatHang.TabIndex = 0;
            // 
            // nhomMatHangColumn1
            // 
            this.nhomMatHangColumn1.FillWeight = 117.1004F;
            this.nhomMatHangColumn1.HeaderText = "Nhóm mặt hàng";
            this.nhomMatHangColumn1.MinimumWidth = 6;
            this.nhomMatHangColumn1.Name = "nhomMatHangColumn1";
            this.nhomMatHangColumn1.Width = 95;
            // 
            // maSoColumn1
            // 
            this.maSoColumn1.FillWeight = 66.10787F;
            this.maSoColumn1.HeaderText = "Mã số";
            this.maSoColumn1.MinimumWidth = 6;
            this.maSoColumn1.Name = "maSoColumn1";
            this.maSoColumn1.Width = 56;
            // 
            // tenMatHangColumn1
            // 
            this.tenMatHangColumn1.FillWeight = 120.9119F;
            this.tenMatHangColumn1.HeaderText = "Tên mặt hàng";
            this.tenMatHangColumn1.MinimumWidth = 6;
            this.tenMatHangColumn1.Name = "tenMatHangColumn1";
            this.tenMatHangColumn1.Width = 107;
            // 
            // giaBanLeColumn1
            // 
            this.giaBanLeColumn1.FillWeight = 102.1244F;
            this.giaBanLeColumn1.HeaderText = "Giá bán ";
            this.giaBanLeColumn1.MinimumWidth = 6;
            this.giaBanLeColumn1.Name = "giaBanLeColumn1";
            this.giaBanLeColumn1.Width = 59;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Màu sắc";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 63;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Size";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // soLuongColumn1
            // 
            this.soLuongColumn1.FillWeight = 77.58211F;
            this.soLuongColumn1.HeaderText = "Số lượng";
            this.soLuongColumn1.MinimumWidth = 6;
            this.soLuongColumn1.Name = "soLuongColumn1";
            this.soLuongColumn1.Width = 83;
            // 
            // trangThaiColumn1
            // 
            this.trangThaiColumn1.FillWeight = 105.7514F;
            this.trangThaiColumn1.HeaderText = "Đang hoạt động";
            this.trangThaiColumn1.MinimumWidth = 6;
            this.trangThaiColumn1.Name = "trangThaiColumn1";
            this.trangThaiColumn1.Width = 122;
            // 
            // luuYColumn1
            // 
            this.luuYColumn1.FillWeight = 106.6959F;
            this.luuYColumn1.HeaderText = "Lưu ý";
            this.luuYColumn1.MinimumWidth = 6;
            this.luuYColumn1.Name = "luuYColumn1";
            this.luuYColumn1.Width = 58;
            // 
            // frmDanhSachMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 713);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDanhSachMatHang";
            this.Text = "frmDanhSachMatHang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDanhSachMatHang_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDanhSachMatHang_FormClosed);
            this.Load += new System.EventHandler(this.frmDanhSachMatHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSMatHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbNhomMatHang;
        private System.Windows.Forms.Button btnThemLoaiHang;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDSMatHang;
        private System.Windows.Forms.Button btnThemMatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn nhomMatHangColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSoColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenMatHangColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaBanLeColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangThaiColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn luuYColumn1;
    }
}