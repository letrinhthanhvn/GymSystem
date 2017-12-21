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
    public partial class fDangKiKoHLV : Form
    {
        DangKiTapKoHLVBUS dangKi = new DangKiTapKoHLVBUS();

        private void fDangKiKoHLV_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = dangKi.ShowDangKiTapKoHLV();
            dataGridView1.DataSource = dt;
        }

        public fDangKiKoHLV()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (this.txtMaNT.TextLength == 0)
                MessageBox.Show("Mã người tập không được bỏ trống!");

            else
                    if (this.txtMaGT.TextLength == 0)
                MessageBox.Show("Tên gói tập không được bỏ trống!");

            else
            {
                try
                {
                    dangKi.Insert(this.txtMaNT.Text, this.txtMaGT.Text, this.dateTimePicker1.Value.ToString(), this.dateTimePicker2.Value.ToString());
                    MessageBox.Show("Đã thêm tài khoản " + this.txtMaNT.Text + " thành công!");
                    fDangKiKoHLV_Load(sender, e);
                }

                catch
                {
                    MessageBox.Show("Đã tồn tại mã người tập " + this.txtMaNT.Text + ". Bạn vui lòng nhập lại!");
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
                    dangKi.Edit(this.txtMaNT.Text, this.txtMaGT.Text, this.dateTimePicker1.Text, this.dateTimePicker2.Value.ToString());
                    MessageBox.Show("Đã sửa tài khoản" + this.txtMaNT.Text + " thành công!");
                    fDangKiKoHLV_Load(sender, e);
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
                    dangKi.Delete(this.txtMaNT.Text, this.dateTimePicker1.Text);
                    MessageBox.Show("Bạn đã xóa mã người tập: " + this.txtMaNT.Text + ", ngày bắt đầu: " + this.dateTimePicker1.Value.ToString() + " thành công!");
                    fDangKiKoHLV_Load(sender, e);
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

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            this.txtMaNT.Clear();
            this.txtMaGT.Clear();
            
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
                dt = dangKi.Search(this.txtTimKiem.Text);
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại đối tượng!");
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int index;
            index = dataGridView1.CurrentRow.Index;
            txtMaNT.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtMaGT.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
        }

        private void btnHienThiAll_Click(object sender, EventArgs e)
        {
            fDangKiKoHLV_Load(sender, e);
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
