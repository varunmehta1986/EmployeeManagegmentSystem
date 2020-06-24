using System.Collections.Generic;

namespace EmployeeManagement.Data.DataManager.Interfaces
{
	public interface IRoleDataManager
	{
		IList<Role> GetAllRoles();
	}
}