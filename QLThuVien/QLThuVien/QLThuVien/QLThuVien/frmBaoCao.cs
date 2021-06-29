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
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
                        nudNam.Maximum = DateTime.Now.Year;
            nudNam.Value = DateTime.Now.Year;
            nudThang.Value = DateTime.Now.Month;
        }
        public void Load_BaoCao(int thang, int nam)
        {
            //string str = @"select CT.MaCTBC,TL.TenTheLoai, CT.SoLuotMuon, CT.TyLe, BC.TongSoLuotMuon 
            //                from BCMSTTL BC join CTBCMSTTL CT on 
            //                                CT.MaBC = Bc.MaBC join THELOAI TL on 
            //                                    CT.MaTheLoai = TL.MaTheLoai where (BC.Thang='" + thang + "'and Nam='" + nam + "')";
            string str = @"select TenTheLoai, COUNT(*) AS SoLuotMuon"
                            + " from THELOAI, PHIEUMUONTRA, SACH, CUONSACH "
                            + "where SACH.MaSach = CUONSACH.MaSach "
                            + "and SACH.MaTheLoai=THELOAI.MaTheLoai "
                            + "and MONTH(PHIEUMUONTRA.NgayMuon) =  '" + nudThang.Value.ToString()
                            + "' and YEAR(PHIEUMUONTRA.NgayMuon) = '" + nudNam.Value.ToString()
                            + "' GROUP BY TenTheLoai";
            DataTable dt = Conn.getDataTable(str);
            dataTraCuu.DataSource = dt;

            if (dataTraCuu.Rows.Count > 1)
            {
                int SUM_TongSoLuotMuon = 0;
                foreach (DataGridViewRow row in dataTraCuu.Rows)
                {
                    if (row.Index <= (dataTraCuu.RowCount - 2))
                    {
                        string n = row.Cells[4].Value.ToString();
                        SUM_TongSoLuotMuon += Convert.ToInt32(row.Cells[4].Value.ToString());
                    }
                }

                foreach (DataGridViewRow row in dataTraCuu.Rows)
                {
                    if (row.Index <= (dataTraCuu.RowCount - 2))
                    {
                        int LuotMuon = Convert.ToInt32(row.Cells[4].Value.ToString());
                        row.Cells[1].Value = Convert.ToString(LuotMuon * 100 / SUM_TongSoLuotMuon) + "%";
                        row.Cells[2].Value = Convert.ToString(SUM_TongSoLuotMuon);
                    }
                }

            }
        }
            

        private void dataTraCuu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nudThang_ValueChanged(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_BaoCao(((int)nudThang.Value), ((int)nudNam.Value));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_BaoCao(((int)nudThang.Value), ((int)nudNam.Value));
        }

        private void nudNam_ValueChanged(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Load_BaoCao(((int)nudThang.Value), ((int)nudNam.Value));
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dataTraCuu.Columns.Count + 1; i++)
            {
                xcelApp.Cells[1, i] = dataTraCuu.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataTraCuu.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataTraCuu.Columns.Count; j++)
                {
                    xcelApp.Cells[i + 2, j + 1] = dataTraCuu.Rows[i].Cells[j].Value.ToString();
                }
            }
            xcelApp.Columns.AutoFit();
            xcelApp.Visible = true;
        }
    }
}
