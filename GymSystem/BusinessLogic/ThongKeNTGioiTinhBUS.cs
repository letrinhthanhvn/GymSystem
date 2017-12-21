using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class ThongKeNTGioiTinhBUS
    {
        Data data = new Data();

        public DataTable ShowThongKe()
        {
            string sql = "SELECT GioiTinh,count(GioiTinh) SoLuong FROM NguoiTap GROUP BY GioiTinh";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
    }
}
