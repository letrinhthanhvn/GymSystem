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

namespace GymSystem
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        

        private void fDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection connectionSTR = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GymSystem;Integrated Security=True");
            try
            {
                connectionSTR.Open();
                string UserName = txtTK.Text;
                string PassWord = txtMK.Text;

                string query = "SELECT * FROM dbo.TaiKhoan WHERE UserName = '" + UserName + "'AND PassWord = '" + PassWord + "'";
                SqlCommand cmd = new SqlCommand(query, connectionSTR);
                DataTable dt = new DataTable(); // tao 1 kho ao de luu tru du lieu

                SqlDataAdapter adapter = new SqlDataAdapter(cmd); // chuyen du lieu ve

                adapter.Fill(dt); // do du lieu vao kho
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    fTrangChu f = new fTrangChu(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                    // fMain f = new fMain();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }

                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu! Vui lòng nhập lại!");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối!");
            }
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
