using Flight_client_server.Helpers;
using Flight_client_server.Models;
using Flight_client_server.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Flight_client_server.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightController : ControllerBase
    {
        private readonly ILogger<FlightController> _logger;
        private readonly IFlightService _flightService;

        public FlightController(ILogger<FlightController> logger, IFlightService flightService)
        {
            _logger = logger;
            _flightService = flightService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            try
            {
                var result = await _flightService.GetAllFlights();

                if (result.Total == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> GetFlights([FromQuery] FilterFlightVM filter)
        {
            try
            {
                var result = await _flightService.GetFlights(FilterHelper.ParseFlightFilter(filter));

                if (result.Total == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] CreateFlightVM model)
        {
            try
            {
                var result = await _flightService.CreateFlight(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFlight([FromBody] UpdateFlightVM model)
        {
            try
            {
                await _flightService.EditFlight(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFlight([FromQuery] Guid flightId)
        {
            try
            {
                await _flightService.DeleteFlight(flightId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}