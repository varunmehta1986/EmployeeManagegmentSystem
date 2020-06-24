using EmployeeManagement.Data.DataManager.Interfaces;
using EmployeeManagement.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.DataManager
{
	public class EmployeeDataManager : IEmployeeDataManager
	{
		readonly string _connectionString;
		public EmployeeDataManager(string connectionString)
		{
			_connectionString = connectionString;
		}
		public void AddEmployee(CreateEmployee createEmployeeModel)
		{
			using (var dbContext = new EmployeeDBEntities(_connectionString))
			{
				dbContext.Employees.Add(new Employee()
				{
					DateJoined = createEmployeeModel.DateJoined,
					EmployeeNumber = createEmployeeModel.EmployeeNumber,
					Extension = createEmployeeModel.Extension,
					FirstName = createEmployeeModel.FirstName,
					LastName = createEmployeeModel.LastName,
					RoleID = createEmployeeModel.RoleId
				});
				dbContext.SaveChanges();
			}
		}

		public bool DeleteEmployee(int employeeId)
		{
			using (var dbContext = new EmployeeDBEntities(_connectionString))
			{
				var employeeToDelete = dbContext.Employees.Where(emp => emp.EmployeeID == employeeId).SingleOrDefault();
				if (employeeToDelete != null)
				{
					dbContext.Employees.Remove(employeeToDelete);
					dbContext.SaveChanges();
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public IList<Employee> GetAllEmployees(int currentPage, int pageSize, out int totalRecords)
		{
			using (var dbContext = new EmployeeDBEntities(_connectionString))
			{
				var totalEmployees = dbContext.Employees.Count();
				var newPageSize = pageSize;
				totalRecords = totalEmployees;
				if (currentPage * pageSize > totalEmployees)
				{
					newPageSize = totalEmployees - ((currentPage - 1) * pageSize);
				}
				return dbContext.Employees.Include(r => r.Role).OrderBy(em=>em.EmployeeID).Skip((currentPage - 1) * pageSize).Take(newPageSize).ToList();
			}
		}


	}
}

