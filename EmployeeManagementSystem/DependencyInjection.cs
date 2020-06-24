using EmployeeManagement.Data.DataManager;
using EmployeeManagement.Data.DataManager.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
	public class DependencyInjection
	{
		public static void Inject(IServiceCollection serviceCollection, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("EmployeeDBEntities");
			serviceCollection.AddTransient<IEmployeeDataManager, EmployeeDataManager>(edm => new EmployeeDataManager(connectionString));
			serviceCollection.AddTransient<IRoleDataManager, RoleDataManager>(rdm => new RoleDataManager(connectionString));
		}
	}
}
