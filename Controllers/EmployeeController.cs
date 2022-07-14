using Microsoft.AspNetCore.Mvc;
using DapperPrac.Models;
using DapperPrac.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DapperPrac.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpPost("CreateEmployee")]
        public int EmployeeCreate(Employee employee)
        {
            return _employeeRepository.CreateEmployee(employee);
        }

        [HttpGet("GetEmployeeById")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }

       [HttpGet("GetAllEmployees")]
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        [HttpPut("UpdateEmployee")]
        public int UpdateEmployee(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }

        [HttpDelete("DeleteEmployee")]
        public int EmployeeDelete(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }
    }
}