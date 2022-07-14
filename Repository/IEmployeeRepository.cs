using System.Threading.Tasks;
using System.Linq;
using System;
using DapperPrac.Models;
using System.Collections.Generic;
namespace DapperPrac.Repository
{
    public interface IEmployeeRepository
    {
         Task<Employee> GetEmployeeById(int id);
         Task<List<Employee>> GetEmployeesByDOB(DateTime dateTime);
         public int CreateEmployee(Employee employee);
         Task <List<Employee>> GetAllEmployees();
         public int UpdateEmployee(Employee emp);
         public int DeleteEmployee(int id);
    }
}