using Microsoft.AspNetCore.Mvc;
using KgToLbApi.Application; 
namespace KgToLbApi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertController : ControllerBase
    {
        [HttpPost("/convert")]
        public IActionResult Convert([FromBody] ConvertWeightCommand command)
        {
            if (command == null)
                return BadRequest(new { error = "Request body is required." });

            if (command.Kilograms < 0)
                return BadRequest(new { error = "Kilograms must be positive." });

            var handler = new ConvertWeightCommandHandler(); 
            var result = handler.Handle(command);

            return Ok(result);
        }
    }
}
