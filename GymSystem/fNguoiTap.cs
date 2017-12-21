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
    public partial class fNguoiTap : Form
    {
        DateTime dateNow = DateTime.Now;

        NguoiTapBUS nguoitap = new NguoiTapBUS();

        private void fNguoiTap_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = nguoitap.ShowNguoiTap();
            dataGridView1.DataSource = dt;
        }

        public fNguoiTap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (this.txtMaNT.TextLength == 0)
                MessageBox.Show("Mã người tập không được bỏ trống!");

            else
                    if (this.txtHoTen.TextLength == 0)
                MessageBox.Show("Tên người tập không được bỏ trống!");
            else
                    if (this.cbbGioiTinh.Text != "Nam" && this.cbbGioiTinh.Text != "Nữ")
                MessageBox.Show("Giới tính là Nam hoặc Nữ. Bạn vui lòng kiểm tra lại thông tin giới tính!");
            else
                if (dateNow.Year - this.dateTimePicker1.Value.Year < 15)
                MessageBox.Show("Tuổi của người tập phải lớn hơn 14 tuổi. Bạn vui lòng xác nhận lại thông tin ngày sinh!");

            else
            {
                try
                {
                    nguoitap.Insert(this.txtMaNT.Text, this.txtHoTen.Text, this.txtSDT.Text, this.dateTimePicker1.Value.ToString(), this.cbbGioiTinh.Text);
                    MessageBox.Show("Đã thêm tài khoản" + this.txtMaNT.Text + " thành công!");
                    fNguoiTap_Load(sender, e);
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
                    nguoitap.Edit(this.txtMaNT.Text, this.txtHoTen.Text, this.txtSDT.Text, this.dateTimePicker1.Value.ToString(), this.cbbGioiTinh.Text);
                    MessageBox.Show("Đã sửa tài khoản" + this.txtMaNT.Text + " thành công!");
                    fNguoiTap_Load(sender, e);
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
                    nguoitap.Delete(this.txtMaNT.Text);
                    MessageBox.Show("Bạn đã xóa " + this.txtMaNT.Text + " thành công!");
                    fNguoiTap_Load(sender, e);
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

       

        private void fNguoiTap_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtMaNT.Clear();
            this.txtHoTen.Clear();
            this.txtSDT.Clear();
        }

        private void btnHienThiAll_Click(object sender, EventArgs e)
        {
            fNguoiTap_Load(sender, e);
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
                dt = nguoitap.Search(this.txtTimKiem.Text);
                dataGridView1.DataSource = dt;
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại đối tượng!");
                }
            }
        }

        int index;

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            txtMaNT.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            cbbGioiTinh.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fTrangChu m = new fTrangChu();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
