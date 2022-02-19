using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace JsonProcessorBackendApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonRequestReaderController : ControllerBase
    {
        private readonly ILogger<JsonRequestReaderController> _logger;


        public JsonRequestReaderController(ILogger<JsonRequestReaderController> logger)
        {
            _logger = logger;
        }
        [HttpPost("Json")]
        public async Task<ActionResult<JsonObject>> PostJsonRequest(JsonObject jsonRequest)
        {
            _logger.Log(LogLevel.Information, "Json Request Recieved");
            if (jsonRequest.Count > 0)
            {
                _logger.Log(LogLevel.Information, "Request is valid");

                return Ok(jsonRequest);
            }
            else
            {
                _logger.Log(LogLevel.Error, "Request is not valid");

                return BadRequest(jsonRequest); 
            }
        }
    }
}
