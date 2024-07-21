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
        CreateModels(modelBuilder);
        AddTestingData(modelBuilder);
    }

    private void CreateModels(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.RecipeIngredients)
            .WithOne(i => i.Recipe)
            .HasForeignKey(i => i.RecipeId).IsRequired();
        
        modelBuilder.Entity<Recipe>()
            .HasMany(r => r.RecipeSteps)
            .WithOne(step => step.Recipe)
            .HasForeignKey(step => step.RecipeId).IsRequired();
        
        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Ingredient)
            .WithMany()
            .HasForeignKey(ri => ri.IngredientId).IsRequired();

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Measure)
            .WithMany()
            .HasForeignKey(ri => ri.MeasureId).IsRequired();
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

        var recipe = new Recipe
        {
            Id = 1,
            Name = "Apple Pie",
            AvatarId = 1,
            CookingTimeInMinutes = 50,
            Servings = 2,
            Calories = 100,
            Proteins = 10,
            Fats = 10,
            Carbohydrates = 10
        };
        modelBuilder.Entity<Recipe>().HasData(recipe);
        
        var recipeIngredient = new RecipeIngredient
        {
            Id = 1,
            RecipeId = recipe.Id,
            IngredientId = apple.Id,
            MeasureId = grams.Id,
            Amount = 800f
        };
        modelBuilder.Entity<RecipeIngredient>().HasData(recipeIngredient);
        
        var recipeSteps = new[]
        {
            new RecipeStep {Id = 1, RecipeId = recipe.Id, Order = 1, Description = "Cut the apple"},
            new RecipeStep {Id = 2, RecipeId = recipe.Id, Order = 2, Description = "Make the pie"}
        };
        modelBuilder.Entity<RecipeStep>().HasData(recipeSteps);
    }
}