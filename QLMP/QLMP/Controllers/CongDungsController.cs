using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLMP.Models;
namespace QLMP.Controllers
{
    public class CongDungsController : Controller
    {

        // GET: CongDungs
        private QLMyPham db = new QLMyPham();

        public ActionResult Index()
        {
            return View(db.ConngDungs.ToList());
        }
        // Detail
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongDung cd = db.ConngDungs.Find(id);
            if (cd == null)
            {
                return HttpNotFound();
            }
            return View(cd);
        }

    }
}