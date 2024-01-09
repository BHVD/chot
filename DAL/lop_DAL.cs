using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class lop_DAL:Connect
    {
        public lop_DAL() { }
        public DataTable Load_Lop()
        {
            return Load_DL("select * from phieuthu");
        }
        public void Insert_Lop(phieuthu ob)
        {
            string sql = "insert into phieuthu values('" +
    ob.sopt + "','" + ob.ngaythu + "','" + ob.makh + "','" + ob.sotien + "')";
            Excecute(sql);
        }
        public void Update_Lop(phieuthu ob)
        {
            string sql = "update phieuthu set sopt= N'" + ob.sopt + "', sotien = '" + ob.sotien + "'" +
    "where makh='" + ob.makh + "'";
            Excecute(sql);
        }
        public void Delete_Lop(string makh)
        {
            string sql = "delete from phieuthu where makh='" + makh + "'";
            Excecute(sql);
        }

    }
}
