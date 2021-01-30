using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Contracts;
using tmherronProfessionalSite.Models;
using tmherronProfessionalSite.ViewModel;

namespace tmherronProfessionalSite.Utility
{
    public static class PostUtility
    {

        public static List<FeedBriefViewModel> ConvertToFeedBriefs(IRepositoryWrapperSite _repo)
        {
            List<FeedBriefViewModel> feedBriefs = new List<FeedBriefViewModel>();

            var posts = _repo.Post.GetFirstFivePostByDateDescending();
            foreach (var post in posts)
            {
                feedBriefs.Add(new FeedBriefViewModel(post));
            }

            return feedBriefs;
        }
    }
}
