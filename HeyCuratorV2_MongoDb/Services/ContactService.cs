using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Data;
using tmherronProfessionalSite.Models;

namespace tmherronProfessionalSite.Services
{

    public class ContactService
    {
        private readonly IMongoCollection<ContactFormModel> _contact;

        //private readonly IConfiguration _config;

        public ContactService(ITmherronProfSiteSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);


            var database = client.GetDatabase(settings.DatabaseName);

            _contact = database.GetCollection<ContactFormModel>(settings.ContactFormCollectionName);
            //_contact = database.GetCollection<PostModel>("Posts");
        }

        //public ContactService(IConfiguration config)
        //{
        //    _config = config;
        //    string connectionString = _config["TmherronProfSiteSettings:ConnectionString"];

        //    var client = new MongoClient(connectionString);


        //    var database = client.GetDatabase(_config["TmherronProfSiteSettings:DatabaseName"]);

        //    _contact = database.GetCollection<ContactFormModel>(_config["TmherronProfSiteSettings:ContactFormCollectionName"]);
        //}

        public void Create(ContactFormModel formData) =>
            _contact.InsertOne(formData);


    }
}
