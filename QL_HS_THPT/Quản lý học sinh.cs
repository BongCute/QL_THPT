using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QL_HS_THPT
{
    public partial class Quản_lý_học_sinh : Form
    {
        public Quản_lý_học_sinh()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DOCONG;Initial Catalog=QL_GV_HS_THPT;Integrated Security=True");
        SqlCommand sqlcmd;
        SqlDataAdapter adapter;



        private void Quản_lý_học_sinh_Load(object sender, EventArgs e)
        {
            locktext();
            ShowHS(dgvHS);

        }

        private void ShowHS(DataGridView dgv)
        {
            QL_GV_HS_THPTEntities sv = new QL_GV_HS_THPTEntities();
            dgv.DataSource = sv.GetAllHS();
        }

        private void dgvHS_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dgvHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                locktext();
                DataGridViewRow row = new DataGridViewRow();
                row = dgvHS.Rows[e.RowIndex];
                txtMa.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtGT.Text = row.Cells[2].Value.ToString();
                dateTime.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                txtDanToc.Text = row.Cells[5].Value.ToString();
                txtTonGiao.Text = row.Cells[6].Value.ToString();
                txtMaLop.Text = row.Cells[7].Value.ToString();
            }
            catch
            { }
        }

        private void locktext()
        {
            txtMa.Enabled = false;
            txtName.Enabled = false;
            txtGT.Enabled = false;
            dateTime.Enabled = false;
            txtDiaChi.Enabled = false;
            txtDanToc.Enabled = false;
            txtTonGiao.Enabled = false;
            txtMaLop.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void clearText()
        {
            txtMa.Text = "";
            txtName.Text = "";
            txtGT.Text = "";
            dateTime.Text = "";
            txtDiaChi.Text = "";
            txtDanToc.Text = "";
            txtTonGiao.Text = "";
            txtMaLop.Text = "";
        }

        private void unlocktext()
        {
            txtMa.Enabled = true;
            txtName.Enabled = true;
            txtGT.Enabled = true;
            dateTime.Enabled = true;
            txtDiaChi.Enabled = true;
            txtDanToc.Enabled = true;
            txtTonGiao.Enabled = true;
            txtMaLop.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        bool ok;
        private void btnThem_Click(object sender, EventArgs e)
        {
            unlocktext();
            ok = true;

        }

     
        QL_GV_HS_THPTEntities sv = new QL_GV_HS_THPTEntities();
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                sv.Them_HS(txtMa.Text, txtName.Text, txtGT.Text, dateTime.Value, txtDiaChi.Text, txtDanToc.Text, txtTonGiao.Text, txtMaLop.Text);
                try
                {
                    MessageBox.Show("Bạn đã thêm học sinh thành công");
                    ShowHS(dgvHS);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                sv.Sua_HS(txtMa.Text, txtName.Text, txtGT.Text, dateTime.Value, txtDiaChi.Text, txtDanToc.Text, txtTonGiao.Text, txtMaLop.Text);
                try
                {
                    MessageBox.Show("Bạn đã sửa sinh viên thành công!");
                    ShowHS(dgvHS);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Bạn có muốn xóa học sinh không?", "chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning));
            if(thongbao==DialogResult.OK)
            {
                sv.Xoa(txtMa.Text);
                clearText();
                try
                {
                    MessageBox.Show("xóa học sinh thành công");
                    ShowHS(dgvHS);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter= new SqlDataAdapter("SELECT * FROM dbo.tblHocSinh WHERE TenHS like N'% " +txtSearch.Text +
                      "%' or MaHS like '%" + txtSearch.Text+"%'",con);
            adapter.Fill(dt);
            dgvHS.DataSource = dt;
            con.Close();
            
            
        }

        private void dgvHS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            unlocktext();
            ok = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSeach_Ten_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
        
    
