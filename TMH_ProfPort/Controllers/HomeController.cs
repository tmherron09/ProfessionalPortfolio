using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TMH_ProfPort.Data;
using TMH_ProfPort.Models;
using TMH_ProfPort.ViewModels;

namespace TMH_ProfPort.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.Take(10).ToList();
            List<PostViewModel> postViewModels = new List<PostViewModel>();

            foreach (var post in posts)
            {
                List<string> tags = _context.PostTags.Where(t => t.PostId == post.PostId).Select(t => t.Tag).ToList();
                postViewModels.Add(new PostViewModel(post, tags));
            }



            return View(postViewModels);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Projects()
        {


            return View();
        } 
        
        [HttpGet]
        public IActionResult Contact()
        {


            return View();
        }
    }
}
