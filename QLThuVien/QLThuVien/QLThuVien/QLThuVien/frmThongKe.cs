using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class frmThongKe : Form
    {
        public int SoNgayMuonMax { get; set; }
        public int TienPhat1Ngay { get; set; }
        public frmThongKe()
        {
            InitializeComponent();
        }
        public void Load_ThongKe(string ngay)
        {
            string str = @"select MaMuonTra,NgayMuon,NgayTra,TienPhat from PhieuMuonTra where NgayTra IS NULL OR TienPhat > 0";
            DataTable dt = Conn.getDataTable(str);
            dt.Columns.Add("SoNgayTraTre", typeof(string));
            dataTraCuu.DataSource = dt;
            for (int i = 0; i < (dataTraCuu.Rows.Count - 1); i = i + 1)
            {
                if(Convert.ToInt32(dataTraCuu.Rows[i].Cells[4].Value) > 0)
                {
                    dataTraCuu.Rows[i].Cells[5].Value = Convert.ToInt32(dataTraCuu.Rows[i].Cells[4].Value) / TienPhat1Ngay;
                }
                else
                {
                    DateTime dates1 = Convert.ToDateTime(dataTraCuu.Rows[i].Cells[2].Value);
                    DateTime dates2 = Convert.ToDateTime(ngay);
                    TimeSpan time = dates1.Subtract(dates2);
                    int days = -(time.Days) - SoNgayMuonMax;
                    if (days >= 1)
                    {
                        dataTraCuu.Rows[i].Cells[5].Value = days.ToString();
                        dataTraCuu.Rows[i].Cells[4].Value = days * TienPhat1Ngay;
                    }
                    else
                        dataTraCuu.Rows[i].Cells[5].Value = 0;
                }

            }


        }
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_ThongKe(dateNgayTra.Text);
        }

        private void dataTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void dateNgayTra_ValueChanged(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_ThongKe(dateNgayTra.Text);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dataTraCuu.Columns.Count + 1; i++)
            {
                xcelApp.Cells[1, i] = dataTraCuu.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataTraCuu.Rows.Count-1; i++)
            {
                for (int j = 0; j < dataTraCuu.Columns.Count; j++)
                {
                    xcelApp.Cells[i + 2, j + 1] = dataTraCuu.Rows[i].Cells[j].Value.ToString();
                }
            }
            xcelApp.Columns.AutoFit();
            xcelApp.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
