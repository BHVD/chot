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
            return Load_DL("select * from hang");
        }
        public void Insert_Lop(Hang ob)
        {
            string sql = "insert into hang values('" +
                ob.maHang + "','" + ob.tenHang + "','" + ob.quyCach + "','" + ob.dvTinh + "')";
            Excecute(sql);
        }
        public void Update_Lop(Hang ob)
        {
            string sql = "update hang set tenhang= '" + ob.tenHang + "', quycach = '" + ob.quyCach + "', dvtinh ='" +ob.dvTinh+"' "+
    "where mahang='" + ob.maHang + "'";
            Excecute(sql);
        }
        public void Delete_Lop(string mah)
        {
            string sql = "delete from hang where mahang='" + mah + "'";
            Excecute(sql);
        }

    }
}
