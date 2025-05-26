using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SMS.API.DTO;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IRole _role;
        private readonly IUserRole _userRole;
        private readonly IConfiguration _configuration;
        public UserController(IUser user, IRole role, IUserRole userRole, IConfiguration configuration) 
        {
            _user = user;
            _role = role;
            _userRole = userRole;
            _configuration = configuration;
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
            var user = _user.Login(login.Email, login.Password);
            if (user == null)
            {
                return Ok(new {token="", role="", name="", success="400"});
            }
            var userRole = _userRole.GetById(user.Id);
            if (userRole == null)
            {
                return Ok(new { token = "", role = "", name = "", success = "401" });
            }
            else 
            {
                var role = _role.GetById(userRole.RoleId);
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: null,
                    expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["Jwt:ExpriesInHours"])),
                    signingCredentials: creds
                    );
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { token = jwt, user = user, role = role, success = "200"});
            }
        }
    }
}
