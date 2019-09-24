using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centroid.Models;

namespace Centroid.Controllers
{
    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private Dictionary<string, string> CountryList = new Dictionary<string, string>();
        private List<string> GenderList = new List<string>();

        public ProfilesController()
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
            //CountryList.OrderBy();

            GenderList.Add("Male");
            GenderList.Add("Female");

        }
        // GET: Profile/SignUp
        public ActionResult Index(int? jobId)
        {
            if (jobId != null)
            {
                ViewBag.JobId = jobId;
            }
            return View();
        }

        // POST: Profile/SignUp
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ProfileRegisterViewModel model, int? JobId)
        {
            if (ModelState.IsValid)
            {
                var emailCheck = db.PersonalInfoes.Where(p => p.Email == model.Email);
                if (emailCheck.Count() != 0)
                {
                    ModelState.AddModelError("Email", "This email address is already registered in our system. Please use the link above to login as an existing user.");
                    ViewBag.JobId = JobId;
                    return View(model);
                }
                var personalInfo = new PersonalInfo();
                personalInfo.Email = model.Email;
                personalInfo.Password = model.Password;
                db.PersonalInfoes.Add(personalInfo);
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                db.SaveChanges();
                return RedirectToAction("Create", new { jobId = JobId, profileId = personalInfo.Id });
            }
            ViewBag.JobId = JobId;
            return View(model);
        }

        // GET: Profile/Login
        public ActionResult Login(int? jobId)
        {
            if (jobId != null)
            {
                ViewBag.JobId = jobId;
            }
            return View();
        }

        // POST: Profile/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Password")] ProfileLoginViewModel model, int? JobId)
        {
            var profileEmail = db.PersonalInfoes.Where(p => p.Email == model.Email).ToList();
            var profilePassword = profileEmail.Where(p => p.Password == model.Password).FirstOrDefault();
            if (profileEmail.Count()==0)
            {
                ModelState.AddModelError("Email", "There was no account with this Email, make sure your email is right or register as a new.");
                ViewBag.JobId = JobId;
                return View(model);
            }
            if (profilePassword == null)
            {
                ModelState.AddModelError("Password", "The password incorrect if you forgot your password please click on Forgot Password link.");
                ViewBag.JobId = JobId;
                return View(model);
            }
            return RedirectToAction("Create", new { jobId = JobId, profileId = profilePassword.Id });
        }
        // GET: Profile/Create
        public ActionResult Create(int? jobId, int? profileId)
        {
            var profile = db.PersonalInfoes.Find(profileId);
            ViewBag.Nationality = new SelectList(CountryList, "Key", "Value");
            if (profile != null)
            {
                ViewBag.Nationality = new SelectList(CountryList, "Key", "Value", profile.Nationality);
            }
            ViewBag.Gender = GenderList;
            ViewBag.JobId = jobId;
            return View(profile);
        }

        // POST: Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Email,Password,DateOfBirth,Nationality,Phone1,Phone2,Gender")] PersonalInfo personalInfo, int? JobId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Educations", new { jobId = JobId, profileId = personalInfo.Id });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.Nationality = new SelectList(CountryList, "Key", "Value");
            ViewBag.Gender = GenderList;
            ViewBag.JobId = JobId;
            return View(personalInfo);
        }

        // GET: PersonalInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInfo personalInfo = db.PersonalInfoes.Find(id);
            if (personalInfo == null)
            {
                return HttpNotFound();
            }
            return View(personalInfo);
        }

        // POST: PersonalInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Email,DateOfBirth,Nationality,Phone1,Phone2,Gender")] PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalInfo);
        }

        // GET: PersonalInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInfo personalInfo = db.PersonalInfoes.Find(id);
            if (personalInfo == null)
            {
                return HttpNotFound();
            }
            return View(personalInfo);
        }

        // POST: PersonalInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalInfo personalInfo = db.PersonalInfoes.Find(id);
            db.PersonalInfoes.Remove(personalInfo);
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
