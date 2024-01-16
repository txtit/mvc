using LuyenDe08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuyenDe08.Controllers
{
    public class BaiThiController : Controller
    {
        // GET: BaiThi
        QLBanChauCanhEntities db = new QLBanChauCanhEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderNav()
        {
            var phanloai = db.PhanLoaiPhus.ToList();
            return PartialView("Thao_Header",phanloai);
        }

        public ActionResult RenderAllProduct()
        {
            var sanpham2 = db.SanPhams.ToList();
            return PartialView("Thao_Main", sanpham2);
        }

        public ActionResult LoadProductByCatId(string catId)
        {
            List<SanPham> sanpham = db.SanPhams.Where(p=>p.MaPhanLoai == catId).ToList();
            return PartialView("Thao_Main", sanpham);
        }

        public ActionResult Create()
        {
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus, "MaPhanLoaiPhu", "TenPhanLoaiPhu");
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return Redirect("Index");
            }
            else
            {
                ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus, "MaPhanLoaiPhu", "TenPhanLoaiPhu");
                ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");
                return View();
            }
        
        }
    }
}