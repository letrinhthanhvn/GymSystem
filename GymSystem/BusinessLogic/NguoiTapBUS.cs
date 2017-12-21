using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class NguoiTapBUS
    {
        Data data = new Data();

        public DataTable ShowNguoiTap()
        {
            string sql = "SELECT * FROM dbo.NguoiTap";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }

        public void Insert(string maID, string hoTen, string SDT,  string ngaySinh, string gioiTinh)
        {
            string query = "Insert Into NguoiTap values('" + maID + "', N'" + hoTen + "', '" + SDT + "', '" + ngaySinh + "', N'" + gioiTinh + "')";
            data.ExcuteNonquery(query);
        }

        public void Edit(string maID, string hoTen, string SDT, string ngaySinh, string gioiTinh)
        {
            string query = "UPDATE dbo.NguoiTap SET HoTen = N'" + hoTen + "',SDT = '" + SDT + "', NgaySinh = '" + ngaySinh + "', GioiTinh = N'" + gioiTinh + "'  WHERE MaNT = '" + maID + "'";
            data.ExcuteNonquery(query);
        }

        public void Delete(string maID)
        {
            string query = "DELETE dbo.NguoiTap WHERE MaNT = '" + maID + "'";
            data.ExcuteNonquery(query);
        }

        public DataTable Search(string dkTimKiem)
        {
            string query = "SELECT * FROM dbo.NguoiTap WHERE HoTen LIKE N'%" + dkTimKiem + "%' OR MaNT LIKE '" + dkTimKiem + "' OR GioiTinh LIKE N'" + dkTimKiem + "' ";
            DataTable dt = new DataTable();
            dt = data.GetTable(query);
            return dt;
        }
    }
}
