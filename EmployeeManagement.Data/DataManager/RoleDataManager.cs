using EmployeeManagement.Data.DataManager.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Data.DataManager
{
	public class RoleDataManager : IRoleDataManager
	{
		readonly string _connectionManager;
		public RoleDataManager(string connectionManager)
		{
			_connectionManager = connectionManager;
		}
		public IList<Role> GetAllRoles()
		{
			using (var dbContext = new EmployeeDBEntities(_connectionManager))
			{
				return dbContext.Roles.ToList();
			}
		}
	}
}
