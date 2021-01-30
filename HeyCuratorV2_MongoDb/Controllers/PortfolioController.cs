using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Controllers
{
    
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult HeyCurator()
        {
            return View();
        }
    }
}
