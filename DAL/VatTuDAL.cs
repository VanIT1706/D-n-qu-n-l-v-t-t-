using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public class VatTuDAL : Database
    {
        //Hàm HienThiDanhSach
        public List<VatTu> HienThiDanhSachVatTu()
        {           
            OpenConection();
            List<VatTu> ds = new List<VatTu>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from VATTU";
            cmd.Connection = sqlCon;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string maVatTu = reader.GetString(0);
                string TenVTu = reader.GetString(1); 
                string dvTinh = reader.GetString(2);
                float phanTram = reader.GetFloat(3);

                VatTu vt = new VatTu();
                vt.MaVTu = maVatTu;
                vt.TenVTu = TenVTu;
                vt.DvTinh = dvTinh;
                vt.PhanTram = phanTram;

                ds.Add(vt);

            }
            reader.Close();
            return ds;
        }

        //Hàm Thêm Vật Tư
        public bool ThemVatTu(VatTu vt)
        {
            OpenConection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into VATTU values(@ma,@ten,@dv,@phantram)";

            SqlParameter parama = new SqlParameter("@ma",SqlDbType.Char);    
            SqlParameter paraten = new SqlParameter("@ten",SqlDbType.NChar);    
            SqlParameter paradvtinh = new SqlParameter("@dv",SqlDbType.NVarChar);    
            SqlParameter paraphantram = new SqlParameter("@phantram",SqlDbType.Real); 
            
            parama.Value = vt.MaVTu;
            paraten.Value = vt.TenVTu;
            paradvtinh.Value = vt.DvTinh;
            paraphantram.Value = vt.PhanTram;

            cmd.Parameters.Add(parama);
            cmd.Parameters.Add(paraten);
            cmd.Parameters.Add(paradvtinh);
            cmd.Parameters.Add(paraphantram);

            cmd.Connection = sqlCon;

            int kt = cmd.ExecuteNonQuery();
            if(kt > 0)
            {
                return true;
            }
            return false;
        }

        //Hàm Xóa Vật Tư
        public bool XoaVatTu(VatTu vt)
        {
            OpenConection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from VATTU where MaVTu=@ma";

            SqlParameter paraMa = new SqlParameter("@ma", SqlDbType.Char);
            paraMa.Value = vt.MaVTu;
            cmd.Parameters.Add(paraMa);

            cmd.Connection= sqlCon;

            int kt = cmd.ExecuteNonQuery();
            if(kt > 0)
            {
                return true;
            }
            return false;            
        }
        //Ham Sua Vat Tu
        public bool SuaVatTu(VatTu vt)
        {
            OpenConection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update VATTU set MaVTu = @ma, TenVTu = @ten,DvTinh = @dv,PhanTram=@pt where MaVTu = @ma";
            SqlParameter parama = new SqlParameter("@ma",SqlDbType.Char);
            SqlParameter paraten = new SqlParameter("@ten", SqlDbType.NVarChar);
            SqlParameter paradvt = new SqlParameter("@dv", SqlDbType.NVarChar);
            SqlParameter parapt = new SqlParameter("@pt", SqlDbType.Real);

            parama.Value = vt.MaVTu;
            paraten.Value = vt.TenVTu;
            paradvt.Value = vt.DvTinh;
            parapt.Value = vt.PhanTram;

            cmd.Parameters.Add(parama);
            cmd.Parameters.Add(paraten);
            cmd.Parameters.Add(paradvt);
            cmd.Parameters.Add(parapt);

            cmd.Connection = sqlCon;

            int kt = cmd.ExecuteNonQuery();
            if (kt > 0)
            {
                return true;
            }
            return false;
        }
    }
}
