using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasterPage_Ex.Models;

namespace MasterPage_Ex.Controllers
{
    public class CRUDController : Controller
    {
        private ProductDatabaseEntities db = new ProductDatabaseEntities();

        // GET: /CRUD/
        public ActionResult Index()
        {
            return View(db.ProductTables.ToList());
        }

        // GET: /CRUD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable producttable = db.ProductTables.Find(id);
            if (producttable == null)
            {
                return HttpNotFound();
            }
            return View(producttable);
        }

        // GET: /CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CRUD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProductId,ProductName,Price,Brand,Type,Details,ImageData")] ProductTable producttable)
        {
            if (ModelState.IsValid)
            {
                db.ProductTables.Add(producttable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producttable);
        }

        // GET: /CRUD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable producttable = db.ProductTables.Find(id);
            if (producttable == null)
            {
                return HttpNotFound();
            }
            return View(producttable);
        }

        // POST: /CRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProductId,ProductName,Price,Brand,Type,Details,ImageData")] ProductTable producttable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producttable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producttable);
        }

        // GET: /CRUD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable producttable = db.ProductTables.Find(id);
            if (producttable == null)
            {
                return HttpNotFound();
            }
            return View(producttable);
        }

        // POST: /CRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductTable producttable = db.ProductTables.Find(id);
            db.ProductTables.Remove(producttable);
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
