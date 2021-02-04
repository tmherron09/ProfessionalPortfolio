using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Controllers
{
    [Authorize]
    [Route("HeyCurator/[controller]/[action]")]
    public class ItemsController : Controller
    {

        [Route("~/HeyCurator/Items")]
        [Route("~/HeyCurator/Items/Index")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listings()
        {
            return View();
        }
    }
}
