using Microsoft.AspNetCore.Mvc;
using Caliber67.Services;

namespace Caliber67.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIController : ControllerBase
    {
        private readonly IAIService _aiService;
        private readonly ILogger<AIController> _logger;

        public AIController(IAIService aiService, ILogger<AIController> logger)
        {
            _aiService = aiService;
            _logger = logger;
        }

        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
            {
                return BadRequest(new { error = "Message cannot be empty" });
            }

            try
            {
                var response = await _aiService.GetAIResponseAsync(request.Message);
                return Ok(new { response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing AI chat request");
                return StatusCode(500, new { error = "An error occurred processing your request" });
            }
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; }
    }
}

