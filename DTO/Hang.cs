using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Hang
    {

        public string maHang;
        public string tenHang;
        public string quyCach;
        public string dvTinh;


        public Hang() { }
        public Hang(string maHang, string tenHang, string quyCach, string dvTinh)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.quyCach = quyCach;
            this.dvTinh = dvTinh;
        }   
    }
}
