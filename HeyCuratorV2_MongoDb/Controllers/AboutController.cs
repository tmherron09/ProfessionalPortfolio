﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AboutController : Controller
    {

        public IActionResult Index()
        {


            return View();
        }



    }
}
