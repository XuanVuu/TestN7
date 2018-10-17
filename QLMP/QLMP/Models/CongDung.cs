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
        public string MaCongDung { get; set; }
        [Required]
        public string TenCongDung { get; set; }
        public virtual ICollection<MyPham> MyPhams { get; set; }
    }
}