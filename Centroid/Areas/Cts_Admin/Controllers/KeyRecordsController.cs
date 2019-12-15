using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centroid.Models;

namespace Centroid.Areas.Admin.Controllers
{
    [Authorize]
    public class KeyRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/KeyRecords
        public ActionResult Index()
        {
            return View(db.KeyRecords.ToList());
        }

        // GET: Admin/KeyRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyRecord keyRecord = db.KeyRecords.Find(id);
            if (keyRecord == null)
            {
                return HttpNotFound();
            }
            return View(keyRecord);
        }

        // GET: Admin/KeyRecords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/KeyRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecordText,RecordImage")] KeyRecord keyRecord)
        {
            if (ModelState.IsValid)
            {
                db.KeyRecords.Add(keyRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(keyRecord);
        }

        // GET: Admin/KeyRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyRecord keyRecord = db.KeyRecords.Find(id);
            if (keyRecord == null)
            {
                return HttpNotFound();
            }
            return View(keyRecord);
        }

        // POST: Admin/KeyRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecordText,RecordImage")] KeyRecord keyRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(keyRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(keyRecord);
        }

        // GET: Admin/KeyRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyRecord keyRecord = db.KeyRecords.Find(id);
            if (keyRecord == null)
            {
                return HttpNotFound();
            }
            return View(keyRecord);
        }

        // POST: Admin/KeyRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KeyRecord keyRecord = db.KeyRecords.Find(id);
            db.KeyRecords.Remove(keyRecord);
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
