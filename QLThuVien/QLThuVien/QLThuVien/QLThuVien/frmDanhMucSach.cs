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
        }
        public void Load_Data()
        {
            string str = @"select * from sach";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }
        private void frmDanhMucSach_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
                txtTL.Text = row.Cells[2].Value.ToString();
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
            Regex r = new Regex("^[a-zA-Z0-9 ]+$");
            if (r.IsMatch(inputString))
                return true;
            else
                return false;
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaSach.Text = "";
            txtTL.Text = "";
            txtTenSach.Text = "";
            datenamxb.Text = "1/1/2021";
            txtNhaXB.Text = "";
            datengaynhap.Text = "1/1/2021";
            txtTriGia.Text = "";
            txtSoLuong.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            string xoa = @"delete from CTTACGIA where MaSach='" + txtMaSach.Text.ToString() + "';delete from CuonSach where MaSach='" + txtMaSach.Text.ToString() + "';delete from Sach where MaSach='" + txtMaSach.Text.ToString() + "'"; ;

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
                        MessageBox.Show("Xóa thành công!!");
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (datengaynhap.Value.Subtract(datenamxb.Value).TotalDays <= KhoangCachXB * 365)
            {
                if (txtTenSach.Text == "")
                    MessageBox.Show("Tên sách không được để trống");
                else if (txtNhaXB.Text == "")
                    MessageBox.Show("Tên nhà xuất bản không được để trống");
                else if (txtTriGia.Text == "0")
                    MessageBox.Show("Xin vui lòng nhập giá trị hợp lệ");
                else if (txtSoLuong.Text == "0")
                    MessageBox.Show("Xin vui lòng nhập số lượng hợp lệ");
                else
                {
                    string capnhat = @"update Sach set TenSach=N'" + txtTenSach.Text.ToString()
                                + "',MaTheLoai='" + txtTL.Text.ToString()
                                + "',NamXuatBan='" + datenamxb.Text.ToString()
                                + "',NhaXuatBan=N'" + txtNhaXB.Text.ToString()
                                + "',NgayNhap='" + datengaynhap.Text.ToString()
                                + "',TriGia='" + txtTriGia.Text.ToString()
                                + "',SoLuong=SoLuong+'" + txtSoLuong.Text.ToString()
                                + "' where MaSach='" + txtMaSach.Text.ToString() + "'";
                    Conn.executeQuery(capnhat);
                    string them2 = @"insert into CUONSACH(MaSach,TinhTrang) values ('" + txtMaSach.Text.ToString() + "',N'có sẵn')";
                    for (int i = 0; i < Convert.ToInt32(txtSoLuong.Text.ToString()); i++)
                    {
                        Conn.executeQuery(them2);
                        //MessageBox.Show("Thêm cuốn sách thànhcông!!");
                    }
                    MessageBox.Show("Cập nhật thành công!!");
                    Load_Data();
                }
            }
            else
                MessageBox.Show("Khoảng cách năm xuất bản lớn hơn quy định. Khoảng cách phải nhỏ hơn " + KhoangCachXB.ToString() + " năm");
        }
    

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (datengaynhap.Value.Subtract(datenamxb.Value).TotalDays <= KhoangCachXB * 365)
            {
                if (IsAlphabets(txtTenSach.Text) == false)
                    MessageBox.Show("Tên sách " + txtTenSach.Text + " chứa kí tự không hợp lệ");
                else if (IsAlphabets(txtNhaXB.Text) == false)
                    MessageBox.Show("Tên nhà xuất bản " + txtNhaXB.Text + " chứa kí tự không hợp lệ");
                else if (txtTriGia.Text == "0")
                    MessageBox.Show("Xin vui lòng nhập trị giá hợp lệ");
                else if (txtSoLuong.Text == "0")
                    MessageBox.Show("Xin vui lòng nhập số lượng hợp lệ");
                else
                {
                    string them = @"insert into Sach values (N'" + txtTenSach.Text + "','" + txtTL.Text + "','" + datenamxb.Text + "',N'" + txtNhaXB.Text + "','" + datengaynhap.Text + "','" + txtTriGia.Text + "','" + txtSoLuong.Text + "')";
                    Conn.executeQuery(them);
                    Load_Data();
                    int z = dataSach.Rows.Count - 2;
                    txtMaSach.Text = dataSach.Rows[z].Cells[0].Value.ToString();

                    string them2 = @"insert into CUONSACH(MaSach,TinhTrang) values ('" + txtMaSach.Text.ToString() + "',N'có sẵn')";
                    for (int i = 0; i < Convert.ToInt32(txtSoLuong.Text.ToString()); i++)
                    {
                        Conn.executeQuery(them2);
                        //MessageBox.Show("Thêm cuốn sách thànhcông!!");
                    }
                    MessageBox.Show("Thêm thành công!!");
                    Load_Data();
                }
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

        private void cboxMaTL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
