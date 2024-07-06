using KuzyaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace KuzyaBackend;

public class ApplicationDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; init; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AddTestingData(modelBuilder);
    }

    private void AddTestingData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingredient>()
            .HasData(
                new Ingredient
                {
                    Id = 1,
                    Name = "Apple",
                    AvatarId = 1,
                    Calories = 100,
                    Proteins = 10,
                    Fats = 10,
                    Carbohydrates = 10
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Banana",
                    AvatarId = 1,
                    Calories = 200,
                    Proteins = 5,
                    Fats = 1,
                    Carbohydrates = 20
                }
            );
    }
}