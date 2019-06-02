using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HS_THPT
{
    public partial class QL_HS_GV_THPT : Form
    {
        public QL_HS_GV_THPT()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btn_HocSinh_Click(object sender, EventArgs e)
        {
            Quản_lý_học_sinh sv = new Quản_lý_học_sinh();
            sv.ShowDialog();
        }

        private void btn_GiaoVien_Click(object sender, EventArgs e)
        {
            Quản_Lý_Giáo_Viên gv = new Quản_Lý_Giáo_Viên();
            gv.ShowDialog();
        }

        private void btn_PhanCong_Click(object sender, EventArgs e)
        {
            Phân_Công_Giảng_Dạy pc = new Phân_Công_Giảng_Dạy();
            pc.ShowDialog();
        }

        private void btn_TKB_Click(object sender, EventArgs e)
        {
            Thời_Khóa_Biểu kb = new Thời_Khóa_Biểu();
            kb.ShowDialog();
        }

        private void btn_User_Click(object sender, EventArgs e)
        {
            Quản_lý_người_dùng us = new Quản_lý_người_dùng();
            us.ShowDialog();

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       private void btnLop_Click(object sender, EventArgs e)
        {
            DanhSachHS hs = new DanhSachHS();
            hs.ShowDialog();
        }

        private void QL_HS_GV_THPT_Load(object sender, EventArgs e)
        {

        }
    }
}
