using Microsoft.AspNetCore.Mvc;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IState _state;

        public StateController(IState state)
        {
            _state = state;
        }
        [HttpGet("GetAllStates")]
        public IActionResult GetAllStates()
        {
            return Ok(_state.GetAll());
        }

        [HttpPost("AddState")]
        public IActionResult AddState(State state)
        {
            return Ok(_state.Add(state));
        }
        [HttpPut("UpdateState")]
        public IActionResult UpdateState(State state)
        {
            return Ok(_state.Update(state));
        }
        [HttpDelete("DeleteState")]
        public IActionResult DeleteState(int Id)
        {
            return Ok(_state.Delete(Id));
        }


    }
}
