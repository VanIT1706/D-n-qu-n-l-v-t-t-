using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BLL;


namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDanhSachVatTu();
        }

        //Hàm hiển thị DanhSachVatTu
        private void HienThiDanhSachVatTu()
        {
            VatTuBLL vtBLL = new VatTuBLL();
            List<VatTu> ds = vtBLL.HienThiDanhSachVatTu();
            lsvDanhSach.Items.Clear();
            foreach (VatTu item in ds)
            {
                ListViewItem lsv = new ListViewItem(item.MaVTu);
                lsv.SubItems.Add(item.TenVTu);
                lsv.SubItems.Add(item.DvTinh);
                lsv.SubItems.Add(item.PhanTram.ToString());

                lsvDanhSach.Items.Add(lsv);
            }
        }
        //Sự kiện Click ListView
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            VatTu vt = new VatTu();
            if (lsvDanhSach.SelectedItems.Count == 0) return;
            ListViewItem lsv = lsvDanhSach.SelectedItems[0];
            txtMaVTu.Text = lsv.SubItems[0].Text;
            txtTenVTu.Text = lsv.SubItems[1].Text;
            txtdvTinh.Text = lsv.SubItems[2].Text;
            txtPhanTram.Text = lsv.SubItems[3].Text;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtMaVTu.Text = "";
            txtTenVTu.Text = "";
            txtdvTinh.Text = "";
            txtPhanTram.Text = "";
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool check = true;
            //bắt lỗi textbox MaVTu
            if (txtMaVTu.Text.Trim() == "")
            {
                errorProvider1.SetError(txtMaVTu, "Mã không được để trống");
                check = false;
            }
            //bắt lỗi textbox TenVTu
            string kituTen = txtTenVTu.Text;
            if (kituTen.Length > 50)
            {
                errorProvider1.SetError(txtTenVTu, "Tên không vượt quá 50 kí tự");
                check = false;
            }
            if (txtTenVTu.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTenVTu, "Tên không được bỏ trống");
                check = false;
            }
            //bắt lỗi textbox DvTinh
            string kituDVTinh = txtdvTinh.Text;
            if (kituDVTinh.Length > 10)
            {
                errorProvider1.SetError(txtdvTinh, "Đơn vị tính không vượt quá 10 kí tự");
                check = false;
            }
            if (txtdvTinh.Text.Trim() == "")
            {
                errorProvider1.SetError(txtdvTinh, "Đơn vị tính không được bỏ trống");
                check = false;
            }
            //Bắt lỗi textboxPhanTram
            int phantram = 0;
            if (int.TryParse(txtPhanTram.Text, out phantram) == false)
            {
                errorProvider1.SetError(txtPhanTram, "Không được nhập chữ");
                check = false;
            }
            if (txtPhanTram.Text.Trim() == "")
            {
                errorProvider1.SetError(txtPhanTram, "Không được bỏ trống");
                check = false;
            }
            else if (int.Parse(txtPhanTram.Text) > 100)
            {
                errorProvider1.SetError(txtPhanTram, "Phải nhỏ hơn 100");
                check = false;
            }
            if (check)
            {
                VatTu vt = new VatTu();
                vt.MaVTu = txtMaVTu.Text.Trim();
                vt.TenVTu = txtTenVTu.Text.Trim();
                vt.DvTinh = txtdvTinh.Text.Trim();
                vt.PhanTram = float.Parse(txtPhanTram.Text.Trim());

                VatTuBLL vtbll = new VatTuBLL();
                bool kt = vtbll.SuaVatTu(vt);
                if (kt)
                {
                    MessageBox.Show("Sửa thành công");
                    HienThiDanhSachVatTu();
                }
                else
                {                    
                    MessageBox.Show("Không thể sửa mã");
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa dữ liệu này không?", "Confirm", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                VatTu vt = new VatTu();
                vt.MaVTu = txtMaVTu.Text.Trim();

                VatTuBLL vatTuBLL = new VatTuBLL();
                bool kt = vatTuBLL.XoaVatTu(vt);
                if (kt)
                {
                    MessageBox.Show("Xóa thành công");
                    HienThiDanhSachVatTu();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool check = true;
            //bắt lỗi textboxMaVTu            
            string kituMa = txtMaVTu.Text;
            if (kituMa.Length > 4)
            {
                errorProvider1.SetError(txtMaVTu, "Mã không quá 4 kí tự");
                check = false;
            }
            if (txtMaVTu.Text.Trim() == "")
            {
                errorProvider1.SetError(txtMaVTu, "Mã không được để trống");
                check = false;
            }
            //bắt lỗi textbox TenVTu
            string kituTen = txtTenVTu.Text;
            if (kituTen.Length > 50)
            {
                errorProvider1.SetError(txtTenVTu, "Tên không vượt quá 50 kí tự");
                check = false;
            }
            if (txtTenVTu.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTenVTu, "Tên không được bỏ trống");
                check = false;
            }
            //bắt lỗi textbox Dvtinh
            string kituDVTinh = txtdvTinh.Text;
            if (kituDVTinh.Length > 10)
            {
                errorProvider1.SetError(txtdvTinh, "Đơn vị tính không vượt quá 10 kí tự");
                check = false;
            }
            if (txtdvTinh.Text.Trim() == "")
            {
                errorProvider1.SetError(txtdvTinh, "Đơn vị tính không được bỏ trống");
                check = false;
            }
            //bắt lỗi textbox PhanTram
            int phantram = 0;            
            if (int.TryParse(txtPhanTram.Text, out phantram) == false)
            {
                errorProvider1.SetError(txtPhanTram, "Không được nhập chữ");
                check = false;
            }
            else if (int.Parse(txtPhanTram.Text) > 100)
            {
                errorProvider1.SetError(txtPhanTram, "Phải nhỏ hơn 100");
                check = false;
            }
            if (txtPhanTram.Text.Trim() == "")
            {
                errorProvider1.SetError(txtPhanTram, "Phần trăm không được bỏ trống");
                check = false;
            }
            //Nếu đúng thì Thêm thành công và bắt lỗi trùng khóa chính
            try
            {
                if (check)
                {
                    VatTu vt = new VatTu();
                    vt.MaVTu = txtMaVTu.Text.Trim();
                    vt.TenVTu = txtTenVTu.Text.Trim();
                    vt.DvTinh = txtdvTinh.Text.Trim();
                    vt.PhanTram = float.Parse(txtPhanTram.Text.Trim());

                    VatTuBLL vtbll = new VatTuBLL();
                    bool kt = vtbll.ThemVatTu(vt);
                    if (kt)
                    {
                        MessageBox.Show("Thêm thành công");
                        HienThiDanhSachVatTu();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Mã bạn nhập đã tồn tại,Vui lòng nhập lại!","Thông báo",MessageBoxButtons.OK);
            }            
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc xóa không"
                , "Confirm"
                , MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
