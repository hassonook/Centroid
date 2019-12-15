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
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        const string _projectImage = "~/Content/images/Projects";
        // GET: Projects
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectTitle,StartDate,EndDate,Client,ClientLogo,Image,Description")] Project project)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png", "image/bmp" };
            if (ModelState.IsValid)
            {
                if (project.Image != null)
                {
                    if (validImageTypes.Contains(Request.Files[0].ContentType))
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpPostedFileBase _file = Request.Files["Image"];
                            string _extension = Path.GetExtension(_file.FileName);
                            string _fileName = Guid.NewGuid().ToString();
                            _fileName = _fileName + _extension;
                            string _path = Path.Combine(Server.MapPath(_projectImage), _fileName);
                            string imageUrl = Path.Combine(_projectImage, _fileName);
                            _file.SaveAs(_path);
                            project.Image = imageUrl;
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "Image file was corrupted because its size 0.");
                            return View(project);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Please Upload image of type: jpeg, jpg, gif, png, bmp");
                        return View(project);
                    }
                }
                else
                {
                    ModelState.AddModelError("Image", "Please Upload image file...");
                    return View(project);
                }
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectTitle,StartDate,EndDate,Client,ClientLogo,Image,Description")] Project project)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png", "image/bmp" };
            if (ModelState.IsValid)
            {
                var model = db.Projects.Find(project.Id);
                model.ProjectTitle = project.ProjectTitle;
                model.StartDate = project.StartDate;
                model.EndDate = project.EndDate;
                model.Client = project.Client;
                model.Description = project.Description;

                if (project.ClientLogo != null)
                {
                    if (validImageTypes.Contains(Request.Files[0].ContentType))
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpPostedFileBase _file = Request.Files[0];
                            string _extension = Path.GetExtension(_file.FileName);
                            string _fileName = Guid.NewGuid().ToString();
                            _fileName = _fileName + _extension;
                            string _path = Path.Combine(Server.MapPath(_projectImage), _fileName);
                            string imageUrl = Path.Combine(_projectImage, _fileName);
                            _file.SaveAs(_path);
                            model.ClientLogo = imageUrl;
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "Image file was corrupted because its size 0.");
                            return View(project);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Please Upload image of type: jpeg, jpg, gif, png, bmp");
                        return View(project);
                    }
                }

                if (project.Image != null)
                {
                    if (validImageTypes.Contains(Request.Files[1].ContentType))
                    {
                        if (Request.Files[1].ContentLength > 0)
                        {
                            HttpPostedFileBase _file = Request.Files[1];
                            string _extension = Path.GetExtension(_file.FileName);
                            string _fileName = Guid.NewGuid().ToString();
                            _fileName = _fileName + _extension;
                            string _path = Path.Combine(Server.MapPath(_projectImage), _fileName);
                            string imageUrl = Path.Combine(_projectImage, _fileName);
                            _file.SaveAs(_path);
                            model.Image = imageUrl;
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "Image file was corrupted because its size 0.");
                            return View(project);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Please Upload image of type: jpeg, jpg, gif, png, bmp");
                        return View(project);
                    }
                }
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            if (System.IO.File.Exists(project.ClientLogo))
            {
                System.IO.File.Delete(project.ClientLogo);
            }
            if (System.IO.File.Exists(project.Image))
            {
                System.IO.File.Delete(project.Image);
            }
            db.Projects.Remove(project);
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
