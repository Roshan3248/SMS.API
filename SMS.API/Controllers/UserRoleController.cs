using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using SMS.Infrastructure.Migrations;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRole _userrole;
        public UserRoleController(IUserRole userRole)
        {
            _userrole = userRole;
        }
        [HttpGet("GetAllUserRoles")]
        public IActionResult GetAllUserRoles()
        {
            return Ok(_userrole.GetAll());
        }
        [HttpPost("AddUserRole")]
        public IActionResult AddUserRole(UserRole userRole)
        {
            return Ok(_userrole.Add(userRole));
        }
    }
}
