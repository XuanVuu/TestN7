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
        public string MaMP { get; set; }
        [Required]
        [StringLength(50)]
        public string TenMP { get; set; }
        public string ThuongHieu { get; set; }
        [ForeignKey("CongDung")]
        public string TenCongDung { get; set; }
        public virtual CongDung CongDung { get; set; }
    }
}