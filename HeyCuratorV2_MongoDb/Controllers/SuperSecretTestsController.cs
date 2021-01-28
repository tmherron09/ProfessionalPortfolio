using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Models;
using tmherronProfessionalSite.Services;

namespace tmherronProfessionalSite.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SuperSecretTestsController : Controller
    {
        public SuperSecretTestService _secretService;


        public SuperSecretTestsController(SuperSecretTestService secretService)
        {
            _secretService = secretService;
        }


        public IActionResult Index()
        {
            List<SuperSecretTestModel> model = _secretService.Get();

            return View(model[0]);
        }

        public IActionResult MarkdownTest()
        {
            return View();
        }

    }
}
