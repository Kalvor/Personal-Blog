using blog_service.RestApi.HealthChecks;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddHealthChecks()
    .AddCheck<DefaultHealthCheck>("Default");

var app = builder.Build();
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.MapControllers();
app.MapHealthChecks("/health");
app.Run();


