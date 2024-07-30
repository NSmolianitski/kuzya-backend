using KuzyaBackend.DataAccess;
using KuzyaBackend.DataAccess.Implementations;
using KuzyaBackend.DataAccess.Interfaces;
using KuzyaBackend.Services.Implementations;
using KuzyaBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KuzyaBackend.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string? connectionString)
    {
        if (connectionString is null)
        {
            var host = Environment.GetEnvironmentVariable("DATABASE_HOST");
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT");
            var database = Environment.GetEnvironmentVariable("DATABASE_NAME");
            var user = Environment.GetEnvironmentVariable("DATABASE_USER");
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

            connectionString = $"Host={host};Port={port};Database={database};Username={user};Password={password};";
        }

        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<IRecipeRepository, RecipeRepository>();
        services.AddScoped<IMealListRepository, MealListRepository>();
        return services;
    }
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddScoped<IRecipeService, RecipeService>();
        services.AddScoped<IMealListService, MealListService>();
        return services;
    }
}