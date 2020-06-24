using EmployeeManagement.Data;

namespace EmployeeManagementSystem.ViewModels
{
	public class RoleViewModel
	{
		public int RoleID { get; set; }
		public string RoleName { get; set; }

		public RoleViewModel(Role roleModel)
		{
			RoleID = roleModel.RoleID;
			RoleName = roleModel.RoleName;
		}
	}
}
