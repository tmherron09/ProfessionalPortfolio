using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Data;
using tmherronProfessionalSite.Models;
using tmherronProfessionalSite.ViewModel;

namespace tmherronProfessionalSite.Services
{
    public class PostService
    {

        private readonly IMongoCollection<PostModel> _posts;

        private readonly IConfiguration _config;

        // Uncomment for local MongoDb Dev
        //public PostService(ITmherronProfSiteSettings settings)
        //{ 
        //    var client = new MongoClient(settings.ConnectionString);


        //    var database = client.GetDatabase(settings.DatabaseName);

        //    _posts = database.GetCollection<PostModel>(settings.PostCollectionName);
        //    _posts = database.GetCollection<PostModel>("Posts");
        //}
        
        public PostService(IConfiguration config)
        {
            _config = config;
            string connectionString = _config["TmherronProfSiteSettings:ConnectionString"];

            var client = new MongoClient(connectionString);


            var database = client.GetDatabase(_config["TmherronProfSiteSettings:DatabaseName"]);

            _posts = database.GetCollection<PostModel>(_config["TmherronProfSiteSettings:PostCollectionName"]);
        }

        public List<PostModel> Get() =>
            _posts.Find(post => true).ToList();

        public List<PostModel> GetFirstFive() =>
            _posts.Find(post => true).Limit(5).ToList();

        public List<FeedBriefViewModel> GetLatest5Briefs()
        {
            // Test once more posts.
            List<PostModel> posts = _posts.Find(post => true).Limit(5).ToList();
            List<FeedBriefViewModel> briefs = new List<FeedBriefViewModel>();

            foreach (var post in posts)
            {
                briefs.Add(new FeedBriefViewModel(post));
            }

            return briefs;
        }


        public IEnumerable<PostModel> GetXNumber(int x) =>
            _posts.Find(post => true).Limit(x).ToList();

        public IEnumerable<PostModel> GetRange(int start, int amount) =>
            _posts.Find(post => true).Skip(start).Limit(amount).ToList();

        public PostModel Get(string id) =>
            _posts.Find<PostModel>(post => post.Id == id).FirstOrDefault();

        public PostModel Create(PostModel post)
        {
            _posts.InsertOne(post);
            return post;
        }

        public void Update(string id, PostModel postUpdate) =>
            _posts.ReplaceOne(profile => profile.Id == id, postUpdate);

        public void Remove(PostModel postRemove) =>
            _posts.DeleteOne(profile => profile.Id == postRemove.Id);

        public void Remove(string id) =>
            _posts.DeleteOne(post => post.Id == id);

    }
}
