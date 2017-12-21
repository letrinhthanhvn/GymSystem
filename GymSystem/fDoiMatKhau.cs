using GymSystem.BusinessLogic;
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
    public partial class fDoiMatKhau : Form
    {
        string UserName = "";
        string PassWord = "";
        string PassWordNew = "";

        DoiMatKhauBUS doiMK = new DoiMatKhauBUS();

        public fDoiMatKhau()
        {
            InitializeComponent();
        }

        public fDoiMatKhau(string UserName, string PassWord)
        {
            InitializeComponent();
            this.UserName = UserName;
            this.PassWord = PassWord;
            
        }



        private void fDoiMatKhau_Load(object sender, EventArgs e)
        {
            this.txtTenTK.Text = UserName;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn thay đổi Mật khẩu!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlr == DialogResult.Yes)
            {                
                    if (txtMKCu.Text == PassWord && txtMKMoi.Text == txtXacNhanMK.Text)

                        try
                        {
                            doiMK.DoiMatKhau(this.txtTenTK.Text,this.txtMKCu.Text, this.txtXacNhanMK.Text);
                            MessageBox.Show("Đã cập nhật mật khẩu của tài khoản " + this.txtTenTK.Text + " thành công!");

                        }

                        catch
                        {
                            MessageBox.Show("Lỗi không sửa được mật khẩu!");
                        }

                        finally
                        {
                            SqlConnection kn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GymSystem;Integrated Security=True");
                            kn.Close();
                        }
                    else
                    {
                        MessageBox.Show("Bạn vui lòng xem lại tên tài khoản hoặc mật khẩu cũ!");
                    }

            }
            
            
        }
    }
}
