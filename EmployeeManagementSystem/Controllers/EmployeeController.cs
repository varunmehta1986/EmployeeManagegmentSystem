using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data.DataManager;
using EmployeeManagement.Data.DataManager.Interfaces;
using EmployeeManagement.Data.DataModels;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : Controller
	{
		readonly IEmployeeDataManager _employeeDataManager;
		public EmployeeController(IEmployeeDataManager employeeDataManager)
		{
			_employeeDataManager = employeeDataManager;
		}
		[HttpGet]
		public IActionResult GetAllEmployees(int currentPage, int pageSize)
		{
			try
			{
				var employees = _employeeDataManager.GetAllEmployees(currentPage, pageSize, out int totalRecords);
				var employeeViewModels = employees.Select(emp =>
				{
					var emploeevm = new EmployeeViewModel(emp);
					return emploeevm;
				}).ToList();
				return new OkObjectResult(new
				{
					totalRecords,
					employees = employeeViewModels
				});
			}
			catch (Exception exc)
			{
				return new BadRequestObjectResult(exc.ToString());
			}
		}
		[HttpPost]
		public IActionResult AddEmployee([FromBody]CreateEmployee createEmployeeModel)
		{
			try
			{
				_employeeDataManager.AddEmployee(createEmployeeModel);
				return new OkResult();
			}
			catch
			{
				return new BadRequestResult();
			}
		}
		[HttpDelete]
		public IActionResult DeleteEmployee(int employeeId)
		{
			try
			{
				_employeeDataManager.DeleteEmployee(employeeId);
				return new OkResult();
			}
			catch
			{
				return new BadRequestResult();
			}
		}
	}
}