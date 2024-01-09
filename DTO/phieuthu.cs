using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class phieuthu
    {
        public string sopt { get; set; }
        public string ngaythu { get; set; }
        public string makh { get; set; }
        public string sotien { get; set; }

        public phieuthu()
        {

        }
        public phieuthu(string sopt, string ngaythu, string amkh, string sotien)
        {
            this.sopt = sopt;
            this.ngaythu = ngaythu;
            this.makh = makh;
            this.sotien = sotien;

        }
    }
}