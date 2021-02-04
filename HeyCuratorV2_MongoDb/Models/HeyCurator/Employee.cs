using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Contracts;

namespace tmherronProfessionalSite.Models.HeyCurator
{
    public class Employee : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("first_name")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [BsonElement("last_name")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Title { get; set; }
        [BsonElement("other_titles")]
        [JsonProperty("otherTitles")]
        public List<string> OtherTitles { get; set; }
        [BsonElement("curator_roles")]
        [JsonProperty("curatorRoles")]
        public Dictionary<string, string> CuratorRoleIds { get; set; }
        [BsonElement("is_purchaser")]
        [JsonProperty("isPurchaser")]
        public bool IsPurchaser { get; set; }
        



    }
}
