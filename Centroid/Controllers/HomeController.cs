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
            HomeViewModels model = new HomeViewModels();
            var homeImages = db.Homes.Where(h => h.Active == true).ToList();
            var about = db.Abouts.Select(a => a.AboutUs).FirstOrDefault();
            var vision = db.Abouts.Select(a => a.Vision).FirstOrDefault();
            var keyRecords = db.KeyRecords.ToList();
            model.HomeImages = homeImages;
            model.About = about;
            model.Vision = vision;
            model.KeyRecords = keyRecords;
            return View(model);
        }
    }
}
