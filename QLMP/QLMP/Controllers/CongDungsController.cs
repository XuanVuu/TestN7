using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLMP.Models;

namespace QLMP.Controllers
{
    public class CongDungsController : Controller
    {
        private QLMyPham db = new QLMyPham();

        // GET: CongDungs
        public async Task<ActionResult> Index()
        {
            return View(await db.ConngDungs.ToListAsync());
        }

        // GET: CongDungs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongDung congDung = await db.ConngDungs.FindAsync(id);
            if (congDung == null)
            {
                return HttpNotFound();
            }
            return View(congDung);
        }

        // GET: CongDungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CongDungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaCongDung,TenCongDung")] CongDung congDung)
        {
            if (ModelState.IsValid)
            {
                db.ConngDungs.Add(congDung);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(congDung);
        }

        // GET: CongDungs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongDung congDung = await db.ConngDungs.FindAsync(id);
            if (congDung == null)
            {
                return HttpNotFound();
            }
            return View(congDung);
        }

        // POST: CongDungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaCongDung,TenCongDung")] CongDung congDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congDung).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(congDung);
        }

        // GET: CongDungs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongDung congDung = await db.ConngDungs.FindAsync(id);
            if (congDung == null)
            {
                return HttpNotFound();
            }
            return View(congDung);
        }

        // POST: CongDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            CongDung congDung = await db.ConngDungs.FindAsync(id);
            db.ConngDungs.Remove(congDung);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
