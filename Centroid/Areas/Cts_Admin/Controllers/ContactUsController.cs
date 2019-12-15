using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Centroid.Email;
using Centroid.Models;

namespace Centroid.Areas.Admin.Controllers
{
    [Authorize]
    public class ContactUsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactUs
        public ActionResult Index()
        {
            var model = db.ContactUs.FirstOrDefault();
            return PartialView(model);
        }

        // POST: ContactUs/Contact
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void SendEnquery(string name, string email, string message)
        {
            string to = "hassona@sudapet.com";
            string UserID, Password, SMTPPort, Host;
            string subject = "Website Enquery";
            string body = message + "<br />" + name + "<br />" + email;
            //Get and set the AppSettings using configuration manager.  
            EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);
            //Call send email methods.
           // EmailManager.SendEmail(email, subject, body, to, UserID, Password, SMTPPort, Host);
            string result = "success message was sent...";
            //return RedirectToLocal(result, JsonRequestBehavior.AllowGet);
        }

        // GET: ContactUs/Create
        public ActionResult Create(string url)
        {
            ViewBag.url = url;
            return View();
        }

        // POST: ContactUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address1,Address2,Phone,Fax,Email,Facebook,Twitter,LinkedIn,Active")] ContactUs contactUs, string url)
        {
            if (ModelState.IsValid)
            {
                db.ContactUs.Add(contactUs);
                db.SaveChanges();
                return Redirect(url + "#contact");
            }

            return View(contactUs);
        }

        // GET: ContactUs/Edit/5
        public ActionResult Edit(int? id, string url)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contactUs = db.ContactUs.Find(id);
            if (contactUs == null)
            {
                return HttpNotFound();
            }
            ViewBag.url = url;
            return View(contactUs);
        }

        // POST: ContactUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address1,Address2,Phone,Fax,Email,Facebook,Twitter,LinkedIn,Active")] ContactUs contactUs, string url)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactUs).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(url + "#contact");
            }
            return View(contactUs);
        }
    }
}
