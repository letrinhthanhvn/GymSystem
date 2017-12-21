using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class ThongKeNTTenHLVBUS
    {
        Data data = new Data();

        public DataTable ShowThongKe()
        {
            string sql = "SELECT DangKi.MaHLV ,HLV.HoTen,count(DangKi.MaHLV) SoLuong FROM DangKi,HLV WHERE DangKi.MaHLV = HLV.MaHLV GROUP BY DangKi.MaHLV, HLV.HoTen";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }
    }
}
