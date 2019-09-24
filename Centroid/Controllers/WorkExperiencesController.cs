using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centroid.Models;

namespace Centroid.Controllers
{
    public class WorkExperiencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkExperiences
        public ActionResult Index(int? jobId, int? profileId)
        {
            var experiences = db.WorkExperiences.Where(e => e.PersonalInfoId == profileId);
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View(experiences.ToList());
        }

        // GET: WorkExperiences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkExperience workExperience = db.WorkExperiences.Find(id);
            if (workExperience == null)
            {
                return HttpNotFound();
            }
            return View(workExperience);
        }

        // GET: WorkExperiences/Create
        public ActionResult Create(int? jobId, int? profileId)
        {
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View();
        }

        // POST: WorkExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Employer,StartDate,EndDate,JobTitle,PersonalInfoId")] WorkExperience workExperience, int? JobId, int ProfileId)
        {
            if (ModelState.IsValid)
            {
                db.WorkExperiences.Add(workExperience);
                db.SaveChanges();
                return RedirectToAction("Index", new { jobId = JobId, profileId = ProfileId});
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.JobId = JobId;
            ViewBag.ProfileId = ProfileId;
            return View(workExperience);
        }

        // GET: WorkExperiences/Edit/5
        public ActionResult Edit(int? id, int? jobId, int? profileId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkExperience workExperience = db.WorkExperiences.Find(id);
            if (workExperience == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View(workExperience);
        }

        // POST: WorkExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Employer,StartDate,EndDate,JobTitle,PersonalInfoId")] WorkExperience workExperience, int? JobId, int? ProfileId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workExperience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { jobId = JobId, profileId = ProfileId });
            }
            ViewBag.JobId = JobId;
            ViewBag.ProfileId = ProfileId;
            return View(workExperience);
        }

        // GET: WorkExperiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkExperience workExperience = db.WorkExperiences.Find(id);
            if (workExperience == null)
            {
                return HttpNotFound();
            }
            return View(workExperience);
        }

        // POST: WorkExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? JobId, int? ProfileId)
        {
            WorkExperience workExperience = db.WorkExperiences.Find(id);
            db.WorkExperiences.Remove(workExperience);
            db.SaveChanges();
            return RedirectToAction("Index", new { jobId = JobId, profileId = ProfileId });
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
