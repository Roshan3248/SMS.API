using Microsoft.AspNetCore.Mvc;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;
        public RoleController(IRole role)
        {
            _role = role;
        }
        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles() 
        {
            return Ok(_role.GetAll);
        }
        [HttpPost("AddRole")]
        public IActionResult AddRole(Role role)
        { 
            return Ok(_role.Add(role));
        }
    }
}
