using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSystem
{
    public partial class fTrangChu : Form
    {
        public string UserName = "";
        public string PassWord = "";
        public string Type = "";

        public fTrangChu()
        {
            InitializeComponent();
        }

        public fTrangChu(string UserName, string PassWord, string Type)
        {
            InitializeComponent();
            this.UserName = UserName;
            this.PassWord = PassWord;
            this.Type = Type;
        }

        private void btnNguoiTap_Click(object sender, EventArgs e)
        {
            fNguoiTap m = new fNguoiTap();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void btnHLV_Click(object sender, EventArgs e)
        {
            fHuanLuyenVien m = new fHuanLuyenVien();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void btnNVQL_Click(object sender, EventArgs e)
        {
            fNhanVienQL m = new fNhanVienQL();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void btnGoiTap_Click(object sender, EventArgs e)
        {
            fGoiTap m = new fGoiTap();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fDangKi m = new fDangKi();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void đĂNGXUẤTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Đăng xuất tài khoản!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void sỐLƯỢNGNGƯỜITẬPTHEOGIỚITÍNHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKeTheoGT m = new fThongKeTheoGT();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void sỐLƯỢNGNGƯỜITẬPTHEOTÊNHLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKeTenHLV m = new fThongKeTenHLV();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void dOANHTHUTHEOTHÁNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKeDoanhThu m = new fThongKeDoanhThu();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void sOLUONGNGUOITAPDANGKITHEOCACGOITAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKeNguoiTapGoiTap m = new fThongKeNguoiTapGoiTap();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void tHÔNGTINTÀIKHOẢNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Type == "1")
            {
                fTaiKhoan m = new fTaiKhoan();
                this.Hide();
                m.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy nhập tính năng này!");
            }
        }

        private void fTrangChu_Load(object sender, EventArgs e)
        {

        }

        public void đỔIMẬTKHẨUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDoiMatKhau m = new fDoiMatKhau(this.UserName, this.PassWord);
            this.Hide();
            m.ShowDialog();
            this.Show();
        }
    }
}
