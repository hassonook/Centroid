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
    public class ServiceDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        const string _ImagePath = "~/Content/images/Services";
        // GET: ServiceDetails
        public ActionResult Index()
        {
            var serviceDetails = db.ServiceDetails.Include(s => s.Service);
            return View(serviceDetails.ToList());
        }

        // GET: ServiceDetails/Create
        public ActionResult Create()
        {
            ViewBag.ServiceId = db.Services.Select(x => x.Id).FirstOrDefault();
            return View();
        }

        // POST: ServiceDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Image")] ServiceDetails serviceDetails)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png", "image/bmp" };
            serviceDetails.ServiceId = db.Services.Select(x => x.Id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (serviceDetails.Image != null)
                {
                    if (validImageTypes.Contains(Request.Files[0].ContentType))
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpPostedFileBase _file = Request.Files["Image"];
                            string _extension = Path.GetExtension(_file.FileName);
                            string _fileName = Guid.NewGuid().ToString();
                            _fileName = _fileName + _extension;
                            string _path = Path.Combine(Server.MapPath(_ImagePath), _fileName);
                            string imageUrl = Path.Combine(_ImagePath, _fileName);
                            _file.SaveAs(_path);
                            serviceDetails.Image = imageUrl;
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "Image file was corrupted because its size 0.");
                            return View(serviceDetails);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Please Upload image of type: jpeg, jpg, gif, png, bmp");
                        return View(serviceDetails);
                    }
                }
                else
                {
                    ModelState.AddModelError("Image", "Please Upload image file...");
                    return View(serviceDetails);
                }
                db.ServiceDetails.Add(serviceDetails);
                db.SaveChanges();
                return RedirectToAction("Index", "Services");
            }

            ViewBag.ServiceId = new SelectList(db.Services, "Id", "ServiceHead", serviceDetails.ServiceId);
            return View(serviceDetails);
        }

        // GET: ServiceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceDetails serviceDetails = db.ServiceDetails.Find(id);
            if (serviceDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "ServiceHead", serviceDetails.ServiceId);
            return View(serviceDetails);
        }

        // POST: ServiceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Image")] ServiceDetails serviceDetails)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png", "image/bmp" };
            if (ModelState.IsValid)
            {
                var model = db.ServiceDetails.Find(serviceDetails.Id);
                model.Description = serviceDetails.Description;
                model.ServiceId = db.Services.Select(x => x.Id).FirstOrDefault();

                if (serviceDetails.Image != null)
                {
                    if (validImageTypes.Contains(Request.Files[0].ContentType))
                    {
                        if (Request.Files[0].ContentLength > 0)
                        {
                            HttpPostedFileBase _file = Request.Files["Image"];
                            string _extension = Path.GetExtension(_file.FileName);
                            string _fileName = Guid.NewGuid().ToString();
                            _fileName = _fileName + _extension;
                            string _path = Path.Combine(Server.MapPath(_ImagePath), _fileName);
                            string imageUrl = Path.Combine(_ImagePath, _fileName);
                            _file.SaveAs(_path);
                            model.Image = imageUrl;
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "Image file was corrupted because its size 0.");
                            return View(serviceDetails);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Please Upload image of type: jpeg, jpg, gif, png, bmp");
                        return View(serviceDetails);
                    }
                }

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Services");
            }
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "ServiceHead", serviceDetails.ServiceId);
            return View(serviceDetails);
        }

        // GET: ServiceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceDetails serviceDetails = db.ServiceDetails.Find(id);
            if (serviceDetails == null)
            {
                return HttpNotFound();
            }
            return View(serviceDetails);
        }

        // POST: ServiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceDetails serviceDetails = db.ServiceDetails.Find(id);
            if (System.IO.File.Exists(serviceDetails.Image))
            {
                System.IO.File.Delete(serviceDetails.Image);
            }
            db.ServiceDetails.Remove(serviceDetails);
            db.SaveChanges();
            return RedirectToAction("Index", "Services");
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
