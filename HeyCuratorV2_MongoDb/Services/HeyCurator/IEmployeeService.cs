using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmherronProfessionalSite.Models.HeyCurator;

namespace tmherronProfessionalSite.Services.HeyCurator
{
    interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetEmployeePurchasers();



    }
}
