using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Contracts.HeyCurator;
using tmherronProfessionalSite.Models.HeyCurator;

namespace tmherronProfessionalSite.Data.HeyCurator
{
    public class EmployeeRespository : RepositoryBaseHC<Employee>, IEmployeeRepository
    {
        public EmployeeRespository(IHCDbSettings settings, string employeeCollectionName):base(settings, employeeCollectionName)
        {

        }

        public bool EmployeeIsPurchaerById(string employeeId)
        {
            var employee = FindById(employeeId);
            if(employee == null)
            {
                throw new NullReferenceException("No Employee with this Id.");
            }
            return employee.IsPurchaser;
        }

        public bool EmployeeIsPurchaerByName(string employeeName)
        {
            var employee = FindAllByCondition(e => e.FirstName == employeeName).FirstOrDefault();
            if (employee == null)
            {
                throw new NullReferenceException("No Employee with this name.");
            }
            return employee.IsPurchaser;
        }

        public IEnumerable<Employee> GetEmployeesByCuratorRoleId(string curatrRoleId) =>
            FindAllByCondition(e => e.CuratorRoleIds.ContainsKey(curatrRoleId)).ToList();


        public IEnumerable<Employee> GetEmployeesByCuratorRoleName(string curatrRoleName) =>
            FindAllByCondition(e => e.CuratorRoleIds.ContainsValue(curatrRoleName)).ToList();

        public IEnumerable<Employee> GetEmployeesArePurchaser() =>
            FindAllByCondition(e => e.IsPurchaser == true);
    }
}
