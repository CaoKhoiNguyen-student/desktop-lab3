namespace BaiTap1
{
    partial class Form1
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
        private void InitializeComponent()
        {
            this.lblMSSV = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.lblHoTenLot = new System.Windows.Forms.Label();
            this.txtHoTenLot = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.clbMonHoc = new System.Windows.Forms.CheckedListBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.colMSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTenLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCMND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Location = new System.Drawing.Point(60, 48);
            this.lblMSSV.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(84, 25);
            this.lblMSSV.TabIndex = 0;
            this.lblMSSV.Text = "MSSV :";
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(240, 42);
            this.txtMSSV.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(356, 31);
            this.txtMSSV.TabIndex = 1;
            // 
            // lblHoTenLot
            // 
            this.lblHoTenLot.AutoSize = true;
            this.lblHoTenLot.Location = new System.Drawing.Point(60, 106);
            this.lblHoTenLot.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblHoTenLot.Name = "lblHoTenLot";
            this.lblHoTenLot.Size = new System.Drawing.Size(145, 25);
            this.lblHoTenLot.TabIndex = 5;
            this.lblHoTenLot.Text = "Họ và tên lót :";
            // 
            // txtHoTenLot
            // 
            this.txtHoTenLot.Location = new System.Drawing.Point(240, 100);
            this.txtHoTenLot.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtHoTenLot.Name = "txtHoTenLot";
            this.txtHoTenLot.Size = new System.Drawing.Size(356, 31);
            this.txtHoTenLot.TabIndex = 6;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(700, 48);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(103, 25);
            this.lblGioiTinh.TabIndex = 2;
            this.lblGioiTinh.Text = "Giới tính :";
            // 
            // rdoNam
            // 
            this.rdoNam.AutoSize = true;
            this.rdoNam.Location = new System.Drawing.Point(840, 44);
            this.rdoNam.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(27, 26);
            this.rdoNam.TabIndex = 3;
            this.rdoNam.TabStop = true;
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // rdoNu
            // 
            this.rdoNu.AutoSize = true;
            this.rdoNu.Location = new System.Drawing.Point(980, 44);
            this.rdoNu.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(70, 29);
            this.rdoNu.TabIndex = 4;
            this.rdoNu.TabStop = true;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(350, 55);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(32, 13);
            this.lblTen.TabIndex = 7;
            this.lblTen.Text = "Tên :";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(840, 100);
            this.txtTen.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(356, 31);
            this.txtTen.TabIndex = 8;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(60, 163);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(120, 25);
            this.lblNgaySinh.TabIndex = 9;
            this.lblNgaySinh.Text = "Ngày sinh :";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(240, 158);
            this.dtpNgaySinh.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(356, 31);
            this.dtpNgaySinh.TabIndex = 10;
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(700, 163);
            this.lblLop.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(60, 25);
            this.lblLop.TabIndex = 11;
            this.lblLop.Text = "Lớp :";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(840, 158);
            this.cboLop.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(356, 33);
            this.cboLop.TabIndex = 12;
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Location = new System.Drawing.Point(60, 221);
            this.lblCMND.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(119, 25);
            this.lblCMND.TabIndex = 13;
            this.lblCMND.Text = "Số CMND :";
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(240, 215);
            this.txtCMND.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(356, 31);
            this.txtCMND.TabIndex = 14;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(700, 221);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(84, 25);
            this.lblSDT.TabIndex = 15;
            this.lblSDT.Text = "Số ĐT :";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(840, 215);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(356, 31);
            this.txtSDT.TabIndex = 16;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(60, 279);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(164, 25);
            this.lblDiaChi.TabIndex = 17;
            this.lblDiaChi.Text = "Địa chỉ liên lạc :";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(240, 273);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(956, 31);
            this.txtDiaChi.TabIndex = 18;
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(60, 337);
            this.lblMonHoc.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(189, 25);
            this.lblMonHoc.TabIndex = 19;
            this.lblMonHoc.Text = "Môn học đăng ký :";
            // 
            // clbMonHoc
            // 
            this.clbMonHoc.ColumnWidth = 220;
            this.clbMonHoc.FormattingEnabled = true;
            this.clbMonHoc.Items.AddRange(new object[] {
            "Mạng máy tính",
            "Đồ án cơ sở",
            "Hệ điều hành",
            "Phương pháp NCKH",
            "Lập trình CSDL",
            "Lập trình trên thiết bị di động",
            "Lập trình mạng",
            "An toàn và bảo mật hệ thống"});
            this.clbMonHoc.Location = new System.Drawing.Point(240, 331);
            this.clbMonHoc.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.clbMonHoc.MultiColumn = true;
            this.clbMonHoc.Name = "clbMonHoc";
            this.clbMonHoc.Size = new System.Drawing.Size(956, 116);
            this.clbMonHoc.TabIndex = 20;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(460, 481);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(150, 44);
            this.btnTimKiem.TabIndex = 21;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(640, 481);
            this.btnThemMoi.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(150, 44);
            this.btnThemMoi.TabIndex = 22;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(820, 481);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(150, 44);
            this.btnCapNhat.TabIndex = 23;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1000, 481);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(150, 44);
            this.btnThoat.TabIndex = 24;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvDanhSach);
            this.grpDanhSach.Location = new System.Drawing.Point(40, 548);
            this.grpDanhSach.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpDanhSach.Size = new System.Drawing.Size(1170, 442);
            this.grpDanhSach.TabIndex = 25;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách sinh viên";
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMSSV,
            this.colHoTenLot,
            this.colTen,
            this.colNgaySinh,
            this.colLop,
            this.colCMND,
            this.colSDT,
            this.colDiaChi});
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSach.Location = new System.Drawing.Point(6, 30);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 82;
            this.dgvDanhSach.Size = new System.Drawing.Size(1158, 406);
            this.dgvDanhSach.TabIndex = 0;
            // 
            // colMSSV
            // 
            this.colMSSV.HeaderText = "MSSV";
            this.colMSSV.MinimumWidth = 10;
            this.colMSSV.Name = "colMSSV";
            this.colMSSV.Width = 200;
            // 
            // colHoTenLot
            // 
            this.colHoTenLot.HeaderText = "Họ và tên lót";
            this.colHoTenLot.MinimumWidth = 10;
            this.colHoTenLot.Name = "colHoTenLot";
            this.colHoTenLot.Width = 200;
            // 
            // colTen
            // 
            this.colTen.HeaderText = "Tên";
            this.colTen.MinimumWidth = 10;
            this.colTen.Name = "colTen";
            this.colTen.Width = 200;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.HeaderText = "Ngày sinh";
            this.colNgaySinh.MinimumWidth = 10;
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Width = 200;
            // 
            // colLop
            // 
            this.colLop.HeaderText = "Lớp";
            this.colLop.MinimumWidth = 10;
            this.colLop.Name = "colLop";
            this.colLop.Width = 200;
            // 
            // colCMND
            // 
            this.colCMND.HeaderText = "Số CMND";
            this.colCMND.MinimumWidth = 10;
            this.colCMND.Name = "colCMND";
            this.colCMND.Width = 200;
            // 
            // colSDT
            // 
            this.colSDT.HeaderText = "Số điện thoại";
            this.colSDT.MinimumWidth = 10;
            this.colSDT.Name = "colSDT";
            this.colSDT.Width = 200;
            // 
            // colDiaChi
            // 
            this.colDiaChi.HeaderText = "Địa chỉ liên lạc";
            this.colDiaChi.MinimumWidth = 10;
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.Width = 200;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 1019);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.clbMonHoc);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.lblCMND);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblLop);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.rdoNu);
            this.Controls.Add(this.rdoNam);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.txtHoTenLot);
            this.Controls.Add(this.lblHoTenLot);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.lblMSSV);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thông tin sinh viên";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label lblHoTenLot;
        private System.Windows.Forms.TextBox txtHoTenLot;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.CheckedListBox clbMonHoc;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTenLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCMND;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
    }
}

