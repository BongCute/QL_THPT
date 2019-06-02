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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using COMExcel = Microsoft.Office.Interop.Excel;
using NsExcel = Microsoft.Office.Interop.Excel;

namespace QL_HS_THPT
{
    public partial class Thời_Khóa_Biểu : Form
    {

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DOCONG;Initial Catalog=QL_GV_HS_THPT;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataReader sqlRea;

        // phương thức kết nối tới csdl
        public void Connect()
        {
            connection = new SqlConnection(str);
            if( connection.State== ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        // phương thức ngắt kết nối
        private void NgatKetNoi()
        {
            if( connection.State== ConnectionState.Open)
            {
                connection.Close();
            }
        }

       /* void LoatData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT g.TenGV,m.TenMon,gd.Thu,gd.Tietday  FROM dbo.tblGiaovien AS g, dbo.tblLop AS l, dbo.tblMonhoc AS m,dbo.tblGiangday AS gd WHERE g.MaMon = m.MaMon AND g.MaGV = gd.MaGV AND gd.MaLop = l.MaLop ";
            //thực thi câu truy vấn
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvTKB.DataSource = table;
        }*/

        public Thời_Khóa_Biểu()
        {
            InitializeComponent();
        }
        // 
        public void LoadDatacombobox( ComboBox cb, string strSelect)
        {
            cb.Items.Clear();
            Connect();
            command = new SqlCommand(strSelect, connection);
            sqlRea = command.ExecuteReader();
            while ( sqlRea.Read())
            {
                cb.Items.Add(sqlRea[0].ToString());
            }
            NgatKetNoi();

        }
        public string GetFieldValues( string sql)
        {
            Connect();
            string ma = "";
            command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = connection;
            command.ExecuteScalar();
            SqlDataReader reader = command.ExecuteReader();
            while ( reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            
            }
            reader.Close();
            return ma;
        }        

        private void Thời_Khóa_Biểu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadDatacombobox(cboMaGV, " Select MaGV, TenGv from tblGiaovien");

            cboMaGV.DataSource = getData("SELECT TenGV, MaGV FROM dbo.tblGiaovien");
            cboMaGV.DisplayMember = "MaGV";
            cboMaGV.ValueMember = "TenGV";

            //LoatData();
        }

        private DataTable getData(string sql)
        {            
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            DataTable tb = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(tb);
            return tb;
        }

        private void cbomalop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = " select TenGV from tblGiaovien Where MaGV='" + cboMaGV.Text + "'";
            txtGV.Text = GetFieldValues(str);
        }



