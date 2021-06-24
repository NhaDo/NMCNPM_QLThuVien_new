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
    public partial class frmDocGia : Form
    {
        public frmDocGia()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            string str = @"select * from DocGia";
            DataTable dt = Conn.getDataTable(str);
            dataDocGia.DataSource = dt;
        }
        private void frmDocGia_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_Data();
        }

        private void dataDocGia_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataDocGia.Rows[e.RowIndex];
                txtMaDG.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                txtLoaiDocGia.Text = row.Cells[2].Value.ToString();
                dateNgaySinh.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtEmail.Text = row.Cells[5].Value.ToString();
                datelapthe.Text = row.Cells[6].Value.ToString();
                datehethan.Text = row.Cells[7].Value.ToString();
                txtTongNo.Text = row.Cells[8].Value.ToString();
            }
            catch (Exception)
            { }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaDG.Text = "";
            txtHoTen.Text = "";
            dateNgaySinh.Text = "01/01/2021";
            datelapthe.Text = "01/01/2021";
            datehethan.Text = "01/01/2021";
            txtLoaiDocGia.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtTongNo.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string xoa = @"delete from tblDocGia where MaDG='" + txtMaDG.Text + "'";
            if (txtMaDG.Text == "")
                MessageBox.Show("Mã độc giả không được trống!!");
            else
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa độc giả:" + txtMaDG.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        Conn.executeQuery(xoa);
                        Load_Data();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (dialog == DialogResult.No)
                {
                    //
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text == "")
                MessageBox.Show("Mã độc giả không được trống!!");
            else
            {
                string them = @"insert into tblDocGia(MaDG,HoTen,GioiTinh,NgaySinh,DiaChi,SDT,Email) values('" + txtMaDG.Text + "',N'" + txtHoTen.Text + "','" + dateNgaySinh.Text + "',N'" + txtDiaChi.Text + "','" + txtEmail.Text + "')";
                Conn.executeQuery(them);
                Load_Data();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaDG.Text == "")
                MessageBox.Show("Mã độc giả không được trống!!");
            else
            {
                string capnhat = @"update tblDocGia set MaDG='" + txtMaDG.Text + "',HoTen=N'" + txtHoTen.Text + "',NgaySinh='" + dateNgaySinh.Text + "',DiaChi=N'" + txtDiaChi.Text + "',SDT='" + txtEmail.Text + "' where MaDG='" + txtMaDG.Text + "'";
                Conn.executeQuery(capnhat);
                Load_Data();
            }
        }

        private void dataDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
