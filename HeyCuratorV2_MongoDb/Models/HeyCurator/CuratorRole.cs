using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Models.HeyCurator
{
    public class CuratorRole
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }
        [BsonElement("exhibit_areas")]
        [JsonProperty("exhibitAreas")]
        public Dictionary<string, string> ExhibitAreaIds { get; set; }
        [BsonElement("storage_spaces")]
        [JsonProperty("storageSpaces")]
        public Dictionary<string, string> StorageSpaceIds { get; set; }
        [BsonElement("employees")]
        [JsonProperty("employees")]
        public Dictionary<string, string> EmployeeIds { get; set; }

        public CuratorRole()
        {
            ExhibitAreaIds = new Dictionary<string, string>();
            StorageSpaceIds = new Dictionary<string, string>();
            EmployeeIds = new Dictionary<string, string>();
        }

    }

}
