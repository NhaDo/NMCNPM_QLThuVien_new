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
        public frmQuyDinh()
        {
            InitializeComponent();
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

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            {
                string them = @"insert into ThamSo values(N'" + txtQuyDinh.Text + "','" + txtGiaTri.Text + "')";
                if (txtQuyDinh.Text == "")
                    MessageBox.Show("Tên tham số không được để trống!!");
                else
                {
                    Conn.executeQuery(them);
                    Load_TL();
                }
            }
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string up = @"update ThamSo set GiaTriThamSo='" + txtGiaTri.Text + "' where TenThamSo='" + txtQuyDinh.Text + "'";
            if (txtQuyDinh.Text == "")
                MessageBox.Show("Tên tham số không được để trống!!");
            else
            {
                Conn.executeQuery(up);
                Load_TL();
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtQuyDinh.Text = "";
            txtGiaTri.Text = "";
        }
    }
}
