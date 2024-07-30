using KuzyaBackend.Web.Extensions;
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
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDatabaseContext(connectionString);

builder.Services.AddRepositories();
builder.Services.AddServices();

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