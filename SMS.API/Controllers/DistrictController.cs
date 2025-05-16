using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrict _district;

        public DistrictController(IDistrict district)
        {
            _district = district;
        }
        [HttpGet("GetAllDistricts")]
        public IActionResult GetAllDistricts()
        {
            return Ok(_district.GetAll());
        }

        [HttpPost("AddDistrict")]
        public IActionResult AddDistrict(District district)
        {
            return Ok(_district.Add(district));
        }
        [HttpPut("UpdateDistrict")]
        public IActionResult UpdateDistrict(District district)
        {
            return Ok(_district.Update(district));
        }
        [HttpDelete("DeleteDistrict")]
        public IActionResult DeleteDistrict(int Id)
        {
            return Ok(_district.Delete(Id));
        }

    }
}
