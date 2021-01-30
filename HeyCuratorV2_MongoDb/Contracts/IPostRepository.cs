using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Models;

namespace tmherronProfessionalSite.Contracts
{
    public interface IPostRepository : IRepositoryBaseSite<PostModel>
    {
        int GetPostCount();
        IEnumerable<PostModel> GetPostByTitleContaining(string query);
        IEnumerable<PostModel> GetPostByAuthor(string author);
        IEnumerable<PostModel> GetAllPostByDateDescending();
        IEnumerable<PostModel> GetAllPostByDateAscending();
        IEnumerable<PostModel> GetFirstFivePostByDateDescending();
        IEnumerable<PostModel> GetFirstFivePostByDateAscending();
        IEnumerable<PostModel> GetPostPaginationResultByDate(int displayCount, int page, bool IsAscending);

    }
}
