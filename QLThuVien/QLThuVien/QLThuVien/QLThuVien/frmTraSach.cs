using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QLThuVien
{

    public partial class frmTraSach : Form
    {
        int NgayMuonToiDa = 4;
        public frmTraSach()
        {
            InitializeComponent();
        }
        public void Load_cbox()
        {
            string sqlcboxSup = "select * from DOCGIA";
            cboxMaDG.DisplayMember = "MaDocGia";
            cboxMaDG.DataSource = Conn.getDataTable(sqlcboxSup);
        }
        public void Load_Sach()
        {
            string str = @"select CUONSACH.MaCuonSach, CUONSACH.MaSach,TenSach from CUONSACH,SACH where CUONSACH.MaSach=SACH.MaSach";
            DataTable dt = Conn.getDataTable(str);
            dataSach.DataSource = dt;
        }
        public void Load_Muon()
        {
            //string Muon = @"select MaSach,TenSach from tblSach where MaSach=(select MaSach from tblChiTietMuon where tblChiTietMuon.MaPM='"+cboxMaPM.Text+"' and tblChiTietMuon.NgayThue='"+cboxNgayMuon.Text+"')";
            string Muon = @"select CUONSACH.MaCuonSach,CUONSACH.MaSach,TenSach from CUONSACH,SACH where CUONSACH.MaSach=SACH.MaSach and MaCuonSach=( select MaCuonSach from PHIEUMUONTRA where (PHIEUMUONTRA.MaMuonTra='" + cboxMaPM.Text + "' and PHIEUMUONTRA.NgayMuon='" + cboxNgayMuon.Text + "' and CUONSACH.MaCuonSach=PHIEUMUONTRA.MaCuonSach))";
            //MessageBox.Show(Muon);
            DataTable dt = Conn.getDataTable(Muon);
            dataSach.DataSource = dt;
        }
        private void frmTraSach_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Load_cbox();
        }

        private void cboxMaDG_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlcboxSup_ = "select * from PHIEUMUONTRA where MaDocGia='" + cboxMaDG.Text + "'"; // tới đây!!
            cboxMaPM.DisplayMember = "MaMuonTra";
            cboxMaPM.DataSource = Conn.getDataTable(sqlcboxSup_);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            Load_Muon();
        }

        private void cboxMaPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlcboxSup_ = "select * from PHIEUMUONTRA where MaMuonTra='" + cboxMaPM.Text + "'"; // tới đây!!
            cboxNgayMuon.DisplayMember = "NgayMuon";
            cboxNgayMuon.DataSource = Conn.getDataTable(sqlcboxSup_);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataSach.SelectedRows)
            {
                listBox1.Items.Add(row.Cells[1].Value.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedIndex >= 0)
                this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
        }

        public int Kiemtra()
        {
            int check = 1; // 0--->chưa trả đủ
            int TongSoMuon, TongSoTra;
            TongSoMuon = dataSach.Rows.Count - 1;
            TongSoTra = Int16.Parse(listBox1.Items.Count.ToString());
            if (TongSoMuon > TongSoTra)
            {
                //MessageBox.Show("->> in phiếu mới!!");
                check = 0;
            }
            else
                if (TongSoMuon == TongSoTra)
            {
                //MessageBox.Show("thành công");
                check = 1;
            }
            return check;
        }
        private void btnTra_Click(object sender, EventArgs e)
        {
            DateTime ngaytra = Convert.ToDateTime(cboxNgayMuon.Text);
            if (Kiemtra() == 1)
            {
               
                //
                foreach (var listBoxItem in listBox1.Items)
                {
                    string tra = @"update PHIEUMUONTRA set NgayTra=getdate()
                                where MaCuonSach='"+ listBoxItem.ToString() 
                                + "' and PHIEUMUONTRA.MaMuonTra='" + cboxMaPM.Text 
                                + "' and PHIEUMUONTRA.NgayMuon='" + cboxNgayMuon.Text + "')";
                    string upTinhTrang = @"update CUONSACH set TinhTrang=N'có sẵn' where MaCuonSach=N'" + listBoxItem.ToString() + "')";
                    //MessageBox.Show(upTontai);
                    Conn.executeQuery(upTinhTrang);
                    //MessageBox.Show(tra);
                    Conn.executeQuery(tra);
                }
                MessageBox.Show("Bạn đã trả hết sách thành công!! Bạn có thể mượn ở lần tới.");
                listBox1.Items.Clear();
            }
            else
            {

                foreach (var listBoxItem in listBox1.Items)
                {
                    if (DateTime.Now.Subtract(ngaytra).TotalDays <= NgayMuonToiDa)
                    {
                        string upTienPhat =
                            @"update PHIEUMUONTRA set (TienPhat=TienPhat+0) where MaPM='" + cboxMaPM.Text
                            + "' and MaDG='" + cboxMaDG.Text + "'";
                        Conn.executeQuery(upTienPhat);
                    }
                    else
                    {
                        string upTienPhat =
                            @"update PHIEUMUONTRA 
                        set (TienPhat=TienPhat+(select GiaTriThamSo from THAMSO
                                        where MaThamSo=7)*
                                        DATEDIFF(day,'" + DateTime.Now.ToString("dd/mm/yyyy") + "','" + cboxNgayMuon.Text + "') '"
                            + "'where MaMuonTra='" + cboxMaPM.Text
                            + "' and MaDG='" + cboxMaDG.Text + "'";
                        Conn.executeQuery(upTienPhat);
                    }




                    string tra = @"delete from tblChiTietMuon where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "' and tblChiTietMuon.MaPM='" + cboxMaPM.Text + "' and tblChiTietMuon.NgayThue='" + cboxNgayMuon.Text + "')";
                    string upTontai = @"update tblSach set TonTai=(TonTai+1) where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "')";
                    string upSLMuon = @"update tblSach set SoLanMuon=(SoLanMuon-1) where MaSach=(select MaSach from tblSach where tblSach.TenSach=N'" + listBoxItem.ToString() + "')";
                    //MessageBox.Show(upTontai);
                    Conn.executeQuery(upTontai);
                    //MessageBox.Show(upSLMuon);
                    Conn.executeQuery(upSLMuon);
                    //MessageBox.Show(tra);
                    Conn.executeQuery(tra);
                }
                MessageBox.Show("Bạn đã trả sách thành công nhưng chưa đủ!!");
                listBox1.Items.Clear();
            }


            //MessageBox.Show("Trả thành công");

        }
    }
}
