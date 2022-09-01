using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    public class UserMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng điền tên")]
        [Display(Name = "Tên")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui lòng điền họ")]
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Vui lòng điền email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn quyền")]
        [Display(Name = "Quyền")]
        public Nullable<bool> IsAdmin { get; set; }
    }
}