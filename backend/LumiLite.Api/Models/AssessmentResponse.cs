namespace LumiLite.Api.Models;

public class AssessmentResponse
{
    public List<Question> Questions { get; set; } = new();
}

public class Question
{
    public string Text { get; set; } = string.Empty;
    public List<string> Options { get; set; } = new();
    public int CorrectOptionIndex { get; set; }
    public string CognitiveLevel { get; set; } = string.Empty; // e.g., "Remember", "Apply"
}
