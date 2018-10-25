using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLMP.Models
{
    public class MyPham
    {
        [Key]
        [Display(Name = "Mã mỹ phẩm")]
        public string MaMP { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập")]
        [Display(Name = "Tên mỹ phẩm")]
        [StringLength(50, ErrorMessage = "Không quá 50 ký tự")]
        public string TenMP { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập")]
        [MaxLength(50, ErrorMessage = "Không quá 50 ký tự")]
        [Display(Name = "Thương hiệu")]
        public string ThuongHieu { get; set; }
        [ForeignKey("CongDung")]
        [Display(Name = "Tên công dụng")]
        public string TenCongDung { get; set; }
        public virtual CongDung CongDung { get; set; }
    }
}