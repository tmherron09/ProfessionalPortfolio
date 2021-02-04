using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Contracts.HeyCurator;
using tmherronProfessionalSite.Models.HeyCurator;

namespace tmherronProfessionalSite.Services.HeyCurator
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryWrapperHC _repo;

        public EmployeeService(IRepositoryWrapperHC repo)
        {
            _repo = repo;
        }

        public IEnumerable<Employee> GetAllEmployees() =>
            _repo.Employee.FindAll();

        public IEnumerable<Employee> GetEmployeePurchasers() =>
            _repo.Employee.GetEmployeesArePurchaser();
    }
}
