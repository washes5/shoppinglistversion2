using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingListVersion2.Models;

namespace ShoppingListVersion2.Controllers
{
    public class ShoppingListViewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingListViews
      
    

        // GET: ShoppingListViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListView shoppingListView = db.ShoppingListViews.Find(id);
            if (shoppingListView == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListView);
        }

        // GET: ShoppingListViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingListViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserId,Name,Color,CreatedUtc,ModifiedUtc")] ShoppingListView shoppingListView)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingListViews.Add(shoppingListView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingListView);
        }

        // GET: ShoppingListViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListView shoppingListView = db.ShoppingListViews.Find(id);
            if (shoppingListView == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListView);
        }

        // POST: ShoppingListViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserId,Name,Color,CreatedUtc,ModifiedUtc")] ShoppingListView shoppingListView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingListView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingListView);
        }

        // GET: ShoppingListViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListView shoppingListView = db.ShoppingListViews.Find(id);
            if (shoppingListView == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListView);
        }

        // POST: ShoppingListViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingListView shoppingListView = db.ShoppingListViews.Find(id);
            db.ShoppingListViews.Remove(shoppingListView);
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
