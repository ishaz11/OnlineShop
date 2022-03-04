using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class ProductsController : Controller
    {
        private OnlineShopDbContext db = new OnlineShopDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Products products)
        {

            string fileName1 = Path.GetFileNameWithoutExtension(products.File1.FileName);
            string extension1 = Path.GetExtension(products.File1.FileName);
            fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + extension1;
            products.Photo1 = "../Images/" + fileName1;
            fileName1 = Path.Combine(Server.MapPath("../Images/"), fileName1);

            string fileName2 = Path.GetFileNameWithoutExtension(products.File2.FileName);
            string extension2 = Path.GetExtension(products.File2.FileName);
            fileName2 = fileName2 + DateTime.Now.ToString("yymmssfff") + extension2;
            products.Photo2 = "../Images/" + fileName2;
            fileName2 = Path.Combine(Server.MapPath("../Images/"), fileName2);

            string fileName3 = Path.GetFileNameWithoutExtension(products.File3.FileName);
            string extension3 = Path.GetExtension(products.File3.FileName);
            fileName3 = fileName3 + DateTime.Now.ToString("yymmssfff") + extension3;
            products.Photo3 = "../Images/" + fileName3;
            fileName3 = Path.Combine(Server.MapPath("../Images/"), fileName3);


            if (ModelState.IsValid)
            {
                
                products.File1.SaveAs(fileName1);
                products.File2.SaveAs(fileName2);
                products.File3.SaveAs(fileName3);

                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,Description,Price,Qty,Available")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
