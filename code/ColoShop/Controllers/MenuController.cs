using ColoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColoShop.Controllers
{
    public class MenuController : Controller
    {
        db_QLBanQuanAoEntities db = new db_QLBanQuanAoEntities();

        // GET: Menu
        public ActionResult Index()
        {
            // lấy phân loại
            var phanLoai = db.PhanLoais.ToList();
            ViewBag.phanLoai = phanLoai;


            // lấy sản phầm
            var sapPham = db.SanPhams.ToList();
            ViewBag.sanPham = sapPham;

            return View();
        }
        public ActionResult NewArrivals()
        {
            // lấy phân loại
            var phanLoai = db.PhanLoais.ToList();
            ViewBag.phanLoai = phanLoai;


            // lấy sản phầm
            var sapPham = db.SanPhams.ToList();
            ViewBag.sanPham = sapPham;
            var items = db.PhanLoais.ToList();
            return PartialView("NewArrivals",items);
        }
        [HttpGet]
        public ActionResult GetProductByCategory(string cateId)
        {

            if (string.IsNullOrEmpty(cateId) || cateId.ToLower() == "all")
            {
                var allSanPham = db.SanPhams
                    .Select(sp => new
                    {
                        MaSanPham = sp.MaSanPham,
                        TenSanPham = sp.TenSanPham,
                        DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat,
                        TrangThai = sp.TrangThai,
                        MoTaNgan = sp.MoTaNgan,
                        AnhDaiDien = sp.AnhDaiDien,
                        NoiBat = sp.NoiBat,
                        MaPhanLoaiPhu = sp.MaPhanLoaiPhu,
                        MaPhanLoai = sp.MaPhanLoai,
                        GiaNhap = sp.GiaNhap
                    })
                    .ToList();

                return Json(new { sanPham = allSanPham }, JsonRequestBehavior.AllowGet);
            }
            var sanPham = db.SanPhams
             .Where(sp => sp.MaPhanLoai == cateId)
             .ToList();

            // tạo danh sách mới chỉ lấy các thuộc tính
            // không lấy các đối tượng tham chiếu
            var _sanPham = sanPham
                .Select(sp => new SanPham
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat,
                    TrangThai = sp.TrangThai,
                    MoTaNgan = sp.MoTaNgan,
                    AnhDaiDien = sp.AnhDaiDien,
                    NoiBat = sp.NoiBat,
                    MaPhanLoaiPhu = sp.MaPhanLoaiPhu,
                    MaPhanLoai = sp.MaPhanLoai,
                    GiaNhap = sp.GiaNhap
                }).ToList();

            return Json(new { sanPham = _sanPham }, JsonRequestBehavior.AllowGet);
        }

    }
}