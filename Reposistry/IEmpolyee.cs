using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeWebApi.Data;

namespace EmployeWebApi.Reposistry
{
   public interface IEmpolyee
    {
        Task<Employee> GetEmployeebyid(int id);
        Task<IEnumerable<Employee>> GetEmployees();
        Task <Employee> CreateEmployee(Employee employeeMo);
        Task<Employee> UpdateEmployee(Employee employeeMo);
         Task <Employee> DeleteEmployee(int id);
    }
}
