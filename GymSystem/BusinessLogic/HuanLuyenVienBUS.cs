using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class HuanLuyenVienBUS
    {
        Data data = new Data();

        public DataTable ShowHLV()
        {
            string sql = "SELECT * FROM dbo.HLV";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }

        public void Insert(string maHLV, string hoTen, string SDT, string ngaySinh, string gioiTinh, string maNVQL)
        {
            string query = "Insert Into dbo.HLV values('" + maHLV + "', N'" + hoTen + "' ,'" + SDT + "', '" + ngaySinh + "', N'" + gioiTinh + "', '" + maNVQL +"')";
            data.ExcuteNonquery(query);
        }

        public void Edit(string maHLV, string hoTen,  string SDT, string ngaySinh, string gioiTinh, string maNVQL)
        {
            string query = "UPDATE dbo.HLV SET HoTen = N'" + hoTen + "', SDT = '" + SDT + "', NgaySinh = '" + ngaySinh + "', GioiTinh = N'" + gioiTinh + "', MaNVQL = '" + maNVQL +"' WHERE MaHLV = '" + maHLV + "'";
            data.ExcuteNonquery(query);
        }

        public void Delete(string maHLV)
        {
            string query = "DELETE dbo.HLV WHERE MaHLV = '" + maHLV + "'";
            data.ExcuteNonquery(query);
        }

        public DataTable Search(string dkTimKiem)
        {
            string query = "SELECT * FROM dbo.HLV WHERE HoTen LIKE N'%" + dkTimKiem + "%' OR MaHLV LIKE '" + dkTimKiem + "'";
            DataTable dt = new DataTable();
            dt = data.GetTable(query);
            return dt;
        }
    }
}
