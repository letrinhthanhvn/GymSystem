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
    public partial class fDangKi : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GymSystem;Integrated Security=True");

        DangKiBUS dangKi = new DangKiBUS();

        public fDangKi()
        {
            InitializeComponent();
           // fDangKiLoad();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      /*  private void fDangKiLoad()
        {
            DataTable dt = new DataTable();
            dt = dangKi.ShowDangKi();
            dataGridView1.DataSource = dt;
        }
*/
        private void fDangKi_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = dangKi.ShowDangKi();
            dataGridView1.DataSource = dt;

            con.Open();

            cbbMaNT.Items.Clear();            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT MaNT FROM dbo.NguoiTap";
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            da1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                cbbMaNT.Items.Add(dr["MaNT"].ToString());
            }

            cbbMaGT.Items.Clear();
            SqlCommand cmd1= con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT MaGT FROM dbo.GoiTap";
            cmd1.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd1);
            da2.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                cbbMaGT.Items.Add(dr["MaGT"].ToString());
            }

            cbbMaHLV.Items.Clear();
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT MaHLV FROM dbo.HLV";
            cmd2.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cmd2);
            da3.Fill(dt3);
            foreach (DataRow dr in dt3.Rows)
            {
                cbbMaHLV.Items.Add(dr["MaHLV"].ToString());
            }



            con.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int compare = DateTime.Compare(this.dateTimePicker1.Value, this.dateTimePicker2.Value);

            if (this.cbbMaNT.Text == "")
                MessageBox.Show("Mã người tập không được bỏ trống!");

            else
                    if (this.cbbMaGT.Text == "")
                MessageBox.Show("Tên gói tập không được bỏ trống!");

            else
                if (this.cbbMaGT.Text == "PT 10 buổi" || this.cbbMaGT.Text == "PT 20 buổi" || this.cbbMaGT.Text == "PT 30 buổi")
                {
                if (this.cbbMaHLV.Text != "")
                    {
                        try
                        {
                            dangKi.Insert(this.cbbMaNT.Text, this.cbbMaGT.Text, this.cbbMaHLV.Text, this.dateTimePicker1.Value.ToString(), this.dateTimePicker2.Value.ToString());
                            MessageBox.Show("Đã thêm tài khoản " + this.cbbMaNT.Text + " thành công!");
                            fDangKi_Load(sender, e);
                    }

                        catch
                        {
                            MessageBox.Show("Đã tồn tại mã người tập " + this.cbbMaNT.Text + " hoặc chưa có thông tin của mã người tập này. Bạn vui lòng nhập lại!");
                        }

                        finally
                        {
                            SqlConnection kn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GymSystem;Integrated Security=True");
                            kn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn vui lòng nhập thông tin huấn luyện viên cá nhân!");
                    }

                }
        
        else
                if ((this.cbbMaGT.Text == "1 tháng" || this.cbbMaGT.Text == "3 tháng" || this.cbbMaGT.Text == "6 tháng" || this.cbbMaGT.Text == "1 năm") && this.cbbMaHLV.Text == "" )
                {
                    try
                    {
                        dangKi.InsertKoHLV(this.cbbMaNT.Text, this.cbbMaGT.Text, this.dateTimePicker1.Value.ToString(), this.dateTimePicker2.Value.ToString());
                        MessageBox.Show("Đã thêm tài khoản " + this.cbbMaNT.Text + " thành công!");
                        fDangKi_Load(sender, e);
                }

                    catch
                    {
                        MessageBox.Show("Đã tồn tại đăng ký của người tập có mã " + this.cbbMaNT.Text + ". Bạn vui lòng nhập lại!");
                    }

                    finally
                    {
                        SqlConnection kn = new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GymSystem;Integrated Security=True");
                        kn.Close();
                    }
                }
        else
                {
                    MessageBox.Show("Mã huấn luyện viên của bạn để trống nếu gói tập của bạn không có huấn luyện viên! Bạn vui lòng bạn nhập lại thông tin!");
                }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Dữ liệu khi bị sửa sẽ không khôi phục lại được! Bạn vui lòng kiểm tra kĩ trước khi sửa dữ liệu!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlr == DialogResult.Yes)
            {
                try
                {
                    dangKi.Edit(this.cbbMaNT.Text, this.cbbMaGT.Text, this.cbbMaHLV.Text, this.dateTimePicker1.Value.ToString(), this.dateTimePicker2.Value.ToString());
                    MessageBox.Show("Đã sửa tài khoản" + this.cbbMaNT.Text + " thành công!");
                    fDangKi_Load(sender, e);
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
                    dangKi.Delete(this.cbbMaNT.Text,this.dateTimePicker1.Value.ToString());
                    MessageBox.Show("Bạn đã xóa " + this.cbbMaNT.Text + " thành công!");
                    fDangKi_Load(sender, e);
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


        private void fDangKi_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int index;
            index = dataGridView1.CurrentRow.Index;
            cbbMaNT.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            cbbMaGT.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            cbbMaHLV.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fTrangChu m = new fTrangChu();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void btnHienThiAll_Click(object sender, EventArgs e)
        {
            fDangKi_Load(sender, e);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        /*    if (this.txtMaGT.Text == "1 tháng")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(30);
            }
            else if (this.txtMaGT.Text == "3 tháng")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(90);
            }
            else if (this.txtMaGT.Text == "6 tháng")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(180);
            }
*/        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (this.cbbMaGT.Text == "1 tháng")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(30);
            }
            else if (this.cbbMaGT.Text == "3 tháng")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(90);
            }
            else if (this.cbbMaGT.Text == "6 tháng")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(180);
            }
            else if (this.cbbMaGT.Text == "1 năm")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(360);
            }
            else if (this.cbbMaGT.Text == "PT 10 buổi")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(30);
            }
            else if (this.cbbMaGT.Text == "PT 20 buổi")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(60);
            }
            else if (this.cbbMaGT.Text == "PT 30 buổi")
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(90);
            }
        }

        //  private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        //  {

        //if (e.KeyCode == Keys.Enter)
        // {
        //     this.btnTimKiem.PerformClick();
        //}
        // }
    }
}
