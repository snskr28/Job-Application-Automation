using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Application.Interfaces.AI;

namespace JobAutomation.Infrastructure.AI
{
    public class OllamaLLMService : ILLMService
    {
        private readonly HttpClient _httpClient;
        private readonly string _modelName;

        public OllamaLLMService(
            HttpClient httpClient,
            string modelName = "mistral")
        {
            _httpClient = httpClient;
            _modelName = modelName;
        }

        public async Task<string> GenerateAsync(
            string systemPrompt,
            string userPrompt,
            CancellationToken cancellationToken = default)
        {
            var combinedPrompt = $"""
                                  <System>
                                  {systemPrompt}
                                  </System>
                                  
                                  <User>
                                  {userPrompt}
                                  </User>
                                  """;

            var request = new OllamaGenerateRequest
            {
                Model = _modelName,
                Prompt = combinedPrompt,
                Stream = false
            };

            var response = await _httpClient.PostAsJsonAsync(
                "/api/generate",
                request,
                cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(
                    $"Ollama request failed with status code {response.StatusCode}");
            }

            var result = await response.Content
                .ReadFromJsonAsync<OllamaGenerateResponse>(cancellationToken);

            if (result is null || string.IsNullOrWhiteSpace(result.Response))
            {
                throw new InvalidOperationException(
                    "Ollama returned an empty response.");
            }

            return result.Response.Trim();
        }

        private sealed class OllamaGenerateRequest
        {
            public string Model { get; set; } = string.Empty;
            public string Prompt { get; set; } = string.Empty;
            public bool Stream { get; set; }
        }

        private sealed class OllamaGenerateResponse
        {
            public string Response { get; set; } = string.Empty;
        }
    }
}
