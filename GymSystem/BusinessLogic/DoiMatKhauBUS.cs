using GymSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.BusinessLogic
{
    public class DoiMatKhauBUS
    {
        Data data = new Data();

        public void DoiMatKhau(string UserName,string PassWord, string PassWordNew)
        {
            string query = "UPDATE dbo.TaiKhoan SET PassWord = N'" + PassWordNew + "'  WHERE UserName = '" + UserName + "'";
            data.ExcuteNonquery(query);
        }
    }
}
