using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using static WebsiteBanHang.Common;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        WebsiteBanHangOnlineEntities objWebsiteBanHangOnlineEntities = new WebsiteBanHangOnlineEntities();
        // GET: Admin/Product
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstUser = new List<User>();
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
                lstUser = objWebsiteBanHangOnlineEntities.Users.Where(n => n.FirstName.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy all sản phẩm trong bảng product
                lstUser = objWebsiteBanHangOnlineEntities.Users.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item của 1 trang = 4
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm, sp mới đưa lên đầu
            lstUser = lstUser.OrderByDescending(n => n.Id).ToList();
            return View(lstUser.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(User objUser)
        {
            this.LoadData();
            try
            {
                if (objUser.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objUser.ImageUpload.FileName);
                    string extension = Path.GetExtension(objUser.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddmmss")) + extension;
                    objUser.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    objWebsiteBanHangOnlineEntities.Users.Add(objUser);
                    objWebsiteBanHangOnlineEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
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
            var objUser = objWebsiteBanHangOnlineEntities.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objUser = objWebsiteBanHangOnlineEntities.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }

        [HttpPost]
        public ActionResult Delete(Brand objUs)
        {
            var objUser = objWebsiteBanHangOnlineEntities.Users.Where(n => n.Id == objUs.Id).FirstOrDefault();
            objWebsiteBanHangOnlineEntities.Users.Remove(objUser);
            objWebsiteBanHangOnlineEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objUser = objWebsiteBanHangOnlineEntities.Users.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }

        [HttpPost]
        public ActionResult Edit(int id, User objUser)
        {
            if (objUser.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objUser.ImageUpload.FileName);
                string extension = Path.GetExtension(objUser.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddmmss")) + extension;
                objUser.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebsiteBanHangOnlineEntities.Entry(objUser).State = EntityState.Modified;
            objWebsiteBanHangOnlineEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}