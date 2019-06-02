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

namespace QL_HS_THPT
{
    public partial class Quản_Lý_Giáo_Viên : Form
    {
        public Quản_Lý_Giáo_Viên()
        {
            InitializeComponent();
        }



        SqlConnection con = new SqlConnection("Data Source=DOCONG;Initial Catalog=QL_GV_HS_THPT;Integrated Security=True");
        SqlCommand sqlcmd;
        SqlDataAdapter adapter;
        private void ShowGV(DataGridView dgv)
        {
            QL_GV_HS_THPTEntities gv = new QL_GV_HS_THPTEntities();
            dgv.DataSource = gv.GetAllGV() ;
        }
        private void dgvGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        //    try
        //    {
        //        locktext();
        //        DataGridViewRow row = new DataGridViewRow();
        //        row = dgvGV.Rows[e.RowIndex];
        //        txtMaGV.Text = row.Cells[0].Value.ToString();
        //        txtTenGV.Text = row.Cells[1].Value.ToString();
        //        cboGT.Text = row.Cells[2].Value.ToString();
        //        dateTime.Text = row.Cells[3].Value.ToString();
        //        txtSDT.Text = row.Cells[4].Value.ToString();
        //        txtDiaChi.Text = row.Cells[5].Value.ToString();
        //        txtLuong.Text = row.Cells[6].Value.ToString();
        //        txtMon.Text = row.Cells[7].Value.ToString();
        //    }
        //    catch
        //    { }
        }

        private void locktext()
        {
            txtMaGV.Enabled = false;
            txtTenGV.Enabled = false;
            txtGT.Enabled = false;
            dateTime.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
            txtLuong.Enabled = false;
            txtMon.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void clearText()
        {
            txtMaGV.Text = "";
            txtTenGV.Text = "";
            txtGT.Text = "";
            dateTime.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtLuong.Text = "";
            txtMon.Text = "";
        }

        private void unlocktext()
        {
            txtMaGV.Enabled = true;
            txtTenGV.Enabled = true;
            txtGT.Enabled = true;
            dateTime.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
            txtLuong.Enabled = true;
            txtMon.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;


        }

        private void Quản_Lý_Giáo_Viên_Load(object sender, EventArgs e)
        {
            ShowGV(dgvGV);
            locktext();

        }



        private void dgvGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                locktext();
                DataGridViewRow row = new DataGridViewRow();
                row = dgvGV.Rows[e.RowIndex];
                txtMaGV.Text = row.Cells[0].Value.ToString();
                txtTenGV.Text = row.Cells[1].Value.ToString();
                txtGT.Text = row.Cells[2].Value.ToString();
                dateTime.Text = row.Cells[3].Value.ToString();
                txtSDT.Text = row.Cells[4].Value.ToString();
                txtDiaChi.Text = row.Cells[5].Value.ToString();
                txtLuong.Text = row.Cells[6].Value.ToString();
                txtMon.Text = row.Cells[7].Value.ToString();
            }
            catch
            { }
        }
        bool ok;

        QL_GV_HS_THPTEntities gv = new QL_GV_HS_THPTEntities();
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                gv.ThemGV(txtMaGV.Text, txtTenGV.Text, txtGT.Text, dateTime.Value,txtSDT.Text, txtDiaChi.Text,int.Parse(txtLuong.Text),txtMon.Text);
                try
                {
                    MessageBox.Show("Bạn đã thêm học sinh thành công");
                    ShowGV(dgvGV);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                gv.SuaGV(txtMaGV.Text, txtTenGV.Text, txtGT.Text, dateTime.Value, txtSDT.Text, txtDiaChi.Text, int.Parse(txtLuong.Text), txtMon.Text);
                try
                {
                    MessageBox.Show("Bạn đã sửa sinh viên thành công!");
                    ShowGV(dgvGV);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            unlocktext();
            ok = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            unlocktext();
            ok = false;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn xóa giáo viên không ?", "chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.OK)
            {
                gv.XoaGV(txtMaGV.Text);
                clearText();
                try
                {
                    MessageBox.Show("xóa học sinh thành công");
                    ShowGV(dgvGV);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.tblGiaovien WHERE TenGV like N'% " + txtSearch.Text +
                      "%' or MaGV like '%" + txtSearch.Text + "%'", con);
            adapter.Fill(dt);
            dgvGV.DataSource = dt;
            con.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
