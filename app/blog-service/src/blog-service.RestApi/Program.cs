var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddCors();
var app = builder.Build();
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.MapGet("/", () =>
{
    return "Test";
});
var v1Api = app.MapGroup("/api/v1");
var servicesApi = v1Api.MapGroup("/service");

servicesApi.MapGet("/status", () => {
    return "Running";
});

app.Run();


