using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class ThongKeDoanhThuTheoThangBUS
    {
        Data data = new Data();

        public DataTable ShowThongKe()
        {
            string sql = "SELECT MONTH(NgayBD) AS THANG,SUM(GoiTap.Gia) DOANH_THU FROM dbo.DangKi,dbo.GoiTap WHERE DangKi.MaGT = GoiTap.MaGT GROUP BY MONTH(DangKi.NgayBD)";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
    }
}
