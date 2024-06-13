using blog_service.RestApi.HealthChecks;
using blog_service.External;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddCors();
builder.Services.AddHealthChecks()
    .AddCheck<DefaultHealthCheck>("Default");

builder.Services.RegisterPersistance(
    builder.Configuration.GetConnectionString("MySqlDb")
    ?? throw new ArgumentException("DB Connection string missing")
);

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


