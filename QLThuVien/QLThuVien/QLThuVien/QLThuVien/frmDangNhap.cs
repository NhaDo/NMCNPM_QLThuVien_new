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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Height = 435;
            txtID.Focus();
        }       
        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập hoặc mật khẩu!", "Thông báo");
                return;
            }
            if (txtID.Text == "admin" || txtPass.Text == "admin")
            {
                MessageBox.Show("Xin chào " + txtID.Text + "! Bạn đã đăng nhập thành công!", "Thông báo");
                this.Hide();
                Form main = new frmMain(txtID.Text, txtPass.Text);
               // Form main = new frmMain();
                main.Show();
            }

            else
            {
                MessageBox.Show("Đăng nhập không thành công!", "Thông báo");
                txtID.Clear();
                txtPass.Clear();
                txtID.Focus();
            }
              
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
                Application.Exit();
            else if (dialog == DialogResult.No)
            {
                //
            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Height = 435;
            txtID.Focus();
        }

        private void lbDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Height = 751;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
