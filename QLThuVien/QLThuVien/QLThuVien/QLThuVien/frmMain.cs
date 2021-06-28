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
            Form QD = new frmQuyDinh();
            QD.Show();            
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
            Form Tra = new frmPhieuThu();
            Tra.Show();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form DG = new frmDocGia();
            DG.Show();
            

        }

       

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form S = new frmDanhMucSach();
            S.Show();
        }

        private void mượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Muon = new frmMuonSach();
            Muon.Show();
        }

        private void trảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Tra = new frmPhieuThu();
            Tra.Show();
        }


        //BackUp
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool bBackUpStatus = true;

            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(@"c:\SQLBackup"))
            {
                if (File.Exists(@"c:\SQLBackup\QLTV.bak"))
                {
                    if (MessageBox.Show(@"Bạn có muốn thay thế nó?", "Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(@"c:\SQLBackup\QLTV.bak");
                    }
                    else
                        bBackUpStatus = false;
                }
            }
            else
                Directory.CreateDirectory(@"c:\SQLBackup");

            if (bBackUpStatus)
            {
                //Connect to DB
                SqlConnection connect;
                string con = @"Data Source=DESKTOP-KA710V7\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
                connect = new SqlConnection(con);
                connect.Open();
                //----------------------------------------------------------------------------------------------------

                //Execute SQL---------------
                SqlCommand command;
                command = new SqlCommand(@"backup database QLThuVien to disk ='c:\SQLBackup\QLTV.bak' with init,stats=10", connect);
                command.ExecuteNonQuery();
                //-------------------------------------------------------------------------------------------------------------------------------

                connect.Close();

                MessageBox.Show("Backup dữ liệu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Restore
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (File.Exists(@"c:\SQLBackup\QLTV.bak"))
                {
                    if (MessageBox.Show("Bạn có muốn khôi phục?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Connect SQL-----------
                        SqlConnection connect;
                        string con = @"Data Source=DESKTOP-KA710V7\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
                        connect = new SqlConnection(con);
                        connect.Open();
                        //-----------------------------------------------------------------------------------------

                        //Excute SQL----------------
                        SqlCommand command;
                        command = new SqlCommand("use master", connect);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(@"restore database QLThuVien from disk = 'c:\SQLBackup\QLTV.bak'", connect);
                        command.ExecuteNonQuery();
                        //--------------------------------------------------------------------------------------------------------
                        connect.Close();

                        MessageBox.Show("Khôi phục dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show(@"Không thực hiện bất kỳ sự chứng thực ở trên (hoặc không có trong đường dẫn chính xác )", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void thốngKêNhanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form TK = new frmThongKe();
            TK.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form TK = new frmThongKe();
            TK.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form BC = new frmBaoCao();
            BC.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmTraSach Tra = new frmTraSach();
            Tra.NgayMuonMax = tham_so[5];
            Tra.TienPhatMotNgay = tham_so[6];
            
            Tra.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            frmPhieuMuonTra MuonTra = new frmPhieuMuonTra();
            MuonTra.Show();           
            
        }

    }

    

}
