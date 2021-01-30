using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Contracts;
using tmherronProfessionalSite.Models;

namespace tmherronProfessionalSite.Data
{
    /*
     * This model does not currently take advantage of mongodb server side querying/aggregations/views. 
     * It may later be transitioned but as the post count is expected to stay low,
     */

    public class PostRepository : RepositoryBaseSite<PostModel>, IPostRepository
    {

        public PostRepository(ISiteDbSettings siteSettings, string postCollectionName):base(siteSettings, postCollectionName)
        {

        }

        // Expectation that number of posts will fit in an integer on Personal Site.
        public int GetPostCount() =>
            (int)_collectionDbContext.CountDocuments(post => true);

        public IEnumerable<PostModel> GetPostByTitleContaining(string query) =>
            FindAllByCondition(p => p.Title.Contains(query));

        public IEnumerable<PostModel> GetPostByAuthor(string author) =>
            FindAllByCondition(p => p.Author == author);

        public IEnumerable<PostModel> GetAllPostByDateDescending() =>
            FindAll().OrderByDescending(post => post.PostedOn);

        public IEnumerable<PostModel> GetAllPostByDateAscending() =>
            FindAll().OrderBy(post => post.PostedOn);

        public IEnumerable<PostModel> GetFirstFivePostByDateDescending() =>
            GetAllPostByDateDescending().Take(5);

        public IEnumerable<PostModel> GetFirstFivePostByDateAscending() =>
            GetAllPostByDateAscending().Take(5);

        public IEnumerable<PostModel> GetPostPaginationResultByDate(int displayCount, int page, bool IsAscending = true)
        {
            if((page - 1) * displayCount >= GetPostCount())
            {
                return null;
            }

            if (IsAscending)
            {
                return GetAllPostByDateAscending().Skip((page - 1) * 10).Take(displayCount);
            }
            else
            {
                return GetAllPostByDateDescending().Skip((page - 1) * 10).Take(displayCount);
            }
        }
    }
}

/*
Proof Method for Pagination result;
    public void Proof(int displayCount, int page, int entries)
    {
        int[] numbers = new int[entries];
        for (int i = 1; i <= numbers.Count(); i++)
        {
            numbers[i - 1] = i;
        }

        if ((page - 1) * displayCount >= numbers.Count())
        {
            Console.WriteLine("Page does not exsist");
            return;
        }

        var paginationResult = numbers.Skip((page - 1) * 10).Take(displayCount);

        foreach (var num in paginationResult)
        {
            Console.WriteLine(num);
        }
    }
*/