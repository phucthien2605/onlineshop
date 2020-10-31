using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopFinal.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Vui lòng nhập Tên Đăng Nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Mật Khẩu")]
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}