using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class frmQuyDinh : Form
    {
        public int TuoiToiThieu { get; set; }

        public int TuoiToiDa { get; set; }

        public int ThoiHanSuDung { get; set; }
        public int SoNgayMuonMax { get; set; }

        public int SoSachMuonMax { get; set; }

        public int KhoangCachXB { get; set; }


        public frmQuyDinh()
        {
            InitializeComponent();
            this.txtQuyDinh.Enabled = false;
        }
        public void Load_TL()
        {
            string str = @"select * from ThamSo";
            DataTable dt = Conn.getDataTable(str);
            dataQuyDinh.DataSource = dt;
        }
        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_TL();
        }

        private void dataTheLoai_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataQuyDinh.Rows[e.RowIndex];
                txtQuyDinh.Text = row.Cells[1].Value.ToString();
                txtGiaTri.Text = row.Cells[2].Value.ToString();
            }
            catch (Exception)
            { }
        }


        private void dataQuyDinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            string xoa = @"delete from ThamSo where TenThamSo='" + txtQuyDinh.Text + "'";
            if (txtQuyDinh.Text == "")
                MessageBox.Show("Tên tham số không được để trống!!");
            else
            {
                Conn.executeQuery(xoa);
                Load_TL();
            }
        }

        public int[] thamso = new int[7];

        public int[] get_thamso()
        {
            return thamso;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string up = @"update ThamSo set GiaTriThamSo='" + txtGiaTri.Text + "' where TenThamSo='" + txtQuyDinh.Text + "'";
            if (txtQuyDinh.Text == "")
                MessageBox.Show("Tên tham số không được để trống!!");
            else
            {
                if (txtQuyDinh.Text == "Tuoitoithieu")
                    if (Convert.ToInt32(txtGiaTri.Text) < TuoiToiDa)
                    {
                        Conn.executeQuery(up);
                        Load_TL();
                    }
                    else
                        MessageBox.Show("Tuổi tối thiểu phải nhỏ hơn tuổi tối đa");
                else if (txtQuyDinh.Text == "Tuoitoida")
                    if (Convert.ToInt32(txtGiaTri.Text) > TuoiToiThieu)
                    {
                        Conn.executeQuery(up);
                        Load_TL();
                    }
                    else
                        MessageBox.Show("Tuổi tối đa phải lớn hơn tuổi tối thiểu");
                else if (txtQuyDinh.Text == "KhoangcachXB")
                    if (Convert.ToInt32(txtGiaTri.Text) > 0)
                    {
                        Conn.executeQuery(up);
                        Load_TL();
                    }
                    else
                        MessageBox.Show("Khoảng cách năm xuất bản phải lớn hơn 0");
                else if (txtQuyDinh.Text == "Sosachmuonmax")
                    if (Convert.ToInt32(txtGiaTri.Text) > 0)
                    {
                        Conn.executeQuery(up);
                        Load_TL();
                    }
                    else
                        MessageBox.Show("Số sách mượn max phải lớn hơn 0");
                else if (txtQuyDinh.Text == "Songaymuonmax")
                    if (Convert.ToInt32(txtGiaTri.Text) > 0)
                    {
                        Conn.executeQuery(up);
                        Load_TL();
                    }
                    else
                        MessageBox.Show("Số ngày mượn max phải lớn hơn 0");
                else if (txtQuyDinh.Text == "Thoihansudung")
                    if (Convert.ToInt32(txtGiaTri.Text) > 0)
                    {
                        Conn.executeQuery(up);
                        Load_TL();
                    }
                    else
                        MessageBox.Show("Thời hạn sử dụng phải lớn hơn 0");
                else if (txtQuyDinh.Text == "Tienphat1ngay")
                    MessageBox.Show("Bạn không có quyền thay đổi tham số này");

            }


            for (int i = 0; i<= 6; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataQuyDinh.Rows[i];
                thamso[i] = Int32.Parse(row.Cells[2].Value.ToString());
            }

        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtQuyDinh.Text = "";
            txtGiaTri.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
