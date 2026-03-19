using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace NDPSo.Chatbot
{
    public class GroqApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        private const string API_URL = "https://api.groq.com/openai/v1/chat/completions";

        // Đổi sang model có TPM limit cao hơn: 12,000 TPM thay vì 6,000
        private const string MODEL = "llama-3.3-70b-versatile";

        public GroqApiService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task<string> ChatAsync(string systemPrompt, string userMessage)
        {
            var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };

            var requestBody = new Dictionary<string, object>
            {
                ["model"] = MODEL,
                ["max_tokens"] = 512,
                ["temperature"] = 0.1,
                ["messages"] = new[]
                {
                    new Dictionary<string, object> { ["role"] = "system", ["content"] = systemPrompt },
                    new Dictionary<string, object> { ["role"] = "user",   ["content"] = userMessage  }
                }
            };

            var json = serializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(API_URL, content);
            var responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var errObj = serializer.DeserializeObject(responseText) as Dictionary<string, object>;
                    var errNode = errObj?["error"] as Dictionary<string, object>;
                    if (errNode?.ContainsKey("message") == true)
                        throw new Exception($"Groq API lỗi: {errNode["message"]}");
                }
                catch (Exception ex) when (!ex.Message.StartsWith("Groq")) { }

                throw new Exception($"Groq API lỗi {(int)response.StatusCode}: {responseText}");
            }

            return ParseResponse(responseText, serializer);
        }

        private string ParseResponse(string responseText, JavaScriptSerializer serializer)
        {
            try
            {
                var result = serializer.DeserializeObject(responseText) as Dictionary<string, object>;
                var choices = result?["choices"] as object[];
                var choice = choices?[0] as Dictionary<string, object>;
                var message = choice?["message"] as Dictionary<string, object>;

                if (message?.ContainsKey("content") == true)
                    return message["content"].ToString().Trim();

                throw new Exception("Không tìm thấy content trong response");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi parse Groq response: {ex.Message}");
            }
        }
    }
}