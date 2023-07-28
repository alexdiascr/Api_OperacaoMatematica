using SomaNumeros.Services.API.Configurations;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using OperacaoMatematica.Services.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// ConfigureServices
//builder.Services.AddDatabaseSetup(builder.Configuration);

// ASP.NET Identity Settings & JWT
//builder.Services.AddIdentitySetup(builder.Configuration);

builder.Services.AddApiConfig(builder.Configuration);

// Authorization
//builder.Services.AddAuthSetup(builder.Configuration);

// Swagger Config
builder.Services.AddSwaggerConfig();

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionSetup();

// AutoMapper Settings
builder.Services.AddAutoMapperSetup();

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseApiConfig(app.Environment);

app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.MapControllers();

app.Run();
