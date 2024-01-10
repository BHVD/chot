using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class lop_BUS
    {
        lop_DAL phieuthu = new lop_DAL();

        public DataTable Load_BUS()
        {
            return phieuthu.Load_Lop();
        }
        public void Insert_Bus(Hang ob)
        {

            phieuthu.Insert_Lop(ob);
        }

        public void Update_Bus(Hang ob)
        {
            phieuthu.Update_Lop(ob);
        }
        public void Delete_Bus(string makh)
        {
            phieuthu.Delete_Lop(makh);
        }

    }
}
