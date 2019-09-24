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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //Directory to save uploaded files...
        const string _SlidesPath = "~/Content/images/slides";
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.AboutUs = db.Abouts.Select(a => a.AboutUs).FirstOrDefault();
            ViewBag.Vision = db.Abouts.Select(a => a.Vision).FirstOrDefault();
            return View(db.Homes.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,Description,Active")] Home home)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png", "image/bmp" };
            if (ModelState.IsValid)
            {
                if (home.Image != null)
                {
                    if (validImageTypes.Contains(Request.Files[0].ContentType))
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpPostedFileBase _file = Request.Files["Image"];
                            string _extension = Path.GetExtension(_file.FileName);
                            string _fileName = Guid.NewGuid().ToString();
                            _fileName = _fileName + _extension;
                            string _path = Path.Combine(Server.MapPath(_SlidesPath), _fileName);
                            string imageUrl = Path.Combine(_SlidesPath, _fileName);
                            _file.SaveAs(_path);
                            home.Image = imageUrl;
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "Image file was corrupted because its size 0.");
                            return View(home);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Please Upload image of type: jpeg, jpg, gif, png, bmp");
                        return View(home);
                    }
                }
                else
                {
                    ModelState.AddModelError("Image", "Please Upload image file...");
                    return View(home);
                }
                db.Homes.Add(home);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(home);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Description,Active")] Home home)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png", "image/bmp" };
            if (ModelState.IsValid)
            {
                var model = db.Homes.Find(home.Id);
                model.Name = home.Name;
                model.Description = home.Description;
                model.Active = home.Active;

                if (home.Image != null)
                {
                    if (validImageTypes.Contains(Request.Files[0].ContentType))
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpPostedFileBase _file = Request.Files["Image"];
                            string _extension = Path.GetExtension(_file.FileName);
                            string _fileName = Guid.NewGuid().ToString();
                            _fileName = _fileName + _extension;
                            string _path = Path.Combine(Server.MapPath(_SlidesPath), _fileName);
                            string imageUrl = Path.Combine(_SlidesPath, _fileName);
                            _file.SaveAs(_path);
                            model.Image = imageUrl;
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "Image file was corrupted because its size 0.");
                            return View(home);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Please Upload image of type: jpeg, jpg, gif, png, bmp");
                        return View(home);
                    }
                }

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(home);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home home = db.Homes.Find(id);
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Home home = db.Homes.Find(id);
            if (System.IO.File.Exists(home.Image))
            {
                System.IO.File.Delete(home.Image);
            }
            db.Homes.Remove(home);
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
