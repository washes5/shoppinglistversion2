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
    public class NoteViewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NoteViews
        public ActionResult Index()
        {
            return View(db.NoteViews.ToList());
        }

        // GET: NoteViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteView noteView = db.NoteViews.Find(id);
            if (noteView == null)
            {
                return HttpNotFound();
            }
            return View(noteView);
        }

        // GET: NoteViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoteViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ShoppingListItemId,Body,CreatedUtc,ModifiedUtc")] NoteView noteView)
        {
            if (ModelState.IsValid)
            {
                db.NoteViews.Add(noteView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(noteView);
        }

        // GET: NoteViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteView noteView = db.NoteViews.Find(id);
            if (noteView == null)
            {
                return HttpNotFound();
            }
            return View(noteView);
        }

        // POST: NoteViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ShoppingListItemId,Body,CreatedUtc,ModifiedUtc")] NoteView noteView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noteView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(noteView);
        }

        // GET: NoteViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteView noteView = db.NoteViews.Find(id);
            if (noteView == null)
            {
                return HttpNotFound();
            }
            return View(noteView);
        }

        // POST: NoteViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NoteView noteView = db.NoteViews.Find(id);
            db.NoteViews.Remove(noteView);
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
