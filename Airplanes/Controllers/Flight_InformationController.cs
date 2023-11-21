using Microsoft.AspNetCore.Mvc;
using Airplanes.Contracts;
using Airplanes.Dtos;
using Airplanes.Models;

namespace Airplanes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Flight_informationController : ControllerBase
    {
        private readonly ILogger<Flight_informationController> _logger; 
        private readonly IFlight_Information _Flight_information;
            public Flight_informationController(ILogger<Flight_informationController> logger, IFlight_Information Flight_information)
        {
            _logger = logger;
            _Flight_information = Flight_information;
        }
        [HttpGet] 
        public async Task<IActionResult> GetAllFlight_informations() 
        { 
            try 
            { 
                var Flight_information = await _Flight_information.GetAllFlight_informations(); 
                return Ok(new 
                { 
                    Success = true, 
                    Message = "All Flight_informations Returned.", 
                    Flight_information
                }); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message); 
            } 
        }
        [HttpPost] 
        public async Task<IActionResult> CreateFlight_information(Flight_InformationForCreationDto Flight_information) 
        { 
            try 
            { 
                var newFlight_information = await _Flight_information.CreateFlight_information(Flight_information); 
                return Ok(new 
                { 
                    Success = true, 
                    Message = "Flight_information Created.",
                    newFlight_information
                }); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message); 
            } 
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFlight_information(Guid id, Flight_InformationForUpdateDto Flight_information)
        {
            try 
            { 
                await _Flight_information.UpdateFlight_information(id, Flight_information); 
                return Ok(new { Success = true, Message = "Flight_information Updated." }); 
                }
                catch (Exception ex)
                { 
                return StatusCode(500, ex.Message); 
                }
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFlight_information(Guid id) 
        { 
            try 
            {
            await _Flight_information.DeleteFlight_information(id); 
            return OK(new 
            { 
                Success = true, 
                Message = "Flight_information Deleted."
            }); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message); 
            } 
        }
}
