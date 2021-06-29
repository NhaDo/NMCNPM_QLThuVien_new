using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class frmDanhMucSach : Form
    {
        public int KhoangCachXB { get; set; }
        public frmDanhMucSach()
        {
            InitializeComponent();
            txtMaSach.Enabled = false;
        }
        public void Load_Data()
        {
            string str = @"select * from sach";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }
        public void Load_cbox()
        {
            string sqlcboxSup = "select * from sach";
            cboxMaTL.DisplayMember = "MaTheLoai";
            cboxMaTL.DataSource = Conn.getDataTable(sqlcboxSup);
        }
        private void frmDanhMucSach_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load_cbox();
            Load_Data();
        }

        private void dataSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataSach.Rows[e.RowIndex];
                txtMaSach.Text = row.Cells[0].Value.ToString();
                txtTenSach.Text = row.Cells[1].Value.ToString();
                cboxMaTL.Text = row.Cells[2].Value.ToString();
                datenamxb.Text = row.Cells[3].Value.ToString();
                txtNhaXB.Text = row.Cells[4].Value.ToString();
                datengaynhap.Text = row.Cells[5].Value.ToString();
                txtTriGia.Text = row.Cells[6].Value.ToString();
                txtSoLuong.Text = row.Cells[7].Value.ToString();
            }
            catch (Exception)
            { }
        }

        public bool IsAlphabets(string inputString)
        {
            Regex r = new Regex("^[a-zA-Z ]+$");
            if (r.IsMatch(inputString))
                return true;
            else
                return false;
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            cboxMaTL.Text = "";
            txtTenSach.Text = "";
            datenamxb.Text = "";
            txtNhaXB.Text = "";
            datengaynhap.Text = "";
            txtTriGia.Text = "";
            txtSoLuong.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string xoa = @"delete from CTTACGIA where MaSach='" + txtMaSach.Text + "';delete from CuonSach where MaSach='" + txtMaSach.Text + "';delete from Sach where MaSach='" + txtMaSach.Text + "'"; ;
            if (txtMaSach.Text == "")
                MessageBox.Show("Mã sách không được trống!!");
            else
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa sách :" + txtTenSach.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        Conn.executeQuery(xoa);
                        Load_Data();
                        MessageBox.Show("Xóa thành công!!");
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (IsAlphabets(txtTenSach.Text) == false)
                MessageBox.Show("Tên sách " + txtTenSach.Text + " chứa kí tự không hợp lệ");
            else if (IsAlphabets(txtNhaXB.Text) == false)
                MessageBox.Show("Tên nhà xuất bản " + txtNhaXB.Text + " chứa kí tự không hợp lệ");
            else if (datengaynhap.Value.Subtract(datenamxb.Value).TotalDays <= KhoangCachXB * 365)
            {
                string capnhat = @"update Sach set TenSach=N'" + txtTenSach.Text + "',MaTheLoai='" + cboxMaTL.Text + "',NamXuatBan='" + datenamxb.Text + "',NhaXuatBan=N'" + txtNhaXB.Text + "',NgayNhap='" + datengaynhap.Text + "',TriGia='" + txtTriGia.Text + "',SoLuong='" + txtSoLuong.Text + "' where MaSach='" + txtMaSach.Text + "'";
                Conn.executeQuery(capnhat);
                Load_Data();
                MessageBox.Show("Cập nhật thành công!!");
            }
            else
                MessageBox.Show("Khoảng cách năm xuất bản lớn hơn quy định. Khoảng cách phải nhỏ hơn " + KhoangCachXB.ToString() + " năm");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (IsAlphabets(txtTenSach.Text) == false)
                MessageBox.Show("Tên sách " + txtTenSach.Text + " chứa kí tự không hợp lệ");
            else if (IsAlphabets(txtNhaXB.Text) == false)
                MessageBox.Show("Tên nhà xuất bản " + txtNhaXB.Text + " chứa kí tự không hợp lệ");
            else if (datengaynhap.Value.Subtract(datenamxb.Value).TotalDays <= KhoangCachXB * 365)
            {
                string them = @"insert into Sach values (N'" + txtTenSach.Text + "','" + cboxMaTL.Text + "','" + datenamxb.Text + "',N'" + txtNhaXB.Text + "','" + datengaynhap.Text + "','" + txtTriGia.Text + "','" + txtSoLuong.Text + "')";
                Conn.executeQuery(them);
<<<<<<< HEAD
=======
                Load_Data();
                int z = dataSach.Rows.Count-2;
                txtMaSach.Text = dataSach.Rows[z].Cells[0].Value.ToString();
                for (int i = 0; i < Convert.ToInt32(txtSoLuong.Text); i++)
                {
                    string them2 = @"insert into CUONSACH values ('" + txtMaSach.Text + "',N'có sẵn')'";
                    Conn.executeQuery(them2);
                }
                MessageBox.Show("Thêm sách thành công!!");
>>>>>>> 1137a496643bdb4f9622cb3fb7baa8cf7e51b8e3
                Load_Data();
                MessageBox.Show("Thêm sách thành công!!");
            }
            else
                MessageBox.Show("Khoảng cách năm xuất bản lớn hơn quy định. Khoảng cách phải nhỏ hơn " + KhoangCachXB.ToString() + " năm");
        }

        private void txtTonTai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string str = @"select * from Sach where MaSach LIKE N'%"+txtTimKiem.Text+"%' or TenSach LIKE N'%"+txtTimKiem.Text+ "%' or NhaXuatBan LIKE N'%" + txtTimKiem.Text + "%'";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
