using Microsoft.AspNetCore.Mvc;

namespace Emergent.CodeChallenge.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
