using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Models.HeyCurator;

namespace tmherronProfessionalSite.Contracts.HeyCurator
{
    public interface IEmployeeRepository : IRepositoryBaseHC<Employee>
    {
        IEnumerable<Employee> GetEmployeesByCuratorRoleId(string curatrRoleId);
        IEnumerable<Employee> GetEmployeesByCuratorRoleName(string curatrRoleName);
        IEnumerable<Employee> GetEmployeesArePurchaser();
        bool EmployeeIsPurchaerById(string employeeId);
        bool EmployeeIsPurchaerByName(string employeeName);

    }
}
