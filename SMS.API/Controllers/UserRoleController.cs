using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRole _userrole;
        public UserRoleController(IUserRole userrole)
        {
            _userrole = userrole;
        }
        [HttpGet("GetAllUserRoles")]
        public IActionResult GetAllUserRoles()
        {
            return Ok(_userrole.GetAll());
        }
    }
}
