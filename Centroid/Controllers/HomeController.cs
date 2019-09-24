using System.Data;
using System.Linq;
using System.Web.Mvc;
using Centroid.Models;

namespace Centroid.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.AboutUs = db.Abouts.Select(a => a.AboutUs).FirstOrDefault();
            ViewBag.Vision = db.Abouts.Select(a => a.Vision).FirstOrDefault();
            return View(db.Homes.Where(x=>x.Active).ToList());
        }
    }
}
