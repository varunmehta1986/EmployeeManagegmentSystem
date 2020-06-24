using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.DataModels
{
	public class CreateEmployee
	{
		public int EmployeeNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateJoined { get; set; }
		public short Extension { get; set; }
		public short RoleId { get; set; }
	}
}
