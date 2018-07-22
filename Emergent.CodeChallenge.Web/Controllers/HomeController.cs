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
            if (request?.Version != null) 
            {
                @ViewBag.Software = _softwareService.GetSoftwareGreaterThanVersion(request.Version);

                var t = _softwareService.GetSoftwareGreaterThanVersion(request.Version);
                t.Any();
            }

            return View();
        }
    }
}
