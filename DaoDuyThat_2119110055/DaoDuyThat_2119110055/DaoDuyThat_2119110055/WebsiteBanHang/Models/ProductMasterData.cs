using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    public class ProductMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập hình đại diện")]
        [Display(Name = "Hình đại diện")]
        public string Avatar { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập danh mục")]
        [Display(Name = "Danh mục")]
        public Nullable<int> CategoryId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả ngắn")]
        [Display(Name = "Mô tả ngắn")]
        public string ShortDes { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả đầy đủ")]
        [Display(Name = "Mô tả đầy đủ")]
        public string FullDescription { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá gốc")]
        [Display(Name = "Giá gốc")]
        public Nullable<double> Price { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá khuyến mãi")]
        [Display(Name = "Giá khuyến mãi")]
        public Nullable<double> PriceDiscount { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập loại sản phẩm!")]
        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> TypeId { get; set; }
        public string Slug { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thương hiệu!")]
        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandId { get; set; }
        public Nullable<bool> DeleteId { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
    }
}