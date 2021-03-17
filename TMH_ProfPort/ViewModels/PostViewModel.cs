using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMH_ProfPort.Data;
using TMH_ProfPort.Models;

namespace TMH_ProfPort.ViewModels
{
    public class PostViewModel
    {

        public Post Post { get; set; }
        public List<string> Tags { get; set; }
        public bool IsValid { get; set; }

        public PostViewModel(ApplicationDbContext context, int id)
        {
            Post = context.Posts.Where(p => p.PostId == id).FirstOrDefault();
            if(Post == null)
            {
                IsValid = false;
            }
            else
            {
                Tags = context.PostTags.Where(t => t.PostId == id).Select(t=> t.Tag).ToList();
                IsValid = true;
            }
        }

        public PostViewModel(Post post, List<string> tags)
        {
            Post = post;
            Tags = tags;
            IsValid = true;
        }


    }
}
