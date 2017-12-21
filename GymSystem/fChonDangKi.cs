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
    public partial class fChonDangKi : Form
    {
        public fChonDangKi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fDangKi m = new fDangKi();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fDangKiKoHLV m = new fDangKiKoHLV();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fTrangChu m = new fTrangChu();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }
    }
}
