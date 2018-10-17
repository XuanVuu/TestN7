
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLMP.Models;
using System.Data.Entity;
using System.Net;

namespace QLMP.Controllers
{
    public class MyPhamsController : Controller
    {
        // GET: MyPhams
        private QLMyPham db = new QLMyPham();

       
        public ActionResult Index()
        {
            var myphams = db.MyPhams.Include(s => s.CongDung);

            return View(myphams.ToList());
        }
        // Details
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           MyPham mp = db.MyPhams.Find(id);
            if (mp == null)
            {
                return HttpNotFound();
            }
            return View(mp);
        }


    }
}