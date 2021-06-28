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
    public partial class frmMuonSach : Form
    {
        public frmMuonSach()
        {
            InitializeComponent();
        }
        public void Load_TL()
        {
            string str = @"select MaTheLoai,TenTheLoai from THELOAI";
            DataTable dt = Conn.getDataTable(str);
            dataTL.DataSource = dt;
        }
        public void Load_Sach()
        {
            string str = @"select CUONSACH.MaCuonSach,CUONSACH.MaSach,TenSach,NhaXuatBan from SACH, CUONSACH where SACH.MaSach = CUONSACH.MaSach";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }
        public void Load_cbox()
        {
            string sqlcboxSup = "select * from DOCGIA";
            cboxMaDG.DisplayMember = "MaDocGia";
            cboxMaDG.DataSource = Conn.getDataTable(sqlcboxSup);
        }
        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            Load_TL();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load_cbox();
            Load_Sach();
            //txtMaPM.Text = "PM00";
            //
        }

        private void txtTimTL_TextChanged(object sender, EventArgs e)
        {
            string str = @"select MaTheLoai,TenTheLoai from THELOAI where TenTheLoai LIKE N'%" + txtTimTL.Text + "%'";
            DataTable dt = Conn.getDataTable(str);
            dataTL.DataSource = dt;
        }

        private void txtTimSach_TextChanged(object sender, EventArgs e)
        {
            string str = @"select CUONSACH.MaCuonSach,CUONSACH.MaSach,TenSach,NhaXuatBan from SACH where TenSach LIKE N'%" + txtTimSach.Text + "%' or NhaXuatBan LIKE N' % " + txtTimSach.Text + " % '";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataSach.SelectedRows)
            {
                listBox1.Items.Add(row.Cells[0].Value.ToString());
            }
        }

        private void dataTL_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataTL.Rows[e.RowIndex];
                txtChonMaTL.Text = row.Cells[0].Value.ToString();
            }
            catch (Exception)
            { }
            //string sach = @"select CUONSACH.MaCuonSach,CUONSACH.MaSach,TenSach,NhaXuatBan from CUONSACH,SACH where CUONSACH.MaSach=SACH.MaSach and MaTheLoai='" + txtChonMaTL.Text + "'";
            //DataTable dt = Conn.getDataTable(sach);
            //dataSach.DataSource = dt;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
                this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);

        }
        private void btnMuon_Click(object sender, EventArgs e)
        {
            //if (txtMaPM.Text == "")
            //MessageBox.Show("Mã Phiếu mượn không được trống!!");
            //else
            {

                foreach (var listBoxItem in listBox1.Items)
                {
                    //MessageBox.Show(listBoxItem.ToString());
                    string PHIEUMUONTRA = @"insert into PHIEUMUONTRA(MaMuonTra,MaCuonSach,MaDocGia,NgayMuon,TienPhat) values('" + txtMaPM.Text + "','" + listBoxItem.ToString() + "','" + cboxMaDG.Text + "','" + dateNgayMuon.Text + "'0,'" + "')";
                    string upTinhTrang = @"update CUONSACH set TinhTrang=N'được mượn' where MaCuonSach=N'" + listBoxItem.ToString() + "')";
                    Conn.executeQuery(PHIEUMUONTRA);
                    Conn.executeQuery(upTinhTrang);
                }
            }
            MessageBox.Show("Mượn thành công!!");
            listBox1.Items.Clear();

            //
        }

        private void txtMaPM_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8);
        }
    }
}
