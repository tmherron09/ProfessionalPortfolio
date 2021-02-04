using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class HeyCuratorController : Controller
    {
        [Route("~/HeyCurator")]
        [Route("~/HeyCurator/Home")]
        [Route("~/HeyCurator/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
