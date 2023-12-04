using Airplanes.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrossController : ControllerBase
    {
        private readonly ILogger<CrossController> _logger;
        private readonly ICross _cross;
        public CrossController(ILogger<CrossController> logger, ICross cross)
        {
            _logger = logger;
            _cross = cross;
        }
        [HttpGet("AirplaneForAirport/{aid}")]
        public async Task<IActionResult> GetCalendarsByMemberId(Guid aid)
        {
            try
            {
                var counter = await _cross.GetAirplaneByAirportId(aid);
                return Ok(new
                {
                    Success = true,
                    Message = "輸出Airport的id,name且對應Airplane",
                    counter
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

