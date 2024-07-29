using KuzyaBackend.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace KuzyaBackend.DataAccess;

public class ApplicationDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; init; } = null!;
    public DbSet<Recipe> Recipes { get; init; } = null!;
    public DbSet<RecipeStep> RecipeSteps { get; init; } = null!;
    public DbSet<RecipeIngredient> RecipeIngredient { get; init; } = null!;
    public DbSet<CookingTool> CookingTools { get; init; } = null!;
    public DbSet<RecipeCookingTool> RecipeCookingTool { get; init; } = null!;
    public DbSet<MealList> MealLists { get; init; } = null!;
    public DbSet<MealGroup> MealGroups { get; init; } = null!;
    public DbSet<MealGroupRecipe> MealGroupRecipes { get; init; } = null!;

    private static bool _isInitialized = false;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        if (_isInitialized) return;

        Database.EnsureDeleted();
        Database.EnsureCreated();
        _isInitialized = true;
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

        var mixer = new CookingTool
        {
            Id = 1,
            Name = "Mixer",
            AvatarId = 1
        };
        var knife = new CookingTool
        {
            Id = 2,
            Name = "Knife",
            AvatarId = 2
        };
        modelBuilder.Entity<CookingTool>().HasData(mixer, knife);

        // Apple Pie Recipe
        var appleRecipe = new Recipe
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
        modelBuilder.Entity<Recipe>().HasData(appleRecipe);

        var appleRecipeIngredient = new RecipeIngredient
        {
            Id = 1,
            RecipeId = appleRecipe.Id,
            IngredientId = apple.Id,
            MeasureId = grams.Id,
            Amount = 800f
        };
        modelBuilder.Entity<RecipeIngredient>().HasData(appleRecipeIngredient);

        var applePieRecipeSteps = new[]
        {
            new RecipeStep {Id = 1, RecipeId = appleRecipe.Id, Order = 1, Description = "Cut the apple"},
            new RecipeStep {Id = 2, RecipeId = appleRecipe.Id, Order = 2, Description = "Make the pie"}
        };
        modelBuilder.Entity<RecipeStep>().HasData(applePieRecipeSteps);

        // Chopped Banana Recipe
        var bananaRecipe = new Recipe
        {
            Id = 2,
            Name = "Chopped Banana",
            AvatarId = 1,
            CookingTimeInMinutes = 5,
            Servings = 2,
            Calories = 100,
            Proteins = 10,
            Fats = 10,
            Carbohydrates = 10
        };
        modelBuilder.Entity<Recipe>().HasData(bananaRecipe);

        var bananaRecipeIngredient = new RecipeIngredient
        {
            Id = 2,
            RecipeId = bananaRecipe.Id,
            IngredientId = banana.Id,
            MeasureId = grams.Id,
            Amount = 400f
        };
        modelBuilder.Entity<RecipeIngredient>().HasData(bananaRecipeIngredient);

        var bananaRecipeSteps = new[]
        {
            new RecipeStep {Id = 3, RecipeId = bananaRecipe.Id, Order = 1, Description = "Cut the banana"}
        };
        modelBuilder.Entity<RecipeStep>().HasData(bananaRecipeSteps);

        // Add recipe cooking tools
        var mixerApplePie = new RecipeCookingTool {Id = 1, RecipeId = appleRecipe.Id, CookingToolId = mixer.Id};
        var knifeApplePie = new RecipeCookingTool {Id = 2, RecipeId = appleRecipe.Id, CookingToolId = knife.Id};
        var knifeBanana = new RecipeCookingTool {Id = 3, RecipeId = bananaRecipe.Id, CookingToolId = knife.Id};
        modelBuilder.Entity<RecipeCookingTool>().HasData(mixerApplePie, knifeApplePie, knifeBanana);

        // Add meal lists
        var breakfastList = new MealList
        {
            Id = 1,
            Name = "Monday"
        };
        var lunchList = new MealList
        {
            Id = 2,
            Name = "Tuesday"
        };
        modelBuilder.Entity<MealList>().HasData(breakfastList, lunchList);
        
        // Add meal groups
        var breakfast = new MealGroup
        {
            Id = 1,
            Name = "Breakfast",
            MealListId = breakfastList.Id
        };
        var lunch = new MealGroup
        {
            Id = 2,
            Name = "Lunch",
            MealListId = breakfastList.Id
        };
        var dinner = new MealGroup
        {
            Id = 3,
            Name = "Dinner",
            MealListId = lunchList.Id
        };
        modelBuilder.Entity<MealGroup>().HasData(breakfast, lunch, dinner);

        // Add meal group recipes
        var applePieBreakfast = new MealGroupRecipe
        {
            Id = 1,
            RecipeId = appleRecipe.Id,
            MealGroupId = breakfast.Id,
            Order = 1
        };
        var bananaBreakfast = new MealGroupRecipe
        {
            Id = 2,
            RecipeId = bananaRecipe.Id,
            MealGroupId = breakfast.Id,
            Order = 2
        };

        var applePieLunch = new MealGroupRecipe
        {
            Id = 3,
            RecipeId = appleRecipe.Id,
            MealGroupId = lunch.Id,
            Order = 1
        };
        var bananaLunch = new MealGroupRecipe
        {
            Id = 4,
            RecipeId = bananaRecipe.Id,
            MealGroupId = lunch.Id,
            Order = 2
        };

        var applePieDinner = new MealGroupRecipe
        {
            Id = 5,
            RecipeId = appleRecipe.Id,
            MealGroupId = dinner.Id,
            Order = 1
        };
        var bananaDinner = new MealGroupRecipe
        {
            Id = 6,
            RecipeId = bananaRecipe.Id,
            MealGroupId = dinner.Id,
            Order = 2
        };

        modelBuilder.Entity<MealGroupRecipe>().HasData(
            applePieBreakfast,
            bananaBreakfast,
            applePieLunch,
            applePieDinner,
            bananaLunch,
            bananaDinner
        );
    }
}