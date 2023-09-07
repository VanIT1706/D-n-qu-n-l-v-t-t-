using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class VatTuBLL
    {
        VatTuDAL vtDAL = new VatTuDAL();

        //Hàm nhận yêu cầu từ phía giao diện, (hiện thị danh sách vật tư)
        public List<VatTu> HienThiDanhSachVatTu()
        {
            return vtDAL.HienThiDanhSachVatTu();
        }

        //Hàm Thêm vật tư
        public bool ThemVatTu(VatTu vt)
        {
            return vtDAL.ThemVatTu(vt);
        }

        //Hàm Xóa vật tư
        public bool XoaVatTu(VatTu vt)
        {
            
            return vtDAL.XoaVatTu(vt);
        }

        //Sửa vật tư
        public bool SuaVatTu(VatTu vt)
        {
            return vtDAL.SuaVatTu(vt);
        }       
         
    }
}
