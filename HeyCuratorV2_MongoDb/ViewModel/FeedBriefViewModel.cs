using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Models;

namespace tmherronProfessionalSite.ViewModel
{
    public class FeedBriefViewModel
    {
        public FeedBriefViewModel()
        {

        }
        public FeedBriefViewModel(PostModel post)
        {
            FeedType = "Post";
            Id = post.Id;
            Title = post.Title;
            Tagline = post.Tagline;
            AuthorName = post.Author;
            ViewCount = post.ViewCount;
            //if(post.PostComments == null)
            //{
            //    CommentCount = 0;
            //} 
            //else
            //{
            //    CommentCount = post.PostComments.Count();
            //}
            BriefText = post.Text.Substring(0, 300);

            int indexOfPeriod = BriefText.LastIndexOf('.');

            BriefText = BriefText.Substring(0, indexOfPeriod + 1);
            
        }


        public string FeedType { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string BriefText { get; set; }
        public string AuthorName { get; set; }
        public int ViewCount { get; set; }
        public int CommentCount { get; set; }

    }
}
