using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class BrandController : Controller
    {
        WebsiteBanHangOnlineEntities objWebsiteBanHangOnlineEntities = new WebsiteBanHangOnlineEntities();
        // GET: Brand
        public ActionResult Index()
        {
            var lstBrand = objWebsiteBanHangOnlineEntities.Brands.ToList();
            return View(lstBrand);
        }
        public ActionResult ProductBrand(int Id)
        {
            WebsiteBanHangOnlineEntities objwebvuEntities3 = new WebsiteBanHangOnlineEntities();
            var listProduct = objwebvuEntities3.Products.Where(n => n.BrandId == Id).ToList();
            return View(listProduct);
        }
    }
}