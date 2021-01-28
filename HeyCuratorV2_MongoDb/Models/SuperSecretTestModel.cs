using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Models
{
    [BsonIgnoreExtraElements]
    public class SuperSecretTestModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        [BsonExtraElements]
        public Dictionary<string, object> ExtensionData { get; set; }

    }
}