        private void dgvTKB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nhanIn(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            NsExcel.Application exApp = new NsExcel.Application();
            NsExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            NsExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            NsExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHS, tblThongtinHang;
            exBook = exApp.Workbooks.Add(NsExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["C1:E3"].Font.Size = 10;
            exRange.Range["C1:E3"].Font.Bold = true;
            exRange.Range["C1:E3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["C1:C1"].ColumnWidth = 7;
            exRange.Range["D1:D1"].ColumnWidth = 15;
            exRange.Range["C1:D1"].MergeCells = true;

            exRange.Range["C1:D1"].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C1:D1"].Value = "Trường THTP Nguyễn Siêu";
            exRange.Range["C2:D2"].MergeCells = true;
            exRange.Range["C2:D2"].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C2:D2"].Value = "Địa chỉ: Hưng Yên";
            exRange.Range["C3:D3"].MergeCells = true;
            exRange.Range["C3:D3"].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C3:D3"].Value = "Điện thoại: (04)45676586834";

            exRange.Range["C1:D3"].Borders.LineStyle = NsExcel.XlLineStyle.xlContinuous;

            exRange.Range["C5:H5"].Font.Size = 16;
            exRange.Range["C5:H5"].Font.Bold = true;
            exRange.Range["C5:H5"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C5:H5"].MergeCells = true;
            exRange.Range["C5:H5"].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C5:H5"].Value = "Thời khóa biểu giáo viên";
            // Biểu diễn thông tin chung của hóa đơn bán


            //Lấy thông tin các mặt hàng           
            DataTable dt = new DataTable();
            dt = getData("SELECT * FROM dbo.tblGiaovien WHERE MaGV = '" + cboMaGV.Text + "'");
            DataTable dts = new DataTable();
            dts = getData("SELECT   gd.Thu,gd.Tietday,l.TenLop,m.TenMon FROM dbo.tblGiaovien AS g, dbo.tblLop AS l, dbo.tblMonhoc AS m, dbo.tblGiangday AS gd WHERE g.MaMon = m.MaMon AND  g.MaGV = gd.MaGV AND gd.MaLop = l.MaLop  AND g.MaGV =  '" + cboMaGV.Text + "'");

            exRange.Range["C6:H6"].MergeCells = true;

            exRange.Range["C7:D7"].MergeCells = true;
            exRange.Range["C7:D7"].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C7:D7"].Value = "Mã Giáo viên: " + dt.Rows[0][0];
            exRange.Range["C8:D8"].MergeCells = true;
            exRange.Range["C8:D8"].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C8:D8"].Value = "Tên Giáo viên: " + dt.Rows[0][1];

            exRange.Range["F7:H7"].MergeCells = true;
            exRange.Range["F7:H7"].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignRight;
            exRange.Range["F7:H7"].Value = "Ngày : " + DateTime.Now.ToShortDateString();

            exRange.Range["C8:H8"].MergeCells = true;




            //Tạo dòng tiêu đề bảng

            exRange.Range["C10:H10"].MergeCells = true;

            exRange.Range["C11:H11"].Font.Bold = true;
            exRange.Range["C11:H11"].Borders.Color = Color.Black;
            exRange.Range["C11:H11"].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:H11"].ColumnWidth = 12;
            exRange.Range["C11:C11"].Value = "Số TT";
            exRange.Range["D11:D11"].Value = "Thứ";
            exRange.Range["D11:D11"].ColumnWidth = 20;
            exRange.Range["E11:E11"].Value = "Tiết";
            exRange.Range["E11:E11"].ColumnWidth = 30;
            exRange.Range["F11:F11"].Value = "Lớp ";
            exRange.Range["G11:G11"].Value = "Tên Môn ";

            //  exRange.Range["H11:H11"].Value = "Địa chỉ";
            int i = 1;
            int hangend = 0;
            for (hang = 0; hang < dts.Rows.Count; hang++)
            {
                exRange.Range["C" + (hang + 12).ToString() + ":C" + (hang + 12).ToString()].Value = i.ToString();
                exRange.Range["D" + (hang + 12).ToString() + ":D" + (hang + 12).ToString()].Value = dts.Rows[hang][0];
                exRange.Range["E" + (hang + 12).ToString() + ":E" + (hang + 12).ToString()].Value = dts.Rows[hang][1];
                exRange.Range["F" + (hang + 12).ToString() + ":F" + (hang + 12).ToString()].Value = dts.Rows[hang][2];
                exRange.Range["G" + (hang + 12).ToString() + ":G" + (hang + 12).ToString()].Value = dts.Rows[hang][3];
            //    exRange.Range["H" + (hang + 12).ToString() + ":H" + (hang + 12).ToString()].Value = dts.Rows[hang][4];
                exRange.Range["C" + (hang + 12).ToString() + ":H" + (hang + 12).ToString()].Borders.LineStyle = NsExcel.XlLineStyle.xlContinuous;
                i++;
                //for (cot = 0; cot < dt.Columns.Count; cot++)
                ////Điền thông tin hàng từ cột thứ 2, dòng 12
                //{
                //    exSheet.Cells[cot + 2][hang + 12] = dts.Rows[hang][cot].ToString();
                //}
                hangend = hang;
            }
            exRange.Range["C" + (hangend + 13) + ":H" + (hangend + 13)].MergeCells = true;
            //Thiết lập ô tổng tiền
            exRange.Range["C" + (hangend + 14) + ":D" + (hangend + 14)].MergeCells = true; // Gộp ô C hàng (hangend+14) với ô D hàng (hangend+14 thành một
            exRange.Range["C" + (hangend + 14) + ":D" + (hangend + 14)].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C" + (hangend + 14) + ":D" + (hangend + 14)].Value = "Tổng số tiêt : " + dts.Rows.Count; // Gán GIá TRị CHô ô Vừa Gộp
            //Thiết lập ô ký tên
            exRange.Range["C" + (hangend + 15) + ":D" + (hangend + 15)].MergeCells = true;
            exRange.Range["C" + (hangend + 15) + ":D" + (hangend + 15)].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C" + (hangend + 15) + ":D" + (hangend + 15)].Value = "Ký tên ";
            //Thiết lập ô nhân viên
            exRange.Range["C" + (hangend + 16) + ":D" + (hangend + 16)].MergeCells = true;
            exRange.Range["C" + (hangend + 16) + ":D" + (hangend + 16)].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C" + (hangend + 16) + ":D" + (hangend + 16)].Value = "Giáo Viên Chủ Nhiệm ";
            //Thiết lập ô họ tên nhân viên
            exRange.Range["C" + (hangend + 17) + ":D" + (hangend + 17)].MergeCells = true;
            exRange.Range["C" + (hangend + 17) + ":D" + (hangend + 17)].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C" + (hangend + 17) + ":D" + (hangend + 17)].Value = dt.Rows[0][2];
            //Thiết lập ô ký tên
            exRange.Range["G" + (hangend + 15) + ":H" + (hangend + 15)].MergeCells = true;
            exRange.Range["G" + (hangend + 15) + ":H" + (hangend + 15)].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["G" + (hangend + 15) + ":H" + (hangend + 15)].Value = "Ký tên ";
            //Thiết lập ô Kế toàn trưởng
            exRange.Range["G" + (hangend + 16) + ":H" + (hangend + 16)].MergeCells = true;
            exRange.Range["G" + (hangend + 16) + ":H" + (hangend + 16)].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["G" + (hangend + 16) + ":H" + (hangend + 16)].Value = "Hiệu Trưởng ";
            //Thiết lập ô họ tên kế toàn trưởng
            exRange.Range["G" + (hangend + 17) + ":H" + (hangend + 17)].MergeCells = true;
            exRange.Range["G" + (hangend + 17) + ":H" + (hangend + 17)].HorizontalAlignment = NsExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["G" + (hangend + 17) + ":H" + (hangend + 17)].Value = "Đỗ Thị Quyên";
            exSheet.Name = "Phiếu Nhập";
            exApp.Visible = true;

            // ExportToPdf((DataTable)dgvTKB.DataSource);

        }

        private void nhanTimKiem(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT gd.Thu,gd.Tietday,l.TenLop,m.TenMon FROM dbo.tblGiaovien AS g, dbo.tblLop AS l, dbo.tblMonhoc AS m,dbo.tblGiangday AS gd WHERE g.MaMon=m.MaMon AND  g.MaGV=gd.MaGV AND gd.MaLop=l.MaLop AND g.MaGV = N'" + cboMaGV.Text + "'";
            //thực thi câu truy vấn
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvTKB.DataSource = table;
        }

  /*      public void ExportToPdf(DataTable dt)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("E://sample.pdf", FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f, 4f };

            table.SetWidths(widths);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Products"));

            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {

                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[0].ToString(), font5));
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                }
            }
            document.Add(table);
            document.Close();
        }*/
    }
}
