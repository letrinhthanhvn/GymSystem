using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class GoiTapBUS
    {
        Data data = new Data();

        public DataTable ShowGoiTap()
        {
            string sql = "SELECT * FROM dbo.GoiTap";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }

        public void Insert(string maGoiTap, string gia, string chuThich)
        {
            string query = "INSERT INTO GoiTap VALUES (N'" + maGoiTap + "', '" + gia + "', N'" + chuThich + "')";
            data.ExcuteNonquery(query);
        }

        public void Edit(string maGoiTap, string gia, string chuThich)
        {
            string query = "UPDATE dbo.GoiTap SET Gia = '" + gia + "', ChuThich = N'" + chuThich + "' WHERE MaGT = '" + maGoiTap + "'";
            data.ExcuteNonquery(query);
        }

        public void Delete(string maGoiTap)
        {
            string query = "DELETE dbo.GoiTap WHERE MaGT = N'" + maGoiTap + "'";
            data.ExcuteNonquery(query);
        }

        public DataTable Search(string dkTimKiem)
        {
            string query = "SELECT * FROM dbo.GoiTap WHERE MaGT LIKE N'%" + dkTimKiem + "%'  ";
            DataTable dt = new DataTable();
            dt = data.GetTable(query);
            return dt;
        }
    }
}
