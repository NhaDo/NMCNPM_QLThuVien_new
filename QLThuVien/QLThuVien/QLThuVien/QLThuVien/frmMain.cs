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
using System.IO;

namespace QLThuVien
{
    public partial class frmMain : Form
    {


        public int[] tham_so = new int[7] { 18, 55, 6, 8, 5, 4, 1000 };



        string username, password;

        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string user, string pass)
        {
            InitializeComponent();
            username = user;
            password = pass;
        }
        // BackUp


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                Form login = new frmDangNhap();
                login.ShowDialog();
            }
            else if (dialog == DialogResult.No)
            {
                //
            }
        }


        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("xin chào: " + username);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmQuyDinh QD = new frmQuyDinh();
            QD.Show();
            QD.TuoiToiThieu = tham_so[1];
            QD.TuoiToiDa = tham_so[2];
            QD.ThoiHanSuDung = tham_so[3];
            QD.KhoangCachXB = tham_so[4];
            QD.SoNgayMuonMax = tham_so[6];
            QD.SoSachMuonMax = tham_so[5];

            QD.FormClosed += new FormClosedEventHandler(QD_formclosed);

        }
        void QD_formclosed(object sender, FormClosedEventArgs e)
        {
            frmQuyDinh QD = sender as frmQuyDinh;
            tham_so = QD.get_thamso();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmDocGia DG = new frmDocGia();
            DG.Show();
            DG.TuoiToiThieu = tham_so[0];
            DG.TuoiToiDa = tham_so[1];
            DG.ThoiHanSuDungThe = tham_so[2];
            DG.FormClosed += new FormClosedEventHandler(DG_formclosed);
            
        }

        void DG_formclosed(object sender, FormClosedEventArgs e)
        {
           Form DG = this;
           //tham_so = DG
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmDanhMucSach S = new frmDanhMucSach();
            S.KhoangCachXB = tham_so[3];
            S.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            frmPhieuThu Tra = new frmPhieuThu();
            Tra.SoNgayMuonMax = tham_so[5];
            Tra.TienPhatMotNgay = tham_so[6];
            Tra.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmThongKe TK = new frmThongKe();
            TK.SoNgayMuonMax = tham_so[5];
            TK.TienPhat1Ngay = tham_so[6];
            TK.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form BC = new frmBaoCao();
            BC.Show();
        }



        private void pictureBox13_Click(object sender, EventArgs e)
        {
            frmPhieuMuonTra MuonTra = new frmPhieuMuonTra();
            MuonTra.SoSachMuonMax = tham_so[4];
            MuonTra.SoNgayMuonMax = tham_so[5];
            MuonTra.TienPhatMotNgay = tham_so[6];
            MuonTra.Show();
        }
    }

    

}
