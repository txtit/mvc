using ColoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColoShop.Controllers
{
    public class ProductController : Controller
    {
        db_QLBanQuanAoEntities db = new db_QLBanQuanAoEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialSPTheoDanhMuc(string maphanloai)
        {
            var items = db.SanPhams.Where(x => x.MaPhanLoai == maphanloai).ToList();
            return PartialView( items);
        }

    }
}