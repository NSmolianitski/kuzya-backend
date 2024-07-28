using KuzyaBackend;
using KuzyaBackend.Repositories.Implementations;
using KuzyaBackend.Repositories.Interfaces;
using KuzyaBackend.Services.Implementations;
using KuzyaBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Kuzya API"
    });
});
builder.Services.AddControllers();

builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json");

// Database environment variables
var host = Environment.GetEnvironmentVariable("DATABASE_HOST");
var port = Environment.GetEnvironmentVariable("DATABASE_PORT");
var database = Environment.GetEnvironmentVariable("DATABASE_NAME");
var user = Environment.GetEnvironmentVariable("DATABASE_USER");
var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

// Connection string
var connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password};";
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

// Repositories
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

// Services
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => options.RouteTemplate = "api/{documentName}/swagger.json");
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/api/v1/swagger.json", "Kuzya API V1");
        options.RoutePrefix = "api";
    });
    app.UseDeveloperExceptionPage();
}

// app.UseExceptionHandler(); // TODO: add global exception handler

// app.UseHttpsRedirection();
app.MapControllers();

app.Run();