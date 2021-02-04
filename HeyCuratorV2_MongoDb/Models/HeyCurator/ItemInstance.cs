using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Models.HeyCurator
{
    /// <summary>
    /// The Item object stored stored on an Item document. One for each instance in the museum.
    /// Example: Baby Dolls are used in the play nursery, play house, and play daycare. The nursery and play hospital each share the same stock of baby dolls and the same curator. But for the play daycare a different inventory of baby dolls is kept. Each is ordered seperately and maintained seperately.
    /// </summary>
    public class ItemInstance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("item_id")]
        [JsonProperty("itemId")]
        public string ItemId { get; set; }
        [BsonElement("item_name")]
        [JsonProperty("itemName")]
        public string ItemName { get; set; }
        // Item reads should be quick. Database writes should find and change associations.
        [BsonElement("exhibit_areas")]
        [JsonProperty("exhibitAreas")]
        public Dictionary<string, string> ExhibitAreaIds { get; set; }
        [BsonElement("curators")]
        [JsonProperty("curators")]
        public Dictionary<string, string> CuratorRoleIds { get; set; }
        [BsonElement("exhibits")]
        [JsonProperty("exhibits")]
        public Dictionary<string, string> ExhibitIds { get; set; }
        [BsonElement("storage_spaces")]
        [JsonProperty("storageSpaces")]
        public Dictionary<string, string> StorageSpaceIds { get; set; }
        /* Inventory Count and Update Data */

        /// <summary>
        /// The minimum count of an item without triggering a ReOrder or Inventory Confirmation.
        /// </summary>
        [BsonElement("min_count")]
        [JsonProperty("minCount")]
        public int MinCount { get; set; }
        [BsonElement("latest_storage_count")]
        [JsonProperty("latestStorageCount")]
        public int LatestStorageCount { get; set; }
        /// <summary>
        /// Number of days after last update to send out reminder to Curator/s to update the item. Used to set DateOfScheduledUpdate.
        /// </summary>
        [BsonElement("days_between_updates")]
        [JsonProperty("daysBetweenUpdates")]
        public int DaysBetweenUpdates { get; set; }
        /// <summary>
        /// Number of days that must pass after an item's scheduled update is not met before message is sent out to larger curator pool notifying the item needs an update. Used tp set DateToNotifyAllCurators.
        /// </summary>
        [BsonElement("days_before_notify_all_curators")]
        [JsonProperty("daysBeforeNotifyAllCurators")]
        public int DaysBeforeNotifyAllCurators { get; set; }
        /// <summary>
        /// Date of last update/count of item.
        /// </summary>
        [BsonElement("date_of_last_update")]
        [JsonProperty("dateOfLastUpdate")]
        public DateTime DateOfLastUpdate { get; set; }
        /// <summary>
        /// Date that item is next scheduled to be updated by else a reminder is sent to update item.
        /// </summary>
        [BsonElement("date_of_scheduled_update")]
        [JsonProperty("dateOfScheduledUpdate")]
        public DateTime DateOfScheduledUpdate { get; set; }
        /// <summary>
        /// Date that if the item has not had an update by, will trigger an announcement to other curatorial staff.
        /// </summary>
        [BsonElement("date_notify_all_curators")]
        [JsonProperty("dateNotifyAllCurators")]
        public DateTime DateToNotifyAllCurators { get; set; }



        // Object References

        //[BsonIgnore]
        //[JsonIgnore]
        //public List<ExhibitArea> ExhibitAreas { get; set; }
        //[BsonIgnore]
        //[JsonIgnore]
        //public List<Exhibit> Exhibits { get; set; }
        //[BsonIgnore]
        //[JsonIgnore]
        //public List<CuratorRole> Curators { get; set; }






    }
}
