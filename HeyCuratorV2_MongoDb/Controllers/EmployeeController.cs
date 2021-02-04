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
    public class EmployeeController : Controller
    {
        [Route("~/HeyCurator/Employee")]
        [Route("~/HeyCurator/Employee/Index")]
        public IActionResult Index()
        {


            return View();
        }
    }
}
