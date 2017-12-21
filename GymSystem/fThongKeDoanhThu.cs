using GymSystem.BusinessLogic;
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
    public partial class fThongKeDoanhThu : Form
    {
        ThongKeDoanhThuTheoThangBUS thongKe = new ThongKeDoanhThuTheoThangBUS();

        public fThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void fThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = thongKe.ShowThongKe();
            dataGridView1.DataSource = dt;
        }
    }
}
