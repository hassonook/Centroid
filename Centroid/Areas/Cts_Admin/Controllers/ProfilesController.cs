using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Centroid.Models;

namespace Centroid.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.PersonalInfoes.ToList());
        }

        // GET: PersonalInfoes/Details/5
        public ActionResult Details(int? id)
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
            var wrIds = db.WorkExperiences.Where(w => w.PersonalInfoId == id).ToList();
            db.WorkExperiences.RemoveRange(wrIds);
            var edIds = db.Educations.Where(w => w.PersonalInfoId == id).ToList();
            db.Educations.RemoveRange(edIds);
            var docIds = db.ProfileDocuments.Where(w => w.ProfileId == id).ToList();
            db.ProfileDocuments.RemoveRange(docIds);
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
