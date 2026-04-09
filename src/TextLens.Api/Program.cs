using Azure;
using Azure.AI.TextAnalytics;
using TextLens.Api.Endpoints;
using TextLens.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorClient", policy =>
        policy.WithOrigins("https://localhost:7001", "http://localhost:5001")
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var endpoint = builder.Configuration["AzureLanguage:Endpoint"]
    ?? throw new InvalidOperationException("AzureLanguage:Endpoint is not configured.");
var key = builder.Configuration["AzureLanguage:Key"]
    ?? throw new InvalidOperationException("AzureLanguage:Key is not configured.");

builder.Services.AddSingleton(new TextAnalyticsClient(
    new Uri(endpoint),
    new AzureKeyCredential(key)));

builder.Services.AddScoped<ILanguageService, LanguageService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("BlazorClient");

app.MapLanguageEndpoints();

app.Run();
