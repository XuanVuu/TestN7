using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace QLMP.Models
{
    public class QLMyPham : DbContext
    {


        public QLMyPham() : base("QLMyPham") { }
        public DbSet<MyPham> MyPhams { get; set; }
        public DbSet<CongDung> ConngDungs { get; set; }
    }
}