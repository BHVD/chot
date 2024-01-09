using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Connect
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-MFFBE7H\\SQL2022;Initial Catalog=qlbanhang;Integrated Security=True");
        public DataTable Load_DL(string sql)
        {
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            conn.Close();
            return dt;
        }
        public void Excecute(string sql)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
