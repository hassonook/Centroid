using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centroid.Models;

namespace Centroid.Areas.Admin.Controllers
{
    [Authorize]
    public class CareersController : Controller
    {
        const string _ProfileDocumetPath = "~/Content/JobApplicationDoc/";
        private ApplicationDbContext db = new ApplicationDbContext();
        IEnumerable<string> jobType = System.Configuration.ConfigurationManager.AppSettings["JobType"].Split(',');
        //GET: Careers
        public ActionResult Index()
        {
            var careers = db.Careers.Where(c => c.Active == true).FirstOrDefault();
            return View(careers);
        }

        // GET: Career/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Career/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CareerMsg,Active")] Career career)
        {
            if (ModelState.IsValid)
            {
                db.Careers.Add(career);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(career);
        }

        // GET: Career/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }

        // POST: Career/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CareerMsg,Active")] Career career)
        {
            if (ModelState.IsValid)
            {
                db.Entry(career).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(career);
        }
        //GET: Job
        public ActionResult Job()
        {
            var jobs = db.Jobs.ToList();
            return View(jobs);
        }

        // GET: Careers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Careers/StartApply
        public ActionResult StartApply(int? jobId)
        {
            if (jobId != null)
            {
                ViewBag.JobId = jobId;
            }
            return View();
        }

        // POST: Careers/StartApply
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StartApply([Bind(Include = "Email")] ProfileRegisterViewModel model, int? JobId)
        {
            var profile = db.PersonalInfoes.Where(p => p.Email == model.Email).FirstOrDefault();
            if (profile == null)
            {
                return RedirectToAction("PersonalInfo", new { jobId = JobId });
            }
            return RedirectToAction("PersonalInfo", new { jobId = JobId, profileId = profile.Id });
        }


            // GET: Careers/PersonalInfo
            public ActionResult PersonalInfo(int? jobId, int? profileId)
        {
            var profile = db.PersonalInfoes.Find(profileId);
            List<string> GenderList = new List<string>();
            Dictionary<string, string> CountryList = new Dictionary<string, string>();
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
            ViewBag.Nationality = new SelectList(CountryList, "Key", "Value");
            if (profile != null)
            {
                ViewBag.Nationality = new SelectList(CountryList, "Key", "Value", profile.Nationality);
            }
            ViewBag.Gender = GenderList;
            ViewBag.JobId = jobId;
            return View(profile);
        }

        // POST: Careers/PersonalInfo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalInfo([Bind(Include = "Id,FullName,Email,DateOfBirth,Nationality,Phone1,Phone2,Gender")] PersonalInfo personalInfo, int? JobId)
        {
            if (ModelState.IsValid)
            {
                var profile = db.PersonalInfoes.Where(p => p.Email == personalInfo.Email).FirstOrDefault();
                if (profile == null)
                {
                    db.PersonalInfoes.Add(personalInfo);
                    profile.Id = personalInfo.Id;
                }
                else
                {
                    profile.FullName = personalInfo.FullName;
                    profile.Email = personalInfo.Email;
                    profile.DateOfBirth = personalInfo.DateOfBirth;
                    profile.Nationality = personalInfo.Nationality;
                    profile.Phone1 = personalInfo.Phone1;
                    profile.Phone2 = personalInfo.Phone2;
                    profile.Gender = personalInfo.Gender;
                    db.Entry(profile).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Education", new { jobId = JobId, profileId = profile.Id });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            //ViewBag.JobId = JobId;
            return RedirectToAction("PersonalInfo", new { jobId = JobId});
        }

        // GET: Careers/Education
        public ActionResult Education(int? jobId, int? profileId)
        {
            var educations = db.Educations.Where(e => e.PersonalInfoId == profileId);
            if (educations.Count() == 0)
            {
                return RedirectToAction("Create", "Educations", new { jobId , profileId });
            }
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View(educations.ToList());
        }

        // POST: Careers/Education
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Education([Bind(Include = "Id,EducationalInstitution,Discipline,StartDate,EndDate,Highest,PersonalInfoId,EducationLevel,Country")] Education education, int JobId, int ProfileId)
        {
            if (ModelState.IsValid)
            {
                db.Educations.Add(education);
                db.SaveChanges();
                return RedirectToAction("Experience", new { jobId = JobId, profileId = ProfileId });
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return RedirectToAction("Education", new { jobId = JobId, profileId = ProfileId });
            }
        }

        // GET: Careers/Experience
        public ActionResult Experience(int? jobId, int? profileId)
        {
            var experiences = db.WorkExperiences.Where(e => e.PersonalInfoId == profileId);
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View(experiences.ToList());
        }

        // POST: Careers/Experience
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Experience([Bind(Include = "Id,Employer,StartDate,EndDate,JobTitle,PersonalInfoId")] WorkExperience experience, int JobId, int ProfileId)
        {
            if (ModelState.IsValid)
            {
                db.WorkExperiences.Add(experience);
                db.SaveChanges();
                return RedirectToAction("Document", new { jobId = JobId, profileId = ProfileId });
            }
            return RedirectToAction("Experience", new { jobId = JobId, profileId = ProfileId });
        }

        // GET: Careers/Document
        public ActionResult Document(int? jobId, int? profileId)
        {
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View();
        }

        // POST: Careers/Document
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Document([Bind(Include = "Id,Name,Document,DocType,ProfileId")] ProfileDocument profileDocument, HttpPostedFileBase Document, int JobId, int ProfileId)
        {
            var validDocTypes = new string[] { "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "image/jpeg", "image/jpg" };
            if (ModelState.IsValid)
            {
                if (Document != null)
                {
                    if (validDocTypes.Contains(Request.Files[0].ContentType))
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpPostedFileBase _file = Request.Files[0];
                            string _extension = Path.GetExtension(_file.FileName);
                            string _fileName = profileDocument.ProfileId + "_" + profileDocument.DocType.ToString();
                            _fileName = _fileName + _extension;
                            string _path = Path.Combine(Server.MapPath(_ProfileDocumetPath), _fileName);
                            string _fileUrl = Path.Combine(_ProfileDocumetPath, _fileName);
                            _file.SaveAs(_path);
                            profileDocument.Document = _fileUrl;
                        }
                        else
                        {
                            ModelState.AddModelError("ImsFile", "file was corrupted because its size 0.");
                            ViewBag.JobId = JobId;
                            ViewBag.ProfileId = ProfileId;
                            return View(profileDocument);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("File", "Please Upload Image .jpg/.jpeg, .pdf or Ms Word .doc/.docx file...");
                        ViewBag.JobId = JobId;
                        ViewBag.ProfileId = ProfileId;
                        return View(profileDocument);
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload the require document...");
                    ViewBag.JobId = JobId;
                    ViewBag.ProfileId = ProfileId;
                    return View(profileDocument);
                }
                db.ProfileDocuments.Add(profileDocument);
                db.SaveChanges();
                return RedirectToAction("Apply", new { jobId = JobId, profileId = ProfileId });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return RedirectToAction("Document", new { jobId = JobId, profileId = ProfileId });
        }

        // GET: Careers/Apply
        public ActionResult Apply(int? jobId, int? profileId)
        {
            var model = db.PersonalInfoes.Find(profileId);
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View(model);
        }

        // POST: Careers/Apply
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply([Bind(Include = "Id,ApplyDate,JobId,ProfileId")] JobApplication jobApplication, int JobId, int ProfileId)
        {
            jobApplication.ApplyDate = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                jobApplication.JobId = JobId;
                jobApplication.ProfileId = ProfileId;
                db.JobApplications.Add(jobApplication);
                db.SaveChanges();
                return RedirectToAction("Complete", new { jobId = JobId, profileId = ProfileId });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return RedirectToAction("Apply", new { jobId = JobId, profileId = ProfileId });
        }

        // GET: Careers/Complete
        public ActionResult Complete(int? jobId, int? profileId)
        {
            var job = db.Jobs.Find(jobId).JobTitle;
            ViewBag.JobTitle = job;
            ViewBag.ProfileId = profileId;
            return View();
        }

    }
}
