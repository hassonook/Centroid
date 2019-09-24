using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centroid.Models;

namespace Centroid.Controllers
{
    public class EducationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Dictionary<string, string> educationLevel = System.Configuration.ConfigurationManager.AppSettings["EducationLevel"].Split(',').ToList().ToDictionary(x => x, x => x);
        public Dictionary<string, string> CountryList = new Dictionary<string, string>();
        public EducationsController()
        {
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Values.Contains(R.EnglishName)))
                {
                    CountryList.Add(R.EnglishName, R.EnglishName);
                }
            }
            CountryList.Add("Sudan", "Sudan");
            CountryList.OrderBy(x => x.Key);
        }
        // GET: Educations
        public ActionResult Index(int? jobId, int? profileId)
        {
            var educations = db.Educations.Where(e => e.PersonalInfoId == profileId);
            if (educations.Count() == 0)
            {
                return RedirectToAction("Create", new { jobId, profileId });
            }
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View(educations.ToList());
        }

        // GET: Educations/Create
        public ActionResult Create(int? jobId, int? profileId)
        {
            ViewBag.EducationLevel = new SelectList(educationLevel, "Key", "Value");
            ViewBag.Country = new SelectList(CountryList, "Key", "Value");
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EducationalInstitution,Discipline,StartDate,EndDate,Highest,PersonalInfoId,EducationLevel,Country")] Education education, int? JobId, int ProfileId)
        {
            if (ModelState.IsValid)
            {
                db.Educations.Add(education);
                db.SaveChanges();
                return RedirectToAction("Index", "Educations", new { jobId = JobId, profileId = ProfileId});
            }
            ViewBag.EducationLevel = new SelectList(educationLevel, "Key", "Value", education.EducationLevel);
            ViewBag.Country = new SelectList(CountryList, "Key", "Value", education.Country);
            ViewBag.JobId = JobId;
            ViewBag.ProfileId = ProfileId;
            return View(education);

        }

        // GET: Educations/Edit/5
        public ActionResult Edit(int? id, int? jobId, int? profileId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            ViewBag.EducationLevel = new SelectList(educationLevel, "Key", "Value", education.EducationLevel);
            ViewBag.Country = new SelectList(CountryList, "Key", "Value", education.Country);
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EducationalInstitution,Discipline,StartDate,EndDate,Highest,PersonalInfoId,EducationLevel,Country")] Education education, int? JobId, int? ProfileId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Educations", new { jobId = JobId, profileId = ProfileId });
            }
            ViewBag.EducationLevel = new SelectList(educationLevel, "Key", "Value", education.EducationLevel);
            ViewBag.Country = new SelectList(CountryList, "Key", "Value", education.Country);
            ViewBag.JobId = JobId;
            ViewBag.ProfileId = ProfileId;
            return View(education);
        }

        // GET: Educations/Delete/5
        public ActionResult Delete(int? id, int? jobId, int? profileId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? JobId, int? ProfileId)
        {
            Education education = db.Educations.Find(id);
            db.Educations.Remove(education);
            db.SaveChanges();
            return RedirectToAction("Index", "Educations", new { jobId = JobId, profileId = ProfileId});
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
