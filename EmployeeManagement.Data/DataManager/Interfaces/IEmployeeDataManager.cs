using EmployeeManagement.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.DataManager.Interfaces
{
	public interface IEmployeeDataManager 
	{
		void AddEmployee(CreateEmployee createEmployee);
		bool DeleteEmployee(int employeeId);
		IList<Employee> GetAllEmployees(int currentPage, int pageSize, out int totalRecords);

	}
}
