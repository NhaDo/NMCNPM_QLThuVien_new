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
    public partial class frmPhieuMuonTra : Form
    {
        public int SoNgayMuonMax { get; set; }

        public int SoSachMuonMax { get; set; }

        public int TienPhatMotNgay { get; set; }

        public int SoQuyenSachTraTre(string MaDocGia)
        {
            int soquyen = 0;
            if (dataPhieuMuonTra.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dataPhieuMuonTra.Rows)
                {
                    if (row.Index <= (dataPhieuMuonTra.RowCount - 2) 
                        && row.Cells[2].Value.ToString() == MaDocGia)
                    {
                        DateTime dates1 = Convert.ToDateTime(row.Cells[3].Value.ToString());
                        TimeSpan time = DateTime.Now.Subtract(dates1);
                        if (time.Days > SoNgayMuonMax)
                            soquyen++;
                    }
                }
            }
            return soquyen;
        }
        public frmPhieuMuonTra()
        {
            InitializeComponent();
        }

        public void Load_Data()
        {
            string str = @"select * from phieumuontra";
            DataTable dt = Conn.getDataTable(str);
            dataPhieuMuonTra.DataSource = dt;
            string str2 = @"select CS.MaCuonSach,S.TenSach,Cs.TinhTrang from Sach S, CUONSACH CS where S.MaSach = CS.MaSach";
            DataTable dt2 = Conn.getDataTable(str2);
            dataSach.DataSource = dt2;
        }

        public void dataPhieuMuonTra_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_Data();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            int flag = 0;
            if (dataPhieuMuonTra.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dataPhieuMuonTra.Rows)
                {
                    if (row.Index<=(dataPhieuMuonTra.RowCount-2) && row.Cells[1].Value.ToString() == txtMaCuonSach.Text.ToString())
                    {
                        MessageBox.Show("Cuốn sách này đã được mượn!");
                        flag = 1;
                        break;
                    }
                }
            }

            int flag2 = 0;
            if (dataPhieuMuonTra.Rows.Count >1)
            {
                foreach (DataGridViewRow row in dataPhieuMuonTra.Rows)
                {
                    if (row.Index <= (dataPhieuMuonTra.RowCount - 2) && row.Cells[2].Value.ToString() == txtMaDocGia.Text.ToString())
                    {
                        flag2++;
                        if (flag2 == 5)
                            break;
                    }
                }
            }
            
            

            if (flag2 == SoSachMuonMax)
            {
                MessageBox.Show("Độc giả đã mượn đủ " + SoSachMuonMax.ToString() + " cuốn sách"); 
            }

            if (flag == 0 && flag2<SoSachMuonMax)
            {
                string them = @"insert into PHIEUMUONTRA(MaCuonSach,MaDocGia,NgayMuon,TienPhat,SoTienTra) values ('"
                                                                    + txtMaCuonSach.Text + "','"
                                                                    + txtMaDocGia.Text + "','"
                                                                    + datengaymuon.Text + "','"
                                                                    
                                                                    + txtTienPhat.Text + "','"
                                                                    + txtSoTienTra.Text + "')";
                Conn.executeQuery(them);
                string here = @"update CUONSACH set TinhTrang = N'được mượn' where MaCuonSach='" + txtMaCuonSach.Text + "'";
                Conn.executeQuery(here);
                MessageBox.Show("Thêm phiếu thành công!");

                Load_Data();
            }
        
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string xoa = @"delete from PhieuMuonTra where MaMuonTra='" + txtMaMuonTra.Text + "'";
            if (txtMaMuonTra.Text == "")
                MessageBox.Show("Mã mượn trả không được trống!!");
            else
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa phiếu:" + txtMaMuonTra.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        Conn.executeQuery(xoa);
                        string here = @"update CuonSach set TinhTrang=N'có sẵn' where MaCuonSach='" + txtMaCuonSach.Text + "'";
                        Conn.executeQuery(here);
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

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            if (txtMaMuonTra.Text == "")
                MessageBox.Show("Mã mượn trả không được để trống!!");
            else
            {
                if (datengaytra.Text == datengaymuon.Text)
                {
                    string capnhat = @"update PHIEUMUONTRA set MaCuonSach='" + txtMaCuonSach.Text + "',MaDocGia='"
                                                            + txtMaDocGia.Text + "',NgayMuon='"
                                                            + datengaymuon.Text + "'TienPhat='"
                                                            + txtTienPhat.Text + "',SoTienTra='"
                                                            + txtSoTienTra.Text + "' where MaMuonTra='"
                                                            + txtMaMuonTra.Text + "'";
                    Conn.executeQuery(capnhat);
                    MessageBox.Show("Cập nhật thành công!!");
                    Load_Data();
                }
                else
                {
                    string capnhat = @"update PHIEUMUONTRA set MaCuonSach='" + txtMaCuonSach.Text + "',MaDocGia='"
                                        + txtMaDocGia.Text + "',NgayMuon='"
                                        + datengaymuon.Text + "',NgayTra='"
                                        + datengaytra.Text + "',TienPhat='"
                                        + txtTienPhat.Text + "',SoTienTra='"
                                        + txtSoTienTra.Text + "' where MaMuonTra='"
                                        + txtMaMuonTra.Text + "'";
                    Conn.executeQuery(capnhat);
                    MessageBox.Show("Cập nhật thành công!!");
                    Load_Data();
                }
            }    
        }

        private void btnMoi_Click_1(object sender, EventArgs e)
        {
            txtMaMuonTra.Text = "";
            txtMaCuonSach.Text = "";
            txtMaDocGia.Text = "";
            datengaymuon.Text = "1/1/2021";
            datengaytra.Text = "1/1/2021";
            txtSoTienTra.Text = "";
            txtTienPhat.Text = "";
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            string str = @"select * from PhieuMuonTra where MaDocGia LIKE '%" + txtTimKiem.Text + "%'";
            DataTable dt = Conn.getDataTable(str);
            dataPhieuMuonTra.DataSource = dt;
        }

        

        private void dataPhieuMuonTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataPhieuMuonTra.Rows[e.RowIndex];
                txtMaMuonTra.Text = row.Cells[0].Value.ToString();
                txtMaCuonSach.Text = row.Cells[1].Value.ToString();
                txtMaDocGia.Text = row.Cells[2].Value.ToString();
                datengaymuon.Text = row.Cells[3].Value.ToString();
                datengaytra.Text = row.Cells[4].Value.ToString();                
                txtTienPhat.Text = row.Cells[5].Value.ToString();
                txtSoTienTra.Text = row.Cells[6].Value.ToString();
            }
            catch (Exception)
            { }
        }

 

        private void datengaytra_ValueChanged(object sender, EventArgs e)
        {
            DateTime dates1 = Convert.ToDateTime(datengaytra.Text);
            DateTime dates2 = Convert.ToDateTime(datengaymuon.Text);

            TimeSpan time = dates1.Subtract(dates2);
            int days = time.Days;
            if (days > SoNgayMuonMax)
            {
                txtTienPhat.Text = ((days-SoNgayMuonMax)*TienPhatMotNgay).ToString();
            }
            else
            {
                txtTienPhat.Text = "0";
            }    
        }

        private void dataSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
