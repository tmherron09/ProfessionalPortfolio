using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMH_ProfPort.Data;
using TMH_ProfPort.Models;
using TMH_ProfPort.ViewModels;

namespace TMH_ProfPort.Controllers
{
    public class PostController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.Take(10).ToList();
            List<PostViewModel> postViewModels = new List<PostViewModel>();

            foreach(var post in posts)
            {
                List<string> tags = _context.PostTags.Where(t => t.PostId == post.PostId).Select(t => t.Tag).ToList();
                postViewModels.Add(new PostViewModel(post, tags));
            }



            return View(postViewModels);
        }

        [HttpGet]
        [Route("post/{id:int}")]
        public IActionResult Post(int id)
        {

            PostViewModel post = new PostViewModel(_context, id);

            if (!post.IsValid)
            {
                return NotFound();
            }


            return View("Post", post);
        }

        [HttpGet]
        [Route("/tag/{id}")]
        public IActionResult Tag(string id)
        {

            List<PostTag> tags = _context.PostTags.Where(t => t.Tag == id).ToList();

            List<PostViewModel> posts = new List<PostViewModel>();
            foreach(var tag in tags)
            {
                Post post = _context.Posts.Where(p => p.PostId == tag.TagId).FirstOrDefault();
                List<string> postTags = _context.PostTags.Where(t => t.PostId == post.PostId).Select(t => t.Tag).ToList();
                posts.Add(new PostViewModel(post, postTags));
            }


            return View(tags);
        }


        [HttpGet]
        public IActionResult ExamplePost()
        {
            return View();
        }


    }
}
