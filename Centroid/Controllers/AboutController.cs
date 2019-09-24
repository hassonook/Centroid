using System.Linq;
using System.Web.Mvc;
using Centroid.Models;

namespace Centroid.Controllers
{
    public class AboutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Abouts
        public ActionResult Index()
        {
            return View(db.Abouts.FirstOrDefault());
        }

    }
}
