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

namespace Centroid.Controllers
{
    public class QHSEController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //Directory to save uploaded files...
        const string _QhsePath = "~/Content/images/QHSE";
        const string _IsoCertificatePath = "~/Content/images/QHSE/IsoCertificates";
        // GET: QHSEs
        public ActionResult Index()
        {
            return View(db.QHSEs.ToList());
        }


        // GET: QHSEs
        public ActionResult List()
        {
            return View(db.QHSEs.ToList());
        }

        // GET: QHSEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QHSE qHSE = db.QHSEs.Find(id);
            if (qHSE == null)
            {
                return HttpNotFound();
            }
            return View(qHSE);
        }

        // GET: QHSEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QHSEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vision,Mission,QhsePolicy,QhsePolicyAr,Hse")] QHSE qHSE, HttpPostedFileBase QhseIMS, HttpPostedFileBase[] isoCertificates)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png", "image/bmp" };
            if (ModelState.IsValid)
            {
                if (QhseIMS != null)
                {
                    if (QhseIMS.ContentType == "application/pdf")
                    {
                        if (QhseIMS.ContentLength > 0)
                        {
                            string _extension = Path.GetExtension(QhseIMS.FileName);
                            string _fileName = Guid.NewGuid().ToString();
                            _fileName = _fileName + _extension;
                            string _path = Path.Combine(Server.MapPath(_QhsePath), _fileName);
                            string _fileUrl = Path.Combine(_QhsePath, _fileName);
                            QhseIMS.SaveAs(_path);
                            qHSE.QhseIMS = _fileUrl;
                        }
                        else
                        {
                            ModelState.AddModelError("ImsFile", "file was corrupted because its size 0.");
                            return View(qHSE);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Please Upload pdf file...");
                        return View(qHSE);
                    }
                }
                else
                {
                    ModelState.AddModelError("ImsFile", "Please Upload IMS file...");
                    return View(qHSE);
                }
                if (isoCertificates.Count() != 0)
                {
                    foreach (HttpPostedFileBase file in isoCertificates)
                    {
                        if (validImageTypes.Contains(file.ContentType))
                        {
                            if (file.ContentLength > 0)
                            {
                                string _extension = Path.GetExtension(file.FileName);
                                string _fileName = Guid.NewGuid().ToString();
                                _fileName = _fileName + _extension;
                                string _path = Path.Combine(Server.MapPath(_IsoCertificatePath), _fileName);
                                file.SaveAs(_path);
                            }
                            else
                            {
                                ModelState.AddModelError("IsoCertificates", "image was corrupted because its size 0.");
                                return View(qHSE);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("IsoCertificates", "Please Upload Image file...");
                            return View(qHSE);
                        }
                    }
                    qHSE.IsoCertificates = _IsoCertificatePath;
                }
                else
                {
                    ModelState.AddModelError("IsoCertificates", "Please Upload ISO Certificates files...");
                    return View(qHSE);
                }
                db.QHSEs.Add(qHSE);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(qHSE);
        }

        // GET: QHSEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QHSE qHSE = db.QHSEs.Find(id);
            if (qHSE == null)
            {
                return HttpNotFound();
            }
            return View(qHSE);
        }

        // POST: QHSEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vision,Mission,QhsePolicy,QhsePolicyAr,Hse,QhseIMS,IsoCertificates")] QHSE qHSE, HttpPostedFileBase QhseIMS, HttpPostedFileBase[] isoCertificates)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png", "image/bmp" };
            if (ModelState.IsValid)
            {
                var model = db.QHSEs.Find(qHSE.Id);
                model.Vision = qHSE.Vision;
                model.Mission = qHSE.Mission;
                model.QhsePolicy = qHSE.QhsePolicy;
                model.QhsePolicyAr = qHSE.QhsePolicyAr;
                model.Hse = qHSE.Hse;
                if (qHSE.QhseIMS != null)
                {
                    if (QhseIMS.ContentType == "application/pdf")
                    {
                        if (QhseIMS.ContentLength > 0)
                        {
                            string _extension = Path.GetExtension(QhseIMS.FileName);
                            string _fileName = Guid.NewGuid().ToString();
                            _fileName = _fileName + _extension;
                            string _path = Path.Combine(Server.MapPath(_QhsePath), _fileName);
                            string _fileUrl = Path.Combine(_QhsePath, _fileName);
                            QhseIMS.SaveAs(_path);
                            model.QhseIMS = _fileUrl;
                        }
                        else
                        {
                            ModelState.AddModelError("ImsFile", "file was corrupted because its size 0.");
                            return View(qHSE);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Please Upload pdf file...");
                        return View(qHSE);
                    }
                }
                if (qHSE.IsoCertificates != null)
                {
                    foreach (HttpPostedFileBase file in isoCertificates)
                    {
                        if (validImageTypes.Contains(file.ContentType))
                        {
                            if (file.ContentLength > 0)
                            {
                                string _extension = Path.GetExtension(file.FileName);
                                string _fileName = Guid.NewGuid().ToString();
                                _fileName = _fileName + _extension;
                                var ServerSavePath = Path.Combine(Server.MapPath(_IsoCertificatePath), _fileName);
                                //Save file to server folder  
                                file.SaveAs(ServerSavePath);
                                //assigning file uploaded status to ViewBag for showing message to user.  
                                ViewBag.UploadStatus = isoCertificates.Count().ToString() + " files uploaded successfully.";
                            }
                            else
                            {
                                ModelState.AddModelError("file", "file was corrupted because its size 0.");
                                return View(qHSE);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "Please Upload Image file...");
                            return View(qHSE);
                        }
                    }
                    model.IsoCertificates = _IsoCertificatePath;
                }
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(qHSE);
        }

        // GET: QHSEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QHSE qHSE = db.QHSEs.Find(id);
            if (qHSE == null)
            {
                return HttpNotFound();
            }
            return View(qHSE);
        }

        // POST: QHSEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QHSE qHSE = db.QHSEs.Find(id);
            db.QHSEs.Remove(qHSE);
            db.SaveChanges();
            return RedirectToAction("List");
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
