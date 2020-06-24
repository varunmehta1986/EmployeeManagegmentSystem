using EmployeeManagement.Data.DataManager.Interfaces;
using EmployeeManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
	[Route("[controller]")]
    public class RoleController : Controller
    {
        readonly IRoleDataManager _roleDataManager;
        public RoleController(IRoleDataManager roleDataManager)
        {
            _roleDataManager = roleDataManager;
        }
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            try
            {
                var roles = _roleDataManager.GetAllRoles();
                var rolevm = roles.Select(role =>
                {
                    return new RoleViewModel(role);
                }).ToList();

                return new OkObjectResult(rolevm);
            }
            catch(Exception exc)
            {
                return new BadRequestObjectResult(exc.ToString());
            }
       
        }
    }
}