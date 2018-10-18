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
    public class MyPhamsController : Controller
    {
        private QLMyPham db = new QLMyPham();

        // GET: MyPhams
        public async Task<ActionResult> Index()
        {
            var myPhams = db.MyPhams.Include(m => m.CongDung);
            return View(await myPhams.ToListAsync());
        }

        // GET: MyPhams/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyPham myPham = await db.MyPhams.FindAsync(id);
            if (myPham == null)
            {
                return HttpNotFound();
            }
            return View(myPham);
        }

        // GET: MyPhams/Create
        public ActionResult Create()
        {
            ViewBag.TenCongDung = new SelectList(db.ConngDungs, "MaCongDung", "TenCongDung");
            return View();
        }

        // POST: MyPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaMP,TenMP,ThuongHieu,TenCongDung")] MyPham myPham)
        {
            if (ModelState.IsValid)
            {
                db.MyPhams.Add(myPham);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TenCongDung = new SelectList(db.ConngDungs, "MaCongDung", "TenCongDung", myPham.TenCongDung);
            return View(myPham);
        }

        // GET: MyPhams/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyPham myPham = await db.MyPhams.FindAsync(id);
            if (myPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.TenCongDung = new SelectList(db.ConngDungs, "MaCongDung", "TenCongDung", myPham.TenCongDung);
            return View(myPham);
        }

        // POST: MyPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaMP,TenMP,ThuongHieu,TenCongDung")] MyPham myPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myPham).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TenCongDung = new SelectList(db.ConngDungs, "MaCongDung", "TenCongDung", myPham.TenCongDung);
            return View(myPham);
        }

        // GET: MyPhams/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyPham myPham = await db.MyPhams.FindAsync(id);
            if (myPham == null)
            {
                return HttpNotFound();
            }
            return View(myPham);
        }

        // POST: MyPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            MyPham myPham = await db.MyPhams.FindAsync(id);
            db.MyPhams.Remove(myPham);
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
