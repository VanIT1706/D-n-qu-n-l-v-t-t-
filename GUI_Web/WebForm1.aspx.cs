using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;

namespace GUI_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HienThiDanhSachVatTu();
        }

        private void HienThiDanhSachVatTu()
        {
            VatTuBLL vtBLL = new VatTuBLL();
            GridView1.DataSource = vtBLL.HienThiDanhSachVatTu();
            GridView1.DataBind();
        }
    }
}