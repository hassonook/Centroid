using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Centroid.Models;

namespace Centroid.Controllers
{
    public class CareersController : Controller
    {
        const string _ProfileDocumetPath = "~/Content/JobApplicationDoc/";
        private ApplicationDbContext db = new ApplicationDbContext();
        IEnumerable<string> jobType = System.Configuration.ConfigurationManager.AppSettings["JobType"].Split(',');
        //GET: Careers
        public ActionResult Index()
        {
            var careers = db.Careers.Where(c => c.Active == true).FirstOrDefault();
            //CareerViewModels careerViewModel = new CareerViewModels();
            //careerViewModel.CareerText = "Some Text For Careers Index Page";
            //careerViewModel.Jobs = db.Jobs.ToList();
            //careerViewModel.CareerMenu = System.Configuration.ConfigurationManager.AppSettings["JobType"].Split(',').ToList();
            return View(careers);
        }

        //GET: Careers
        public ActionResult Job()
        {
            var jobs = db.Jobs.ToList();
            return View(jobs);
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
