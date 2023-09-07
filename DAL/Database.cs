using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Database
    {
        string strCon = @"Data Source=DESKTOP-6C6VA39\SQLEXPRESS01;Initial Catalog=Quanlybanhang;Integrated Security=True";
        protected SqlConnection sqlCon = null;

        //Hàm mở kết nối
        public void OpenConection()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        //Hàm đóng kết nối
        public void CloseConection()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
    }
}
