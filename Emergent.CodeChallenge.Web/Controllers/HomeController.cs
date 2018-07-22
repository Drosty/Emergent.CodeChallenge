using Microsoft.AspNetCore.Mvc;
using Emergent.CodeChallenge.Web.Models;
using Emergent.CodeChallenge.Service;
using System.Linq;

namespace Emergent.CodeChallenge.Web.Controllers
{
    public class HomeController : Controller
    {
        SoftwareService _softwareService = new SoftwareService();

        public IActionResult Index(VersionRequest request)
        {
            var version = "0";
            if (request?.Version != null)
            {
                version = request.Version;
            }

            @ViewBag.Software = _softwareService.GetSoftwareGreaterThanVersion(version);
            return View();
        }
    }
}
