using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Models;
using tmherronProfessionalSite.Services;
using tmherronProfessionalSite.ViewModel;

namespace tmherronProfessionalSite.Controllers
{
    
    public class FeedController : Controller
    {
        private readonly PostService _postService;

        public FeedController(PostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            List<PostModel> posts = _postService.Get();
            List<FeedBriefViewModel> briefs = new List<FeedBriefViewModel>();
            
            foreach(var post in posts)
            {
                briefs.Add(new FeedBriefViewModel(post));
            }


            //briefs.Add(new FeedBriefViewModel
            //{
            //    Id = "0",
            //    FeedType = "Post",
            //    Title = "Integrating React into an Asp.Net Core MVC App",
            //    AuthorName = "Tim Herron",
            //    Tagline = "Lessons from learning ReactJs.Net",
            //    ViewCount = 10,
            //    CommentCount = 0
            //});

            return View(briefs);
        }

        [Route("feed/{id:length(24)}")]
        public IActionResult Entry(string id)
        {
            PostModel post = _postService.Get(id);
            return View(post);
        }

    }
}
