using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class ThongTinTaiKhoanBUS
    {
        Data data = new Data();

        public DataTable ShowThongKe()
        {
            string sql = "SELECT * FROM TaiKhoan";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }

        public void Insert(string tenTaiKhoan, string matKhau, string Type)
        {
            string query = "Insert Into TaiKhoan values('" + tenTaiKhoan + "', N'" + matKhau + "', '" + Type + "')";
            data.ExcuteNonquery(query);
        }

        public void Edit(string tenTaiKhoan, string matKhau, string Type)
        {
            string query = "UPDATE dbo.TaiKhoan SET PassWord = N'" + matKhau + "',Tyoe = '" + Type + "' WHERE UserName = '" + tenTaiKhoan + "'";
            data.ExcuteNonquery(query);
        }

        public void Delete(string tenTaiKhoan)
        {
            string query = "DELETE dbo.TaiKhoan WHERE UserName = '" + tenTaiKhoan + "'";
            data.ExcuteNonquery(query);
        }
    }
}
