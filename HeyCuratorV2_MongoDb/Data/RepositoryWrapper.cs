using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Contracts;
using tmherronProfessionalSite.Models;

namespace tmherronProfessionalSite.Data
{
    public class RepositoryWrapper : IRepositoryWrapperSite
    {
        public ISiteDbSettings _siteSettings;

        public RepositoryWrapper(ISiteDbSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }


        private IPostRepository _post;

        public IPostRepository Post { get 
            {
                if(_post == null)
                {
                    _post = new PostRepository(_siteSettings, _siteSettings.PostCollectionName);
                }
                return _post;
            }
        }
    }
}
