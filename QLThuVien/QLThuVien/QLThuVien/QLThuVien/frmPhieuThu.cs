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
using System.Text.RegularExpressions;


namespace QLThuVien
{
    public partial class frmPhieuThu : Form
    {
        public int SoNgayMuonMax { get; set; }
        public int TienPhatMotNgay { get; set; }
        public frmPhieuThu()
        {
            InitializeComponent();
        }
        public void Load_Data()
        {
            string str = @"select * from phieuthu";
            DataTable dt = Conn.getDataTable(str);
            dataPhieuThu.DataSource = dt;
        }

        public void Load_MaDocGia()
        {
            string n = DateTime.Now.ToString("dd/MM/yyyy");
            string sqlcboxSup = "select * from DOCGIA, PHIEUMUONTRA " +
                                "where DOCGIA.MaDocGia = PHIEUMUONTRA.MaDocGia" +
                                " and DATEDIFF(day, PHIEUMUONTRA.NgayMuon, getdate())>'"
                                + SoNgayMuonMax.ToString() + "'";
            txtMaDocGia.DisplayMember = "MaDocGia";
            txtMaDocGia.DataSource = Conn.getDataTable(sqlcboxSup);
        }


        private void frmTraSach_Load_1(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_Data();
            Load_MaDocGia();
        }

        

        

            private void dataPhieuThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataPhieuThu.Rows[e.RowIndex];
                txtMaPhieuThu.Text = row.Cells[0].Value.ToString();
                txtMaDocGia.Text = row.Cells[1].Value.ToString();
                txtSoTienThu.Text = row.Cells[2].Value.ToString();
                txtConLai.Text = row.Cells[3].Value.ToString();
            }
            catch (Exception)
            { }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            txtMaPhieuThu.Text = "";
            txtMaDocGia.Text = "";
            txtSoTienThu.Text = "";
            txtConLai.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string xoa = @"delete from PhieuThu where MaPhieuThu='" + txtMaPhieuThu.Text + "'";
            if (txtMaPhieuThu.Text == "")
                MessageBox.Show("Mã phiếu thu không được trống!!");
            else
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa phiếu thu :" + txtMaPhieuThu.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            if (Convert.ToInt32(txtSoTienThu.Text) > 0)
            {
                string capnhat = @"update PhieuThu set MaDocGia='" + txtMaDocGia.Text + "',SoTienThu='"
                                                               + txtSoTienThu.Text + "',ConLai='"
                                                               + txtConLai.Text + "' where MaPhieuThu='"
                                                               + txtMaPhieuThu.Text + "'";
                Conn.executeQuery(capnhat);
                MessageBox.Show("Cập nhật thành công!!");
                Load_Data();
            }
            else
            {
                MessageBox.Show("Phải nhập số tiền thu lớn hơn 0");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtSoTienThu.Text)>0)
            {
                string them = @"insert into PhieuThu values ('" + txtMaDocGia.Text + "','" + txtSoTienThu.Text + "','" + txtConLai.Text + "')";
                Conn.executeQuery(them);
                MessageBox.Show("Thêm sách thành công!!");
                Load_Data();
            }
            else
            {
                MessageBox.Show("Phải nhập số tiền thu lớn hơn 0");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string str = @"select * from PhieuThu where MaDocGia LIKE '%" + txtTimKiem.Text + "%'";
            DataTable dt = Conn.getDataTable(str);
            dataPhieuThu.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataPhieuThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataPhieuThu.Rows[e.RowIndex];
                txtMaPhieuThu.Text = row.Cells[0].Value.ToString();
                txtMaDocGia.Text = row.Cells[1].Value.ToString();
                txtSoTienThu.Text = row.Cells[2].Value.ToString();
                txtConLai.Text = row.Cells[3].Value.ToString();
            }
            catch (Exception)
            { }
        }

        private void txtMaDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmDocGia DG = new frmDocGia();
            DG.Visible = false;
            DG.SendToBack();
            DG.Show();
            DG.Hide();

            int tongno = DG.TongNo(txtMaDocGia.Text.ToString());

            txtTongNo.Text = tongno.ToString();
        }
        public bool IsAlphabets(string inputString)
        {
            Regex r = new Regex("^[a-zA-Z ]+$");
            if (r.IsMatch(inputString))
                return true;
            else
                return false;
        }

        private void txtSoTienThu_TextChanged(object sender, EventArgs e)
        {
            if (!IsAlphabets(txtSoTienThu.Text) && txtSoTienThu.Text!="")
                txtConLai.Text = Convert.ToString(Convert.ToInt32(txtTongNo.Text) - Convert.ToInt32(txtSoTienThu.Text));
            else
                MessageBox.Show("chỉ được nhập số");
        }
    }
}
