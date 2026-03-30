using LumiLite.Api.Models;

namespace LumiLite.Api.Services;

public interface IAssessmentService
{
    Task<AssessmentResponse> GenerateAssessmentAsync(AssessmentRequest request);
}
