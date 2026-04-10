using LumiLite.Api.Models;
using LumiLite.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace LumiLite.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssessmentController : ControllerBase
{
    private readonly IAssessmentService _assessmentService;

    public AssessmentController(IAssessmentService assessmentService)
    {
        _assessmentService = assessmentService;
    }

    [HttpPost]
    public async Task<ActionResult<AssessmentResponse>> CreateAssessment([FromBody] AssessmentRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.CourseNotes))
        {
            return BadRequest("Course notes cannot be empty.");
        }

        var response = await _assessmentService.GenerateAssessmentAsync(request);
        return Ok(response);
    }
}
