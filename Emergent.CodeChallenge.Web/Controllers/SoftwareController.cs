using System;
using Emergent.CodeChallenge.Service;
using Microsoft.AspNetCore.Mvc;

namespace Emergent.CodeChallenge.Web.Controllers
{
    public class SoftwareController : Controller
    {
        SoftwareService _softwareService = new SoftwareService();

        public IActionResult Index(string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                version = "0";
            }
            
            var software = _softwareService.GetSoftwareGreaterThanVersion(version);
            return Json(software);
        }
    }
}
