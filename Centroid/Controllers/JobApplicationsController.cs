﻿using System;
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
    public class JobApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobApplications
        public ActionResult Index()
        {
            var jobApplications = db.JobApplications.Include(j => j.Job).Include(j => j.Profile);
            return View(jobApplications.ToList());
        }

        // GET: JobApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return HttpNotFound();
            }
            return View(jobApplication);
        }

        // GET: JobApplications/Create
        public ActionResult Create()
        {
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobTitle");
            ViewBag.ProfileId = new SelectList(db.PersonalInfoes, "Id", "FullName");
            return View();
        }

        // POST: JobApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplyDate,ProfileId,JobId")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                db.JobApplications.Add(jobApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobTitle", jobApplication.JobId);
            ViewBag.ProfileId = new SelectList(db.PersonalInfoes, "Id", "FullName", jobApplication.ProfileId);
            return View(jobApplication);
        }

        // GET: JobApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobTitle", jobApplication.JobId);
            ViewBag.ProfileId = new SelectList(db.PersonalInfoes, "Id", "FullName", jobApplication.ProfileId);
            return View(jobApplication);
        }

        // POST: JobApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApplyDate,ProfileId,JobId")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobId = new SelectList(db.Jobs, "Id", "JobTitle", jobApplication.JobId);
            ViewBag.ProfileId = new SelectList(db.PersonalInfoes, "Id", "FullName", jobApplication.ProfileId);
            return View(jobApplication);
        }

        // GET: JobApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplication jobApplication = db.JobApplications.Find(id);
            if (jobApplication == null)
            {
                return HttpNotFound();
            }
            return View(jobApplication);
        }

        // POST: JobApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobApplication jobApplication = db.JobApplications.Find(id);
            db.JobApplications.Remove(jobApplication);
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
