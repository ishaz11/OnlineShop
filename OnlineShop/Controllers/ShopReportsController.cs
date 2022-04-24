using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class ShopReportsController : Controller
    {
        private OnlineShopDbContext db = new OnlineShopDbContext();

        // GET: ShopReports
        public ActionResult Index()
        {
            ViewBag.shopReports = db.ShopReports.Include(s => s.Products).Include(s => s.Users);
            var shopReports = db.ShopReports.Include(s => s.Products).Include(s => s.Users);
            return View(shopReports.ToList());
        }

        // GET: ShopReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopReports shopReports = db.ShopReports.Find(id);
            if (shopReports == null)
            {
                return HttpNotFound();
            }
            return View(shopReports);
        }

        // GET: ShopReports/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Fname");
            return View();
        }

        // POST: ShopReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reportID,ProductID,Quantity,isAble,Note,Date,Action,UserID")] ShopReports shopReports)
        {
            if (ModelState.IsValid)
            {
                db.ShopReports.Add(shopReports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", shopReports.ProductID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Fname", shopReports.UserID);
            return View(shopReports);
        }

        // GET: ShopReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopReports shopReports = db.ShopReports.Find(id);
            if (shopReports == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", shopReports.ProductID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Fname", shopReports.UserID);
            return View(shopReports);
        }

        // POST: ShopReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reportID,ProductID,Quantity,isAble,Note,Date,Action,UserID")] ShopReports shopReports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopReports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", shopReports.ProductID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Fname", shopReports.UserID);
            return View(shopReports);
        }

        // GET: ShopReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopReports shopReports = db.ShopReports.Find(id);
            if (shopReports == null)
            {
                return HttpNotFound();
            }
            return View(shopReports);
        }

        // POST: ShopReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShopReports shopReports = db.ShopReports.Find(id);
            db.ShopReports.Remove(shopReports);
            db.SaveChanges();
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
