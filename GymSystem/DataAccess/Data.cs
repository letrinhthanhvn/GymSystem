using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.DataAccess
{
    public class Data
    {
        public SqlConnection getConnect()
        {
            return new SqlConnection(@"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=GymSystem;Integrated Security=True");
        }

        // lệnh SQL trả về 1 bảng

        public DataTable GetTable(string sql)
        {
            SqlConnection connect = getConnect();
            SqlDataAdapter ad = new SqlDataAdapter(sql, connect);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        // lệnh SQL không trả về

        public void ExcuteNonquery(string sql)
        {
            SqlConnection connect = getConnect();
            connect.Open();
            SqlCommand cmd = new SqlCommand(sql, connect);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connect.Close();
        }
    }
}
