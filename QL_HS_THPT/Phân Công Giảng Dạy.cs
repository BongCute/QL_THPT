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
using Dapper;

namespace QL_HS_THPT
{
    public partial class Phân_Công_Giảng_Dạy : Form
    {
        public int key = 1;
        public int Ma_=1;
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DOCONG;Initial Catalog=QL_GV_HS_THPT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataReader sqlRea;

        

        SqlConnection con = new SqlConnection("Data Source=DOCONG;Initial Catalog=QL_GV_HS_THPT;Integrated Security=True");
        SqlCommand sqlcmd;
      //  SqlDataAdapter adapter;



        // phương thức kết nối tới csdl
        public SqlConnection Connect()
        {
            connection = new SqlConnection(str);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
        // phương thức ngắt kết nối
        private void NgatKetNoi()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        void LoatData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT gd.Ma, g.TenGV,l.TenLop,m.TenMon,gd.Thu,gd.Tietday FROM dbo.tblGiaovien AS g, dbo.tblLop AS l, dbo.tblMonhoc AS m,dbo.tblGiangday AS gd WHERE g.MaMon=m.MaMon AND  g.MaGV=gd.MaGV AND gd.MaLop=l.MaLop ";
            //thực thi câu truy vấn
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvGiangDay.DataSource = table;
        }

        public void LoadDatacombobox(ComboBox cb, string strSelect)
        {
            cb.Items.Clear();
            Connect();
            command = new SqlCommand(strSelect, connection);
            sqlRea = command.ExecuteReader();
            while (sqlRea.Read())
            {
                cb.Items.Add(sqlRea[0].ToString());
            }
            NgatKetNoi();

        }
        public string GetFieldValues(string sql)
        {
            Connect();
            string ma = "";
            command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = connection;
            command.ExecuteScalar();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();

            }
            reader.Close();
            return ma;
        }

        public Phân_Công_Giảng_Dạy()
        {
            InitializeComponent();
            cboTenGV.DataSource = getData("SELECT TenGV, MaGV FROM dbo.tblGiaovien");
            cboTenGV.DisplayMember = "TenGV";
            cboTenGV.ValueMember = "MaGV";

            cboTenMon.DataSource = getData("SELECT MaMon,TenMon FROM dbo.tblMonhoc");
            cboTenMon.DisplayMember = "TenMon";
            cboTenMon.ValueMember = "TenMon";

            cboLop.DataSource = getData("SELECT TenLop, MaLop FROM dbo.tblLop");
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";


        }

 

        private void dgvGiangDay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Phân_Công_Giảng_Dạy_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoatData();
        }

        private void dgvGiangDay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                
                int i;
                i = dgvGiangDay.CurrentRow.Index;
                Ma_ = (int)dgvGiangDay.Rows[i].Cells[0].Value;
                cboTenGV.Text = dgvGiangDay.Rows[i].Cells[1].Value.ToString();
                cboTenMon.Text = dgvGiangDay.Rows[i].Cells[2].Value.ToString();
                cboLop.Text = dgvGiangDay.Rows[i].Cells[3].Value.ToString();
                txtThu.Text = dgvGiangDay.Rows[i].Cells[4].Value.ToString();
                txtTiet.Text = dgvGiangDay.Rows[i].Cells[5].Value.ToString();



            
        }
        private DataTable getData(string sql)
        {
            SqlConnection conn = Connect();
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataTable tb = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(tb);
            return tb;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }        

        private void nhanLuu(object sender, EventArgs e)
        {
            SqlConnection conn = Connect();
            if(key==1)
                conn.Query<bool>("PhanCongGD", new { MaGV = cboTenGV.SelectedValue, MaLop = cboLop.SelectedValue, Thu = txtThu.Text, Tietday = txtTiet.Text }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            if(key==2)
                conn.Query<bool>("SuaPhanCongGD", new {Ma = this.Ma_, MaGV = cboTenGV.SelectedValue, MaLop = cboLop.SelectedValue, Thu = txtThu.Text, Tietday = txtTiet.Text }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            if (key==3)
                conn.Query<bool>("DelPhanCongGD", new {Ma = this.Ma_ }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            LoatData();
            conn.Close();
        }

        private void suaEnable(object sender, EventArgs e)
        {
            key = 2;
        }

        private void xoaEnable(object sender, EventArgs e)
        {
            key = 3;
        }

        private void themEnable(object sender, EventArgs e)
        {
            key = 1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT gd.Ma, g.TenGV,l.TenLop,m.TenMon,gd.Thu,gd.Tietday FROM dbo.tblGiaovien AS g, dbo.tblLop AS l, dbo.tblMonhoc AS m,dbo.tblGiangday AS gd WHERE g.MaMon=m.MaMon AND  g.MaGV=gd.MaGV AND gd.MaLop=l.MaLop AND (gd.Ma LIKE N'%"+ txtTuKhoa.Text + "%' OR g.TenGV LIKE N'%" + txtTuKhoa.Text + "%' OR l.TenLop LIKE N'%" + txtTuKhoa.Text + "%' OR m.TenMon LIKE N'%" + txtTuKhoa.Text + "%' OR gd.Thu LIKE N'%" + txtTuKhoa.Text + "%' OR gd.TietDay LIKE N'%" + txtTuKhoa.Text + "%')";
            //thực thi câu truy vấn
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvGiangDay.DataSource = table;
            con.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
