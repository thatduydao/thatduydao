using WebsiteBanHang.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static WebsiteBanHang.Common;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        WebsiteBanHangOnlineEntities objWebsiteBanHangOnlineEntities = new WebsiteBanHangOnlineEntities();
        // GET: Admin/Order
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstOrder = new List<Order>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //Lấy ds sản phẩm theo từ khóa tìm kiếm
                lstOrder = objWebsiteBanHangOnlineEntities.Orders.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy all sản phẩm trong bảng product
                lstOrder = objWebsiteBanHangOnlineEntities.Orders.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item của 1 trang = 4
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstOrder = lstOrder.OrderByDescending(n => n.Id).ToList();
            return View(lstOrder.ToPagedList(pageNumber, pageSize));
        }

        void LoadData()
        {
            Common objCommon = new Common();
            //Lấy dữ liệu danh mục dưới database
            var lstCat = objWebsiteBanHangOnlineEntities.Categories.ToList();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            //Convert sang select list dạng value, text
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            //Lấy dữ liệu danh mục dưới database
            var lstBrand = objWebsiteBanHangOnlineEntities.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            //Convert sang select list dạng value, text
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");

            //Loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            //Convert sang select list dạng value, text
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objOrder = objWebsiteBanHangOnlineEntities.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objOrder = objWebsiteBanHangOnlineEntities.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }

        [HttpPost]
        public ActionResult Delete(Order objOd)
        {
            var objOrder = objWebsiteBanHangOnlineEntities.Orders.Where(n => n.Id == objOd.Id).FirstOrDefault();
            objWebsiteBanHangOnlineEntities.Orders.Remove(objOrder);
            objWebsiteBanHangOnlineEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objOrder = objWebsiteBanHangOnlineEntities.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpPost]
        public ActionResult Edit(int id, Order objOrder)
        {
            if (objOrder.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objOrder.ImageUpload.FileName);
                string extension = Path.GetExtension(objOrder.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddmmss")) + extension;
                objOrder.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebsiteBanHangOnlineEntities.Entry(objOrder).State = EntityState.Modified;
            objWebsiteBanHangOnlineEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}