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

namespace QL_HS_THPT
{
    public partial class formLoGin : Form
    {
        public string SavePassFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "SavePassFile.txt";
        public formLoGin()
        {
            InitializeComponent();
            if(File.Exists(SavePassFilePath))
            {
                StreamReader sr = new StreamReader(SavePassFilePath);
                //Read the first line of text
                try
                {
                    if (sr.ReadLine().Equals("1"))
                    {
                        Ck_NhoMatKhau.Checked = true;
                        txtTaiKhoan.Text = sr.ReadLine();
                        txtMk.Text = sr.ReadLine();
                    }
                    else
                    {
                        txtTaiKhoan.Text = "";
                        txtMk.Text = "";
                    }
                }
                catch (Exception ex) { }
                finally { sr.Close(); }
            }
            else
            {
                File.Create(SavePassFilePath);
            }            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void formLoGin_Load(object sender, EventArgs e)
        {

        }
      

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DoCong;Initial Catalog=QL_GV_HS_THPT;Integrated Security=True");
            try
            {
                con.Open();
                string tk = txtTaiKhoan.Text;
                string mk = txtMk.Text;
                string sql = "  SELECT * FROM dbo.tblUser where Username='" + tk + "'and Password='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dta = cmd.ExecuteReader();
                if(dta.Read()==true)
                {
                    if(Ck_NhoMatKhau.Checked==true)
                    {
                        string[] lines = {"1",tk,mk};
                        System.IO.File.WriteAllLines(SavePassFilePath, lines);
                    }
                    else
                    {
                        string[] lines = { "0", "", "" };
                        System.IO.File.WriteAllLines(SavePassFilePath, lines);
                    }
                    this.Hide();
                    //MessageBox.Show("Đăng nhập thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    QL_HS_GV_THPT f = new QL_HS_GV_THPT();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            
            


        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }

        private void ck_HienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if(ck_HienThiMatKhau.Checked)
            {
                txtMk.UseSystemPasswordChar = false;

            }
            else
            {
                txtTaiKhoan.UseSystemPasswordChar = true;
            }
        }

        private void Ck_NhoMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
