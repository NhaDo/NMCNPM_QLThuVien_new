using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using QLThuVien;

namespace QLThuVien
{
    public partial class frmDocGia : Form
    {

        public int TuoiToiDa { get; set; }
        public int TuoiToiThieu { get; set; }

        public int ThoiHanSuDungThe { get; set; }
        public frmDocGia()
        {
            InitializeComponent();

            this.datehethan.Enabled = false;
            this.datehethan.Value = datelapthe.Value.AddMonths(ThoiHanSuDungThe);
            txtMaDG.Enabled = false;
        }


        public void Load_Data()
        {
            string str = @"select * from DOCGIA";
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

            txtMaDG.Text = "";
            txtHoTen.Text = "";
            dateNgaySinh.Text = "";
            dateNgaySinh.Text = DateTime.Now.ToString("dd/mm/yyyy");
            datelapthe.Text = DateTime.Now.ToString("dd/mm/yyyy");
            datehethan.Text = DateTime.Now.AddMonths(ThoiHanSuDungThe).ToString("dd/mm/yyyy");
            txtLoaiDocGia.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtTongNo.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string xoa = @"delete from DOCGIA where MaDocGia='" + txtMaDG.Text + "'";
            if (txtMaDG.Text == "")
                MessageBox.Show("Mã độc giả không được trống!!");
            else
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa độc giả: " + txtMaDG.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        Conn.executeQuery(xoa);
                        Load_Data();
                        MessageBox.Show("Xóa độc giả thành công!!");
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
            
    
            if (txtLoaiDocGia.Text != "1" && txtLoaiDocGia.Text != "2" && txtLoaiDocGia.Text != "3")
                MessageBox.Show("Loại độc giả " + txtLoaiDocGia.Text + " không tồn tại");
            else if (IsAlphabets(txtHoTen.Text) == false)
                MessageBox.Show("Tên độc giả " + txtHoTen.Text + " chứa kí tự không hợp lệ");
            else if (txtDiaChi.Text == "")
                MessageBox.Show("Xin vui lòng nhập địa chỉ");
            else if (txtEmail.Text == "")
                MessageBox.Show("Xin vui lòng nhập email hợp lệ");
            else if (DateTime.Now.Subtract(dateNgaySinh.Value).TotalDays < TuoiToiThieu*365)
                MessageBox.Show("Tuổi độc giả " + txtHoTen.Text + " phải lớn hơn " + TuoiToiThieu.ToString());
            else if (DateTime.Now.Subtract(dateNgaySinh.Value).TotalDays > TuoiToiDa*365)
                MessageBox.Show("Tuổi độc giả " + txtHoTen.Text + " phải nhỏ hơn " + TuoiToiDa.ToString());
            else
            {
                string them = @"insert into DOCGIA(TenDocGia,MaLoaiDocGia,NgaySinh,DiaChi,Email,NgayLapThe,NgayHetHan,TongNo) values('"

                                             + txtHoTen.Text +
                                            "','" + txtLoaiDocGia.Text +
                                            "','" + dateNgaySinh.Text +
                                            "',N'" + txtDiaChi.Text +
                                            "','" + txtEmail.Text +
                                            "','" + datelapthe.Text +
                                            "','" + datehethan.Text +
                                            "','" + txtTongNo.Text + "')";
                Conn.executeQuery(them);
                Load_Data();
                MessageBox.Show("Thêm độc giả thành công!");
            }
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //if (txtMaDG.Text == "")
            //MessageBox.Show("Mã độc giả không được trống!!");

            if (txtLoaiDocGia.Text != "1" && txtLoaiDocGia.Text != "2" && txtLoaiDocGia.Text != "3")
                MessageBox.Show("Loại độc giả " + txtLoaiDocGia.Text + " không tồn tại");
            else if (IsAlphabets(txtHoTen.Text) == false)
                MessageBox.Show("Tên độc giả " + txtHoTen.Text + " chứa kí tự không hợp lệ");
            else if (txtDiaChi.Text == "")
                MessageBox.Show("Xin vui lòng nhập địa chỉ");
            else if (txtEmail.Text == "")
                MessageBox.Show("Xin vui lòng nhập email hợp lệ");
            else if (DateTime.Now.Subtract(dateNgaySinh.Value).TotalDays < TuoiToiThieu * 365)
                MessageBox.Show("Tuổi độc giả " + txtHoTen.Text + " phải lớn hơn " + TuoiToiThieu.ToString());
            else if (DateTime.Now.Subtract(dateNgaySinh.Value).TotalDays > TuoiToiDa * 365)
                MessageBox.Show("Tuổi độc giả " + txtHoTen.Text + " phải nhỏ hơn " + TuoiToiDa.ToString());
            else
            {
                string capnhat = @"update DOCGIA set 
                                TenDocGia=N'" + txtHoTen.Text +
                                "',MaLoaiDocGia='" + txtLoaiDocGia.Text +
                                "',NgaySinh='" + dateNgaySinh.Text +
                                "',DiaChi=N'" + txtDiaChi.Text +
                                "',Email='" + txtEmail.Text +
                                "' WHERE MaDocGia='" + txtMaDG.Text + "'";
                Conn.executeQuery(capnhat);
                Load_Data();
                MessageBox.Show("Cập nhật độc giả thành công!");
            }
        }

        private void dataDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datehethan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datelapthe_ValueChanged(object sender, EventArgs e)
        {
            this.datehethan.Value = datelapthe.Value.AddMonths(ThoiHanSuDungThe);
        }
    }
}
