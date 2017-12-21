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
    public partial class fNhanVienQL : Form
    {
        NhanVienQLBUS nhanVien = new NhanVienQLBUS();

        public fNhanVienQL()
        {
            InitializeComponent();
        }

        private void fNhanVienQL_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = nhanVien.ShowNhanVien();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtMaNVQL.TextLength == 0)
                MessageBox.Show("Mã người tập không được bỏ trống!");

            else
                   if (this.txtHT.TextLength == 0)
                MessageBox.Show("Tên người tập không được bỏ trống!");

            else
            {
                try
                {
                    nhanVien.Insert(this.txtMaNVQL.Text, this.txtHT.Text, this.txtSDT.Text, this.dateTimePicker1.Value.ToString(), this.cbbGioiTinh.Text);
                    MessageBox.Show("Đã thêm tài khoản" + this.txtMaNVQL.Text + " thành công!");
                    fNhanVienQL_Load( sender,  e);
                }

                catch
                {
                    MessageBox.Show("Đã tồn tại mã người tập " + this.txtMaNVQL.Text + ". Bạn vui lòng nhập lại!");
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
                    nhanVien.Delete(this.txtMaNVQL.Text);
                    MessageBox.Show("Bạn đã xóa " + this.txtMaNVQL.Text + " thành công!");
                    fNhanVienQL_Load(sender, e);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Dữ liệu khi bị sửa sẽ không khôi phục lại được! Bạn vui lòng kiểm tra kĩ trước khi sửa dữ liệu!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlr == DialogResult.Yes)
            {
                try
                {
                    nhanVien.Edit(this.txtMaNVQL.Text, this.txtHT.Text, this.txtSDT.Text, this.dateTimePicker1.Value.ToString(), this.cbbGioiTinh.Text);
                    MessageBox.Show("Đã sửa tài khoản" + this.txtMaNVQL.Text + " thành công!");
                    fNhanVienQL_Load(sender, e);
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.txtMaNVQL.Clear();
            this.txtHT.Clear();
            this.txtSDT.Clear();
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
                dt = nhanVien.Search(this.txtTimKiem.Text);
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại đối tượng!");
                }
            }
        }

        private void btnHienThiAll_Click(object sender, EventArgs e)
        {
            fNhanVienQL_Load(sender, e);
        }

       

        private void fNhanVienQL_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int index;
            index = dataGridView1.CurrentRow.Index;
            txtMaNVQL.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtHT.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            cbbGioiTinh.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fTrangChu m = new fTrangChu();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }
    }
}
