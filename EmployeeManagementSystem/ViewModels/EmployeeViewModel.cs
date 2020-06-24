using EmployeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.ViewModels
{
	public class EmployeeViewModel
	{
        public long EmployeeId { get; set; }
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateJoined { get; set; }
        public string Extension { get; set; }
        public string Role { get; set; }
        public EmployeeViewModel(Employee employee)
        {
            EmployeeId = employee.EmployeeID;
            EmployeeNumber = employee.EmployeeNumber;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            DateJoined = employee.DateJoined.ToShortDateString();
            Extension = employee.Extension.HasValue? employee.Extension.ToString() : "-";
            Role = employee.Role!=null?employee.Role.RoleName : "-";
        }
    }
}
