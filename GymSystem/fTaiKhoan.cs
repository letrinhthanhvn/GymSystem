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
    public partial class fTaiKhoan : Form
    {
        

        ThongTinTaiKhoanBUS thongTin = new ThongTinTaiKhoanBUS();

        public fTaiKhoan()
        {
            InitializeComponent();
        }

        

        private void fTaiKhoan_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = thongTin.ShowThongKe();
            dataGridView1.DataSource = dt;
        }

        private void txtMaGT_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (this.txtTenTK.TextLength == 0)
                MessageBox.Show("Mã người tập không được bỏ trống!");

            else
                    if (this.txtMatKhau.TextLength == 0)
                MessageBox.Show("Tên người tập không được bỏ trống!");

            else
            {
                try
                {
                    thongTin.Insert(this.txtTenTK.Text, this.txtMatKhau.Text, this.cbbType.Text);
                    MessageBox.Show("Đã thêm tài khoản" + this.txtTenTK.Text + " thành công!");
                    fTaiKhoan_Load(sender, e);
                }

                catch
                {
                    MessageBox.Show("Đã tồn tại mã người tập " + this.txtTenTK.Text + ". Bạn vui lòng nhập lại!");
                }

                finally
                {
                    SqlConnection kn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GymSystem;Integrated Security=True");
                    kn.Close();
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Dữ liệu khi bị sửa sẽ không khôi phục lại được! Bạn vui lòng kiểm tra kĩ trước khi sửa dữ liệu!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlr == DialogResult.Yes)
            {
                try
                {
                    thongTin.Edit(this.txtTenTK.Text, this.txtMatKhau.Text, this.cbbType.Text);
                    MessageBox.Show("Đã sửa tài khoản" + this.txtTenTK.Text + " thành công!");
                    fTaiKhoan_Load(sender, e);
                }

                catch
                {
                    MessageBox.Show("Lỗi không sửa được dữ liệu!");
                }

                finally
                {
                    SqlConnection kn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GymSystem;Integrated Security=True");
                    kn.Close();
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Dữ liệu khi bị xóa sẽ không khôi phục lại được! Bạn vui lòng kiểm tra kĩ trước khi sửa dữ liệu!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dlr == DialogResult.Yes)
            {
                try
                {
                    thongTin.Delete(this.txtTenTK.Text);
                    MessageBox.Show("Bạn đã xóa " + this.txtTenTK.Text + " thành công!");
                    fTaiKhoan_Load(sender, e);
                }

                catch
                {
                    MessageBox.Show("Lỗi không xóa được dữ liệu!");
                }

                finally
                {
                    SqlConnection kn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GymSystem;Integrated Security=True");
                    kn.Close();
                }
            }
        }
    }
}
