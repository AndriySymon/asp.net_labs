using Task3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();
app.UseMiddleware<RequestCounterMiddleware>();
app.UseMiddleware<CustomQueryMiddleware>();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ApiKeyMiddleware>();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
