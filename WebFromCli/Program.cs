using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/who", () => new { FirstName = "Андрій", LastName = "Симон" });

app.MapGet("/time", () => new { ServerTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });

app.Run();