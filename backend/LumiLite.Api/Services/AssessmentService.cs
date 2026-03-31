using System.Text;
using System.Text.Json;
using LumiLite.Api.Models;

namespace LumiLite.Api.Services;

public class AssessmentService : IAssessmentService
{
    private readonly IHttpClientFactory _httpClientFactory;

    // Dependency Injecting the HTTP Client factory class
    public AssessmentService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<AssessmentResponse> GenerateAssessmentAsync(AssessmentRequest request)
    {
        // TODO: using is for IDisposable resource management
        using var client = _httpClientFactory.CreateClient("AiWorker");
        
        var payload = new StringContent(
            JsonSerializer.Serialize(new { notes = request.CourseNotes }), 
            Encoding.UTF8, 
            "application/json"
        );

        // TODO replace with the Python AI worker
        // var response = await client.PostAsync("api/generate", payload);
        
        // TODO replace with the actual response from the AI worker
        // This is a mock response for now.
        return await Task.FromResult(new AssessmentResponse
        {
            Questions = new List<Question>
            {
                new Question
                {
                    Text = "What cognitive level does this question represent?",
                    Options = new List<string> { "Remember", "Apply", "Create", "Evaluate" },
                    CorrectOptionIndex = 1,
                    CognitiveLevel = "Apply"
                }
            }
        });
    }
}
