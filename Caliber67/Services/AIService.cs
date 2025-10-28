using System.Text;
using System.Text.Json;

namespace Caliber67.Services
{
    public interface IAIService
    {
        Task<string> GetAIResponseAsync(string userMessage);
    }

    public class DeepSeekAIService : IAIService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<DeepSeekAIService> _logger;
        private readonly IConfiguration _configuration;
        private const string DEEPSEEK_API_URL = "https://api.deepseek.com/v1/chat/completions";

        public DeepSeekAIService(IHttpClientFactory httpClientFactory, ILogger<DeepSeekAIService> logger, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<string> GetAIResponseAsync(string userMessage)
        {
            try
            {
                var apiKey = _configuration["DeepSeek:ApiKey"];
                
                if (string.IsNullOrEmpty(apiKey))
                {
                    // For demo purposes, return a mock response
                    return GetMockResponse(userMessage);
                }

                using var httpClient = _httpClientFactory.CreateClient();
                
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

                var requestBody = new
                {
                    model = "deepseek-chat",
                    messages = new[]
                    {
                        new { role = "system", content = "You are a helpful AI assistant that can answer any question the user asks. Be concise, informative, and friendly. You can discuss any topic - technology, science, general knowledge, questions about products, or anything else the user might ask. Provide accurate and helpful responses." },
                        new { role = "user", content = userMessage }
                    },
                    temperature = 0.7,
                    max_tokens = 300
                };

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(DEEPSEEK_API_URL, content);
                
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"DeepSeek API error: {response.StatusCode}");
                    return GetMockResponse(userMessage);
                }

                var responseJson = await response.Content.ReadAsStringAsync();
                var responseObj = JsonSerializer.Deserialize<DeepSeekResponse>(responseJson);

                return responseObj?.choices?.FirstOrDefault()?.message?.content ?? "I'm sorry, I couldn't process that request.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling DeepSeek API");
                return GetMockResponse(userMessage);
            }
        }

        private string GetMockResponse(string userMessage)
        {
            var message = userMessage.ToLower();
            
            if (message.Contains("gun") || message.Contains("firearm") || message.Contains("weapon"))
            {
                return "Our firearms are carefully selected for quality and reliability. What type of firearm are you interested in - handgun, rifle, or shotgun?";
            }
            else if (message.Contains("ammo") || message.Contains("ammunition"))
            {
                return "We stock high-quality ammunition from top manufacturers. What caliber are you looking for?";
            }
            else if (message.Contains("accessory") || message.Contains("gear"))
            {
                return "We have magazines, cleaning kits, optics, and tactical gear. What specific accessory do you need?";
            }
            else if (message.Contains("order") || message.Contains("checkout"))
            {
                return "To place an order, add items to your cart and proceed to checkout. For firearms, you'll need to upload a valid license.";
            }
            else if (message.Contains("cart") || message.Contains("cart"))
            {
                return "Your cart shows all items ready to purchase. You can update quantities or remove items anytime.";
            }
            else
            {
                return "I'm your tactical assistant. I can help you with product recommendations, technical questions, or order assistance. What do you need?";
            }
        }
    }

    public class DeepSeekResponse
    {
        public List<Choice> choices { get; set; }
    }

    public class Choice
    {
        public Message message { get; set; }
    }

    public class Message
    {
        public string content { get; set; }
    }
}

