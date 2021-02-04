using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Models.HeyCurator
{
    public class ExhibitArea
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        [JsonProperty("description")]
        public string Description { get; set; }
        [BsonElement("curators")]
        [JsonProperty("curators")]
        public Dictionary<string, string> CuratorRoleIds { get; set; }
        [BsonElement("exhibits")]
        [JsonProperty("exhibits")]
        public Dictionary<string, string> ExhibitIds { get; set; }
        [BsonElement("storage_spaces")]
        [JsonProperty("storageSpaces")]
        public Dictionary<string, string> StorageSpaceIds { get; set; }
        [BsonElement("location_tags")]
        [JsonProperty("locationTags")]
        public List<string> LocationTags { get; set; }
        [BsonElement("open_during_fieldtrips")]
        [JsonProperty("isOpenDuringFieldTrips")]
        public bool IsOpenDuringFieldTrips { get; set; }
        [BsonElement("school_year_openining_time")]
        [JsonProperty("schoolYearOpeningTime")]
        public DateTime SchoolYearOpeningTime { get; set; }
        [BsonElement("special_event_notes")]
        [JsonProperty("specialEventNotes")]
        public List<string> SpecialEventNotes { get; set; }
        [BsonElement("training_information")]
        [JsonProperty("trainingInformation")]
        public List<string> TrainingInformation { get; set; }
        [BsonElement("cleaning_information")]
        [JsonProperty("cleaningInformation")]
        public List<string> CleaningInformation { get; set; }

    }
}
