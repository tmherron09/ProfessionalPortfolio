using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Contracts.HeyCurator;

namespace tmherronProfessionalSite.Data.HeyCurator
{
    public class RepositoryWrapperHC : IRepositoryWrapperHC
    {
        public IHCDbSettings _settings;

        public RepositoryWrapperHC(IHCDbSettings settings)
        {
            _settings = settings;
        }

        private IEmployeeRepository _employee;


        public IEmployeeRepository Employee { get
            {
                if(_employee == null)
                {
                    _employee = new EmployeeRespository(_settings, _settings.EmployeesCollectionName);
                }
                return _employee;
            } 
        }


    }
}
