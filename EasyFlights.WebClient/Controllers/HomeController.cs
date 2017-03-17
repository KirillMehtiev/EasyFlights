using System.Web.Mvc;

namespace EasyFlights.WebClient.Controllers
{    
    public class HomeController : Controller
    {
        [Route("~/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}