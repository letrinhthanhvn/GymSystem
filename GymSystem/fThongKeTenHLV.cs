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
    public partial class fThongKeTenHLV : Form
    {
        ThongKeNTTenHLVBUS thongKe = new ThongKeNTTenHLVBUS();

        public fThongKeTenHLV()
        {
            InitializeComponent();
        }

        private void fThongKeTenHLV_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = thongKe.ShowThongKe();
            dataGridView1.DataSource = dt;
        }
    }
}
