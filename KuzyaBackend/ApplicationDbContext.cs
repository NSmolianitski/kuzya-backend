using KuzyaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace KuzyaBackend;

public class ApplicationDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; init; } = null!;
    public DbSet<Recipe> Recipes { get; init; } = null!;
    public DbSet<RecipeStep> RecipeSteps { get; init; } = null!;
    public DbSet<RecipeIngredient> RecipeIngredients { get; init; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.Ingredients)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i => i.RecipeId).IsRequired();
        
        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.RecipeSteps)
            .WithOne(step => step.Recipe)
            .HasForeignKey(step => step.RecipeId).IsRequired();
        
        AddTestingData(modelBuilder);
    }

    private void AddTestingData(ModelBuilder modelBuilder)
    {
        var apple = new Ingredient
        {
            Id = 1,
            Name = "Apple",
            AvatarId = 1,
            Calories = 100,
            Proteins = 10,
            Fats = 10,
            Carbohydrates = 10
        };
        
        var banana = new Ingredient
        {
            Id = 2,
            Name = "Banana",
            AvatarId = 1,
            Calories = 200,
            Proteins = 5,
            Fats = 1,
            Carbohydrates = 20
        };
        modelBuilder.Entity<Ingredient>().HasData(apple, banana);

        var grams = new Measure
        {
            Id = 1,
            Name = "grams",
            GramRatio = 1
        };
        modelBuilder.Entity<Measure>().HasData(grams);
        
        modelBuilder.Entity<Recipe>()
            .HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Apple Pie",
                    AvatarId = 1,
                    
                    CookingTimeInMinutes = 50,
                    Servings = 2,
                    
                    Ingredients =
                    {
                        new RecipeIngredient { Id = 1,Ingredient = apple, Measure = grams, Amount = 800f } 
                    },
                    
                    RecipeSteps =
                    {
                        new RecipeStep { Id = 1, Order = 1, Description = "Cut the apple" },
                        new RecipeStep { Id = 2, Order = 2, Description = "Make the pie" }
                    },
                    
                    Calories = 100,
                    Proteins = 10,
                    Fats = 10,
                    Carbohydrates = 10
                },
                new Recipe
                {
                    Id = 2,
                    Name = "Banana Pie",
                    AvatarId = 1,
                    
                    CookingTimeInMinutes = 30,
                    Servings = 10,
                    
                    Ingredients =
                    {
                        new RecipeIngredient { Id = 2, Ingredient = apple, Measure = grams, Amount = 350f }, 
                        new RecipeIngredient { Id = 3, Ingredient = banana, Measure = grams, Amount = 2500f }
                    },
                    
                    RecipeSteps =
                    {
                        new RecipeStep { Id = 3, Order = 1, Description = "Cut the banana" },
                        new RecipeStep { Id = 4, Order = 2, Description = "Cut the apple" },
                        new RecipeStep { Id = 5, Order = 3, Description = "Make the pie" }
                    },
                    
                    Calories = 200,
                    Proteins = 5,
                    Fats = 1,
                    Carbohydrates = 20
                }
            );
    }
}