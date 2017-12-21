using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class DangKiBUS
    {
        Data data = new Data();

        public DataTable ShowDangKi()
        {
            string sql = "SELECT * FROM dbo.DangKi";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }

        public void Insert(string maNguoiTap, string maGoiTap, string maHLV, string ngayBD, string ngayKT)
        {
            string query = "Insert Into dbo.DangKi(MaNT,MaGT,MaHLV,NgayBD,NgayKT) values('" + maNguoiTap + "', N'" + maGoiTap + "', '" + maHLV + "', '" + ngayBD + "', '" + ngayKT + "')";
            data.ExcuteNonquery(query);
        }

        public void InsertKoHLV(string maNguoiTap, string maGoiTap, string ngayBD, string ngayKT)
        {
            string query = "Insert Into dbo.DangKi(MaNT,MaGT,NgayBD,NgayKT) values('" + maNguoiTap + "', N'" + maGoiTap + "', '" + ngayBD + "', '" + ngayKT + "')";
            data.ExcuteNonquery(query);
        }

        public void Edit(string maNguoiTap, string maGoiTap, string maHLV, string ngayBD, string ngayKT)
        {
            string query = "UPDATE dbo.DangKi SET MaGT = N'" + maGoiTap + "',MaHLV = '" + maHLV + "', NgayKT = '" + ngayKT + "' WHERE MaNT = '" + maNguoiTap + "' AND NgayBD = '"+ ngayBD +"'";
            data.ExcuteNonquery(query);
        }

        public void Delete(string maNguoiTap, string ngayBD)
        {
            string query = "DELETE dbo.DangKi WHERE MaNT = '" + maNguoiTap + "' AND NgayBD = '"+ ngayBD +"'";
            data.ExcuteNonquery(query);
        }

        public DataTable Search(string dkTimKiem)
        {
            string query = "SELECT * FROM dbo.DangKi WHERE MaNT LIKE N'" + dkTimKiem + "' OR MaGT LIKE '" + dkTimKiem + "' OR MaHLV LIKE '" + dkTimKiem + "'";
            DataTable dt = new DataTable();
            dt = data.GetTable(query);
            return dt;
        }
    }
}
