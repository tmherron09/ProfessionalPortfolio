using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using tmherronProfessionalSite.Data;
using tmherronProfessionalSite.Models;

namespace tmherronProfessionalSite.Services
{
    public class SuperSecretTestService
    {

        private readonly IMongoCollection<SuperSecretTestModel> _superSecretBson;

        //private readonly IConfiguration _config;

        //Uncomment for local MongoDb Dev
        public SuperSecretTestService(ISiteDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);


            var database = client.GetDatabase(settings.DatabaseName);


            _superSecretBson = database.GetCollection<SuperSecretTestModel>("tests");

            //_superSecretBson = database.GetCollection<BsonDocument>(settings.PostCollectionName);
            //_posts = database.GetCollection<PostModel>("Posts");
        }

        public List<SuperSecretTestModel> Get() =>
            _superSecretBson.Find(b => true).ToList();


    }
}
