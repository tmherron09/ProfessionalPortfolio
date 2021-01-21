using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace tmherronProfessionalSite.Models
{
    public class PostModel
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Author { get; set; }
        //public string AuthorEmail { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Text { get; set; }
        public DateTime PostedOn { get; set; }
        public int ViewCount { get; set; }
        public string FeedType { get; set; }
        public IEnumerable<PostCommentModel> PostComments { get; set; }
        public int CommentCount { get { return PostComments.Count(); } }

    }
}
