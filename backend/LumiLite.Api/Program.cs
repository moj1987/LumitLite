using LumiLite.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- DEPENDENCY INJECTION REGISTRATIONS ---
builder.Services.AddHttpClient("AiWorker", client => 
{
    client.BaseAddress = new Uri("http://localhost:5000"); // Mock Python worker address
});
// This maps our Interface to our Implementation!
builder.Services.AddScoped<IAssessmentService, AssessmentService>();
// ------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
