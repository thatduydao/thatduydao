using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    public class OrderMasterData
    {
        public int Id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Người dùng")]
        public Nullable<int> UserId { get; set; }
        [Display(Name = "Trạng thái")]
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
    }
}