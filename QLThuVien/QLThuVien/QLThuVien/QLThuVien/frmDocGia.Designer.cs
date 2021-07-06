namespace QLThuVien
{
    partial class frmDocGia
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocGia));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataDocGia = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoaiDocGia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTongNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.datehethan = new System.Windows.Forms.DateTimePicker();
            this.datelapthe = new System.Windows.Forms.DateTimePicker();
            this.dateNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaDG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.png");
            this.imageList1.Images.SetKeyName(1, "1460546211_DeleteRed.ico");
            this.imageList1.Images.SetKeyName(2, "chitiettour2.ico");
            this.imageList1.Images.SetKeyName(3, "ios7-document-icon.png");
            // 
            // dataDocGia
            // 
            this.dataDocGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataDocGia.BackgroundColor = System.Drawing.Color.White;
            this.dataDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDocGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column6,
            this.Column8,
            this.Column9});
            this.dataDocGia.Location = new System.Drawing.Point(12, 361);
            this.dataDocGia.Name = "dataDocGia";
            this.dataDocGia.ReadOnly = true;
            this.dataDocGia.RowHeadersWidth = 51;
            this.dataDocGia.RowTemplate.Height = 24;
            this.dataDocGia.Size = new System.Drawing.Size(899, 214);
            this.dataDocGia.TabIndex = 4;
            this.dataDocGia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataDocGia_CellContentClick);
            this.dataDocGia.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataDocGia_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaDocGia";
            this.Column1.HeaderText = "Mã ĐG";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenDocGia";
            this.Column2.HeaderText = "Họ Tên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "MaLoaiDocGia";
            this.Column3.HeaderText = "Loại ĐG";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NgaySinh";
            this.Column4.HeaderText = "Ngày Sinh";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DiaChi";
            this.Column5.HeaderText = "Địa Chỉ";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Email";
            this.Column7.HeaderText = "Email";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NgayLapThe";
            this.Column6.HeaderText = "Ngày Lập Thẻ";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "NgayHetHan";
            this.Column8.HeaderText = "Ngày Hết Hạn";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "TongNo";
            this.Column9.HeaderText = "Tổng Nợ";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(389, 278);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 25);
            this.label10.TabIndex = 5;
            this.label10.Text = "Danh sách độc giả";
            this.label10.UseWaitCursor = true;
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox1.Location = new System.Drawing.Point(255, 318);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(442, 26);
            this.textBox1.TabIndex = 11;
            this.textBox1.UseWaitCursor = true;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(196, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "           ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLoaiDocGia
            // 
            this.txtLoaiDocGia.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtLoaiDocGia.Location = new System.Drawing.Point(623, 126);
            this.txtLoaiDocGia.Name = "txtLoaiDocGia";
            this.txtLoaiDocGia.Size = new System.Drawing.Size(260, 26);
            this.txtLoaiDocGia.TabIndex = 10;
            this.txtLoaiDocGia.UseWaitCursor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(511, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "Loại Độc Giả";
            this.label11.UseWaitCursor = true;
            // 
            // txtTongNo
            // 
            this.txtTongNo.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtTongNo.Location = new System.Drawing.Point(368, 170);
            this.txtTongNo.Name = "txtTongNo";
            this.txtTongNo.Size = new System.Drawing.Size(284, 26);
            this.txtTongNo.TabIndex = 8;
            this.txtTongNo.UseWaitCursor = true;
            this.txtTongNo.TextChanged += new System.EventHandler(this.txtTongNo_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Ngày Hết Hạn";
            this.label9.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(16, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Ngày Lập Thẻ";
            this.label8.UseWaitCursor = true;
            // 
            // datehethan
            // 
            this.datehethan.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.datehethan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datehethan.Location = new System.Drawing.Point(127, 124);
            this.datehethan.Name = "datehethan";
            this.datehethan.Size = new System.Drawing.Size(274, 26);
            this.datehethan.TabIndex = 5;
            this.datehethan.UseWaitCursor = true;
            this.datehethan.ValueChanged += new System.EventHandler(this.datehethan_ValueChanged);
            // 
            // datelapthe
            // 
            this.datelapthe.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.datelapthe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datelapthe.Location = new System.Drawing.Point(127, 92);
            this.datelapthe.Name = "datelapthe";
            this.datelapthe.Size = new System.Drawing.Size(274, 26);
            this.datelapthe.TabIndex = 4;
            this.datelapthe.UseWaitCursor = true;
            this.datelapthe.ValueChanged += new System.EventHandler(this.datelapthe_ValueChanged);
            // 
            // dateNgaySinh
            // 
            this.dateNgaySinh.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.dateNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateNgaySinh.Location = new System.Drawing.Point(623, 26);
            this.dateNgaySinh.Name = "dateNgaySinh";
            this.dateNgaySinh.Size = new System.Drawing.Size(260, 26);
            this.dateNgaySinh.TabIndex = 3;
            this.dateNgaySinh.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(295, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tổng nợ";
            this.label7.UseWaitCursor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtEmail.Location = new System.Drawing.Point(623, 94);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(260, 26);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(564, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Email";
            this.label6.UseWaitCursor = true;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtDiaChi.Location = new System.Drawing.Point(623, 60);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(260, 26);
            this.txtDiaChi.TabIndex = 1;
            this.txtDiaChi.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(552, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Địa Chỉ";
            this.label5.UseWaitCursor = true;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtHoTen.Location = new System.Drawing.Point(127, 60);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(274, 26);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(60, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ Tên";
            this.label2.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(531, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày Sinh";
            this.label4.UseWaitCursor = true;
            // 
            // txtMaDG
            // 
            this.txtMaDG.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtMaDG.Enabled = false;
            this.txtMaDG.Location = new System.Drawing.Point(127, 28);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.Size = new System.Drawing.Size(274, 26);
            this.txtMaDG.TabIndex = 1;
            this.txtMaDG.UseWaitCursor = true;
            this.txtMaDG.TextChanged += new System.EventHandler(this.txtMaDG_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Độc Giả";
            this.label1.UseWaitCursor = true;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(47, 209);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(164, 54);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.UseWaitCursor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.SteelBlue;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(283, 209);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(164, 54);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.UseWaitCursor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnMoi
            // 
            this.btnMoi.BackColor = System.Drawing.Color.MediumOrchid;
            this.btnMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoi.ForeColor = System.Drawing.Color.White;
            this.btnMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnMoi.Image")));
            this.btnMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoi.Location = new System.Drawing.Point(719, 209);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(164, 54);
            this.btnMoi.TabIndex = 0;
            this.btnMoi.Text = " Làm Mới";
            this.btnMoi.UseVisualStyleBackColor = false;
            this.btnMoi.UseWaitCursor = true;
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.MediumPurple;
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhat.Location = new System.Drawing.Point(515, 209);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(164, 54);
            this.btnCapNhat.TabIndex = 0;
            this.btnCapNhat.Text = " Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.UseWaitCursor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // frmDocGia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::QLThuVien.Properties.Resources.nền1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(923, 587);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtLoaiDocGia);
            this.Controls.Add(this.dateNgaySinh);
            this.Controls.Add(this.btnMoi);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTongNo);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.datelapthe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datehethan);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMaDG);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataDocGia);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDocGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Độc Giả";
            this.Load += new System.EventHandler(this.frmDocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataDocGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DateTimePicker dateNgaySinh;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataDocGia;
        private System.Windows.Forms.TextBox txtMaDG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datehethan;
        private System.Windows.Forms.DateTimePicker datelapthe;
        private System.Windows.Forms.TextBox txtTongNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.TextBox txtLoaiDocGia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}