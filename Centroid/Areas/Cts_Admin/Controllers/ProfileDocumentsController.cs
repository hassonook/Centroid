using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centroid.Models;

namespace Centroid.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfileDocumentsController : Controller
    {
        const string _ProfileDocumetPath = "~/Content/JobApplicationDoc/";
        private ApplicationDbContext db = new ApplicationDbContext();
        private Dictionary<string, string> docType = System.Configuration.ConfigurationManager.AppSettings["DocType"].Split(',').ToList().ToDictionary(x => x, x => x);
        private string[] validDocTypes =  { "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "image/jpeg", "image/jpg" };
        // GET: ProfileDocuments
        public ActionResult Index(int? jobId, int? profileId)
        {
            var profileDocuments = db.ProfileDocuments.Where(d => d.ProfileId == profileId);
            var resume = profileDocuments.Where(d => d.DocType == "Resume");
            if (profileDocuments.Count() == 0 || resume.Count() == 0)
            {
                return RedirectToAction("Create", new { jobId, profileId });
            }
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View(profileDocuments.ToList());
        }

        // GET: ProfileDocuments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileDocument profileDocument = db.ProfileDocuments.Find(id);
            if (profileDocument == null)
            {
                return HttpNotFound();
            }
            return View(profileDocument);
        }

        // GET: ProfileDocuments/Create
        public ActionResult Create(int? jobId, int? profileId)
        {
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            ViewBag.DocType = new SelectList(docType, "Key", "Value");
            return View();
        }

        // POST: ProfileDocuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Document,DocType,ProfileId")] ProfileDocument profileDocument, HttpPostedFileBase Document, int? JobId, int ProfileId)
        {
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
                            ViewBag.DocType = new SelectList(docType, "Key", "Value", profileDocument.DocType);
                            return View(profileDocument);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("File", "Please Upload Image .jpg/.jpeg, .pdf or Ms Word .doc/.docx file...");
                        ViewBag.JobId = JobId;
                        ViewBag.ProfileId = ProfileId;
                        ViewBag.DocType = new SelectList(docType, "Key", "Value", profileDocument.DocType);
                        return View(profileDocument);
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload the require document...");
                    ViewBag.JobId = JobId;
                    ViewBag.ProfileId = ProfileId;
                    ViewBag.DocType = new SelectList(docType, "Key", "Value", profileDocument.DocType);
                    return View(profileDocument);
                }
                db.ProfileDocuments.Add(profileDocument);
                db.SaveChanges();
                return RedirectToAction("Index", new { jobId = JobId, profileId = ProfileId });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.JobId = JobId;
            ViewBag.ProfileId = ProfileId;
            ViewBag.DocType = new SelectList(docType, "Key", "Value");
            return View(profileDocument);
        }

        // GET: ProfileDocuments/Edit/5
        public ActionResult Edit(int? id, int? jobId, int? profileId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileDocument profileDocument = db.ProfileDocuments.Find(id);
            if (profileDocument == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            ViewBag.DocType = new SelectList(docType, "Key", "Value", profileDocument.DocType);
            return View(profileDocument);
        }

        // POST: ProfileDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Document,DocType,ProfileId")] ProfileDocument profileDocument, HttpPostedFileBase Document, int JobId, int ProfileId)
        {
            if (ModelState.IsValid)
            {
                var model = db.ProfileDocuments.Find(profileDocument.Id);
                model.Name = profileDocument.Name;
                model.DocType = profileDocument.DocType;
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
                            ViewBag.DocType = new SelectList(docType, "Key", "Value", profileDocument.DocType);
                            return View(profileDocument);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("File", "Please Upload Image .jpg/.jpeg, .pdf or Ms Word .doc/.docx file...");
                        ViewBag.JobId = JobId;
                        ViewBag.ProfileId = ProfileId;
                        ViewBag.DocType = new SelectList(docType, "Key", "Value", profileDocument.DocType);
                        return View(profileDocument);
                    }
                }
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { jobId = JobId, profileId = ProfileId });
            }
            ViewBag.JobId = JobId;
            ViewBag.ProfileId = ProfileId;
            ViewBag.DocType = new SelectList(docType, "Key", "Value", profileDocument.DocType);
            return View(profileDocument);
        }

        // GET: ProfileDocuments/Delete/5
        public ActionResult Delete(int? id, int? jobId, int? profileId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileDocument profileDocument = db.ProfileDocuments.Find(id);
            if (profileDocument == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobId = jobId;
            ViewBag.ProfileId = profileId;
            return View(profileDocument);
        }

        // POST: ProfileDocuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int JobId, int ProfileId)
        {
            ProfileDocument profileDocument = db.ProfileDocuments.Find(id);
            db.ProfileDocuments.Remove(profileDocument);
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
