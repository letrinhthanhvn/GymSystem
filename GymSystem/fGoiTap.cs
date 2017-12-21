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
    public partial class fGoiTap : Form
    {
        GoiTapBUS goitap = new GoiTapBUS();

        public fGoiTap()
        {
            InitializeComponent();
        }

        private void fGoiTap_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = goitap.ShowGoiTap();
            dataGridView1.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (this.txtMaGT.TextLength == 0)
                MessageBox.Show("Mã người tập không được bỏ trống!");

            else
                    if (this.txtGia.TextLength == 0)
                MessageBox.Show("Giá gói tập không được bỏ trống!");

            else
            {
                try
                {
                    goitap.Insert(this.txtMaGT.Text, this.txtGia.Text, this.txtChuThich.Text);
                    MessageBox.Show("Đã thêm tài khoản" + this.txtMaGT.Text + " thành công!");
                    fGoiTap_Load(sender, e);
                }

                catch
                {
                    MessageBox.Show("Đã tồn tại mã người tập " + this.txtMaGT.Text + ". Bạn vui lòng nhập lại!");
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
                    goitap.Edit(this.txtMaGT.Text, this.txtGia.Text, this.txtChuThich.Text);
                    MessageBox.Show("Bạn đã sửa gói tập " + this.txtMaGT.Text + " thành công!");
                    fGoiTap_Load(sender, e);
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
            DialogResult dlr = MessageBox.Show("Dữ liệu khi bị sửa sẽ không khôi phục lại được! Bạn vui lòng kiểm tra kĩ trước khi sửa dữ liệu!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dlr == DialogResult.Yes)
            {


                try
                {
                    goitap.Delete(this.txtMaGT.Text);
                    MessageBox.Show("Bạn đã xóa gói tập " + this.txtMaGT.Text + " thành công!");
                    fGoiTap_Load(sender, e);
                }

                catch
                {
                    MessageBox.Show("Lỗi không xoa được dữ liệu!");
                }

                finally
                {
                    SqlConnection kn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GymSystem;Integrated Security=True");
                    kn.Close();
                }
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            this.txtMaGT.Clear();
            this.txtGia.Clear();
            this.txtChuThich.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khóa tìm kiếm!");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = goitap.Search(this.txtTimKiem.Text);
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại đối tượng!");
                }
            }
        }

        private void btnHienThiAll_Click(object sender, EventArgs e)
        {
            fGoiTap_Load(sender, e);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int index;
            index = dataGridView1.CurrentRow.Index;
            txtMaGT.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtGia.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtChuThich.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fTrangChu m = new fTrangChu();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }
    }
}
