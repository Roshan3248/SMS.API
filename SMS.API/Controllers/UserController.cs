using Microsoft.AspNetCore.Mvc;
using SMS.API.DTO;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user) 
        {
            _user = user;
        }
        [HttpGet("GettAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_user.GetAll());
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            return Ok(_user.Add(user));
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequest login) 
        {
            var userdata = _user.Login(login.Email, login.Password);
            if (userdata == null)
            {
                return Ok(new { Token = "", user = "", statuscode = 404, role = "" });
            }
            else 
            {

                //fetch data from userroles table
                //fetch role data
                //if(role == null)
                //return Ok(new { Token = "", user = "", statuscode = 401, role = "" });
                //else
                //generate token token
                //return Ok(new { token = "fdglkjljkgfdgfg", user = userdata, statuscode = 200, role = role });
            }



            return Ok();
        }
    }
}
