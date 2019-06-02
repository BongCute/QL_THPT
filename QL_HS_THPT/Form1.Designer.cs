namespace QL_HS_THPT
{
    partial class formLoGin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ck_HienThiMatKhau = new System.Windows.Forms.CheckBox();
            this.Ck_NhoMatKhau = new System.Windows.Forms.CheckBox();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtMk = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tài Khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật Khẩu";
            // 
            // ck_HienThiMatKhau
            // 
            this.ck_HienThiMatKhau.AutoSize = true;
            this.ck_HienThiMatKhau.Location = new System.Drawing.Point(212, 196);
            this.ck_HienThiMatKhau.Name = "ck_HienThiMatKhau";
            this.ck_HienThiMatKhau.Size = new System.Drawing.Size(109, 17);
            this.ck_HienThiMatKhau.TabIndex = 3;
            this.ck_HienThiMatKhau.Text = "Hiển thị mật khẩu";
            this.ck_HienThiMatKhau.UseVisualStyleBackColor = true;
            this.ck_HienThiMatKhau.CheckedChanged += new System.EventHandler(this.ck_HienThiMatKhau_CheckedChanged);
            // 
            // Ck_NhoMatKhau
            // 
            this.Ck_NhoMatKhau.AutoSize = true;
            this.Ck_NhoMatKhau.Location = new System.Drawing.Point(49, 196);
            this.Ck_NhoMatKhau.Name = "Ck_NhoMatKhau";
            this.Ck_NhoMatKhau.Size = new System.Drawing.Size(93, 17);
            this.Ck_NhoMatKhau.TabIndex = 4;
            this.Ck_NhoMatKhau.Text = "Nhớ mật khẩu";
            this.Ck_NhoMatKhau.UseVisualStyleBackColor = true;
            this.Ck_NhoMatKhau.CheckedChanged += new System.EventHandler(this.Ck_NhoMatKhau_CheckedChanged);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_DangNhap.Location = new System.Drawing.Point(49, 245);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(75, 23);
            this.btn_DangNhap.TabIndex = 5;
            this.btn_DangNhap.Text = "Đăng Nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = false;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.BackColor = System.Drawing.Color.Red;
            this.btn_Thoat.Location = new System.Drawing.Point(212, 245);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_Thoat.TabIndex = 6;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = false;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(140, 105);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(128, 20);
            this.txtTaiKhoan.TabIndex = 7;
            this.txtTaiKhoan.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtMk
            // 
            this.txtMk.Location = new System.Drawing.Point(140, 145);
            this.txtMk.Name = "txtMk";
            this.txtMk.Size = new System.Drawing.Size(128, 20);
            this.txtMk.TabIndex = 8;
            this.txtMk.UseSystemPasswordChar = true;
            // 
            // formLoGin
            // 
            this.AcceptButton = this.btn_DangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(343, 321);
            this.Controls.Add(this.txtMk);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.Ck_NhoMatKhau);
            this.Controls.Add(this.ck_HienThiMatKhau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "formLoGin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.formLoGin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ck_HienThiMatKhau;
        private System.Windows.Forms.CheckBox Ck_NhoMatKhau;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtMk;
    }
}

