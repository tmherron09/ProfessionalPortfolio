using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Data.HeyCurator;

namespace tmherronProfessionalSite.Data
{
    public class TmherronProfSiteSettings : ISiteDbSettings, IHCDbSettings
    {
        public string ConnectionString { get; set ; }
        public string DatabaseName { get; set ; }
        public string PostCollectionName { get; set; }
        public string PostCommentCollectionName { get; set; }
        public string ContactFormCollectionName { get; set; }

        // Hey Curator Settings

        public string HeyCuratorDatabaseName { get; set; }
        public string EmployeesCollectionName { get; set; }
        public string CuratorRolesCollectionName { get; set; }
        public string ExhibitAreasCollectionName { get; set; }
        public string ItemsCollectionName { get; set; }
        public string ItemInstancesCollectionName { get; set; }
        public string UpdateRecordsCollectionName { get; set; }
    }
}
