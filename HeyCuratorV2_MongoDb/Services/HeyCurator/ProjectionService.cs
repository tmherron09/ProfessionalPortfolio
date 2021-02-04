using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using tmherronProfessionalSite.Contracts.HeyCurator;

namespace tmherronProfessionalSite.Services.HeyCurator
{
    public class ProjectionService
    {
        private readonly IRepositoryWrapperHC _repo;

        public ProjectionService(IRepositoryWrapperHC repo)
        {
            _repo = repo;
        }

        //public async Task<Dictionary<string, string>> GetAllCuratorRoleIdNameProject()
        //{
        //    var curatorRoles = new Dictionary<string, string>();

            

        //}

    }
}
