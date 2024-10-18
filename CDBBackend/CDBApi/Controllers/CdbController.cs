using CDBApi.Models;
using CDBApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CDBApi.Controllers
{
    [ApiController]
    [Route("api/cdb")]
    public class CdbController(ICdbService cdbService) : ControllerBase
    {
        private readonly ICdbService _cdbService = cdbService;

        [HttpPost("calculate")]
        [ProducesResponseType(typeof(CdbInvestmentResponse), StatusCodes.Status200OK)]
        public IActionResult Calculate([FromBody] CdbInvestmentRequest request)
        {
            try
            {
                var response = _cdbService.Calculate(request);
                return Ok(response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Errors = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Errors = "An unexpected error occurred. Please try again later." });
            }
        }
    }
}