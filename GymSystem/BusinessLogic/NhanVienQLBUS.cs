using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class NhanVienQLBUS
    {
        Data data = new Data();

        public DataTable ShowNhanVien()
        {
            string sql = "SELECT * FROM dbo.NvQLHlv";
            DataTable dt = new DataTable();
            dt = data.GetTable(sql);
            return dt;
        }

        public void Insert(string maNhanVien, string hoTen, string SDT, string ngaySinh, string gioiTinh)
        {
            string query = "Insert Into NvQLHlv values('" + maNhanVien + "', N'" + hoTen + "', '" + SDT + "' ,'" + ngaySinh + "', N'" + gioiTinh + "')";
            data.ExcuteNonquery(query);
        }

        public void Edit(string maNhanVien, string hoTen, string SDT, string ngaySinh, string gioiTinh)
        {
            string query = "UPDATE dbo.NvQLHlv SET HoTen = N'" + hoTen + "',SDT = '" + SDT + "',NgaySinh = '" + ngaySinh + "', GioiTinh = N'" + gioiTinh + "' WHERE MaNVQL = '" + maNhanVien + "'";
            data.ExcuteNonquery(query);
        }

        public void Delete(string maNhanVien)
        {
            string query = "DELETE dbo.NvQLHlv WHERE MaNVQL = '" + maNhanVien + "'";
            data.ExcuteNonquery(query);
        }

        public DataTable Search(string dkTimKiem)
        {
            string query = "SELECT * FROM dbo.NvQLHlv WHERE HoTen LIKE N'%" + dkTimKiem + "%' OR MaNVQL LIKE '" + dkTimKiem + "'";
            DataTable dt = new DataTable();
            dt = data.GetTable(query);
            return dt;
        }
    }
}
