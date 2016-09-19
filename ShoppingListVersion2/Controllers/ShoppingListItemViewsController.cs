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
    public class ShoppingListItemViewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingListItemViews
        public ActionResult Index()
        {
            return View(db.ShoppingListItemViews.ToList());
        }

        // GET: ShoppingListItemViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItemView shoppingListItemView = db.ShoppingListItemViews.Find(id);
            if (shoppingListItemView == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItemView);
        }

        // GET: ShoppingListItemViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingListItemViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ShoppingListId,Contents,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItemView shoppingListItemView)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingListItemViews.Add(shoppingListItemView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingListItemView);
        }

        // GET: ShoppingListItemViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItemView shoppingListItemView = db.ShoppingListItemViews.Find(id);
            if (shoppingListItemView == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItemView);
        }

        // POST: ShoppingListItemViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ShoppingListId,Contents,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItemView shoppingListItemView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingListItemView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingListItemView);
        }

        // GET: ShoppingListItemViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItemView shoppingListItemView = db.ShoppingListItemViews.Find(id);
            if (shoppingListItemView == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItemView);
        }

        // POST: ShoppingListItemViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingListItemView shoppingListItemView = db.ShoppingListItemViews.Find(id);
            db.ShoppingListItemViews.Remove(shoppingListItemView);
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
