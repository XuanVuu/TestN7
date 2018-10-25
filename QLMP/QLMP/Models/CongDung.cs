using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLMP.Models
{
    public class CongDung
    {
        [Key]
        [Display(Name = "Mã công dụng")]
        public string MaCongDung { get; set; }
        [Required(ErrorMessage = "Bắt buộc nhập tên")]
        [Display(Name = "Tên công dụng")]
        [MaxLength(40, ErrorMessage = "Không quá 40 ký tự")]
        public string TenCongDung { get; set; }
        public virtual ICollection<MyPham> MyPhams { get; set; }
    }
}