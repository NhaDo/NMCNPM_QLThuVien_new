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
        public frmPhieuMuonTra()
        {
            InitializeComponent();
        }

        public void Load_Data()
        {
            string str = @"select * from phieumuontra";
            DataTable dt = Conn.getDataTable(str);
            dataPhieuMuonTra.DataSource = dt;
        }

        private void frmPhieuMuonTra_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_Data();
        }

        private void dataPhieuMuonTra_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
                txtSoTienTra.Text = row.Cells[5].Value.ToString();
                txtTienPhat.Text = row.Cells[6].Value.ToString();
            }
            catch (Exception)
            { }
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
                txtSoTienTra.Text = row.Cells[5].Value.ToString();
                txtTienPhat.Text = row.Cells[6].Value.ToString();
            }
            catch (Exception)
            { }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaMuonTra.Text = "";
            txtMaCuonSach.Text = "";
            txtMaDocGia.Text = "";
            datengaymuon.Text = "1/1/2021";
            datengaytra.Text = "1/1/2021";
            txtSoTienTra.Text = "";
            txtTienPhat.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
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
                        string here = @"update CuonSach set TinhTrang=N'Có sẵn')";
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (@"Select MaCuonSach from PhieuMuonTra" == txtMaCuonSach.Text)
                MessageBox.Show("Cuốn sách này đã được mượn!");
            else {
                        string them = @"insert into PhieuMuonTra values ('" + txtMaCuonSach.Text + "','"
                                                                            + txtMaDocGia.Text + "','"
                                                                            + datengaymuon.Text + "','"
                                                                            + datengaytra.Text + "','"
                                                                            + txtSoTienTra.Text + "','"
                                                                            + txtTienPhat + "')";
                        Conn.executeQuery(them);
                        string here = @"update CuonSach set TinhTrang=N'Đang mượn')";
                        Conn.executeQuery(here);
                        MessageBox.Show("Thêm phiếu thành công!");
                        Load_Data();
                    
                    }
        }

       

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string capnhat = @"update PhieuMuonTra set MaCuonSach='" + txtMaCuonSach.Text + "',MaDocGia='" 
                                                                     + txtMaDocGia.Text + "',NgayMuon='" 
                                                                     + datengaymuon.Text +"',NgayTra='" 
                                                                     + datengaytra +"',SoTienTra'='" 
                                                                     + txtSoTienTra +"',TienPhat='" 
                                                                     + txtTienPhat + "' where MaMuonTra='" 
                                                                     + txtMaMuonTra.Text + "'";
            Conn.executeQuery(capnhat);
            MessageBox.Show("Cập nhật thành công!!");
            Load_Data();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string str = @"select * from PhieuMuonTra where MaDocGia LIKE '%" + txtTimKiem.Text + "%'";
            DataTable dt = Conn.getDataTable(str);
            dataPhieuMuonTra.DataSource = dt;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void PhieuMuonTra_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
