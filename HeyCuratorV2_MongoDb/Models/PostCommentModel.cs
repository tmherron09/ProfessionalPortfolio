using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace tmherronProfessionalSite.Models
{
    [BsonIgnoreExtraElements]
    public class PostCommentModel
    {

        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }
        [BsonElement("PostId")]
        [JsonProperty("postId")]
        public string PostId { get; set; }

        [BsonElement("Comment_Author_Name")]
        [JsonProperty("commentAuthorName")]
        public string CommentAuthor { get; set; }
        [BsonElement("Comment_Author_Email")]
        [JsonProperty("commentAuthorEmail")]
        public string CommentAuthorEmail { get; set; }
        [BsonElement("Email_Visible")]
        [JsonProperty("emailVisible")]
        public bool EmailVisible { get; set; }
        [BsonElement("Comment_Text")]
        [JsonProperty("commentText")]
        public string CommentText { get; set; }
        public DateTime DateOfPost { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> ExtensionData { get; set; }

    }
}
