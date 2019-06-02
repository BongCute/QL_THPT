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
    public partial class Quản_lý_người_dùng : Form
    {
        SqlConnection connection;
        SqlCommand command;
        //chuỗi kết nối
        string str = "Data Source=DOCONG;Initial Catalog=QL_GV_HS_THPT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        
        

        void LoatData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.tblUser";
            //thực thi câu truy vấn
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvUser.DataSource = table;
        }

        public Quản_lý_người_dùng()
        {
            InitializeComponent();
        }

        private void Quản_lý_người_dùng_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoatData();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        //{
        //    try
        //    {
        //        //int i;
        //        //i = dgvUser.CurrentRow.Index;
        //        //txtUser.Text = dgvUser.Rows[i].Cells[0].Value.ToString();
        //        //txtPassWord.Text = dgvUser.Rows[i].Cells[1].Value.ToString();
        //        //txtMaGV.Text = dgvUser.Rows[i].Cells[2].Value.ToString();
        //        //txtQuyen.Text = dgvUser.Rows[i].Cells[3].Value.ToString();
        //        DataGridViewRow row = new DataGridViewRow();
        //        row = dgvUser.Rows[e.RowIndex];
        //        txtUser.Text = row.Cells[0].Value.ToString();
        //        txtPassWord.Text = row.Cells[1].Value.ToString();
        //        txtMaGV.Text = row.Cells[2].Value.ToString();
        //        txtQuyen.Text = row.Cells[3].Value.ToString();
        //    }
        //    catch
        //    {

        //    }

        

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Insert into dbo.tblUser values('" + txtUser.Text + "','" + txtPassWord.Text + "','" + txtMaGV.Text + "','" + txtQuyen.Text+"')";
            command.ExecuteNonQuery();//sử lý truy vấn và trả về kết quả
            LoatData();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                txtUser.ReadOnly = true;
                int i;
                i = dgvUser.CurrentRow.Index;
                txtUser.Text = dgvUser.Rows[i].Cells[0].Value.ToString();
                txtPassWord.Text = dgvUser.Rows[i].Cells[1].Value.ToString();
                txtMaGV.Text = dgvUser.Rows[i].Cells[2].Value.ToString();
                txtQuyen.Text = dgvUser.Rows[i].Cells[3].Value.ToString();
             

            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {


            command = connection.CreateCommand();
            command.CommandText = "UPDATE  dbo.tblUser SET  Password='" + txtPassWord.Text + "', MaGV='" + txtMaGV.Text + "',Quyen='" + txtQuyen.Text + "'where Username='" + txtUser.Text + "'";
            command.ExecuteNonQuery();
            LoatData();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "  Delete from dbo.tblUser where Username='" + txtUser.Text + "'";
            command.ExecuteNonQuery();
            LoatData();
        }

        private void ShareMaGiaoVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.tblUser WHERE Username LIKE N'%"+ txtTuKhoa.Text+ "%' OR MaGV LIKE N'%" + txtTuKhoa.Text + "%' OR Quyen LIKE N'%" + txtTuKhoa.Text + "%'";
            //thực thi câu truy vấn
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvUser.DataSource = table;
        }
    }
}
