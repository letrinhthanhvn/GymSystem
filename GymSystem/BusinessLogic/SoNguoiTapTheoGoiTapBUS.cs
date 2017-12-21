using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class SoNguoiTapTheoGoiTapBUS
    {
        Data data = new Data();

        public DataTable ShowThongKe()
        {
            string sql = "SELECT MaGT,count(*) SoNguoiTap FROM dbo.DangKi GROUP BY MaGT";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
    }
}
