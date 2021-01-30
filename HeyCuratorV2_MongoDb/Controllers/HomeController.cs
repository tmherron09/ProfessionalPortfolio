using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Contracts;
using tmherronProfessionalSite.Models;
using tmherronProfessionalSite.Services;
using tmherronProfessionalSite.ViewModel;
using tmherronProfessionalSite.Utility;

namespace tmherronProfessionalSite.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostService _postService;
        private readonly IRepositoryWrapperSite _repo;

        public HomeController(ILogger<HomeController> logger, PostService postService, IRepositoryWrapperSite repo)
        {
            _logger = logger;
            _postService = postService;
            _repo = repo;
        }

        public IActionResult Index()
        {

            return View(PostUtility.ConvertToFeedBriefs(_repo));

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
