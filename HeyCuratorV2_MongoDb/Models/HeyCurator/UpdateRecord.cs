using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Models.HeyCurator
{
    public class UpdateRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("item_instance_id")]
        [JsonProperty("itemInstanceId")]
        public string ItemInstanceId { get; set; }
        [BsonElement("employee_name")]
        [JsonProperty("employeeName")]
        public string EmployeeName { get; set; }
        // Was this a verifid updated by items curator
        [BsonElement("is_curator_verified")]
        [JsonProperty("isCuratorVerified")]
        public bool isCuratorVerified { get; set; }

        [BsonElement("item_id")]
        [JsonProperty("itemId")]
        public string ItemId { get; set; }
        [BsonElement("item_name")]
        [JsonProperty("itemName")]
        public string ItemName { get; set; }




    }
}
