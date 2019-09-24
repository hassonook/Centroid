using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Centroid.Email;
using Centroid.Models;

namespace Centroid.Controllers
{
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
        [ActionName("Index")]
        public ActionResult SendEnquery(string name, string email, string message)
        {
            //string to = db.ContactUs.Single().Email;
            string to = "hassona@sudapet.com";
            string UserID, Password, SMTPPort, Host;
            string subject = "Website Enquery";
            string body = message + "<br />" + name + "<br />" + email;
            //Get and set the AppSettings using configuration manager.  
            EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);
            //Call send email methods.
            // EmailManager.SendEmail(email, subject, body, to, UserID, Password, SMTPPort, Host);

            return Content("success message was sent...");
        }
    }
}
