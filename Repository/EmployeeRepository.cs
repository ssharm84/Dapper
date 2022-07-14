using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DapperPrac.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace DapperPrac.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _config;
        public EmployeeRepository(IConfiguration config)
        {
            this._config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MyConnectionString"));
            }
        }
        public int CreateEmployee(Employee Emp)
        {
            using(IDbConnection conn = Connection)
            {
                conn.Open();
                IDbTransaction trans = conn.BeginTransaction();
                var param = new DynamicParameters();
                param.Add("@Fname",Emp.FirstName);
                param.Add("@Lname",Emp.LastName);
                param.Add("@Dob",Emp.DateOfBirth);
                var result = conn.Execute("AddEmployee",param,trans,0,System.Data.CommandType.StoredProcedure);
                if(result>0)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
                return result;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            using(IDbConnection conn = Connection)
            {
                conn.Open();
                IDbTransaction trans = conn.BeginTransaction();
                var param = new DynamicParameters();
                param.Add("@Id",id);
                var result = await conn.QueryAsync<Employee>("GetEmployeeById",param,trans,0,System.Data.CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public async Task <List<Employee>> GetAllEmployees()
        {
            using(IDbConnection conn = Connection)
            {
                conn.Open();
                IDbTransaction trans = conn.BeginTransaction();
                //var param = new DynamicParameters();
                
                var result = await conn.QueryAsync<Employee>("GetAllEmployees",null,trans,0,System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<Employee>> GetEmployeesByDOB(DateTime dateTime)
        {
            using(IDbConnection conn = Connection)
            {
                conn.Open();
                IDbTransaction trans = conn.BeginTransaction();
                var param = new DynamicParameters();
                param.Add("@dateTime",dateTime);
                var result = await conn.QueryAsync<Employee>("GetEmployeeByDob",param,trans,0,System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public int UpdateEmployee(Employee emp)
        {
            using(IDbConnection conn = Connection)
            {
                conn.Open();
                IDbTransaction trans = conn.BeginTransaction();
                var param = new DynamicParameters();
                param.Add("@Id",emp.Id);
                param.Add("@Fname",emp.FirstName);
                param.Add("@Lname",emp.LastName);
                param.Add("@DOB",emp.DateOfBirth);
                var result = conn.Execute("UpdateEmployee",param,trans,0,System.Data.CommandType.StoredProcedure);
                if(result>0)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
                return result;
            }
        }

        public int DeleteEmployee(int id)
        {
            using(IDbConnection conn = Connection)
            {
                conn.Open();
                IDbTransaction trans = conn.BeginTransaction();
                var param = new DynamicParameters();
                param.Add("@Id",id);
                var result = conn.Execute("DeleteEmployee",param,trans,0,System.Data.CommandType.StoredProcedure);
                if(result>0)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
                return result;
            }
        }
    }
}