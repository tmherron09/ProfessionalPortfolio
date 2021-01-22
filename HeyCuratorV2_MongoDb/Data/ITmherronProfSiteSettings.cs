using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmherronProfessionalSite.Data
{
    public interface ITmherronProfSiteSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string PostCollectionName { get; set; }
        string PostCommentCollectionName { get; set; }
        string ContactFormCollectionName { get; set; }
    }
}
