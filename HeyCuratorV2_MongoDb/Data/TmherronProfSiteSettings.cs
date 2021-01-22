using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Data
{
    public class TmherronProfSiteSettings : ITmherronProfSiteSettings
    {
        public string ConnectionString { get; set ; }
        public string DatabaseName { get; set ; }
        public string PostCollectionName { get; set; }
        public string PostCommentCollectionName { get; set; }
        public string ContactFormCollectionName { get; set; }
    }
}
